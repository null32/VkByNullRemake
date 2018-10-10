namespace VkByNullRemakeFormsGui.UtilWindows
{
    partial class Options
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
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.GeneralConfigTab = new System.Windows.Forms.TabPage();
            this.GeneralLangPathBtn = new System.Windows.Forms.Button();
            this.GeneralLangPathTextBox = new System.Windows.Forms.TextBox();
            this.GeneralLangPathLab = new System.Windows.Forms.Label();
            this.GeneralLangTextBox = new System.Windows.Forms.TextBox();
            this.GeneralLangLab = new System.Windows.Forms.Label();
            this.AudioConfigTab = new System.Windows.Forms.TabPage();
            this.AudioClearCacheBtn = new System.Windows.Forms.Button();
            this.AudioGuiListPlayColorGroup = new System.Windows.Forms.GroupBox();
            this.AudioPlayColorPreview = new System.Windows.Forms.TextBox();
            this.AudioPlayColorB = new System.Windows.Forms.Label();
            this.AudioListPlayColorB = new System.Windows.Forms.NumericUpDown();
            this.AudioListPlayColorR = new System.Windows.Forms.NumericUpDown();
            this.AudioPlayColorG = new System.Windows.Forms.Label();
            this.AudioListPlayColorG = new System.Windows.Forms.NumericUpDown();
            this.AudioPlayColorR = new System.Windows.Forms.Label();
            this.AudioGuiListDefColorGroup = new System.Windows.Forms.GroupBox();
            this.AudioDefColorPreview = new System.Windows.Forms.TextBox();
            this.AudioDefColorB = new System.Windows.Forms.Label();
            this.AudioListDefColorB = new System.Windows.Forms.NumericUpDown();
            this.AudioListDefColorR = new System.Windows.Forms.NumericUpDown();
            this.AudioDefColorG = new System.Windows.Forms.Label();
            this.AudioListDefColorG = new System.Windows.Forms.NumericUpDown();
            this.AudioDefColorR = new System.Windows.Forms.Label();
            this.AudioMaxCacheTextBox = new System.Windows.Forms.NumericUpDown();
            this.AudioMaxCacheLab = new System.Windows.Forms.Label();
            this.AudioLimitCacheCheck = new System.Windows.Forms.CheckBox();
            this.AudioPrecacheStepLab = new System.Windows.Forms.Label();
            this.AudioPrecacheStepTextBox = new System.Windows.Forms.NumericUpDown();
            this.AudioVolumeTextBox = new System.Windows.Forms.NumericUpDown();
            this.AudioVolumeLab = new System.Windows.Forms.Label();
            this.AudioOpenAudioPathBtn = new System.Windows.Forms.Button();
            this.AudioDownPathTextBox = new System.Windows.Forms.TextBox();
            this.AudioDownPathLab = new System.Windows.Forms.Label();
            this.OpenLangFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.OpenAudioDownFileDiaolog = new System.Windows.Forms.FolderBrowserDialog();
            this.AudioCacheSizeLab = new System.Windows.Forms.Label();
            this.AudioCacheSize = new System.Windows.Forms.Label();
            this.MainTabs.SuspendLayout();
            this.GeneralConfigTab.SuspendLayout();
            this.AudioConfigTab.SuspendLayout();
            this.AudioGuiListPlayColorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorG)).BeginInit();
            this.AudioGuiListDefColorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioMaxCacheTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioPrecacheStepTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioVolumeTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabs
            // 
            this.MainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabs.Controls.Add(this.GeneralConfigTab);
            this.MainTabs.Controls.Add(this.AudioConfigTab);
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(392, 332);
            this.MainTabs.TabIndex = 0;
            // 
            // GeneralConfigTab
            // 
            this.GeneralConfigTab.AutoScroll = true;
            this.GeneralConfigTab.Controls.Add(this.GeneralLangPathBtn);
            this.GeneralConfigTab.Controls.Add(this.GeneralLangPathTextBox);
            this.GeneralConfigTab.Controls.Add(this.GeneralLangPathLab);
            this.GeneralConfigTab.Controls.Add(this.GeneralLangTextBox);
            this.GeneralConfigTab.Controls.Add(this.GeneralLangLab);
            this.GeneralConfigTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralConfigTab.Name = "GeneralConfigTab";
            this.GeneralConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralConfigTab.Size = new System.Drawing.Size(384, 306);
            this.GeneralConfigTab.TabIndex = 0;
            this.GeneralConfigTab.Text = "General";
            this.GeneralConfigTab.UseVisualStyleBackColor = true;
            // 
            // GeneralLangPathBtn
            // 
            this.GeneralLangPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralLangPathBtn.Location = new System.Drawing.Point(303, 32);
            this.GeneralLangPathBtn.Name = "GeneralLangPathBtn";
            this.GeneralLangPathBtn.Size = new System.Drawing.Size(75, 23);
            this.GeneralLangPathBtn.TabIndex = 5;
            this.GeneralLangPathBtn.Text = "Open File";
            this.GeneralLangPathBtn.UseVisualStyleBackColor = true;
            this.GeneralLangPathBtn.Click += new System.EventHandler(this.GeneralLangPathBtn_Click);
            // 
            // GeneralLangPathTextBox
            // 
            this.GeneralLangPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralLangPathTextBox.Location = new System.Drawing.Point(89, 34);
            this.GeneralLangPathTextBox.Name = "GeneralLangPathTextBox";
            this.GeneralLangPathTextBox.Size = new System.Drawing.Size(208, 20);
            this.GeneralLangPathTextBox.TabIndex = 4;
            this.GeneralLangPathTextBox.TextChanged += new System.EventHandler(this.GeneralLangPathTextBox_TextChanged);
            // 
            // GeneralLangPathLab
            // 
            this.GeneralLangPathLab.AutoSize = true;
            this.GeneralLangPathLab.Location = new System.Drawing.Point(8, 37);
            this.GeneralLangPathLab.Name = "GeneralLangPathLab";
            this.GeneralLangPathLab.Size = new System.Drawing.Size(75, 13);
            this.GeneralLangPathLab.TabIndex = 3;
            this.GeneralLangPathLab.Text = "Lang File Path";
            // 
            // GeneralLangTextBox
            // 
            this.GeneralLangTextBox.Location = new System.Drawing.Point(69, 6);
            this.GeneralLangTextBox.Name = "GeneralLangTextBox";
            this.GeneralLangTextBox.ReadOnly = true;
            this.GeneralLangTextBox.Size = new System.Drawing.Size(50, 20);
            this.GeneralLangTextBox.TabIndex = 2;
            // 
            // GeneralLangLab
            // 
            this.GeneralLangLab.AutoSize = true;
            this.GeneralLangLab.Location = new System.Drawing.Point(8, 9);
            this.GeneralLangLab.Name = "GeneralLangLab";
            this.GeneralLangLab.Size = new System.Drawing.Size(55, 13);
            this.GeneralLangLab.TabIndex = 1;
            this.GeneralLangLab.Text = "Language";
            // 
            // AudioConfigTab
            // 
            this.AudioConfigTab.AutoScroll = true;
            this.AudioConfigTab.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.AudioConfigTab.Controls.Add(this.AudioCacheSize);
            this.AudioConfigTab.Controls.Add(this.AudioCacheSizeLab);
            this.AudioConfigTab.Controls.Add(this.AudioClearCacheBtn);
            this.AudioConfigTab.Controls.Add(this.AudioGuiListPlayColorGroup);
            this.AudioConfigTab.Controls.Add(this.AudioGuiListDefColorGroup);
            this.AudioConfigTab.Controls.Add(this.AudioMaxCacheTextBox);
            this.AudioConfigTab.Controls.Add(this.AudioMaxCacheLab);
            this.AudioConfigTab.Controls.Add(this.AudioLimitCacheCheck);
            this.AudioConfigTab.Controls.Add(this.AudioPrecacheStepLab);
            this.AudioConfigTab.Controls.Add(this.AudioPrecacheStepTextBox);
            this.AudioConfigTab.Controls.Add(this.AudioVolumeTextBox);
            this.AudioConfigTab.Controls.Add(this.AudioVolumeLab);
            this.AudioConfigTab.Controls.Add(this.AudioOpenAudioPathBtn);
            this.AudioConfigTab.Controls.Add(this.AudioDownPathTextBox);
            this.AudioConfigTab.Controls.Add(this.AudioDownPathLab);
            this.AudioConfigTab.Location = new System.Drawing.Point(4, 22);
            this.AudioConfigTab.Name = "AudioConfigTab";
            this.AudioConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.AudioConfigTab.Size = new System.Drawing.Size(384, 306);
            this.AudioConfigTab.TabIndex = 1;
            this.AudioConfigTab.Text = "Audio";
            this.AudioConfigTab.UseVisualStyleBackColor = true;
            // 
            // AudioClearCacheBtn
            // 
            this.AudioClearCacheBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioClearCacheBtn.Location = new System.Drawing.Point(303, 82);
            this.AudioClearCacheBtn.Name = "AudioClearCacheBtn";
            this.AudioClearCacheBtn.Size = new System.Drawing.Size(75, 23);
            this.AudioClearCacheBtn.TabIndex = 14;
            this.AudioClearCacheBtn.Text = "Clear Cache";
            this.AudioClearCacheBtn.UseVisualStyleBackColor = true;
            this.AudioClearCacheBtn.Click += new System.EventHandler(this.ClearCacheBtn_Click);
            // 
            // AudioGuiListPlayColorGroup
            // 
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioPlayColorPreview);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioPlayColorB);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioListPlayColorB);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioListPlayColorR);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioPlayColorG);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioListPlayColorG);
            this.AudioGuiListPlayColorGroup.Controls.Add(this.AudioPlayColorR);
            this.AudioGuiListPlayColorGroup.Location = new System.Drawing.Point(187, 135);
            this.AudioGuiListPlayColorGroup.Name = "AudioGuiListPlayColorGroup";
            this.AudioGuiListPlayColorGroup.Size = new System.Drawing.Size(175, 99);
            this.AudioGuiListPlayColorGroup.TabIndex = 13;
            this.AudioGuiListPlayColorGroup.TabStop = false;
            this.AudioGuiListPlayColorGroup.Text = "List Playing Back Color";
            // 
            // AudioPlayColorPreview
            // 
            this.AudioPlayColorPreview.Location = new System.Drawing.Point(124, 45);
            this.AudioPlayColorPreview.Name = "AudioPlayColorPreview";
            this.AudioPlayColorPreview.Size = new System.Drawing.Size(45, 20);
            this.AudioPlayColorPreview.TabIndex = 23;
            this.AudioPlayColorPreview.Text = "Preview";
            // 
            // AudioPlayColorB
            // 
            this.AudioPlayColorB.AutoSize = true;
            this.AudioPlayColorB.Location = new System.Drawing.Point(6, 73);
            this.AudioPlayColorB.Name = "AudioPlayColorB";
            this.AudioPlayColorB.Size = new System.Drawing.Size(28, 13);
            this.AudioPlayColorB.TabIndex = 18;
            this.AudioPlayColorB.Text = "Blue";
            // 
            // AudioListPlayColorB
            // 
            this.AudioListPlayColorB.Location = new System.Drawing.Point(73, 71);
            this.AudioListPlayColorB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListPlayColorB.Name = "AudioListPlayColorB";
            this.AudioListPlayColorB.Size = new System.Drawing.Size(45, 20);
            this.AudioListPlayColorB.TabIndex = 21;
            this.AudioListPlayColorB.ValueChanged += new System.EventHandler(this.AudioListPlayColorAny_ValueChanged);
            // 
            // AudioListPlayColorR
            // 
            this.AudioListPlayColorR.Location = new System.Drawing.Point(73, 19);
            this.AudioListPlayColorR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListPlayColorR.Name = "AudioListPlayColorR";
            this.AudioListPlayColorR.Size = new System.Drawing.Size(45, 20);
            this.AudioListPlayColorR.TabIndex = 19;
            this.AudioListPlayColorR.ValueChanged += new System.EventHandler(this.AudioListPlayColorAny_ValueChanged);
            // 
            // AudioPlayColorG
            // 
            this.AudioPlayColorG.AutoSize = true;
            this.AudioPlayColorG.Location = new System.Drawing.Point(6, 47);
            this.AudioPlayColorG.Name = "AudioPlayColorG";
            this.AudioPlayColorG.Size = new System.Drawing.Size(36, 13);
            this.AudioPlayColorG.TabIndex = 17;
            this.AudioPlayColorG.Text = "Green";
            // 
            // AudioListPlayColorG
            // 
            this.AudioListPlayColorG.Location = new System.Drawing.Point(73, 45);
            this.AudioListPlayColorG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListPlayColorG.Name = "AudioListPlayColorG";
            this.AudioListPlayColorG.Size = new System.Drawing.Size(45, 20);
            this.AudioListPlayColorG.TabIndex = 20;
            this.AudioListPlayColorG.ValueChanged += new System.EventHandler(this.AudioListPlayColorAny_ValueChanged);
            // 
            // AudioPlayColorR
            // 
            this.AudioPlayColorR.AutoSize = true;
            this.AudioPlayColorR.Location = new System.Drawing.Point(6, 21);
            this.AudioPlayColorR.Name = "AudioPlayColorR";
            this.AudioPlayColorR.Size = new System.Drawing.Size(27, 13);
            this.AudioPlayColorR.TabIndex = 16;
            this.AudioPlayColorR.Text = "Red";
            // 
            // AudioGuiListDefColorGroup
            // 
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioDefColorPreview);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioDefColorB);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioListDefColorB);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioListDefColorR);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioDefColorG);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioListDefColorG);
            this.AudioGuiListDefColorGroup.Controls.Add(this.AudioDefColorR);
            this.AudioGuiListDefColorGroup.Location = new System.Drawing.Point(6, 135);
            this.AudioGuiListDefColorGroup.Name = "AudioGuiListDefColorGroup";
            this.AudioGuiListDefColorGroup.Size = new System.Drawing.Size(175, 99);
            this.AudioGuiListDefColorGroup.TabIndex = 12;
            this.AudioGuiListDefColorGroup.TabStop = false;
            this.AudioGuiListDefColorGroup.Text = "List Default Back Color";
            // 
            // AudioDefColorPreview
            // 
            this.AudioDefColorPreview.Location = new System.Drawing.Point(123, 45);
            this.AudioDefColorPreview.Name = "AudioDefColorPreview";
            this.AudioDefColorPreview.Size = new System.Drawing.Size(45, 20);
            this.AudioDefColorPreview.TabIndex = 22;
            this.AudioDefColorPreview.Text = "Preview";
            // 
            // AudioDefColorB
            // 
            this.AudioDefColorB.AutoSize = true;
            this.AudioDefColorB.Location = new System.Drawing.Point(6, 73);
            this.AudioDefColorB.Name = "AudioDefColorB";
            this.AudioDefColorB.Size = new System.Drawing.Size(28, 13);
            this.AudioDefColorB.TabIndex = 2;
            this.AudioDefColorB.Text = "Blue";
            // 
            // AudioListDefColorB
            // 
            this.AudioListDefColorB.Location = new System.Drawing.Point(72, 71);
            this.AudioListDefColorB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListDefColorB.Name = "AudioListDefColorB";
            this.AudioListDefColorB.Size = new System.Drawing.Size(45, 20);
            this.AudioListDefColorB.TabIndex = 15;
            this.AudioListDefColorB.ValueChanged += new System.EventHandler(this.AudioListDefColorAny_ValueChanged);
            // 
            // AudioListDefColorR
            // 
            this.AudioListDefColorR.Location = new System.Drawing.Point(72, 19);
            this.AudioListDefColorR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListDefColorR.Name = "AudioListDefColorR";
            this.AudioListDefColorR.Size = new System.Drawing.Size(45, 20);
            this.AudioListDefColorR.TabIndex = 13;
            this.AudioListDefColorR.ValueChanged += new System.EventHandler(this.AudioListDefColorAny_ValueChanged);
            // 
            // AudioDefColorG
            // 
            this.AudioDefColorG.AutoSize = true;
            this.AudioDefColorG.Location = new System.Drawing.Point(6, 47);
            this.AudioDefColorG.Name = "AudioDefColorG";
            this.AudioDefColorG.Size = new System.Drawing.Size(36, 13);
            this.AudioDefColorG.TabIndex = 1;
            this.AudioDefColorG.Text = "Green";
            // 
            // AudioListDefColorG
            // 
            this.AudioListDefColorG.Location = new System.Drawing.Point(72, 45);
            this.AudioListDefColorG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AudioListDefColorG.Name = "AudioListDefColorG";
            this.AudioListDefColorG.Size = new System.Drawing.Size(45, 20);
            this.AudioListDefColorG.TabIndex = 14;
            this.AudioListDefColorG.ValueChanged += new System.EventHandler(this.AudioListDefColorAny_ValueChanged);
            // 
            // AudioDefColorR
            // 
            this.AudioDefColorR.AutoSize = true;
            this.AudioDefColorR.Location = new System.Drawing.Point(6, 21);
            this.AudioDefColorR.Name = "AudioDefColorR";
            this.AudioDefColorR.Size = new System.Drawing.Size(27, 13);
            this.AudioDefColorR.TabIndex = 0;
            this.AudioDefColorR.Text = "Red";
            // 
            // AudioMaxCacheTextBox
            // 
            this.AudioMaxCacheTextBox.Enabled = false;
            this.AudioMaxCacheTextBox.Location = new System.Drawing.Point(114, 109);
            this.AudioMaxCacheTextBox.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.AudioMaxCacheTextBox.Name = "AudioMaxCacheTextBox";
            this.AudioMaxCacheTextBox.Size = new System.Drawing.Size(60, 20);
            this.AudioMaxCacheTextBox.TabIndex = 11;
            this.AudioMaxCacheTextBox.ValueChanged += new System.EventHandler(this.AudioMaxCacheLabTextBox_ValueChanged);
            // 
            // AudioMaxCacheLab
            // 
            this.AudioMaxCacheLab.AutoSize = true;
            this.AudioMaxCacheLab.Enabled = false;
            this.AudioMaxCacheLab.Location = new System.Drawing.Point(8, 111);
            this.AudioMaxCacheLab.Name = "AudioMaxCacheLab";
            this.AudioMaxCacheLab.Size = new System.Drawing.Size(75, 13);
            this.AudioMaxCacheLab.TabIndex = 10;
            this.AudioMaxCacheLab.Text = "Max Size (MB)";
            // 
            // AudioLimitCacheCheck
            // 
            this.AudioLimitCacheCheck.AutoSize = true;
            this.AudioLimitCacheCheck.Location = new System.Drawing.Point(8, 86);
            this.AudioLimitCacheCheck.Name = "AudioLimitCacheCheck";
            this.AudioLimitCacheCheck.Size = new System.Drawing.Size(81, 17);
            this.AudioLimitCacheCheck.TabIndex = 9;
            this.AudioLimitCacheCheck.Text = "Cache Limit";
            this.AudioLimitCacheCheck.UseVisualStyleBackColor = true;
            this.AudioLimitCacheCheck.CheckedChanged += new System.EventHandler(this.AudioLimitCacheCheck_CheckedChanged);
            // 
            // AudioPrecacheStepLab
            // 
            this.AudioPrecacheStepLab.AutoSize = true;
            this.AudioPrecacheStepLab.Location = new System.Drawing.Point(8, 62);
            this.AudioPrecacheStepLab.Name = "AudioPrecacheStepLab";
            this.AudioPrecacheStepLab.Size = new System.Drawing.Size(78, 13);
            this.AudioPrecacheStepLab.TabIndex = 7;
            this.AudioPrecacheStepLab.Text = "Precache Step";
            // 
            // AudioPrecacheStepTextBox
            // 
            this.AudioPrecacheStepTextBox.Location = new System.Drawing.Point(114, 60);
            this.AudioPrecacheStepTextBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AudioPrecacheStepTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AudioPrecacheStepTextBox.Name = "AudioPrecacheStepTextBox";
            this.AudioPrecacheStepTextBox.Size = new System.Drawing.Size(60, 20);
            this.AudioPrecacheStepTextBox.TabIndex = 6;
            this.AudioPrecacheStepTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AudioPrecacheStepTextBox.ValueChanged += new System.EventHandler(this.AudioPrecacheStepTextBox_ValueChanged);
            // 
            // AudioVolumeTextBox
            // 
            this.AudioVolumeTextBox.DecimalPlaces = 3;
            this.AudioVolumeTextBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            this.AudioVolumeTextBox.Location = new System.Drawing.Point(114, 34);
            this.AudioVolumeTextBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AudioVolumeTextBox.Name = "AudioVolumeTextBox";
            this.AudioVolumeTextBox.Size = new System.Drawing.Size(60, 20);
            this.AudioVolumeTextBox.TabIndex = 5;
            this.AudioVolumeTextBox.ValueChanged += new System.EventHandler(this.AudioVolumeTextBox_ValueChanged);
            // 
            // AudioVolumeLab
            // 
            this.AudioVolumeLab.AutoSize = true;
            this.AudioVolumeLab.Location = new System.Drawing.Point(8, 36);
            this.AudioVolumeLab.Name = "AudioVolumeLab";
            this.AudioVolumeLab.Size = new System.Drawing.Size(74, 13);
            this.AudioVolumeLab.TabIndex = 4;
            this.AudioVolumeLab.Text = "Player Volume";
            // 
            // AudioOpenAudioPathBtn
            // 
            this.AudioOpenAudioPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioOpenAudioPathBtn.Location = new System.Drawing.Point(301, 6);
            this.AudioOpenAudioPathBtn.Name = "AudioOpenAudioPathBtn";
            this.AudioOpenAudioPathBtn.Size = new System.Drawing.Size(77, 23);
            this.AudioOpenAudioPathBtn.TabIndex = 2;
            this.AudioOpenAudioPathBtn.Text = "Select Folder";
            this.AudioOpenAudioPathBtn.UseVisualStyleBackColor = true;
            this.AudioOpenAudioPathBtn.Click += new System.EventHandler(this.AudioOpenAudioPathBtn_Click);
            // 
            // AudioDownPathTextBox
            // 
            this.AudioDownPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioDownPathTextBox.Location = new System.Drawing.Point(114, 8);
            this.AudioDownPathTextBox.Name = "AudioDownPathTextBox";
            this.AudioDownPathTextBox.Size = new System.Drawing.Size(181, 20);
            this.AudioDownPathTextBox.TabIndex = 1;
            this.AudioDownPathTextBox.TextChanged += new System.EventHandler(this.AudioDownPathTextBox_TextChanged);
            // 
            // AudioDownPathLab
            // 
            this.AudioDownPathLab.AutoSize = true;
            this.AudioDownPathLab.Location = new System.Drawing.Point(8, 11);
            this.AudioDownPathLab.Name = "AudioDownPathLab";
            this.AudioDownPathLab.Size = new System.Drawing.Size(100, 13);
            this.AudioDownPathLab.TabIndex = 0;
            this.AudioDownPathLab.Text = "Download Directory";
            // 
            // OpenLangFileDialog
            // 
            this.OpenLangFileDialog.FileName = "openFileDialog1";
            this.OpenLangFileDialog.Filter = "Json|*.json|All Files|*.*";
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(143, 338);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(224, 338);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyBtn.Location = new System.Drawing.Point(305, 338);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyBtn.TabIndex = 8;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // AudioCacheSizeLab
            // 
            this.AudioCacheSizeLab.AutoSize = true;
            this.AudioCacheSizeLab.Location = new System.Drawing.Point(111, 87);
            this.AudioCacheSizeLab.Name = "AudioCacheSizeLab";
            this.AudioCacheSizeLab.Size = new System.Drawing.Size(64, 13);
            this.AudioCacheSizeLab.TabIndex = 15;
            this.AudioCacheSizeLab.Text = "Cache Size:";
            // 
            // AudioCacheSize
            // 
            this.AudioCacheSize.AutoSize = true;
            this.AudioCacheSize.Location = new System.Drawing.Point(181, 87);
            this.AudioCacheSize.Name = "AudioCacheSize";
            this.AudioCacheSize.Size = new System.Drawing.Size(49, 13);
            this.AudioCacheSize.TabIndex = 16;
            this.AudioCacheSize.Text = "1337 Mb";
            // 
            // Options
            // 
            this.AcceptButton = this.ApplyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.OkBtn);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.VisibleChanged += new System.EventHandler(this.Options_VisibleChanged);
            this.MainTabs.ResumeLayout(false);
            this.GeneralConfigTab.ResumeLayout(false);
            this.GeneralConfigTab.PerformLayout();
            this.AudioConfigTab.ResumeLayout(false);
            this.AudioConfigTab.PerformLayout();
            this.AudioGuiListPlayColorGroup.ResumeLayout(false);
            this.AudioGuiListPlayColorGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListPlayColorG)).EndInit();
            this.AudioGuiListDefColorGroup.ResumeLayout(false);
            this.AudioGuiListDefColorGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioListDefColorG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioMaxCacheTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioPrecacheStepTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioVolumeTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage GeneralConfigTab;
        private System.Windows.Forms.TabPage AudioConfigTab;
        private System.Windows.Forms.TextBox GeneralLangTextBox;
        private System.Windows.Forms.Label GeneralLangLab;
        private System.Windows.Forms.OpenFileDialog OpenLangFileDialog;
        private System.Windows.Forms.TextBox GeneralLangPathTextBox;
        private System.Windows.Forms.Label GeneralLangPathLab;
        private System.Windows.Forms.Button GeneralLangPathBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button AudioOpenAudioPathBtn;
        private System.Windows.Forms.TextBox AudioDownPathTextBox;
        private System.Windows.Forms.Label AudioDownPathLab;
        private System.Windows.Forms.Label AudioPrecacheStepLab;
        private System.Windows.Forms.NumericUpDown AudioPrecacheStepTextBox;
        private System.Windows.Forms.NumericUpDown AudioVolumeTextBox;
        private System.Windows.Forms.Label AudioVolumeLab;
        private System.Windows.Forms.GroupBox AudioGuiListDefColorGroup;
        private System.Windows.Forms.Label AudioDefColorB;
        private System.Windows.Forms.NumericUpDown AudioListDefColorB;
        private System.Windows.Forms.NumericUpDown AudioListDefColorR;
        private System.Windows.Forms.Label AudioDefColorG;
        private System.Windows.Forms.NumericUpDown AudioListDefColorG;
        private System.Windows.Forms.Label AudioDefColorR;
        private System.Windows.Forms.NumericUpDown AudioMaxCacheTextBox;
        private System.Windows.Forms.Label AudioMaxCacheLab;
        private System.Windows.Forms.CheckBox AudioLimitCacheCheck;
        private System.Windows.Forms.GroupBox AudioGuiListPlayColorGroup;
        private System.Windows.Forms.Label AudioPlayColorB;
        private System.Windows.Forms.NumericUpDown AudioListPlayColorB;
        private System.Windows.Forms.NumericUpDown AudioListPlayColorR;
        private System.Windows.Forms.Label AudioPlayColorG;
        private System.Windows.Forms.NumericUpDown AudioListPlayColorG;
        private System.Windows.Forms.Label AudioPlayColorR;
        private System.Windows.Forms.FolderBrowserDialog OpenAudioDownFileDiaolog;
        private System.Windows.Forms.TextBox AudioPlayColorPreview;
        private System.Windows.Forms.TextBox AudioDefColorPreview;
        private System.Windows.Forms.Button AudioClearCacheBtn;
        private System.Windows.Forms.Label AudioCacheSize;
        private System.Windows.Forms.Label AudioCacheSizeLab;
    }
}