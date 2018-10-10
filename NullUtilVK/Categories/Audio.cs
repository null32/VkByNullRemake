using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Enums;
using NullUtilVK.Model.EventArg;
using NullUtilVK.Enums.Win;
using NullUtilVK.Model;

namespace NullUtilVK.Categories
{
    public partial class Audio : IDisposable
    {
        //Sub classes
        public AudioPlayer Player
        {
            get
            {
                if (_Player == null)
                    _Player = new AudioPlayer(GetConfigValue, Log, SetConfigValue, WebPath, GetById, GetById, AudioCommands.GetCategory, GetLastAudioList, SecToTime, DB.Insert, CachePath, DB.Select); 
                return _Player;
            }
        }
        private AudioPlayer _Player;
        //Main Constructor
        public Audio(
            Func<long> GetUserId, 
            Func<string, IDictionary<string, string>, bool, string> ApiDirectCall,
            VkNet.Categories.AudioCategory ApiAudio, 
            Func<int, string> SecToTime,
            Func<string, FileCriterion, FileInfo> GetBestFile,
            Func<string, long> GetFolderSize,
            Action<MessageStatus, string> Log, 
            Func<ConfigDefault, object> GetConfigValue,
            Action<ConfigDefault, object> SetConfigValue,
            Func<string, ConsoleCommands> GetAudioCommands,
            DataBase DB
            )
        {
            #region Dependencies
            this.GetUserId = GetUserId;
            this.ApiDirectCall = ApiDirectCall;
            this.GetAudioCommands = GetAudioCommands;
            this.ApiAudio = ApiAudio;
            this.SecToTime = SecToTime;
            this.GetBestFile = GetBestFile;
            this.GetFolderSize = GetFolderSize;
            this.Log = Log;
            this.GetConfigValue = GetConfigValue;
            this.SetConfigValue = SetConfigValue;
            this.DB = DB;
            #endregion
            //Some private members
            _DownloaderBW = new BackgroundWorker();
            _DownloaderBW.DoWork += new DoWorkEventHandler(_Downloader_DoWork);
            _Downloader = new WebClient();
            _DownloadQueue = new List<VkNet.Model.Attachments.Audio>();
            _SearchHistory = (GetConfigValue(ConfigDefault.AudioGuiSearchHistory) as string[]).ToList();
            //Events
            Player.NowPlaying += UpdateUserStatus;
            if (Convert.ToBoolean(GetConfigValue(ConfigDefault.AudioLimitCache)))
            {
                Player.PrecacheStatusChanged += CacheCleaner;
                _MaxCacheSize = Convert.ToInt32(GetConfigValue(ConfigDefault.AudioMaxCacheSizeMB));
            }
            //Console output constants
            MaxArtistLength = 30;
            MaxTitleLength = 30;
        }

        #region Function dependencies
        long UserId { get { return GetUserId(); } }
        ConsoleCommands AudioCommands { get { return GetAudioCommands("audio"); } }
        Func<string, ConsoleCommands> GetAudioCommands;

        Func<string, IDictionary<string, string>, bool, string> ApiDirectCall;

        Func<long> GetUserId;
        Func<int, string> SecToTime;
        Func<string, FileCriterion, FileInfo> GetBestFile;
        Func<string, long> GetFolderSize;
        Action<MessageStatus, string> Log;
        Func<Localization, string> GetLangValue;
        Func<ConfigDefault, object> GetConfigValue;
        Action<ConfigDefault, object> SetConfigValue;
        #endregion

        #region Web api methods
        //Console output configs
        public int MaxArtistLength { get; set; }
        public int MaxTitleLength { get; set; }
        //Get auios count
        public int Count(long? UserId = null)
        {
            UserId = (UserId == null) ? this.UserId : UserId;
            this.Log(MessageStatus.Request, String.Format(LogStrings.Info.Audio.CountRequest, UserId));
            int count = this.ApiAudio.GetCount((long)UserId);
            this.Log(MessageStatus.Response, String.Format(LogStrings.Info.Audio.CountResponse, count));

            return count;
        }
        //Get user audios
        public List<VkNet.Model.Attachments.Audio> Get(long? UserId = null, long? AlbumId = null, int? Count = 1, int? Offset = null)
        {
            UserId = (UserId == null) ? this.UserId : UserId;
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.GetUserRequest, UserId, AlbumId, Count, Offset));
            var response = this.ApiAudio.Get(Convert.ToUInt64(UserId), AlbumId, null, Convert.ToUInt32(Count), Convert.ToUInt32(Offset));
            _LastAudioList = response.Where(c => c.Url != null).ToList();

