using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Enums.Win;
using NullUtilVK.Model.EventArg.Win;
using NullUtilVK.Model.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories.Win
{
    public class AudioWin : IDisposable
    {
        NullUtilVk MainApi;

        List<AudioTabPageBody> TabPageBodies;
        BackgroundWorker FileSizeGetter;
        List<VkNet.Model.Attachments.Audio> SizeGetterToDo;
        int AudioGetStep;

        public AudioWin(NullUtilVk api)
        {
            MainApi = api;


            //Background file size getter
            FileSizeGetter = new BackgroundWorker();
            FileSizeGetter.DoWork += FileSizeGetter_DoWork;
            SizeGetterToDo = new List<VkNet.Model.Attachments.Audio>();
            //Configs & vars
            TabPageBodies = new List<AudioTabPageBody>();
            AudioGetStep = (int)MainApi.Config.GetValue(ConfigDefault.AudioPrecacheStep);


            TabPageBodies.Add(new AudioTabPageBody());
        }

        public void OpenUserAudios(long? UserId = null, long? AlbumId = null, bool OpenInNewTab = true)
        {
            MainApi.ClientLog("Opening user audios");
            if (OpenInNewTab)
                AddNewTab();
            FillAudioList(new FillAudioBody(TabPageBodies.Count - 1, FillAudioType.UserAudio, AlbumId: AlbumId, UserId: UserId));
        }
        public void OpenGroupAudios(long GroupId, long? AlbumId = null, bool OpenInNewTab = true)
        {
            MainApi.ClientLog("Opening group audios");
            if (OpenInNewTab)
                AddNewTab();
            FillAudioList(new FillAudioBody(TabPageBodies.Count - 1, FillAudioType.GroupAudio, AlbumId: AlbumId, GroupId: GroupId));
        }
        public void OpenAudioSearch(string Querry, bool OpenInNewTab = true)
        {
            MainApi.ClientLog("Opening search request");
            if (OpenInNewTab)
                AddNewTab();
            FillAudioList(new FillAudioBody(TabPageBodies.Count - 1, FillAudioType.Search, SearchQuerry: Querry));
        }

        public List<AudioTabPageBody> TabPages
        {
            get
            {
                return TabPageBodies;
            }
        }

        public Task FillAudioList(FillAudioBody argument)
        {
            return Task.Run(() =>
                {
                    int startIndex = 0;
                    if (argument.Type != FillAudioType.AddMore)
                    {
                        TabPageBodies[argument.Index].PlayList.Clear();
                        switch (argument.Type)
                        {
                            case FillAudioType.UserAudio:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.Get(UserId: argument.UserId, AlbumId: argument.AlbumId, Count: AudioGetStep));
                                TabPageBodies[argument.Index].User = MainApi.User.Get(argument.UserId);
                                TabPageBodies[argument.Index].TotalAudios = MainApi.Audio.Count(argument.UserId);
                                TabPageBodies[argument.Index].AlbumList = MainApi.Audio.GetAlbums(argument.UserId).ToList();
                                break;
                            case FillAudioType.GroupAudio:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetGroup((long)argument.GroupId, AlbumId: argument.AlbumId, Count: AudioGetStep));
                                TabPageBodies[argument.Index].Group = MainApi.Group.GetById((long)argument.GroupId);
                                TabPageBodies[argument.Index].TotalAudios = MainApi.Audio.Count(0 - argument.GroupId);
                                TabPageBodies[argument.Index].AlbumList = MainApi.Audio.GetAlbums(0 - argument.GroupId).ToList();
                                break;
                            case FillAudioType.Search:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.Search(argument.SearchQuerry, out TabPageBodies[argument.Index].TotalAudios, (bool)argument.IsArtist, Count: AudioGetStep));
                                break;
                            case FillAudioType.Recommendation:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetRecommended(UserId: argument.UserId, Count: AudioGetStep));
                                break;
                            case FillAudioType.Popular:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetPopular(AudioGetStep));
                                break;
                            case FillAudioType.Playlist:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.Player.GetPlaylist());
                                break;
                            case FillAudioType.Cache:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetCache(Count: AudioGetStep));
                                TabPageBodies[argument.Index].TotalAudios = MainApi.Audio.CacheCount();
                                break;
                        }
                        TabPageBodies[argument.Index].LastAudioAction = argument;
                    }
                    else
                    {
                        startIndex = TabPageBodies[argument.Index].PlayList.Count;
                        var lastArgument = TabPageBodies[argument.Index].LastAudioAction;

                        switch (lastArgument.Type)
                        {
                            case FillAudioType.UserAudio:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.Get(lastArgument.UserId, lastArgument.AlbumId, AudioGetStep, startIndex));
                                break;
                            case FillAudioType.GroupAudio:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetGroup((long)lastArgument.GroupId, lastArgument.AlbumId, AudioGetStep, startIndex));
                                break;
                            case FillAudioType.Search:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.Search(lastArgument.SearchQuerry, (bool)lastArgument.IsArtist, AudioGetStep, startIndex));
                                break;
                            case FillAudioType.Recommendation:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetRecommended(UserId: argument.UserId, Count: AudioGetStep, Offset: startIndex));
                                break;
                            case FillAudioType.Popular:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetPopular(AudioGetStep, Offset: startIndex));
                                break;
                            case FillAudioType.Playlist:
                                break;
                            case FillAudioType.Cache:
                                TabPageBodies[argument.Index].PlayList.AddRange(MainApi.Audio.GetCache(Count: AudioGetStep, Offset: startIndex));
                                break;
                        }
                    }

                    var KnownBitrate = new Dictionary<int, string>();
                    
                    for (int i = startIndex; i < TabPageBodies[argument.Index].PlayList.Count; i++)
                    {
                        var predicate = "{0} == {1} AND {2} == {3}";
                        var resp = MainApi.DB.Select(DBTable.AudioRate, string.Format(predicate, DBTable.AudioRate.Columns[1].Name, TabPageBodies[argument.Index].PlayList[i].Id, DBTable.AudioRate.Columns[2].Name, TabPageBodies[argument.Index].PlayList[i].OwnerId));
                        if (resp.Count > 0)
                        {
                            long rate = Convert.ToInt64((resp[0] as object[]).Last());
                            if (rate != 0)
                            {
                                KnownBitrate.Add(i, (rate * 8 / 1000 / TabPageBodies[argument.Index].PlayList[i].Duration) + "kb/s");
                            }
                        }
                    }

                    if (AudioListUpdater != null)
                        AudioListUpdater(this, new FillAudioListEventArgs(TabPageBodies[argument.Index], startIndex, KnownBitrate));
                });
        }

        public Task AddNewTab()
        {
            return Task.Run(() =>
                {
                    TabPageBodies.Add(new AudioTabPageBody());
                    if (OnTabAdd != null)
                        OnTabAdd(this, EventArgs.Empty);
                });
        }

        public Task CloseTab(int index)
        {
            return Task.Run(() =>
                {
                    TabPageBodies.RemoveAt(index);
                    if (OnTabRemove != null)
                        OnTabRemove(this, new TabRemoveEventArgs(index));
                });
        }

        public Task CloseAllTabsExceptOne(int index)
        {
            return Task.Run(() =>
                {
                    for (int i = 0; i != index; i++)
                    {
                        TabPageBodies.RemoveAt(i);
                    }
                    while (TabPageBodies.Count > 1)
                    {
                        TabPageBodies.RemoveAt(1);
                    }
                    if (OnTabRemoveAllExceptOne != null)
                        OnTabRemoveAllExceptOne(this, new TabRemoveEventArgs(index));
                });
        }

        public void UpdateAudioBitrate(VkNet.Model.Attachments.Audio audio)
        {
            //background worker here because of server requests
           // return Task.Run(() =>
          //      {
                    if (!SizeGetterToDo.Contains(audio))
                        SizeGetterToDo.Add(audio);
                    if (!FileSizeGetter.IsBusy && _canRunFileSizeGetter)
                        FileSizeGetter.RunWorkerAsync();
          //      });
        }

        public Task UpdateHeader(int index)
        {
            return Task.Run(() =>
                {
                    if (HeaderUpdater != null)
                        HeaderUpdater(this, new FillAudioListEventArgs(TabPageBodies[index], 0));
                });
        }

        //getting audio bitrate
        private void FileSizeGetter_DoWork(object sender, DoWorkEventArgs e)
        {
            _canRunFileSizeGetter = false;
            while (SizeGetterToDo.Count > 0)
            {
                var audio = SizeGetterToDo.First();
                if (audio.Duration == 0)
                {
                    SizeGetterToDo.Remove(audio);
                    continue;
                }
                long rate;
                var predicate = "{0} == {1} AND {2} == {3}";
                var resp = MainApi.DB.Select(DBTable.AudioRate, string.Format(predicate, DBTable.AudioRate.Columns[1].Name, audio.Id, DBTable.AudioRate.Columns[2].Name, audio.OwnerId));
                if (resp.Count > 0)
                {
                    rate = Convert.ToInt64((resp[0] as object[]).Last());
                    if (rate == 0)
                    {
                        rate = Util.GetWebFileSize(audio.Url.ToString().Split('?')[0]);
                        MainApi.DB.Insert(DBTable.AudioRate, audio.Id, audio.OwnerId, rate);
                    }
                }
                else
                {
                    rate = Util.GetWebFileSize(audio.Url.ToString().Split('?')[0]);
                    MainApi.DB.Insert(DBTable.AudioRate, audio.Id, audio.OwnerId, rate);
                }
                var rateStr = (rate * 8 / 1000 / audio.Duration) + "kb/s";
                if (AudioBitrateUpdater != null)
                    AudioBitrateUpdater(this, new SetBitrateEventArgs(audio.Id, (long)audio.OwnerId, rateStr));
                SizeGetterToDo.Remove(audio);
            }
            _canRunFileSizeGetter = true;
        }
        bool _canRunFileSizeGetter = true;

        public event EventHandler<FillAudioListEventArgs> AudioListUpdater;
        public event EventHandler<FillAudioListEventArgs> HeaderUpdater;
        public event EventHandler<SetBitrateEventArgs> AudioBitrateUpdater;
        public event EventHandler OnTabAdd;
        public event EventHandler<TabRemoveEventArgs> OnTabRemove;
        public event EventHandler<TabRemoveEventArgs> OnTabRemoveAllExceptOne;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (FileSizeGetter != null)
                    FileSizeGetter.Dispose();
            }
        }
    }
}
