using NullUtilVK;
using NullUtilVK.Categories;
using NullUtilVK.Enums;
using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Enums.Win;
using NullUtilVK.Model.EventArg;
using NullUtilVK.Model.EventArg.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VkByNullRemakeFormsGui.Categories
{
    public partial class Audio : Form, ISavable
    {
        public Audio(NullUtilVk MainApi)
        {
            this.MainApi = MainApi;

            MainApi.MainWin.AudioWin.AudioListUpdater += AudioWin_AudioListUpdater;
            MainApi.MainWin.AudioWin.HeaderUpdater += AudioWin_HeaderUpdater;
            MainApi.MainWin.AudioWin.AudioBitrateUpdater += AudioWin_AudioBitrateUpdater;
            MainApi.MainWin.AudioWin.OnTabAdd += OnAddTabPageEventHandler;
            MainApi.MainWin.AudioWin.OnTabRemove += AudioWin_OnTabRemove;
            MainApi.MainWin.AudioWin.OnTabRemoveAllExceptOne += AudioWin_OnTabRemoveAllExceptOne;

            InitializeComponent();
            VolumeComboBox.Value = Convert.ToDecimal(MainApi.Audio.Player.Volume);

            TabUpdatingThreads = new List<int>();
        }

        void AudioWin_OnTabRemoveAllExceptOne(object sender, TabRemoveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new OnTabRemove(AudioWin_OnTabRemoveAllExceptOne);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            for (int i = 0; i < e.Index; i++)
            {
                MainTabs.TabPages.RemoveAt(i);
            }
            while (MainTabs.TabPages.Count > 1)
            {
                MainTabs.TabPages.RemoveAt(1);
            }
        }

        void AudioWin_OnTabRemove(object sender, TabRemoveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new OnTabRemove(AudioWin_OnTabRemove);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            MainTabs.TabPages.RemoveAt(e.Index);
        }


        NullUtilVk MainApi;

        Color RowBackColorDefault;
        Color RowBackColorPlaying;

        List<int> TabUpdatingThreads;

        //For future use
        #region public methods

        public void SaveState()
        {
            MainApi.Config.SetValue(ConfigDefault.AudioPlayerVolume, Convert.ToDouble(VolumeComboBox.Value));
        }

        public void ShowContent()
        {
            //Start page
            MainApi.MainWin.AudioWin.OpenUserAudios(OpenInNewTab: false);

            this.Show();
        }

        #endregion

        private void Audio_Load(object sender, EventArgs e)
        {
            //Event handling
            MainApi.Audio.Player.ActionAvaibility += PrevNextEventHandler;
            MainApi.Audio.Player.NowPlaying += UpdateNowPlaingEventHandler;
            MainApi.Audio.Player.PlaylistChanged += UpdatePlaylistEventhandler;
            MainApi.Audio.Player.PlayerStatusChanged += Player_PlayerStatusChanged;
            MainApi.Audio.Player.PrecacheStatusChanged += Player_PrecacheStatusChanged;
            //Album's items
            AlbumSelectComboBox.Items.Add("All");
            AlbumSelectComboBox.Items.Add("Recommendations");
            AlbumSelectComboBox.Items.Add("Popular");
            //Colors
            int[] colorArrayDefault = MainApi.Config.GetValue(ConfigDefault.AudioGuiListDefaultColor) as int[];
            int[] colorArrayPlaying = MainApi.Config.GetValue(ConfigDefault.AudioGuiListPlayingColor) as int[];
            RowBackColorDefault = Color.FromArgb(colorArrayDefault[0], colorArrayDefault[1], colorArrayDefault[2]);
            RowBackColorPlaying = Color.FromArgb(colorArrayPlaying[0], colorArrayPlaying[1], colorArrayPlaying[2]);

            SearchComboBox.AutoCompleteCustomSource.AddRange(MainApi.Audio.GetSearchHis().ToArray());
        }
        //Proper columns resizing
        private void MainTabs_SizeChanged(object sender, EventArgs e)
        {
            // Num Artist Title Bitrate Text Duration Scroll
            // 30  200    200   50      40   60       20 = :: 600
            foreach (TabPage item in MainTabs.TabPages)
            {
                (item.Controls[0] as DataGridView).Columns[2].Width = MainTabs.Width - 30 - 200 - 50 - 40 - 60 - 20 /*Dunno why but it's also need - 7 */ - 7;
            }
        }
        //Load More
        private void LoadMoreBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, NullUtilVK.Enums.Win.FillAudioType.AddMore));
        }
        //Search
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchComboBox.Text))
                MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, NullUtilVK.Enums.Win.FillAudioType.UserAudio));
            else
            {
                MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, NullUtilVK.Enums.Win.FillAudioType.Search, SearchQuerry: SearchComboBox.Text, IsArtist:IsArtistCheck.Checked));
                MainApi.Audio.AddSearchHis(SearchComboBox.Text);
                SearchComboBox.AutoCompleteCustomSource.Add(SearchComboBox.Text);
            }
        }
        //Tab switching
        private void MainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.UpdateHeader(MainTabs.SelectedIndex);
        }
        //Album switching
        private void AlbumSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            if (AlbumSelectComboBox.SelectedIndex == 0)
                if (TabPageBodies[MainTabs.SelectedIndex].User == null)
                    MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, FillAudioType.UserAudio));
                else
                    MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, FillAudioType.UserAudio, TabPageBodies[MainTabs.SelectedIndex].User.Id));
            else if (AlbumSelectComboBox.SelectedIndex == 1)
                MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, NullUtilVK.Enums.Win.FillAudioType.Recommendation));
            else if (AlbumSelectComboBox.SelectedIndex == 2)
                MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.SelectedIndex, NullUtilVK.Enums.Win.FillAudioType.Popular));
            else if (AlbumSelectComboBox.SelectedIndex > 3)
                MainApi.MainWin.AudioWin.OpenUserAudios(TabPageBodies[MainTabs.SelectedIndex].User.Id, TabPageBodies[MainTabs.SelectedIndex].AlbumList[AlbumSelectComboBox.SelectedIndex - 4].AlbumId, false);
        }
        //Volume changing
        private void VolumeComboBox_ValueChanged(object sender, EventArgs e)
        {
            MainApi.Audio.Player.Volume = Convert.ToDouble(VolumeComboBox.Value);
        }
        //Before closing
        private void Audio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _isHidden = true;
            Pause(true);
            e.Cancel = true;
        }

        private void Audio_Activated(object sender, EventArgs e)
        {
            _isHidden = false;
        }
        //Audio filtering
        private void SearchComboBox_TextChanged(object sender, EventArgs e)
        {
            string text = SearchComboBox.Text.ToLower();
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                foreach (DataGridViewRow row in (MainTabs.SelectedTab.Controls[0] as DataGridView).Rows)
                {
                    row.Visible = true;
                }
            else
                foreach (DataGridViewRow row in (MainTabs.SelectedTab.Controls[0] as DataGridView).Rows)
                {
                    if ((row.Cells[1].Value as string).ToLower().Contains(text) || (row.Cells[2].Value as string).ToLower().Contains(text))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
        }
        //Playing on double-click
        private void AudioListDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Play((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows[0].Index);
        }

        #region main tabs contex menu
        //Close all tabs exept this
        private void closeAllTabsExceptThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.CloseAllTabsExceptOne(MainTabs.SelectedIndex);
        }
        //Add tab
        private void addTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.AddNewTab();
        }
        //Close tab
        private void closeThisTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.CloseTab(MainTabs.SelectedIndex);
        }
        //On menu opening
        private void MainTabsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            closeThisTabToolStripMenuItem.Enabled = MainTabs.TabPages.Count != 1;
            closeAllTabsExceptThisToolStripMenuItem.Enabled = MainTabs.TabPages.Count != 1;
        }
        //Add playlist tab
        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.AddNewTab();
            MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.TabCount - 1, NullUtilVK.Enums.Win.FillAudioType.Playlist));
        }
        //Open cache
        private void openCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.AudioWin.AddNewTab();
            MainApi.MainWin.AudioWin.FillAudioList(new NullUtilVK.Model.Win.FillAudioBody(MainTabs.TabCount - 1, NullUtilVK.Enums.Win.FillAudioType.Cache));
        }
        private void MainTabs_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < MainTabs.TabCount; ++i)
            {
                if (MainTabs.GetTabRect(i).Contains(e.Location))
                {
                    MainTabs.SelectedIndex = i;
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                MainTabsContextMenu.Show(MainTabs, e.Location);
        }
        #endregion

        #region private methods
        //Adding new tab page
        private void OnAddTabPageEventHandler(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokeMethod = new OnAddTabPageEventHandler(OnAddTabPageEventHandler);
                this.Invoke(invokeMethod, sender, e);
                return;
            }

            MainTabs.TabPages.Add(new AudioTabPage());
            MainTabs.TabPages[MainTabs.TabPages.Count - 1].Controls[0].ContextMenuStrip = this.AudioListContexStrip;
            (MainTabs.TabPages[MainTabs.TabPages.Count - 1].Controls[0] as DataGridView).CellContentDoubleClick += AudioListDataGrid_CellContentDoubleClick;
            MainTabs.SelectedIndex = MainTabs.TabPages.Count - 1;
        }
        //Tab content updating
        void AudioWin_AudioListUpdater(object sender, FillAudioListEventArgs e)
        {
            if (this.InvokeRequired)
            {
                TabUpdatingThreads.Add(System.Threading.Thread.CurrentThread.ManagedThreadId);
                var invokedMethod = new AudioListUpdater(AudioWin_AudioListUpdater);
                this.Invoke(invokedMethod, sender, e);
                TabUpdatingThreads.Remove(System.Threading.Thread.CurrentThread.ManagedThreadId);
                UpdateStatusBar();
                return;
            }

            var argument = e.TabPageBody;
            //if (argument.LastAudioAction.Type != FillAudioType.AddMore)
            if (e.StartIndex == 0)
                (MainTabs.TabPages[argument.LastAudioAction.Index].Controls[0] as DataGridView).Rows.Clear();

            bool HasText;
            string BitRate;

            for (int i = e.StartIndex; i < argument.PlayList.Count; i++)
            {
                bool callBitrateUpdater = false;
                var item = argument.PlayList[i];
                HasText = item.LyricsId != null ? true : false;
                if (e.KnownBitrate != null && e.KnownBitrate.ContainsKey(argument.PlayList.IndexOf(item)))
                    BitRate = e.KnownBitrate[argument.PlayList.IndexOf(item)];
                else
                {
                    BitRate = "?";
                    callBitrateUpdater = true;
                }
                (MainTabs.TabPages[argument.LastAudioAction.Index].Controls[0] as DataGridView).Rows.Add((i + 1).ToString(), item.Artist, item.Title, BitRate, HasText, Util.SecToTime(item.Duration));
                if (callBitrateUpdater)
                    MainApi.MainWin.AudioWin.UpdateAudioBitrate(item);
            }
            switch (argument.LastAudioAction.Type)
            {
                case FillAudioType.UserAudio:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = argument.User.FirstName + " " + argument.User.LastName;
                    if (argument.LastAudioAction.AlbumId != null)
                        MainTabs.TabPages[argument.LastAudioAction.Index].Text += "(" + argument.AlbumList.First(c => c.AlbumId == argument.LastAudioAction.AlbumId).Title + ")";
                    break;
                case FillAudioType.GroupAudio:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = argument.Group.Name;
                    if (argument.LastAudioAction.AlbumId != null)
                        MainTabs.TabPages[argument.LastAudioAction.Index].Text += "(" + argument.AlbumList.First(c => c.AlbumId == argument.LastAudioAction.AlbumId).Title + ")";
                    break;
                case FillAudioType.Search:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = "Search Result";
                    break;
                case FillAudioType.Recommendation:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = "Recommendations";
                    break;
                case FillAudioType.Popular:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = "Popular";
                    break;
                case FillAudioType.Playlist:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = "Playlist";
                    break;
                case FillAudioType.Cache:
                    MainTabs.TabPages[argument.LastAudioAction.Index].Text = "Cache";
                    break;
            }
            //this called to high-light playing song
            UpdateNowPlaingEventHandler(this, new AudioItemEventArgs() { Audio = MainApi.Audio.Player.CurrentSong });
            MainApi.MainWin.AudioWin.UpdateHeader(argument.LastAudioAction.Index);
        }
        //Header updating
        void AudioWin_HeaderUpdater(object sender, FillAudioListEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new AudioListUpdater(AudioWin_HeaderUpdater);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            if (e.TabPageBody.User == null && e.TabPageBody.Group == null)
            {
                AudiosOfLab.Visible = false;
                AudiosOfLinkLab.Visible = false;
            }
            else
            {
                AudiosOfLab.Visible = true;
                AudiosOfLinkLab.Visible = true;
                AudiosOfLinkLab.Text = e.TabPageBody.User != null ? e.TabPageBody.User.FirstName + " " + e.TabPageBody.User.LastName : e.TabPageBody.Group.Name;
            }
            switch (e.TabPageBody.LastAudioAction.Type)
            {
                case FillAudioType.Playlist:
                    LoadedAudiosLab.Text = e.TabPageBody.PlayList.Count.ToString();
                    LoadMoreBtn.Enabled = false;
                    break;
                case FillAudioType.UserAudio:
                case FillAudioType.GroupAudio:
                case FillAudioType.Search:
                case FillAudioType.Cache:
                    if (e.TabPageBody.LastAudioAction.AlbumId != null)
                    {
                        LoadedAudiosLab.Text = e.TabPageBody.PlayList.Count.ToString() + "/Unknown";
                        LoadMoreBtn.Enabled = true;
                    }
                    else
                    {
                        LoadedAudiosLab.Text = e.TabPageBody.PlayList.Count.ToString() + "/" + e.TabPageBody.TotalAudios.ToString();
                        LoadMoreBtn.Enabled = e.TabPageBody.PlayList.Count != e.TabPageBody.TotalAudios;
                    }
                    break;
                case FillAudioType.None:
                    LoadedAudiosLab.Text = "0/0";
                    LoadMoreBtn.Enabled = false;
                    break;
                default:
                    //case FillAudioType.Recommendation:
                    //case FillAudioType.Popular:
                    //case FillAudioType.AddMore:        
                    break;
            }
            List<object> toRemove = new List<object>();
            for (int i = 3; i < AlbumSelectComboBox.Items.Count; i++)
            {
                toRemove.Add(AlbumSelectComboBox.Items[i]);
            }
            foreach (var item in toRemove)
            {
                AlbumSelectComboBox.Items.Remove(item);
            }
            if (e.TabPageBody.AlbumList != null)
            {
                AlbumSelectComboBox.Items.Add("(User Albums)");
                foreach (var item in e.TabPageBody.AlbumList)
                {
                    AlbumSelectComboBox.Items.Add(item.Title);
                }
            }
        }
        
        void AudioWin_AudioBitrateUpdater(object sender, SetBitrateEventArgs e)
        {
            foreach (var tab in MainApi.MainWin.AudioWin.TabPages.Where(c => c.PlayList.FirstOrDefault(v => v.Id == e.Id && v.OwnerId == e.OwnerId) != null))
            {
                (MainTabs.TabPages[MainApi.MainWin.AudioWin.TabPages.IndexOf(tab)].Controls[0] as DataGridView).Rows[tab.PlayList.IndexOf(tab.PlayList.FirstOrDefault(c => c.Id == e.Id && c.OwnerId == e.OwnerId))].Cells[3].Value = e.BitRate;
            }
        }
        //Update current song handler
        private void UpdateNowPlaingEventHandler(object sender, AudioItemEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new UpdateNowPlayingDelegate(UpdateNowPlaingEventHandler);
                this.Invoke(invokedMethod, new object[] { sender, e });
                return;
            }

            if (e.Audio == null)
                return;
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (var pageBody in TabPageBodies.Where(c => c.LastPlayingSongIndex != null))
            {
                (MainTabs.TabPages[TabPageBodies.IndexOf(pageBody)].Controls[0] as DataGridView).Rows[Convert.ToInt32(pageBody.LastPlayingSongIndex)].DefaultCellStyle.BackColor = RowBackColorDefault;
                pageBody.LastPlayingSongIndex = null;
            }
            foreach (var pageBody in TabPageBodies.Where(c => c.PlayList.FirstOrDefault(v => v.Id == e.Audio.Id && v.OwnerId == e.Audio.OwnerId) != null))
            //for some reason this just don't working ¯\_(ツ)_/¯
            //foreach (var pageBody in TabPageBodies.Where(c => c.PlayList.Contains(e.Audio)))
            {
                //so i can't use IndexOf either ¯\_(ツ)_/¯
                //(MainTabs.TabPages[TabPageBodies.IndexOf(pageBody)].Controls[0] as DataGridView).Rows[pageBody.PlayList.IndexOf(e.Audio)].DefaultCellStyle.BackColor = RowBackColorPlaying;
                //pageBody.LastPlayingSong = pageBody.PlayList.IndexOf(e.Audio);
                (MainTabs.TabPages[TabPageBodies.IndexOf(pageBody)].Controls[0] as DataGridView).Rows[pageBody.PlayList.IndexOf(pageBody.PlayList.FirstOrDefault(c => c.Id == e.Audio.Id && c.OwnerId == e.Audio.OwnerId))].DefaultCellStyle.BackColor = RowBackColorPlaying;
                pageBody.LastPlayingSongIndex = pageBody.PlayList.IndexOf(pageBody.PlayList.FirstOrDefault(c => c.Id == e.Audio.Id && c.OwnerId == e.Audio.OwnerId));
            }
            NowPlayingContentLab.Text = e.Audio.Artist + " - " + e.Audio.Title;
        }
        //Update prev & next state handler
        private void PrevNextEventHandler(object sender, ActionAvaibilityEventArgs e)
        {
            if (PrevBtn.InvokeRequired || NextBtn.InvokeRequired)
            {
                var invokedMethod = new PrevNextEnablerDelegate(PrevNextEventHandler);
                this.Invoke(invokedMethod, new object[] { sender, e });
                return;
            }

            PrevBtn.Enabled = e.PrevEnabled;
            NextBtn.Enabled = e.NextEnabled;
        }

        private void UpdatePlaylistEventhandler(object sender, PlaylistChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new UpdatePlaylistDelegate(UpdatePlaylistEventhandler);
                this.Invoke(invokedMethod, new object[] { sender, e });
                return;
            }
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            List<int> indexes = new List<int>();
            foreach (var item in TabPageBodies.Where(c => c.LastAudioAction.Type == FillAudioType.Playlist))
            {
                indexes.Add(TabPageBodies.IndexOf(item));
            }
            if (e.Type == PlaylistChangeType.Remove)
            {
                foreach (var item in e.ChangedItems)
                {
                    foreach (var index in indexes)
                    {
                        int i = TabPageBodies[index].PlayList.IndexOf(TabPageBodies[index].PlayList.First(c => c.Id == item.Value.Id));
                        TabPageBodies[index].PlayList.RemoveAt(i);
                        (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows.RemoveAt(i);
                        List<DataGridViewRow> toChangeIndex = new List<DataGridViewRow>();
                        foreach (DataGridViewRow itemBelow in (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows)
                        {
                            if (itemBelow.Index >= item.Key)
                                toChangeIndex.Add(itemBelow);
                        }
                        foreach (DataGridViewRow row in toChangeIndex)
                        {
                            (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows.RemoveAt(row.Index);
                        }
                        foreach (DataGridViewRow row in toChangeIndex)
                        {
                            (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows.Add(new object[] { ((MainTabs.TabPages[index].Controls[0] as DataGridView).Rows.Count + 1).ToString(), row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value });
                        }
                    }
                }
            }
            else if (e.Type == PlaylistChangeType.Replace)
            {
                foreach (var item in e.ChangedItems)
                {
                    foreach (var index in indexes)
                    {
                        var cells = (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows[item.Key].Cells;
                        cells[0].Value = (item.Key + 1).ToString();
                        cells[1].Value = item.Value.Artist;
                        cells[2].Value = item.Value.Title;
                        cells[3].Value = item.Value.LyricsId == null ? true : false;
                        cells[4].Value = Util.SecToTime(item.Value.Duration);
                        TabPageBodies[index].PlayList[item.Key] = item.Value;
                    }
                }
            }
            else if (e.Type == PlaylistChangeType.Add)
            {
                foreach (var item in e.ChangedItems)
                {
                    foreach (var index in indexes)
                    {
                        bool hasText = item.Value.LyricsId != null;
                        (MainTabs.TabPages[index].Controls[0] as DataGridView).Rows.Add(new object[] { (item.Key + 1).ToString(), item.Value.Artist, item.Value.Title, hasText, Util.SecToTime(item.Value.Duration) });
                        TabPageBodies[index].PlayList.Add(item.Value);
                    }
                }
            }
        }
        //Should broadcast to status?
        void ToStatusCheck_CheckedChanged(object sender, EventArgs e)
        {
            MainApi.Audio.ToStatus = ToStatusCheck.Checked;
        }
        //Controls updater
        void Player_PlayerStatusChanged(object sender, PlayerStatusChangedEventArgs e)
        {
            switch (e.NewStatus)
            {
                case PlaybackStatus.Playing:
                    PauseBtn.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Pause;
                    PlayerStatusLabel.Text = "Player Status: Playing";
                    PlayerStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Play;
                    break;
                case PlaybackStatus.Paused:
                    PauseBtn.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Play;
                    PlayerStatusLabel.Text = "Player Status: Paused";
                    PlayerStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Pause;
                    break;
                case PlaybackStatus.Stopped:
                    PauseBtn.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Pause;
                    PlayerStatusLabel.Text = "Player Status: Stopped";
                    PlayerStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Player_Stop;
                    break;
            }
        }
        //Precache status updater
        void Player_PrecacheStatusChanged(object sender, PrecacheStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case WorkerState.Done:
                    PrecacheStatusLabel.Text = "Precaching: Done";
                    PrecacheStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Check_16x16;
                    break;
                case WorkerState.Working:
                    PrecacheStatusLabel.Text = "Precaching: Working";
                    PrecacheStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Loading_16x16;
                    break;
            }
        }
        //Call this to play song
        private void Play(int StartIndex = 0)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            if (TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type != FillAudioType.Playlist)
            {
                List<VkNet.Model.Attachments.Audio> toAdd = new List<VkNet.Model.Attachments.Audio>();
                foreach (DataGridViewRow row in (MainTabs.SelectedTab.Controls[0] as DataGridView).Rows)
                {
                    if (row.Visible)
                        toAdd.Add(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
                }
                foreach (var item in toAdd)
                {
                    if (item.Id == TabPageBodies[MainTabs.SelectedIndex].PlayList[StartIndex].Id)
                    {
                        StartIndex = toAdd.IndexOf(item);
                        break;
                    }
                }
                MainApi.Audio.Player.ClearPlaylist();
                MainApi.Audio.Player.AddToPlaylist(toAdd);
            }
            MainApi.Audio.Player.Play(StartIndex);
        }
        //Player pause
        private void Pause(bool ForcePause = false)
        {
            if (MainApi.Audio.Player.PlaybackStatus == PlaybackStatus.Playing)
            {
                MainApi.Audio.Player.Pause();
            }
            else if (!ForcePause)
            {
                MainApi.Audio.Player.Resume();
            }
        }

        private void UpdateStatusBar()
        {
            if (TabUpdatingThreads.Count > 0)
            {
                this.AudioFillerStatusLabel.Text = "Window status: Working";
                this.AudioFillerStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Loading_16x16;
            }
            else
            {
                this.AudioFillerStatusLabel.Text = "Window Status: Done";
                this.AudioFillerStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Check_16x16;
            }
        }
        #endregion

        #region Player buttons
        //Play
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if ((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).Rows.Count > 0)
                Play((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows[0].Index);
        }
        //Pause/Resume
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            Pause();
        }
        //Prev
        private void PrevBtn_Click(object sender, EventArgs e)
        {
            MainApi.Audio.Player.Prev();
        }
        //Next
        private void NextBtn_Click(object sender, EventArgs e)
        {
            MainApi.Audio.Player.Next();
        }
        //Repeat
        private void RepeatCheck_CheckedChanged(object sender, EventArgs e)
        {
            MainApi.Audio.Player.Repeat = RepeatCheck.Checked;
        }
        //Shuffle
        private void ShuffleBtn_Click(object sender, EventArgs e)
        {
            MainApi.Audio.Player.ShufflePlaylist();
        }
        
        #endregion

        #region Audio List contex menu
        //Before menu opening
        private void AudioListContexStrip_Opening(object sender, CancelEventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            if ((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows.Count > 0)
            {
                removeFromPlaylistToolStripMenuItem.Enabled = TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type == FillAudioType.Playlist;
                addToPlaylistToolStripMenuItem.Enabled = !removeFromPlaylistToolStripMenuItem.Enabled;
                
                removeFromMyAudiosToolStripMenuItem.Enabled = TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type == FillAudioType.UserAudio && TabPageBodies[MainTabs.SelectedIndex].User.Id == MainApi.UserId;
                editToolStripMenuItem.Enabled = TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type == FillAudioType.UserAudio && TabPageBodies[MainTabs.SelectedIndex].User.Id == MainApi.UserId;
                addToMyAudiosToolStripMenuItem.Enabled = !removeFromMyAudiosToolStripMenuItem.Enabled;

                searchArtistToolStripMenuItem.Enabled = (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows.Count == 1;

                showTextToolStripMenuItem.Enabled = true;
                artistTitleToolStripMenuItem.Enabled = true;
                urlToolStripMenuItem.Enabled = TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type != FillAudioType.Cache;

                removeFromCacheToolStripMenuItem.Enabled = TabPageBodies[MainTabs.SelectedIndex].LastAudioAction.Type == FillAudioType.Cache;
            }
            else
            {
                removeFromPlaylistToolStripMenuItem.Enabled = false;
                addToPlaylistToolStripMenuItem.Enabled = false;

                addToMyAudiosToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                removeFromMyAudiosToolStripMenuItem.Enabled = false;

                searchArtistToolStripMenuItem.Enabled = false;

                showTextToolStripMenuItem.Enabled = false;
                artistTitleToolStripMenuItem.Enabled = false;
                urlToolStripMenuItem.Enabled = false;
            }
        }
        //Play
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Play((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows[0].Index);
        }
        //Pause
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
        }
        //Stop
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApi.Audio.Player.Stop();
        }
        //Add to playlist
        private void addToPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            List<VkNet.Model.Attachments.Audio> toAdd = new List<VkNet.Model.Attachments.Audio>();
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                toAdd.Add(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
            }
            toAdd.Reverse();
            MainApi.Audio.Player.AddToPlaylist(toAdd);
        }
        //Remove from playlist
        private void removeFromPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            List<VkNet.Model.Attachments.Audio> toRemove = new List<VkNet.Model.Attachments.Audio>();
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                toRemove.Add(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
            }
            MainApi.Audio.Player.RemoveFromPlaylist(toRemove);
        }
        //Add to my audios
        private void addToMyAudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                MainApi.Audio.Add(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
            }
        }
        //Remove from my audios
        private void removeFromMyAudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                MainApi.Audio.Delete(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
            }
        }
        //Search artist
        private void searchArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            SearchComboBox.Text = TabPageBodies[MainTabs.SelectedIndex].PlayList[(int)((MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows[0].Index)].Artist;
            IsArtistCheck.Checked = true;
            SearchBtn_Click(this, EventArgs.Empty);
        }
        //Show text
        private void showTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                var item = (TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
                VkByNullRemakeFormsGui.UtilWindows.AudioTextShower TextWin;
                if (item.LyricsId != null)
                {
                    TextWin = new VkByNullRemakeFormsGui.UtilWindows.AudioTextShower(item.Artist + " - " + item.Title, MainApi.Audio.GetText((long)item.LyricsId));
                    TextWin.Show();
                }
            }
            
        }
        //Copy -> Artist + Title
        private void artistTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                var item = (TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
                sb.Append(", ");
                sb.Append(item.Artist);
                sb.Append(" - ");
                sb.Append(item.Title);
            }
            Clipboard.SetText(sb.ToString().Remove(0, 2));
        }
        //Copy -> Url
        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                sb.Append(", ");
                sb.Append((TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]).Url.ToString().Split('?')[0]);
            }
            Clipboard.SetText(sb.ToString().Remove(0, 2));
        }
        //Download
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                MainApi.Audio.Download(TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
            }
        }
        //Remove From Cache
        private void removeFromCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                var audio = TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index];
                if (MainApi.Audio.Player.CurrentSong != null && audio.Id == MainApi.Audio.Player.CurrentSong.Id && audio.OwnerId == MainApi.Audio.Player.CurrentSong.OwnerId)
                {
                    return;
                }
                else
                {
                    MainApi.Audio.DeleteFromCache(audio);
                    (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).Rows.Remove(row);
                }
            }
        }
        //Edit
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            foreach (DataGridViewRow row in (MainTabs.TabPages[MainTabs.SelectedIndex].Controls[0] as DataGridView).SelectedRows)
            {
                var item = (TabPageBodies[MainTabs.SelectedIndex].PlayList[row.Index]);
                VkByNullRemakeFormsGui.UtilWindows.AudioSongEditor Editor = new UtilWindows.AudioSongEditor(MainApi.Audio, MainApi.Audio.GetById((long)item.OwnerId, item.Id));
                Editor.Show();
            }
        }
        #endregion


        #region ISavable
        public IDictionary<string, object> SaveInst()
        {
            var Values = new Dictionary<string, object>();
            //Window related
            Values.Add("is_hidden", (this as ISavable).IsHidden);
            Values.Add("state", (int)(this as Form).WindowState);
            Values.Add("width", (this as ISavable).WidthI);
            Values.Add("height", (this as ISavable).HeightI);
            Values.Add("pos_x", (this as ISavable).PosX);
            Values.Add("pos_y", (this as ISavable).PosY);

            Values.Add("broadcast", this.ToStatusCheck.Checked);
            Values.Add("repeat", this.RepeatCheck.Checked);
            if (!String.IsNullOrEmpty(SearchComboBox.Text))
                Values.Add("search_text", this.SearchComboBox.Text);
            //Playback related
            Values.Add("playback_state", (int)MainApi.Audio.Player.PlaybackStatus);
            if (MainApi.Audio.Player.CurrentSong != null)
                Values.Add("playing_index", MainApi.Audio.Player.CurrentSong.ToString());
            //Current playlist
            var Playlist = new List<Dictionary<string, object>>();
            foreach (var audio in MainApi.Audio.Player.GetPlaylist())
            {
                Playlist.Add(AudioToDict(audio));
            }
            Values.Add("playlist", Playlist);
            //Tabs
            var Tabs = new List<Dictionary<string, object>>();
            foreach (var tabBody in MainApi.MainWin.AudioWin.TabPages)
            {
                Tabs.Add(TabToDict(tabBody));
            }
            Values.Add("tabs", Tabs);

            return Values;
        }

        public async void LoadInst(Castable values)
        {
            await System.Threading.Tasks.Task.Run(() => { LoaderBack(values); });
        }

        public void LoaderBack(Castable values)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new LoaderBackGround(LoaderBack);
                this.Invoke(invokedMethod, values );
                return;
            }

            this.WindowState = Util.EnumFrom<FormWindowState>(values["state"]);
            this.Width = values["width"];
            this.Height = values["height"];
            this.Left = values["pos_x"];
            this.Top = values["pos_y"];

            this.ToStatusCheck.Checked = values["broadcast"];
            this.RepeatCheck.Checked = values["repeat"];
            this.SearchComboBox.Text = values["search_text"];

            var playlist = new List<KeyValuePair<long, long>>();
            foreach (var audio in (CastableArray)values["playlist"])
            {
                playlist.Add(new KeyValuePair<long, long>(audio["owner_id"], audio["id"]));
            }
            if (playlist.Count > 0)
                MainApi.Audio.Player.AddToPlaylist(MainApi.Audio.GetById(playlist).ToList());
            if (values["playing_index"] != null && Util.EnumFrom<PlaybackStatus>(values["playback_state"]) == PlaybackStatus.Playing)
            {
                MainApi.Audio.Player.Play(values["playing_index"]);
            }

            foreach (var tab in (CastableArray)values["tabs"])
            {
                if (MainApi.MainWin.AudioWin.TabPages[MainTabs.SelectedIndex].LastAudioAction.Type != FillAudioType.None)
                    MainApi.MainWin.AudioWin.AddNewTab();
                CastToTab(tab, MainTabs.SelectedIndex);
            }

            if (TabUpdatingThreads.Count == 0)
            {
                this.AudioFillerStatusLabel.Text = "Window Status: Done";
                this.AudioFillerStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Check_16x16;
            }
        }

        public bool IsHidden
        {
            get { return _isHidden; }
        }
        private bool _isHidden;
        public FormWindowState FormState
        {
            get { return this.WindowState; }
        }
        public int WidthI
        {
            get { return this.WidthI; }
        }
        public int HeightI
        {
            get { return this.HeightI; }
        }
        public int PosX
        {
            get { return this.Left; }
        }
        public int PosY
        {
            get { return this.Top; }
        }
        #endregion

        private Dictionary<string, object> AudioToDict(VkNet.Model.Attachments.Audio audio)
        {
            var result = new Dictionary<string, object>();
            result.Add("id", audio.Id);
            result.Add("owner_id", audio.OwnerId);

            return result;
        }
        private Dictionary<string, object> TabToDict(NullUtilVK.Enums.Win.AudioTabPageBody body)
        {
            var result = new Dictionary<string, object>();

            var lastAction = new Dictionary<string, object>();
            lastAction.Add("index", body.LastAudioAction.Index);
            lastAction.Add("type", (int)body.LastAudioAction.Type);
            if (body.LastAudioAction.UserId != null)
                lastAction.Add("user_id", body.LastAudioAction.UserId);
            if (body.LastAudioAction.GroupId != null)
                lastAction.Add("group_id", body.LastAudioAction.GroupId);
            if (body.LastAudioAction.AlbumId != null)
                lastAction.Add("album_id", body.LastAudioAction.AlbumId);
            if (body.LastAudioAction.SearchQuerry != null)
                lastAction.Add("search_querry", body.LastAudioAction.SearchQuerry);
            result.Add("last_action", lastAction);

            var Playlist = new List<Dictionary<string, object>>();
            foreach (var audio in body.PlayList)
            {
                Playlist.Add(AudioToDict(audio));
            }
            result.Add("playlist", Playlist);

            if (body.AlbumList != null)
            {
                var AlbumList = new List<Dictionary<string, object>>();
                foreach (var album in body.AlbumList)
                {
                    var Album = new Dictionary<string, object>();
                    Album.Add("id", album.AlbumId);
                    Album.Add("owner_id", album.OwnerId);
                    Album.Add("title", album.Title);

                    AlbumList.Add(Album);
                }
                result.Add("album_list", AlbumList);
            }
            
            result.Add("total_audios", body.TotalAudios);
            if (body.User != null)
                result.Add("user", body.User.Id);
            if (body.Group != null)
                result.Add("group", body.Group.Id);
            if (body.LastPlayingSongIndex != null)
                result.Add("last_song_index", body.LastPlayingSongIndex);

            return result;
        }
        private void CastToTab(Castable cast, int index)
        {
            var TabPageBodies = MainApi.MainWin.AudioWin.TabPages;
            TabPageBodies[index].LastAudioAction.Index = cast["last_action"]["index"];
            TabPageBodies[index].LastAudioAction.Type = Util.EnumFrom<FillAudioType>(cast["last_action"]["type"]);
            TabPageBodies[index].LastAudioAction.UserId = cast["last_action"]["user_id"];
            TabPageBodies[index].LastAudioAction.GroupId = cast["last_action"]["group_id"];
            TabPageBodies[index].LastAudioAction.AlbumId = cast["last_action"]["album_id"];
            TabPageBodies[index].LastAudioAction.SearchQuerry = cast["last_action"]["search_querry"];

            var playlist = new List<KeyValuePair<long, long>>();
            foreach (var audio in (CastableArray)cast["playlist"])
            {
                playlist.Add(new KeyValuePair<long, long>(audio["owner_id"], audio["id"]));
            }
            TabPageBodies[index].PlayList = MainApi.Audio.GetById(playlist).ToList();

            if ((CastableArray)cast["album_list"] != null)
                foreach (var album in (CastableArray)cast["album_list"])
                {
                    TabPageBodies[index].AlbumList.Add(new VkNet.Model.AudioAlbum()
                    {
                        AlbumId = album["id"],
                        OwnerId = album["owner_id"],
                        Title = album["title"]
                    });
                }

            TabPageBodies[index].TotalAudios = cast["total_audios"];
            TabPageBodies[index].User = cast["user"] == null ? null : MainApi.User.Get(cast["user"]);
            TabPageBodies[index].Group = cast["group"] == null ? null : MainApi.Group.GetById(cast["group"]);
            TabPageBodies[index].LastPlayingSongIndex = cast["last_song_index"];
            MainApi.MainWin.AudioWin.FillAudioList(TabPageBodies[index].LastAudioAction);
        }

        
    }
    //Some delegates
    delegate void PrevNextEnablerDelegate(object sender, ActionAvaibilityEventArgs e);
    delegate void UpdateNowPlayingDelegate(object sender, AudioItemEventArgs e);
    delegate void UpdatePlaylistDelegate(object sender, PlaylistChangedEventArgs e);

    delegate void LoaderBackGround(Castable values);

    delegate void OnAddTabPageEventHandler(object sender, EventArgs e);
    delegate void AudioListUpdater(object sender, FillAudioListEventArgs e);
    delegate void OnTabRemove(object sender, TabRemoveEventArgs e);
    //new tab body
    class AudioTabPage : TabPage
    {
        private DataGridView AudioListDataGrid;
        private DataGridViewTextBoxColumn AudioColumnNum;
        private DataGridViewTextBoxColumn AudioColumnArtist;
        private DataGridViewTextBoxColumn AudioColumnTitle;
        private DataGridViewTextBoxColumn AudioColumnBitrate;
        private DataGridViewCheckBoxColumn AudioColumnHasText;
        private DataGridViewTextBoxColumn AudioColumnDuration;

        public AudioTabPage()
        {
            this.AudioListDataGrid = new System.Windows.Forms.DataGridView();
            this.AudioColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnHasText = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AudioColumnDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // 
            // SampleTabPage
            // 
            this.Controls.Add(this.AudioListDataGrid);
            this.Location = new System.Drawing.Point(4, 22);
            this.Name = "SampleTabPage";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(600, 314);
            this.TabIndex = 0;
            this.Text = "User Audio";
            this.UseVisualStyleBackColor = true;
            // 
            // AudioListDataGrid
            // 
            this.AudioListDataGrid.AllowUserToAddRows = false;
            this.AudioListDataGrid.AllowUserToDeleteRows = false;
            this.AudioListDataGrid.AllowUserToResizeRows = false;
            this.AudioListDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AudioListDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AudioColumnNum,
            this.AudioColumnArtist,
            this.AudioColumnTitle,
            this.AudioColumnBitrate,
            this.AudioColumnHasText,
            this.AudioColumnDuration});
            this.AudioListDataGrid.Location = new System.Drawing.Point(0, 0);
            this.AudioListDataGrid.Name = "AudioListDataGrid";
            this.AudioListDataGrid.ReadOnly = true;
            this.AudioListDataGrid.RowHeadersVisible = false;
            this.AudioListDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AudioListDataGrid.Size = new System.Drawing.Size(600, 314);
            this.AudioListDataGrid.TabIndex = 0;
            // 
            // AudioColumnNum
            // 
            this.AudioColumnNum.HeaderText = "#";
            this.AudioColumnNum.Name = "AudioColumnNum";
            this.AudioColumnNum.ReadOnly = true;
            this.AudioColumnNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AudioColumnNum.Width = 30;
            // 
            // AudioColumnArtist
            // 
            this.AudioColumnArtist.HeaderText = "Artist";
            this.AudioColumnArtist.Name = "AudioColumnArtist";
            this.AudioColumnArtist.ReadOnly = true;
            this.AudioColumnArtist.Width = 200;
            // 
            // AudioColumnTitle
            // 
            this.AudioColumnTitle.HeaderText = "Title";
            this.AudioColumnTitle.Name = "AudioColumnTitle";
            this.AudioColumnTitle.ReadOnly = true;
            this.AudioColumnTitle.Width = 200;
            // 
            // AudioColumnBitrate
            // 
            this.AudioColumnBitrate.HeaderText = "Bitrate";
            this.AudioColumnBitrate.Name = "AudioColumnBitrate";
            this.AudioColumnBitrate.ReadOnly = true;
            this.AudioColumnBitrate.Width = 50;
            // 
            // AudioColumnHasText
            // 
            this.AudioColumnHasText.HeaderText = "Text";
            this.AudioColumnHasText.Name = "AudioColumnHasText";
            this.AudioColumnHasText.ReadOnly = true;
            this.AudioColumnHasText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AudioColumnHasText.Width = 40;
            // 
            // AudioColumnDuration
            // 
            this.AudioColumnDuration.HeaderText = "Duration";
            this.AudioColumnDuration.Name = "AudioColumnDuration";
            this.AudioColumnDuration.ReadOnly = true;
            this.AudioColumnDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AudioColumnDuration.Width = 60;
        }
    }
}
