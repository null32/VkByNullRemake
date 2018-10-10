namespace VkByNullRemakeFormsGui.Categories
{
    partial class Audio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AudiosOfLab = new System.Windows.Forms.Label();
            this.AudiosOfLinkLab = new System.Windows.Forms.LinkLabel();
            this.LoadedAudiosLab = new System.Windows.Forms.Label();
            this.LoadMoreBtn = new System.Windows.Forms.Button();
            this.AlbumLab = new System.Windows.Forms.Label();
            this.AlbumSelectComboBox = new System.Windows.Forms.ComboBox();
            this.NowPlayingLab = new System.Windows.Forms.Label();
            this.NowPlayingContentLab = new System.Windows.Forms.Label();
            this.VolumeLab = new System.Windows.Forms.Label();
            this.VolumeComboBox = new System.Windows.Forms.NumericUpDown();
            this.SearchComboBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.MainTabsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeThisTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTabsExceptThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SampleTabPage = new System.Windows.Forms.TabPage();
            this.AudioListDataGrid = new System.Windows.Forms.DataGridView();
            this.AudioColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioColumnHasText = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AudioColumnDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioListContexStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToMyAudiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromMyAudiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchArtistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RepeatCheck = new System.Windows.Forms.CheckBox();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.ShuffleBtn = new System.Windows.Forms.Button();
            this.ToStatusCheck = new System.Windows.Forms.CheckBox();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.AudioFillerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PrecacheStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.IsArtistCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeComboBox)).BeginInit();
            this.MainTabs.SuspendLayout();
            this.MainTabsContextMenu.SuspendLayout();
            this.SampleTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDataGrid)).BeginInit();
            this.AudioListContexStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AudiosOfLab
            // 
            this.AudiosOfLab.AutoSize = true;
            this.AudiosOfLab.Location = new System.Drawing.Point(12, 18);
            this.AudiosOfLab.Name = "AudiosOfLab";
            this.AudiosOfLab.Size = new System.Drawing.Size(54, 13);
            this.AudiosOfLab.TabIndex = 0;
            this.AudiosOfLab.Text = "Audios of:";
            // 
            // AudiosOfLinkLab
            // 
            this.AudiosOfLinkLab.AutoSize = true;
            this.AudiosOfLinkLab.Location = new System.Drawing.Point(72, 18);
            this.AudiosOfLinkLab.Name = "AudiosOfLinkLab";
            this.AudiosOfLinkLab.Size = new System.Drawing.Size(73, 13);
            this.AudiosOfLinkLab.TabIndex = 1;
            this.AudiosOfLinkLab.TabStop = true;
            this.AudiosOfLinkLab.Text = "%UserName%";
            // 
            // LoadedAudiosLab
            // 
            this.LoadedAudiosLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadedAudiosLab.AutoSize = true;
            this.LoadedAudiosLab.Location = new System.Drawing.Point(207, 18);
            this.LoadedAudiosLab.Name = "LoadedAudiosLab";
            this.LoadedAudiosLab.Size = new System.Drawing.Size(60, 13);
            this.LoadedAudiosLab.TabIndex = 2;
            this.LoadedAudiosLab.Text = "1000/9999";
            // 
            // LoadMoreBtn
            // 
            this.LoadMoreBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadMoreBtn.Location = new System.Drawing.Point(283, 13);
            this.LoadMoreBtn.Name = "LoadMoreBtn";
            this.LoadMoreBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadMoreBtn.TabIndex = 2;
            this.LoadMoreBtn.Text = "Load More";
            this.LoadMoreBtn.UseVisualStyleBackColor = true;
            this.LoadMoreBtn.Click += new System.EventHandler(this.LoadMoreBtn_Click);
            // 
            // AlbumLab
            // 
            this.AlbumLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumLab.AutoSize = true;
            this.AlbumLab.Location = new System.Drawing.Point(364, 18);
            this.AlbumLab.Name = "AlbumLab";
            this.AlbumLab.Size = new System.Drawing.Size(36, 13);
            this.AlbumLab.TabIndex = 4;
            this.AlbumLab.Text = "Album";
            // 
            // AlbumSelectComboBox
            // 
            this.AlbumSelectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlbumSelectComboBox.FormattingEnabled = true;
            this.AlbumSelectComboBox.Location = new System.Drawing.Point(406, 15);
            this.AlbumSelectComboBox.Name = "AlbumSelectComboBox";
            this.AlbumSelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.AlbumSelectComboBox.TabIndex = 3;
            this.AlbumSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.AlbumSelectComboBox_SelectedIndexChanged);
            // 
            // NowPlayingLab
            // 
            this.NowPlayingLab.AutoSize = true;
            this.NowPlayingLab.Location = new System.Drawing.Point(139, 49);
            this.NowPlayingLab.Name = "NowPlayingLab";
            this.NowPlayingLab.Size = new System.Drawing.Size(68, 13);
            this.NowPlayingLab.TabIndex = 12;
            this.NowPlayingLab.Text = "Now playing:";
            // 
            // NowPlayingContentLab
            // 
            this.NowPlayingContentLab.AutoSize = true;
            this.NowPlayingContentLab.Location = new System.Drawing.Point(209, 49);
            this.NowPlayingContentLab.Name = "NowPlayingContentLab";
            this.NowPlayingContentLab.Size = new System.Drawing.Size(145, 13);
            this.NowPlayingContentLab.TabIndex = 13;
            this.NowPlayingContentLab.Text = "Some Artist - Some cool song";
            // 
            // VolumeLab
            // 
            this.VolumeLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLab.AutoSize = true;
            this.VolumeLab.Location = new System.Drawing.Point(519, 49);
            this.VolumeLab.Name = "VolumeLab";
            this.VolumeLab.Size = new System.Drawing.Size(42, 13);
            this.VolumeLab.TabIndex = 14;
            this.VolumeLab.Text = "Volume";
            // 
            // VolumeComboBox
            // 
            this.VolumeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeComboBox.DecimalPlaces = 3;
            this.VolumeComboBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            this.VolumeComboBox.Location = new System.Drawing.Point(567, 47);
            this.VolumeComboBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VolumeComboBox.Name = "VolumeComboBox";
            this.VolumeComboBox.Size = new System.Drawing.Size(53, 20);
            this.VolumeComboBox.TabIndex = 12;
            this.VolumeComboBox.ValueChanged += new System.EventHandler(this.VolumeComboBox_ValueChanged);
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchComboBox.Location = new System.Drawing.Point(12, 75);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(472, 20);
            this.SearchComboBox.TabIndex = 16;
            this.SearchComboBox.TextChanged += new System.EventHandler(this.SearchComboBox_TextChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(545, 73);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 18;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // MainTabs
            // 
            this.MainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabs.Controls.Add(this.SampleTabPage);
            this.MainTabs.Location = new System.Drawing.Point(12, 101);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(608, 327);
            this.MainTabs.TabIndex = 18;
            this.MainTabs.SelectedIndexChanged += new System.EventHandler(this.MainTabs_SelectedIndexChanged);
            this.MainTabs.SizeChanged += new System.EventHandler(this.MainTabs_SizeChanged);
            this.MainTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabs_MouseClick);
            // 
            // MainTabsContextMenu
            // 
            this.MainTabsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTabToolStripMenuItem,
            this.closeThisTabToolStripMenuItem,
            this.closeAllTabsExceptThisToolStripMenuItem,
            this.openPlaylistToolStripMenuItem,
            this.openCacheToolStripMenuItem});
            this.MainTabsContextMenu.Name = "MainTabsContextMenu";
            this.MainTabsContextMenu.Size = new System.Drawing.Size(199, 114);
            this.MainTabsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MainTabsContextMenu_Opening);
            // 
            // addTabToolStripMenuItem
            // 
            this.addTabToolStripMenuItem.Name = "addTabToolStripMenuItem";
            this.addTabToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addTabToolStripMenuItem.Text = "Add Tab";
            this.addTabToolStripMenuItem.Click += new System.EventHandler(this.addTabToolStripMenuItem_Click);
            // 
            // closeThisTabToolStripMenuItem
            // 
            this.closeThisTabToolStripMenuItem.Name = "closeThisTabToolStripMenuItem";
            this.closeThisTabToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.closeThisTabToolStripMenuItem.Text = "Close This Tab";
            this.closeThisTabToolStripMenuItem.Click += new System.EventHandler(this.closeThisTabToolStripMenuItem_Click);
            // 
            // closeAllTabsExceptThisToolStripMenuItem
            // 
            this.closeAllTabsExceptThisToolStripMenuItem.Name = "closeAllTabsExceptThisToolStripMenuItem";
            this.closeAllTabsExceptThisToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.closeAllTabsExceptThisToolStripMenuItem.Text = "Close All Tabs Except This";
            this.closeAllTabsExceptThisToolStripMenuItem.Click += new System.EventHandler(this.closeAllTabsExceptThisToolStripMenuItem_Click);
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
            this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.openPlaylistToolStripMenuItem_Click);
            // 
            // openCacheToolStripMenuItem
            // 
            this.openCacheToolStripMenuItem.Name = "openCacheToolStripMenuItem";
            this.openCacheToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openCacheToolStripMenuItem.Text = "Open Cache";
            this.openCacheToolStripMenuItem.Click += new System.EventHandler(this.openCacheToolStripMenuItem_Click);
            // 
            // SampleTabPage
            // 
            this.SampleTabPage.Controls.Add(this.AudioListDataGrid);
            this.SampleTabPage.Location = new System.Drawing.Point(4, 22);
            this.SampleTabPage.Name = "SampleTabPage";
            this.SampleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SampleTabPage.Size = new System.Drawing.Size(600, 301);
            this.SampleTabPage.TabIndex = 0;
            this.SampleTabPage.Text = "User Audio";
            this.SampleTabPage.UseVisualStyleBackColor = true;
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
            this.AudioListDataGrid.ContextMenuStrip = this.AudioListContexStrip;
            this.AudioListDataGrid.Location = new System.Drawing.Point(0, 0);
            this.AudioListDataGrid.Name = "AudioListDataGrid";
            this.AudioListDataGrid.ReadOnly = true;
            this.AudioListDataGrid.RowHeadersVisible = false;
            this.AudioListDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AudioListDataGrid.Size = new System.Drawing.Size(600, 301);
            this.AudioListDataGrid.TabIndex = 0;
            this.AudioListDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AudioListDataGrid_CellContentDoubleClick);
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
            // 
            // AudioListContexStrip
            // 
            this.AudioListContexStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToPlaylistToolStripMenuItem,
            this.removeFromPlaylistToolStripMenuItem,
            this.toolStripSeparator2,
            this.addToMyAudiosToolStripMenuItem,
            this.removeFromMyAudiosToolStripMenuItem,
            this.editToolStripMenuItem,
            this.searchArtistToolStripMenuItem,
            this.showTextToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.removeFromCacheToolStripMenuItem});
            this.AudioListContexStrip.Name = "AudioListContexStrip";
            this.AudioListContexStrip.Size = new System.Drawing.Size(193, 308);
            this.AudioListContexStrip.Opening += new System.ComponentModel.CancelEventHandler(this.AudioListContexStrip_Opening);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // addToPlaylistToolStripMenuItem
            // 
            this.addToPlaylistToolStripMenuItem.Name = "addToPlaylistToolStripMenuItem";
            this.addToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addToPlaylistToolStripMenuItem.Text = "Add To Playlist";
            this.addToPlaylistToolStripMenuItem.Click += new System.EventHandler(this.addToPlaylistToolStripMenuItem_Click);
            // 
            // removeFromPlaylistToolStripMenuItem
            // 
            this.removeFromPlaylistToolStripMenuItem.Name = "removeFromPlaylistToolStripMenuItem";
            this.removeFromPlaylistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeFromPlaylistToolStripMenuItem.Text = "Remove From Playlist";
            this.removeFromPlaylistToolStripMenuItem.Click += new System.EventHandler(this.removeFromPlaylistToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // addToMyAudiosToolStripMenuItem
            // 
            this.addToMyAudiosToolStripMenuItem.Name = "addToMyAudiosToolStripMenuItem";
            this.addToMyAudiosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addToMyAudiosToolStripMenuItem.Text = "Add To My Audios";
            this.addToMyAudiosToolStripMenuItem.Click += new System.EventHandler(this.addToMyAudiosToolStripMenuItem_Click);
            // 
            // removeFromMyAudiosToolStripMenuItem
            // 
            this.removeFromMyAudiosToolStripMenuItem.Name = "removeFromMyAudiosToolStripMenuItem";
            this.removeFromMyAudiosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeFromMyAudiosToolStripMenuItem.Text = "Remove From My Audios";
            this.removeFromMyAudiosToolStripMenuItem.Click += new System.EventHandler(this.removeFromMyAudiosToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // searchArtistToolStripMenuItem
            // 
            this.searchArtistToolStripMenuItem.Name = "searchArtistToolStripMenuItem";
            this.searchArtistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.searchArtistToolStripMenuItem.Text = "Search Artist";
            this.searchArtistToolStripMenuItem.Click += new System.EventHandler(this.searchArtistToolStripMenuItem_Click);
            // 
            // showTextToolStripMenuItem
            // 
            this.showTextToolStripMenuItem.Name = "showTextToolStripMenuItem";
            this.showTextToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showTextToolStripMenuItem.Text = "Show Text";
            this.showTextToolStripMenuItem.Click += new System.EventHandler(this.showTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artistTitleToolStripMenuItem,
            this.urlToolStripMenuItem});
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // artistTitleToolStripMenuItem
            // 
            this.artistTitleToolStripMenuItem.Name = "artistTitleToolStripMenuItem";
            this.artistTitleToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.artistTitleToolStripMenuItem.Text = "Artist + Title";
            this.artistTitleToolStripMenuItem.Click += new System.EventHandler(this.artistTitleToolStripMenuItem_Click);
            // 
            // urlToolStripMenuItem
            // 
            this.urlToolStripMenuItem.Name = "urlToolStripMenuItem";
            this.urlToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.urlToolStripMenuItem.Text = "Url";
            this.urlToolStripMenuItem.Click += new System.EventHandler(this.urlToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // removeFromCacheToolStripMenuItem
            // 
            this.removeFromCacheToolStripMenuItem.Name = "removeFromCacheToolStripMenuItem";
            this.removeFromCacheToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeFromCacheToolStripMenuItem.Text = "Remove From Cache";
            this.removeFromCacheToolStripMenuItem.Click += new System.EventHandler(this.removeFromCacheToolStripMenuItem_Click);
            // 
            // RepeatCheck
            // 
            this.RepeatCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RepeatCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.RepeatCheck.AutoSize = true;
            this.RepeatCheck.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Refresh;
            this.RepeatCheck.Location = new System.Drawing.Point(564, 12);
            this.RepeatCheck.MinimumSize = new System.Drawing.Size(25, 25);
            this.RepeatCheck.Name = "RepeatCheck";
            this.RepeatCheck.Size = new System.Drawing.Size(25, 25);
            this.RepeatCheck.TabIndex = 5;
            this.RepeatCheck.UseVisualStyleBackColor = true;
            this.RepeatCheck.CheckedChanged += new System.EventHandler(this.RepeatCheck_CheckedChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Player_Next;
            this.NextBtn.Location = new System.Drawing.Point(108, 43);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(25, 25);
            this.NextBtn.TabIndex = 11;
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PrevBtn
            // 
            this.PrevBtn.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Player_Prev;
            this.PrevBtn.Location = new System.Drawing.Point(77, 43);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(25, 25);
            this.PrevBtn.TabIndex = 10;
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Player_Pause;
            this.PauseBtn.Location = new System.Drawing.Point(46, 43);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(25, 25);
            this.PauseBtn.TabIndex = 9;
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Player_Play;
            this.PlayBtn.Location = new System.Drawing.Point(15, 43);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(25, 25);
            this.PlayBtn.TabIndex = 8;
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // ShuffleBtn
            // 
            this.ShuffleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleBtn.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Shuffle;
            this.ShuffleBtn.Location = new System.Drawing.Point(595, 12);
            this.ShuffleBtn.Name = "ShuffleBtn";
            this.ShuffleBtn.Size = new System.Drawing.Size(25, 25);
            this.ShuffleBtn.TabIndex = 6;
            this.ShuffleBtn.UseVisualStyleBackColor = true;
            this.ShuffleBtn.Click += new System.EventHandler(this.ShuffleBtn_Click);
            // 
            // ToStatusCheck
            // 
            this.ToStatusCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToStatusCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.ToStatusCheck.AutoSize = true;
            this.ToStatusCheck.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Broadcast;
            this.ToStatusCheck.Location = new System.Drawing.Point(533, 12);
            this.ToStatusCheck.MinimumSize = new System.Drawing.Size(25, 25);
            this.ToStatusCheck.Name = "ToStatusCheck";
            this.ToStatusCheck.Size = new System.Drawing.Size(25, 25);
            this.ToStatusCheck.TabIndex = 4;
            this.ToStatusCheck.UseVisualStyleBackColor = true;
            this.ToStatusCheck.CheckedChanged += new System.EventHandler(this.ToStatusCheck_CheckedChanged);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AudioFillerStatusLabel,
            this.PrecacheStatusLabel,
            this.PlayerStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 431);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(632, 22);
            this.MainStatusStrip.TabIndex = 20;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // AudioFillerStatusLabel
            // 
            this.AudioFillerStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Loading_16x16;
            this.AudioFillerStatusLabel.Name = "AudioFillerStatusLabel";
            this.AudioFillerStatusLabel.Size = new System.Drawing.Size(141, 17);
            this.AudioFillerStatusLabel.Text = "Window Status: Working";
            this.AudioFillerStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // PrecacheStatusLabel
            // 
            this.PrecacheStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Check_16x16;
            this.PrecacheStatusLabel.Name = "PrecacheStatusLabel";
            this.PrecacheStatusLabel.Size = new System.Drawing.Size(107, 17);
            this.PrecacheStatusLabel.Text = "Precaching: Done";
            this.PrecacheStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // PlayerStatusLabel
            // 
            this.PlayerStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Player_Stop;
            this.PlayerStatusLabel.Name = "PlayerStatusLabel";
            this.PlayerStatusLabel.Size = new System.Drawing.Size(134, 17);
            this.PlayerStatusLabel.Text = "Player Status: Stopped";
            this.PlayerStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // IsArtistCheck
            // 
            this.IsArtistCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsArtistCheck.AutoSize = true;
            this.IsArtistCheck.Location = new System.Drawing.Point(490, 77);
            this.IsArtistCheck.Name = "IsArtistCheck";
            this.IsArtistCheck.Size = new System.Drawing.Size(49, 17);
            this.IsArtistCheck.TabIndex = 17;
            this.IsArtistCheck.Text = "Artist";
            this.IsArtistCheck.UseVisualStyleBackColor = true;
            // 
            // Audio
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.IsArtistCheck);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.ToStatusCheck);
            this.Controls.Add(this.RepeatCheck);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchComboBox);
            this.Controls.Add(this.VolumeComboBox);
            this.Controls.Add(this.VolumeLab);
            this.Controls.Add(this.NowPlayingContentLab);
            this.Controls.Add(this.NowPlayingLab);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PrevBtn);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.ShuffleBtn);
            this.Controls.Add(this.AlbumSelectComboBox);
            this.Controls.Add(this.AlbumLab);
            this.Controls.Add(this.LoadMoreBtn);
            this.Controls.Add(this.LoadedAudiosLab);
            this.Controls.Add(this.AudiosOfLinkLab);
            this.Controls.Add(this.AudiosOfLab);
            this.Icon = global::VkByNullRemakeFormsGui.Properties.Resources.TempIcon_snd;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Audio";
            this.Text = "Audio";
            this.Activated += new System.EventHandler(this.Audio_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Audio_FormClosing);
            this.Load += new System.EventHandler(this.Audio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeComboBox)).EndInit();
            this.MainTabs.ResumeLayout(false);
            this.MainTabsContextMenu.ResumeLayout(false);
            this.SampleTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDataGrid)).EndInit();
            this.AudioListContexStrip.ResumeLayout(false);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AudiosOfLab;
        private System.Windows.Forms.LinkLabel AudiosOfLinkLab;
        private System.Windows.Forms.Label LoadedAudiosLab;
        private System.Windows.Forms.Button LoadMoreBtn;
        private System.Windows.Forms.Label AlbumLab;
        private System.Windows.Forms.ComboBox AlbumSelectComboBox;
        private System.Windows.Forms.Button ShuffleBtn;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label NowPlayingLab;
        private System.Windows.Forms.Label NowPlayingContentLab;
        private System.Windows.Forms.Label VolumeLab;
        private System.Windows.Forms.NumericUpDown VolumeComboBox;
        private System.Windows.Forms.TextBox SearchComboBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.CheckBox RepeatCheck;
        private System.Windows.Forms.ContextMenuStrip MainTabsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeThisTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllTabsExceptThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.TabPage SampleTabPage;
        private System.Windows.Forms.ContextMenuStrip AudioListContexStrip;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addToMyAudiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromMyAudiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchArtistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromCacheToolStripMenuItem;
        private System.Windows.Forms.CheckBox ToStatusCheck;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AudioFillerStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel PlayerStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel PrecacheStatusLabel;
        private System.Windows.Forms.CheckBox IsArtistCheck;
        private System.Windows.Forms.DataGridView AudioListDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioColumnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioColumnArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioColumnBitrate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AudioColumnHasText;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioColumnDuration;
    }
}