            LogResponse(_LastAudioList);
            
            return _LastAudioList;
        }
        //Get group audios
        public List<VkNet.Model.Attachments.Audio> GetGroup(long GroupId, long? AlbumId = null, int? Count = 1, int? Offset = null)
        {
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.GetGroupRequst, GroupId, AlbumId, Count, Offset));
            var response = this.ApiAudio.GetFromGroup(GroupId, albumId: AlbumId, count: Convert.ToUInt32(Count), offset: Convert.ToUInt32(Offset));
            _LastAudioList = response.Where(c => c.Url != null).ToList();

            LogResponse(_LastAudioList);

            return _LastAudioList;
        }
        //Search for querry
        public List<VkNet.Model.Attachments.Audio> Search(string Txt, bool IsArtist = false, int? Count = 1, int? Offset = null)
        {
            _Search(Txt, IsArtist, Count, Offset);
            return _LastAudioList;
        }
        public List<VkNet.Model.Attachments.Audio> Search(string Txt, out int TotalCount, bool IsArtist = false, int? Count = 1, int? Offset = null)
        {
            TotalCount = (int)_Search(Txt, IsArtist, Count, Offset);

            return _LastAudioList;
        }
        private int? _Search(string Txt, bool IsArtist, int? Count = 1, int? Offset = null)
        {
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.SearchRequest, Txt, IsArtist, Count, Offset));
            AddSearchHis(Txt);
            //Get
            var parameters = new Dictionary<string, string>();
            parameters.Add("q", Txt);
            parameters.Add("v", "5.41");
            parameters.Add("performer_only", Convert.ToInt16(IsArtist).ToString());
            parameters.Add("auto_complete", "1");
            parameters.Add("sort", "2");
            if (Offset != null)
                parameters.Add("offset", Offset.ToString());
            parameters.Add("count", Count.ToString());
            var answer = ApiDirectCall("audio.search", parameters, false);
            var json = Newtonsoft.Json.Linq.JObject.Parse(answer)["response"];
            //Serialize

            List<VkNet.Model.Attachments.Audio> AudioList = new List<VkNet.Model.Attachments.Audio>();
            foreach (var audioItem in json["items"] as Newtonsoft.Json.Linq.JArray)
            {
                var item = new Castable(audioItem);
                AudioList.Add(new VkNet.Model.Attachments.Audio()
                {
                    Id = item["id"],
                    OwnerId = item["owner_id"],
                    Artist = item["artist"],
                    Title = item["title"],
                    Duration = item["duration"],
                    Url = item["url"],
                    LyricsId = item["lyrics_id"],
                    AlbumId = item["album_id"],
                    Genre = item["genre_id"] == null ? null : Util.NullableEnumFrom<VkNet.Enums.AudioGenre>(item["genre_id"])
                });
            }
            _LastAudioList = AudioList.Where(c => c.Url != null).ToList();

            LogResponse(_LastAudioList);

            return (int)json["count"];
        }
        //Get recommended audios of user
        public List<VkNet.Model.Attachments.Audio> GetRecommended(long? UserId = null, int? Count = 1, int? Offset = null)
        {
            UserId = (UserId == null) ? this.UserId : UserId;
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.RecommendRequest, UserId, Count, Offset));
            var response = this.ApiAudio.GetRecommendations(Convert.ToUInt64(UserId), Convert.ToUInt32(Count), Convert.ToUInt32(Offset));
            _LastAudioList = response.Where(c => c.Url != null).ToList();

            LogResponse(_LastAudioList);

            return _LastAudioList;
        }
        //Get popular audios
        public List<VkNet.Model.Attachments.Audio> GetPopular(int? Count = 1, int? Offset = null)
        {
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.PopularRequest, Count, Offset));
            var response = this.ApiAudio.GetPopular(count: Convert.ToUInt32(Count), offset: Convert.ToUInt32(Offset));
            _LastAudioList = response.Where(c => c.Url != null).ToList();

            LogResponse(_LastAudioList);

            return _LastAudioList;
        }
        //Get text by id
        public string GetText(long TextId)
        {
            Log(MessageStatus.Request, string.Format(LogStrings.Info.Audio.LyricsRequest, TextId));
            string text = ApiAudio.GetLyrics(TextId).Text;
            this.Log(MessageStatus.Response, string.Join(Environment.NewLine, text.Split('\r')));
            return text;
        }
        //Get user albums
        public List<VkNet.Model.AudioAlbum> GetAlbums(long? UserId = null)
        {
            UserId = (UserId == null) ? this.UserId : UserId;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(LogStrings.Info.Audio.GetAlbumsRequest, UserId));
            var albums = this.ApiAudio.GetAlbums((long)UserId);
            foreach (var item in albums)
            {
                sb.Append(Environment.NewLine);
                sb.Append(item.Title);
            }
            this.Log(MessageStatus.Response, LogStrings.Info.Audio.GetAlbumsResponse + sb.ToString());
            return albums.ToList();
        }
        //Get audio by id
        public VkNet.Model.Attachments.Audio GetById(long OwnredId, long AudioId)
        {
            this.Log(MessageStatus.Request, LogStrings.Info.Audio.InfoRequest + OwnredId.ToString() + "_" + AudioId.ToString());
            var Audio = this.ApiAudio.GetById(new string[] { OwnredId.ToString() + "_" + AudioId.ToString() }).First();
            this.Log(MessageStatus.Response, LogStrings.Info.Audio.InfoResponse + Audio.Artist + " - " + Audio.Title + " - " + Audio.OwnerId + "_" + Audio.Id + " - " + Audio.Url.ToString().Split('?')[0]);
            return Audio;
        }
        public List<VkNet.Model.Attachments.Audio> GetById(List<KeyValuePair<long, long>> Items)
        {
            List<string> toSendArg = new List<string>();
            string request = LogStrings.Info.Audio.InfoRequest;
            foreach (var item in Items)
            {
                toSendArg.Add(item.Key.ToString() + "_" + item.Value.ToString());
                request += item.Key.ToString() + "_" + item.Value.ToString();
                request += ", ";
            }
            request = request.Remove(request.Length - 2);
            this.Log(MessageStatus.Request, request);
            var Audios = this.ApiAudio.GetById(toSendArg).Where(c => c.Url != null).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in Audios)
            {
                sb.Append(Environment.NewLine);
                sb.Append(item.Artist);
                sb.Append(" - ");
                sb.Append(item.Title);
                sb.Append(" - ");
                sb.Append(item.OwnerId + "_" + item.Id);
                sb.Append(item.Url.ToString().Split('?')[0]);
            }
            this.Log(MessageStatus.Response, LogStrings.Info.Audio.InfoResponse + sb.ToString());
            return Audios;
        }
        //Add to user's audio
        public void Add(VkNet.Model.Attachments.Audio Audio)
        {
            this.ApiAudio.Add(Convert.ToUInt64(Audio.Id), (long)Audio.OwnerId);

            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Added + Audio.Artist + " - " + Audio.Title);
        }
        //Remove from user's audio
        public void Delete(VkNet.Model.Attachments.Audio Audio)
        {
            this.ApiAudio.Delete(Convert.ToUInt64(Audio.Id), (long)Audio.OwnerId);

            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Deleted + Audio.Artist + " - " + Audio.Title);
        }
        //Edit audio
        public void Edit(long AudioId, long OwnerId, string Artist, string Title, NullUtilVK.Enums.SafetyEnums.VK.AudioGenre Genre, string Text, bool HideSearch)
        {
            var args = new Dictionary<string, string>();
            args.Add("owner_id", OwnerId.ToString());
            args.Add("audio_id", AudioId.ToString());
            args.Add("artist", Artist);
            args.Add("title", Title);
            args.Add("text", Text);
            args.Add("genre_id", Genre.Id.ToString());
            args.Add("no_search", Convert.ToInt16(HideSearch).ToString());
            ApiDirectCall("audio.edit", args, false);
        }
        //Should be displyed in status?
        public bool ToStatus
        {
            set
            {
                _ToStatus = value;
                if (value && Player.CurrentSong != null)
                    UpdateUserStatus(this, new AudioItemEventArgs() { Audio = Player.CurrentSong });
                else
                    ApiAudio.SetBroadcast("0", new long[] { UserId });
                if (value)
                    Log(MessageStatus.Info, LogStrings.Info.Audio.ToStatusEnabled);
                else
                    Log(MessageStatus.Info, LogStrings.Info.Audio.ToStatusDisabled);
            }
            get
            {
                return _ToStatus;
            }
        }
        private bool _ToStatus;
        #endregion

        #region NullUtil methods
        //Save localy to defined folder
        public void Download(VkNet.Model.Attachments.Audio Audio)
        {
            string downDir = (string)GetConfigValue(ConfigDefault.AudioDownloadDir);
            if (!Directory.Exists(downDir))
                Directory.CreateDirectory(downDir);

            _DownloadQueue.Add(Audio);
            if (!_DownloaderBW.IsBusy)
                _DownloaderBW.RunWorkerAsync();

            this.Log(MessageStatus.Info, LogStrings.Info.Audio.StartedDownloading + Audio.Artist + " - " + Audio.Title);
        }
        //Add search query to history
        public void AddSearchHis(string Txt)
        {
            if (!_SearchHistory.Contains(Txt))
                _SearchHistory.Add(Txt);
        }
        //Get search history
        public List<string> GetSearchHis()
        {
            return _SearchHistory;
        }
        //Get list of cached audios
        public List<VkNet.Model.Attachments.Audio> GetCache(int Count = 100, int Offset = 0)
        {
            var returnList = new List<VkNet.Model.Attachments.Audio>();
            foreach (object[] item in DB.Select(DBTable.Audio, Count, Offset))
            {
                returnList.Add(new VkNet.Model.Attachments.Audio()
                { 
                    Id = Convert.ToInt64(item[1]),
                    OwnerId = Convert.ToInt64(item[2]),
                    Artist = Convert.ToString(item[3]),
                    Title = string.Join("'", Convert.ToString(item[4]).Split(new string[] { "&apos" }, StringSplitOptions.None)),
                    Duration = Convert.ToInt32(item[5]),
                    LyricsId = Convert.ToInt64(item[6])
                });
            }
            return returnList;
        }
        //Get count of audios in cache
        public int CacheCount()
        {
            return DB.Size(DBTable.Audio);
        }
        //Get bite size of cache
        public long CacheSize()
        {
            return Util.GetFolderSize(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix);
        }
        //Remove record from cache and delete local file
        public async void DeleteFromCache(VkNet.Model.Attachments.Audio Audio)
        {
            string predicate = DBTable.Audio.Columns[1].Name;
            predicate += " == ";
            predicate += Audio.Id;
            predicate += " AND ";
            predicate += DBTable.Audio.Columns[2].Name;
            predicate += " == ";
            predicate += Audio.OwnerId;
            List<object> response = DB.Select(DBTable.Audio, predicate);
            if (response.Count == 0)
                return;
            await Task.Run(() =>
                {
                    DB.Remove(DBTable.Audio, Convert.ToInt32((response[0] as object[])[0]));
                    string path = Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + CachePath(Audio);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                });
                
        }
        public async void DeleteFromCache(int id)
        {
            List<object> response = DB.Select(DBTable.Audio, DBTable.Audio.Columns[0].Name + " == " + id);
            if (response.Count < 1)
            {
                Log(MessageStatus.Error, string.Format(LogStrings.Error.DB.InvalidIndex, id));
                return;
            }
            await Task.Run(() =>
            {
                DB.Remove(DBTable.Audio, id);
                object[] item = response.First() as object[];
                string path = Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + CachePath(new VkNet.Model.Attachments.Audio() { Id = (long)item[1], OwnerId = (long)item[2] });
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            });
        }
        #endregion

        //Interface inplementations
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_ToStatus)
                ApiAudio.SetBroadcast("0", new long[] { UserId });
            SetConfigValue(ConfigDefault.AudioGuiSearchHistory, _SearchHistory.ToArray());

            if (disposing)
            {
                if (_Player != null)
                    _Player.Dispose();
                if (_Downloader != null)
                    _Downloader.Dispose();
                if (_DownloaderBW != null)
                    _DownloaderBW.Dispose();
            }
        }

        //Event handler for updating user's status
        private void UpdateUserStatus(object sender, AudioItemEventArgs e)
        {
            if (_ToStatus)
                ApiAudio.SetBroadcast(e.Audio.OwnerId.ToString() + "_" + e.Audio.Id.ToString(), new long[] { UserId });
        }
        //Event handler for automatic cache cleaning
        private async void CacheCleaner(object sender, PrecacheStatusChangedEventArgs e)
        {
            if (e.Status != WorkerState.Done)
                return;
            while (GetFolderSize(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix) > _MaxCacheSize * 1024 * 1024)
            {
                await Task.Run(() =>
                {
                    var File = GetBestFile(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix, FileCriterion.Oldest);
                    string predicate = string.Empty;
                    predicate += DBTable.Audio.Columns[2].Name;
                    predicate += " == ";
                    predicate += File.Name.Split('_')[0];
                    predicate += " AND ";
                    predicate += DBTable.Audio.Columns[1].Name;
                    predicate += " == ";
                    predicate += File.Name.Split('_')[1].Split('.')[0];
                    List<object> response = DB.Select(DBTable.Audio, predicate);
                    if (response.Count > 0)
                    {
                        var audio = (response[0] as object[]);
                        if (Convert.ToInt64(audio[1]) != Player.CurrentSong.Id && Convert.ToInt64(audio[2]) != Player.CurrentSong.OwnerId)
                        {
                            DB.Remove(DBTable.Audio, Convert.ToInt32(audio[0]));
                            System.IO.File.Delete(File.FullName);
                        }
                    }
                });
            }
        }
        //Thread for audio downloading
        private void _Downloader_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_DownloadQueue.Count > 0)
            {
                var Audio = _DownloadQueue.First();
                string path = DownloadPath(Audio);

                if (File.Exists(path))
                {
                    this.Log(Enums.SafetyEnums.MessageStatus.Error, LogStrings.Error.Audio.DownloadFileExists + path);
                    _DownloadQueue.Remove(Audio);
                    return;
                }

                _Downloader.DownloadFile(new Uri(WebPath(Audio)), path);
                                
                _DownloadQueue.Remove(Audio);
            }
        }
        //Get full path for audio
        private string DownloadPath(VkNet.Model.Attachments.Audio Audio)
        {
            string name = Audio.Artist + " - " + Audio.Title;
            foreach (char CHR in _BadSymbs)
            {
                name = String.Join("_", name.Split(CHR));
            }
            return (string)this.GetConfigValue(ConfigDefault.AudioDownloadDir) + "\\" + name + ".mp3";
        }
        //Get audio url
        private string WebPath(VkNet.Model.Attachments.Audio Audio)
        {
            return Audio.Url.ToString().Split('?')[0];
        }
        //Console 
        private List<VkNet.Model.Attachments.Audio> GetLastAudioList()
        {
            return _LastAudioList;
        }
        //Get local audio cahce name
        private string CachePath(VkNet.Model.Attachments.Audio Audio)
        {
            return Audio.OwnerId.ToString() + "_" + Audio.Id.ToString() + ".mp3";
        }
        //Log response
        private void LogResponse(IEnumerable<VkNet.Model.Attachments.Audio> list)
        {
            //1 - Xploding Plastix – Kissed by a Kisser - 6:47 - https://psv4.vk.me/c4593/u657240/audios/44e9f7f94a71.mp3
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var audio in list)
            {
                sb.Append(Environment.NewLine);
                sb.Append(i);
                sb.Append(" - ");
                if (audio.Artist.Length > MaxArtistLength)
                    sb.Append(audio.Artist.Remove(MaxArtistLength));
                else
                    sb.Append(audio.Artist);
                sb.Append(" - ");
                if (audio.Title.Length > MaxTitleLength)
                    sb.Append(audio.Title.Remove(MaxTitleLength));
                else
                    sb.Append(audio.Title);
                sb.Append(" - ");
                sb.Append(this.SecToTime(audio.Duration));
                sb.Append(" - ");
                sb.Append(audio.Url.ToString().Split('?')[0]);
                i++;
            }
            if (sb.ToString() != string.Empty)
                this.Log(MessageStatus.Response, sb.ToString().Remove(0, Environment.NewLine.Length));
        }

        //Private members
        private List<VkNet.Model.Attachments.Audio> _DownloadQueue;
        private WebClient _Downloader;
        private BackgroundWorker _DownloaderBW;
        private List<VkNet.Model.Attachments.Audio> _LastAudioList;
        private List<string> _SearchHistory;
        private int _MaxCacheSize;

        #region Dependencies
        private VkNet.Categories.AudioCategory ApiAudio;
        private DataBase DB;
        #endregion
        private char[] _BadSymbs = { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };
    }
}
