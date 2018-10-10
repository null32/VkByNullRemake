namespace VkByNullRemakeFormsGui
{
    partial class MainWindow
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
                if (MainApi != null)
                    MainApi.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainWindowMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.EmailLab = new System.Windows.Forms.Label();
            this.PassLab = new System.Windows.Forms.Label();
            this.LogInBtn = new System.Windows.Forms.Button();
            this.NormalLoginRadBtn = new System.Windows.Forms.RadioButton();
            this.AltLoginRadBtn = new System.Windows.Forms.RadioButton();
            this.ShowPassCheck = new System.Windows.Forms.CheckBox();
            this.InstAddBtn = new System.Windows.Forms.Button();
            this.IdentitySelectComBox = new System.Windows.Forms.ComboBox();
            this.InstNameLab = new System.Windows.Forms.Label();
            this.InstNameTextBox = new System.Windows.Forms.TextBox();
            this.InstRemoveBtn = new System.Windows.Forms.Button();
            this.InstUpdateBtn = new System.Windows.Forms.Button();
            this.CategoriesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AudioCategoryBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifuIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.AuthorizationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainWindowMenuStrip.SuspendLayout();
            this.CategoriesFlowPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.NotifuIconMenu.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainWindowMenuStrip
            // 
            this.MainWindowMenuStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainWindowMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainWindowMenuStrip.Name = "MainWindowMenuStrip";
            this.MainWindowMenuStrip.Size = new System.Drawing.Size(472, 24);
            this.MainWindowMenuStrip.TabIndex = 0;
            this.MainWindowMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.consoleToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.consoleToolStripMenuItem.Text = "&Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(115, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(95, 80);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(150, 20);
            this.EmailTextBox.TabIndex = 4;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.InstAttribsTextChanged);
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(95, 106);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(150, 20);
            this.PassTextBox.TabIndex = 5;
            this.PassTextBox.UseSystemPasswordChar = true;
            this.PassTextBox.TextChanged += new System.EventHandler(this.InstAttribsTextChanged);
            // 
            // EmailLab
            // 
            this.EmailLab.AutoSize = true;
            this.EmailLab.Location = new System.Drawing.Point(12, 83);
            this.EmailLab.Name = "EmailLab";
            this.EmailLab.Size = new System.Drawing.Size(68, 13);
            this.EmailLab.TabIndex = 3;
            this.EmailLab.Text = "Email/Phone";
            // 
            // PassLab
            // 
            this.PassLab.AutoSize = true;
            this.PassLab.Location = new System.Drawing.Point(12, 109);
            this.PassLab.Name = "PassLab";
            this.PassLab.Size = new System.Drawing.Size(53, 13);
            this.PassLab.TabIndex = 4;
            this.PassLab.Text = "Password";
            // 
            // LogInBtn
            // 
            this.LogInBtn.Location = new System.Drawing.Point(12, 230);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(115, 23);
            this.LogInBtn.TabIndex = 1;
            this.LogInBtn.Text = "Log In";
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // NormalLoginRadBtn
            // 
            this.NormalLoginRadBtn.AutoSize = true;
            this.NormalLoginRadBtn.Checked = true;
            this.NormalLoginRadBtn.Location = new System.Drawing.Point(6, 19);
            this.NormalLoginRadBtn.Name = "NormalLoginRadBtn";
            this.NormalLoginRadBtn.Size = new System.Drawing.Size(58, 17);
            this.NormalLoginRadBtn.TabIndex = 6;
            this.NormalLoginRadBtn.TabStop = true;
            this.NormalLoginRadBtn.Text = "Normal";
            this.NormalLoginRadBtn.UseVisualStyleBackColor = true;
            this.NormalLoginRadBtn.CheckedChanged += new System.EventHandler(this.LoginMethodChanged);
            // 
            // AltLoginRadBtn
            // 
            this.AltLoginRadBtn.AutoSize = true;
            this.AltLoginRadBtn.Location = new System.Drawing.Point(6, 42);
            this.AltLoginRadBtn.Name = "AltLoginRadBtn";
            this.AltLoginRadBtn.Size = new System.Drawing.Size(77, 17);
            this.AltLoginRadBtn.TabIndex = 7;
            this.AltLoginRadBtn.Text = "Alternatime";
            this.AltLoginRadBtn.UseVisualStyleBackColor = true;
            this.AltLoginRadBtn.CheckedChanged += new System.EventHandler(this.LoginMethodChanged);
            // 
            // ShowPassCheck
            // 
            this.ShowPassCheck.AutoSize = true;
            this.ShowPassCheck.Location = new System.Drawing.Point(143, 132);
            this.ShowPassCheck.Name = "ShowPassCheck";
            this.ShowPassCheck.Size = new System.Drawing.Size(102, 17);
            this.ShowPassCheck.TabIndex = 8;
            this.ShowPassCheck.Text = "Show Password";
            this.ShowPassCheck.UseVisualStyleBackColor = true;
            this.ShowPassCheck.CheckedChanged += new System.EventHandler(this.ShowPassCheck_CheckedChanged);
            // 
            // InstAddBtn
            // 
            this.InstAddBtn.Enabled = false;
            this.InstAddBtn.Location = new System.Drawing.Point(12, 201);
            this.InstAddBtn.Name = "InstAddBtn";
            this.InstAddBtn.Size = new System.Drawing.Size(75, 23);
            this.InstAddBtn.TabIndex = 9;
            this.InstAddBtn.Text = "Add";
            this.InstAddBtn.UseVisualStyleBackColor = true;
            this.InstAddBtn.Click += new System.EventHandler(this.InstAddBtn_Click);
            // 
            // IdentitySelectComBox
            // 
            this.IdentitySelectComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IdentitySelectComBox.FormattingEnabled = true;
            this.IdentitySelectComBox.Location = new System.Drawing.Point(15, 27);
            this.IdentitySelectComBox.Name = "IdentitySelectComBox";
            this.IdentitySelectComBox.Size = new System.Drawing.Size(230, 21);
            this.IdentitySelectComBox.TabIndex = 2;
            this.IdentitySelectComBox.SelectedIndexChanged += new System.EventHandler(this.IdentitySelectComBox_SelectedIndexChanged);
            // 
            // InstNameLab
            // 
            this.InstNameLab.AutoSize = true;
            this.InstNameLab.Location = new System.Drawing.Point(12, 57);
            this.InstNameLab.Name = "InstNameLab";
            this.InstNameLab.Size = new System.Drawing.Size(79, 13);
            this.InstNameLab.TabIndex = 11;
            this.InstNameLab.Text = "Instance Name";
            // 
            // InstNameTextBox
            // 
            this.InstNameTextBox.Location = new System.Drawing.Point(95, 54);
            this.InstNameTextBox.Name = "InstNameTextBox";
            this.InstNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.InstNameTextBox.TabIndex = 3;
            this.InstNameTextBox.TextChanged += new System.EventHandler(this.InstAttribsTextChanged);
            // 
            // InstRemoveBtn
            // 
            this.InstRemoveBtn.Enabled = false;
            this.InstRemoveBtn.Location = new System.Drawing.Point(93, 201);
            this.InstRemoveBtn.Name = "InstRemoveBtn";
            this.InstRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.InstRemoveBtn.TabIndex = 10;
            this.InstRemoveBtn.Text = "Remove";
            this.InstRemoveBtn.UseVisualStyleBackColor = true;
            this.InstRemoveBtn.Click += new System.EventHandler(this.InstRemoveBtn_Click);
            // 
            // InstUpdateBtn
            // 
            this.InstUpdateBtn.Enabled = false;
            this.InstUpdateBtn.Location = new System.Drawing.Point(174, 201);
            this.InstUpdateBtn.Name = "InstUpdateBtn";
            this.InstUpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.InstUpdateBtn.TabIndex = 11;
            this.InstUpdateBtn.Text = "Update";
            this.InstUpdateBtn.UseVisualStyleBackColor = true;
            this.InstUpdateBtn.Click += new System.EventHandler(this.InstUpdateBtn_Click);
            // 
            // CategoriesFlowPanel
            // 
            this.CategoriesFlowPanel.Controls.Add(this.AudioCategoryBtn);
            this.CategoriesFlowPanel.Location = new System.Drawing.Point(251, 27);
            this.CategoriesFlowPanel.Name = "CategoriesFlowPanel";
            this.CategoriesFlowPanel.Size = new System.Drawing.Size(209, 281);
            this.CategoriesFlowPanel.TabIndex = 15;
            // 
            // AudioCategoryBtn
            // 
            this.AudioCategoryBtn.Location = new System.Drawing.Point(3, 3);
            this.AudioCategoryBtn.Name = "AudioCategoryBtn";
            this.AudioCategoryBtn.Size = new System.Drawing.Size(75, 23);
            this.AudioCategoryBtn.TabIndex = 0;
            this.AudioCategoryBtn.Text = "Audio";
            this.AudioCategoryBtn.UseVisualStyleBackColor = true;
            this.AudioCategoryBtn.Click += new System.EventHandler(this.AudioCategoryBtn_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(133, 230);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(116, 23);
            this.LogOutBtn.TabIndex = 16;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NormalLoginRadBtn);
            this.groupBox1.Controls.Add(this.AltLoginRadBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 63);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Type";
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MainNotifyIcon.BalloonTipText = "Click here to access it";
            this.MainNotifyIcon.BalloonTipTitle = "VK by Null is now minimized";
            this.MainNotifyIcon.ContextMenuStrip = this.NotifuIconMenu;
            this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
            this.MainNotifyIcon.Text = "VK by Null Pointer";
            this.MainNotifyIcon.Visible = true;
            this.MainNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseDoubleClick);
            // 
            // NotifuIconMenu
            // 
            this.NotifuIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.toolStripSeparator3,
            this.categoriesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.NotifuIconMenu.Name = "NotifuIconMenu";
            this.NotifuIconMenu.Size = new System.Drawing.Size(127, 82);
            this.NotifuIconMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifuIconMenu_Opening);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(123, 6);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioToolStripMenuItem});
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.audioToolStripMenuItem.Text = "Audio";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.audioToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(123, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthorizationStatusLabel});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 311);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(472, 22);
            this.MainStatusStrip.TabIndex = 18;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // AuthorizationStatusLabel
            // 
            this.AuthorizationStatusLabel.Image = global::VkByNullRemakeFormsGui.Properties.Resources.Cross_16x16;
            this.AuthorizationStatusLabel.Name = "AuthorizationStatusLabel";
            this.AuthorizationStatusLabel.Size = new System.Drawing.Size(119, 17);
            this.AuthorizationStatusLabel.Text = "Authorization: None";
            this.AuthorizationStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "nvksav";
            this.SaveFileDialog.Filter = "VK saves|*.nvksav|All Files|*.*";
            this.SaveFileDialog.RestoreDirectory = true;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "nvksav";
            this.OpenFileDialog.Filter = "VK saves|*.nvksav|All Files|*.*";
            this.OpenFileDialog.RestoreDirectory = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 333);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.CategoriesFlowPanel);
            this.Controls.Add(this.InstUpdateBtn);
            this.Controls.Add(this.InstRemoveBtn);
            this.Controls.Add(this.InstNameTextBox);
            this.Controls.Add(this.InstNameLab);
            this.Controls.Add(this.IdentitySelectComBox);
            this.Controls.Add(this.InstAddBtn);
            this.Controls.Add(this.ShowPassCheck);
            this.Controls.Add(this.LogInBtn);
            this.Controls.Add(this.PassLab);
            this.Controls.Add(this.EmailLab);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.MainWindowMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainWindowMenuStrip;
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "MainWindow";
            this.Text = "VK by Null Pointer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.MainWindowMenuStrip.ResumeLayout(false);
            this.MainWindowMenuStrip.PerformLayout();
            this.CategoriesFlowPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.NotifuIconMenu.ResumeLayout(false);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.Label EmailLab;
        private System.Windows.Forms.Label PassLab;
        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.RadioButton NormalLoginRadBtn;
        private System.Windows.Forms.RadioButton AltLoginRadBtn;
        private System.Windows.Forms.CheckBox ShowPassCheck;
        private System.Windows.Forms.Button InstAddBtn;
        private System.Windows.Forms.ComboBox IdentitySelectComBox;
        private System.Windows.Forms.Label InstNameLab;
        private System.Windows.Forms.TextBox InstNameTextBox;
        private System.Windows.Forms.Button InstRemoveBtn;
        private System.Windows.Forms.Button InstUpdateBtn;
        private System.Windows.Forms.FlowLayoutPanel CategoriesFlowPanel;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.Button AudioCategoryBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifuIconMenu;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AuthorizationStatusLabel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

