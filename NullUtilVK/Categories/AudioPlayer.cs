using NAudio.Wave;
using NullUtilVK.Enums;
using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Enums.Win;
using NullUtilVK.Model;
using NullUtilVK.Model.EventArg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;

namespace NullUtilVK.Categories
{
    public partial class AudioPlayer : IDisposable
    {
        public AudioPlayer(
            Func<Enums.SafetyEnums.ConfigDefault, object> GetConfigValue,
            Action<MessageStatus, string> Log, 
            Action<ConfigDefault, object> SetConfigValue,
            Func<VkNet.Model.Attachments.Audio, string> AudioWebPath,
            Func<long, long, VkNet.Model.Attachments.Audio> GetById,
            Func<List<KeyValuePair<long, long>>, List<VkNet.Model.Attachments.Audio>> GetByIdList,
            Func<string, ConsoleCommands> GetPlayerCommands,
            Func<List<VkNet.Model.Attachments.Audio>> GetLastAudioList,
            Func<int, string> SecToTime,
            Action<DBTable, object[]> DBInsert,
            Func<VkNet.Model.Attachments.Audio, string> GetAudioFileName,
            Func<DBTable, string, List<object>> DBRetrievePredicate
            )
        {
            #region Dependecies
            this.GetConfigValue = GetConfigValue;
            this.Log = Log;
            this.SetConfigValue = SetConfigValue;
            this.AudioWebPath = AudioWebPath;
            this.GetById = GetById;
            this.GetByIdList = GetByIdList;
            this.GetPlayerCommands = GetPlayerCommands;
            this.GetLastAudioList = GetLastAudioList;
            this.SecToTime = SecToTime;
            this.DBInsert = DBInsert;
            this.GetAudioFileName = GetAudioFileName;
            this.DBRetrievePredicate = DBRetrievePredicate;
            #endregion

            _PlayList = new List<VkNet.Model.Attachments.Audio>();

            _DownloadQueue = new List<VkNet.Model.Attachments.Audio>();
            _bw = new BackgroundWorker();
            _bw.DoWork += _bw_DoWork;
            _wc = new WebClient();
            SongDownloaded += SomeSongDown;

            _ApiPlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
            _ApiPlayer.PlaybackStopped += PlayerStopped;

            Volume = (double)GetConfigValue(ConfigDefault.AudioPlayerVolume);
            Repeat = false;

            if (!System.IO.Directory.Exists(Environment.CurrentDirectory + Constants.CacheDirSuffix))
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + Constants.CacheDirSuffix);
            if (!System.IO.Directory.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix))
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix);
        }

        #region Dependecies
        Func<ConfigDefault, object> GetConfigValue;
        Action<ConfigDefault, object> SetConfigValue;
        Action<MessageStatus, string> Log;
        Func<VkNet.Model.Attachments.Audio, string> AudioWebPath;
        Func<long, long, VkNet.Model.Attachments.Audio> GetById;
        Func<List<KeyValuePair<long, long>>, List<VkNet.Model.Attachments.Audio>> GetByIdList;
        Action<DBTable, object[]> DBInsert;
        Func<DBTable, string, List<object>> DBRetrievePredicate;

        ConsoleCommands PlayerCommands { get { return GetPlayerCommands("player"); } }
        Func<string, ConsoleCommands> GetPlayerCommands;

        Func<List<VkNet.Model.Attachments.Audio>> GetLastAudioList;
        Func<int, string> SecToTime;
        Func<VkNet.Model.Attachments.Audio, string> GetAudioFileName;
        #endregion

        protected event EventHandler<AudioItemEventArgs> SongDownloaded;

        public event EventHandler<ActionAvaibilityEventArgs> ActionAvaibility;
        public event EventHandler<AudioItemEventArgs> NowPlaying;
        public event EventHandler<PlaylistChangedEventArgs> PlaylistChanged;
        public event EventHandler<PlayerStatusChangedEventArgs> PlayerStatusChanged;
        public event EventHandler<PrecacheStatusChangedEventArgs> PrecacheStatusChanged;

        #region Public vars
        public PlaybackStatus PlaybackStatus
        {
            get
            {
                return _Status;
            }
            private set
            {
                _Status = value;
                if (PlayerStatusChanged != null)
                    PlayerStatusChanged(this, new PlayerStatusChangedEventArgs(value));
            }
        }
        private PlaybackStatus _Status;
        public VkNet.Model.Attachments.Audio CurrentSong
        {
            get
            {
                if (_PlayList.Count < _CurrentSongIndex + 1)
                    return null;
                else
                    return _PlayList[_CurrentSongIndex];
            }
        }
        public double Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _ApiPlayer.Volume = (float)value;
                _volume = value;
            }
        }
        private double _volume;
        public bool Repeat { get; set; }
        public int PlaylistLength { get { return _PlayList.Count; } }
        public long AudioTick { get { return _ApiPlayer.GetPosition(); } }
        public long AudioLength { get { return _ApiReader.Length; } }
        #endregion

        #region Player actions
        public void Play(int? StartIndex = null)
        {
            if (_PlayList.Count == 0)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Audio.Player.EmptyPlaylist);
                return;
            }

            if (StartIndex != null)
                _CurrentSongIndex = (int)StartIndex;
            if (_PlayList.Count <= StartIndex)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + StartIndex + "] & (" + (_PlayList.Count - 1) + ")");
                return;
            }
            var audio = _PlayList[_CurrentSongIndex];


            string predicate = string.Empty;
            predicate += DBTable.Audio.Columns[1].Name;
            predicate += " == ";
            predicate += audio.Id;
            predicate += " AND ";
            predicate += DBTable.Audio.Columns[2].Name;
            predicate += " == ";
            predicate += audio.OwnerId;
            if (System.IO.File.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(audio)) && DBRetrievePredicate(DBTable.Audio, predicate).Count > 0)
            {
                this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.CacheFileExists + GetAudioFileName(audio));
                _AwaitingSong = null;
            }
            else
            {
                this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.CacheFileNotExists + GetAudioFileName(audio));
                DownloadAudio(audio);
                //if (_ApiPlayer.PlaybackState != PlaybackState.Stopped)
                _AwaitingSong = audio;
                return;
            }

            if (_ApiPlayer.PlaybackState != PlaybackState.Stopped)
                StopPlayer();

            try
            {
                //Getting file
                //Moved to StopPlayer event
                //_ApiPlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
                _ApiReader = new Mp3FileReader(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(audio));
                _ApiPlayer.Init(_ApiReader);
            }
            catch (NAudio.MmException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Audio.Player.InvalidFile + GetAudioFileName(audio));
                return;
            }
            _ApiPlayer.Play();
            _ApiPlayer.Volume = (float)Volume;
            PlaybackStatus = PlaybackStatus.Playing;
            if (NowPlaying != null)
                NowPlaying(this, new AudioItemEventArgs() { Audio = _PlayList[_CurrentSongIndex] });

            bool prevAvaible = false;
            bool nextAvaible = false;
            if (_CurrentSongIndex != 0 && !System.IO.File.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(_PlayList[_CurrentSongIndex - 1])))
                DownloadAudio(_PlayList[_CurrentSongIndex - 1]);
            else if (_CurrentSongIndex != 0)
                prevAvaible = true;
            if (_CurrentSongIndex != _PlayList.Count - 1 && !System.IO.File.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(_PlayList[_CurrentSongIndex + 1])))
                DownloadAudio(_PlayList[_CurrentSongIndex + 1]);
            else if (_CurrentSongIndex != _PlayList.Count - 1)
                nextAvaible = true;

            if (ActionAvaibility != null)
                ActionAvaibility(this, new ActionAvaibilityEventArgs(nextAvaible, prevAvaible));

        }
        public void Next()
        {
            if (_CurrentSongIndex + 1 != _PlayList.Count)
                Play(_CurrentSongIndex + 1);
        }
        public void Prev()
        {
            if (_CurrentSongIndex != 0)
                Play(_CurrentSongIndex - 1);
        }
        public void Pause()
        {
            if (PlaybackStatus == PlaybackStatus.Playing)
            {
                //_ApiPlayer.PlaybackStopped -= PlayerStopped;
                //_ApiPlayer.Pause();
                StopPlayer(false);
                PlaybackStatus = PlaybackStatus.Paused;
            }
        }
        public void Resume()
        {
            if (PlaybackStatus == PlaybackStatus.Paused)
            {
                //_ApiPlayer.Resume();
                _ApiPlayer.Init(_ApiReader);
                _ApiPlayer.Play();

                PlaybackStatus = PlaybackStatus.Playing;
                //_ApiPlayer.PlaybackStopped += PlayerStopped;
            }
        }
        public void Stop()
        {
            if (_ApiPlayer.PlaybackState != PlaybackState.Stopped)
                StopPlayer();
        }
        #endregion

        public void GotoTick(long Tick)
        {
            if (Tick > AudioLength)
                return;
            _ApiReader.Position = Tick;
        }

        #region Playlist actions
        public List<VkNet.Model.Attachments.Audio> GetPlaylist()
        {
            return _PlayList;
        }
        public void AddToPlaylist(VkNet.Model.Attachments.Audio Audio)
        {
            _PlayList.Add(Audio);
            if (PlaylistChanged != null)
            {
                var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
                audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(Audio), Audio));
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Add, audioList));
            }
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistAdd + GetAudioFileName(Audio));
        }
        public void AddToPlaylist(List<VkNet.Model.Attachments.Audio> Audios)
        {
            _PlayList.AddRange(Audios);
            StringBuilder sb = new StringBuilder();
            var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
            foreach (var audio in Audios)
            {
                sb.Append(Environment.NewLine);
                sb.Append(GetAudioFileName(audio));

                audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(audio), audio));
            }
            if (PlaylistChanged != null)
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Add, audioList));
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistAdd + sb.ToString());
        }
        public void RemoveFromPlaylist(VkNet.Model.Attachments.Audio Audio)
        {
            if (PlaylistChanged != null)
            {
                var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
                audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(Audio), Audio));
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Remove, audioList));
            }
            _PlayList.Remove(Audio);
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistDell + GetAudioFileName(Audio));
        }
        public void RemoveFromPlaylist(List<VkNet.Model.Attachments.Audio> Audios)
        {
            var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
            foreach (var audio in Audios)
            {
                audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(audio), audio));
                _PlayList.Remove(audio);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var audio in Audios)
            {
                sb.Append(Environment.NewLine);
                sb.Append(GetAudioFileName(audio));

            }
            if (PlaylistChanged != null)
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Remove, audioList));
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistDellRange + sb.ToString());
        }
        public void ClearPlaylist()
        {
            var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
            foreach (var audio in _PlayList)
            {
                audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(audio), audio));
            }
            _PlayList.Clear();
            if (PlaylistChanged != null)
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Remove, audioList));
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistDellRange + "all");
        }
        public void ShufflePlaylist()
        {
            if (PlaylistChanged != null)
            {
                var remList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
                foreach (var item in _PlayList)
                {
                    remList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(item), item));
                }
                PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Remove, remList));
            }
            List<VkNet.Model.Attachments.Audio> newPl = new List<VkNet.Model.Attachments.Audio>();
            Random ran = new Random(DateTime.Now.Minute + DateTime.Now.Second);
            int i;
            while (_PlayList.Count > 0)
            {
                i = ran.Next(_PlayList.Count);
                newPl.Add(_PlayList[i]);
                _PlayList.RemoveAt(i);
                ran = new Random(ran.Next());
            }
            AddToPlaylist(newPl);
        }
        #endregion

        private void StopPlayer(bool disposeReader = true)
        {
            _ApiPlayer.PlaybackStopped -= PlayerStopped;
            _ApiPlayer.Stop();
            _ApiPlayer.Dispose();
            _ApiPlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
            if (disposeReader)
            {
                _ApiReader.Close();
                _ApiReader.Dispose();
            }
            PlaybackStatus = PlaybackStatus.Stopped;
            _ApiPlayer.PlaybackStopped += PlayerStopped;
        }
        private void PlayerStopped(object sender, StoppedEventArgs e)
        {
            _ApiReader.Close();
            _ApiReader.Dispose();
            _ApiPlayer.Dispose();
            _ApiPlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
            _ApiPlayer.PlaybackStopped += PlayerStopped;
            if (Repeat)
                Play(_CurrentSongIndex);
            else if (_CurrentSongIndex != _PlayList.Count - 1 && !_Disposed)
                Play(_CurrentSongIndex + 1);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _Disposed = true;
            if (_ApiPlayer.PlaybackState != PlaybackState.Stopped)
            {
                _ApiPlayer.Stop();
            }
            this.SetConfigValue(ConfigDefault.AudioPlayerVolume, Volume);
            if (disposing)
            {
                if (_ApiReader != null)
                    _ApiReader.Dispose();
                if (_ApiPlayer != null)
                    _ApiPlayer.Dispose();
                if (_bw != null)
                    _bw.Dispose();
                if (_wc != null)
                    _wc.Dispose();
            }
        }

        private void DownloadAudio(VkNet.Model.Attachments.Audio Audio)
        {
            if (!_DownloadQueue.Contains(Audio))
                _DownloadQueue.Add(Audio);
            if (!_bw.IsBusy)
                _bw.RunWorkerAsync();
        }
        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (PrecacheStatusChanged != null)
                PrecacheStatusChanged(this, new PrecacheStatusChangedEventArgs(WorkerState.Working));

            int errorStreak = 0;
            while (_DownloadQueue.Count > 0)
            {
                var Audio = _DownloadQueue.First<VkNet.Model.Attachments.Audio>();
                this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PrecacheStarted + GetAudioFileName(Audio));
                string path = Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(Audio);
                try
                {
                    _wc.DownloadFile(new Uri(AudioWebPath(Audio)), path);
                }
                catch (System.Net.WebException)
                {
                    errorStreak++;
                    if (errorStreak > 3)
                    {
                        this.Log(MessageStatus.Info, string.Format(LogStrings.Info.Audio.Player.RetryPrecache, errorStreak));
                        int oldSongPos = _DownloadQueue.FindIndex(c => c.Id == Audio.Id && c.OwnerId == Audio.OwnerId);
                        var newAudio = this.GetById((long)Audio.OwnerId, Audio.Id);
                        if (newAudio.Url.ToString().Split('?')[0] != Audio.Url.ToString().Split('?')[0])
                        {
                            var randomItem = _PlayList[new Random().Next(_PlayList.Count)];
                            var refreshedRandomItem = this.GetById((long)randomItem.OwnerId, randomItem.Id);
                            if (randomItem.Url.ToString().Split('?')[0] != refreshedRandomItem.Url.ToString().Split('?')[0])
                            {
                                this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PlaylistOutdated);
                                //Saving downloader queue
                                List<int> savedQueue = new List<int>();
                                foreach (var item in _DownloadQueue)
                                {
                                    savedQueue.Add(_PlayList.IndexOf(item));
                                }
                                var toSendArg = new List<KeyValuePair<long, long>>();
                                foreach (var item in _PlayList)
                                {
                                    toSendArg.Add(new KeyValuePair<long, long>((long)item.OwnerId, item.Id));
                                }
                                _PlayList = this.GetByIdList(toSendArg).ToList();

                                if (PlaylistChanged != null)
                                {
                                    var audioList = new List<KeyValuePair<int, VkNet.Model.Attachments.Audio>>();
                                    foreach (var audio in _PlayList)
                                    {
                                        audioList.Add(new KeyValuePair<int, VkNet.Model.Attachments.Audio>(_PlayList.IndexOf(audio), audio));
                                    }
                                    PlaylistChanged(this, new PlaylistChangedEventArgs(PlaylistChangeType.Replace, audioList));
                                }
                                _DownloadQueue.Clear();
                                foreach (int index in savedQueue)
                                {
                                    _DownloadQueue.Add(_PlayList[index]);
                                }
                                errorStreak = 0;
                                continue;
                            }
                        }
                        this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.RemovedInvalidSong);
                        _DownloadQueue.Remove(Audio);
                        RemoveFromPlaylist(Audio);
                        Next();
                        continue;
                    }
                    else
                    {
                        this.Log(MessageStatus.Error, LogStrings.Error.General.Downloading + this.AudioWebPath(Audio));
                        this.Log(MessageStatus.Info, string.Format(LogStrings.Info.Audio.Player.RetryPrecache, errorStreak));
                        continue;
                    }
                }

                _DownloadQueue.Remove(Audio);
                if (SongDownloaded != null )
                {
                    SongDownloaded(this, new AudioItemEventArgs() { Audio = Audio });
                }
                errorStreak = 0;
            }

            if (PrecacheStatusChanged != null)
                PrecacheStatusChanged(this, new PrecacheStatusChangedEventArgs(WorkerState.Done));
        }
        private void SomeSongDown(object sender, AudioItemEventArgs e)
        {
            var audio = e.Audio;
            this.Log(MessageStatus.Info, LogStrings.Info.Audio.Player.PrecacheDone + GetAudioFileName(audio));

            DBInsert(DBTable.Audio, new object[] { audio.Id, audio.OwnerId, audio.Artist, audio.Title, audio.Duration, audio.LyricsId });
            
            if (_ApiPlayer.PlaybackState != PlaybackState.Paused)
            {
                if (_ApiPlayer.PlaybackState == PlaybackState.Stopped)
                    Play();
                if (audio == _AwaitingSong)
                {
                    Play();
                    _AwaitingSong = null;
                }
            }
            if (ActionAvaibility != null)
            {
                bool prevAvaible = false;
                if (_CurrentSongIndex != 0)
                    if (System.IO.File.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(_PlayList[_CurrentSongIndex - 1])))
                        prevAvaible = true;
                bool nextAvaible = false;
                if (_CurrentSongIndex != _PlayList.Count - 1)
                    if (System.IO.File.Exists(Environment.CurrentDirectory + Constants.CacheDirAudioSuffix + "\\" + GetAudioFileName(_PlayList[_CurrentSongIndex + 1])))
                        nextAvaible = true;
                ActionAvaibility(this, new ActionAvaibilityEventArgs(nextAvaible, prevAvaible));
            }

        }


        private WaveOut _ApiPlayer;
        private Mp3FileReader _ApiReader;
        private int _CurrentSongIndex;
        private List<VkNet.Model.Attachments.Audio> _PlayList;
        private List<VkNet.Model.Attachments.Audio> _DownloadQueue;
        private BackgroundWorker _bw;
        private WebClient _wc;

        private bool _Disposed = false;

        //Song, that will be played on download, if player is already playing
        private VkNet.Model.Attachments.Audio _AwaitingSong;
    }
}
