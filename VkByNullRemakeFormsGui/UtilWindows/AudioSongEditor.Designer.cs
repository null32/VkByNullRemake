namespace VkByNullRemakeFormsGui.UtilWindows
{
    partial class AudioSongEditor
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
            this.ArtistLab = new System.Windows.Forms.Label();
            this.TitleLab = new System.Windows.Forms.Label();
            this.LyricsLab = new System.Windows.Forms.Label();
            this.ArtistTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.HideSearchCheck = new System.Windows.Forms.CheckBox();
            this.GenreComboBox = new System.Windows.Forms.ComboBox();
            this.genrelab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArtistLab
            // 
            this.ArtistLab.AutoSize = true;
            this.ArtistLab.Location = new System.Drawing.Point(12, 15);
            this.ArtistLab.Name = "ArtistLab";
            this.ArtistLab.Size = new System.Drawing.Size(30, 13);
            this.ArtistLab.TabIndex = 0;
            this.ArtistLab.Text = "Artist";
            // 
            // TitleLab
            // 
            this.TitleLab.AutoSize = true;
            this.TitleLab.Location = new System.Drawing.Point(12, 41);
            this.TitleLab.Name = "TitleLab";
            this.TitleLab.Size = new System.Drawing.Size(27, 13);
            this.TitleLab.TabIndex = 1;
            this.TitleLab.Text = "Title";
            // 
            // LyricsLab
            // 
            this.LyricsLab.AutoSize = true;
            this.LyricsLab.Location = new System.Drawing.Point(12, 94);
            this.LyricsLab.Name = "LyricsLab";
            this.LyricsLab.Size = new System.Drawing.Size(34, 13);
            this.LyricsLab.TabIndex = 2;
            this.LyricsLab.Text = "Lyrics";
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArtistTextBox.Location = new System.Drawing.Point(80, 8);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(200, 20);
            this.ArtistTextBox.TabIndex = 3;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(80, 38);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.TitleTextBox.TabIndex = 4;
            // 
            // LyricsTextBox
            // 
            this.LyricsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LyricsTextBox.Location = new System.Drawing.Point(80, 91);
            this.LyricsTextBox.Multiline = true;
            this.LyricsTextBox.Name = "LyricsTextBox";
            this.LyricsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LyricsTextBox.Size = new System.Drawing.Size(200, 118);
            this.LyricsTextBox.TabIndex = 5;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.Location = new System.Drawing.Point(124, 238);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(205, 238);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // HideSearchCheck
            // 
            this.HideSearchCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HideSearchCheck.AutoSize = true;
            this.HideSearchCheck.Location = new System.Drawing.Point(80, 215);
            this.HideSearchCheck.Name = "HideSearchCheck";
            this.HideSearchCheck.Size = new System.Drawing.Size(111, 17);
            this.HideSearchCheck.TabIndex = 8;
            this.HideSearchCheck.Text = "Hide From Search";
            this.HideSearchCheck.UseVisualStyleBackColor = true;
            // 
            // GenreComboBox
            // 
            this.GenreComboBox.FormattingEnabled = true;
            this.GenreComboBox.Location = new System.Drawing.Point(80, 64);
            this.GenreComboBox.Name = "GenreComboBox";
            this.GenreComboBox.Size = new System.Drawing.Size(200, 21);
            this.GenreComboBox.TabIndex = 9;
            // 
            // genrelab
            // 
            this.genrelab.AutoSize = true;
            this.genrelab.Location = new System.Drawing.Point(12, 67);
            this.genrelab.Name = "genrelab";
            this.genrelab.Size = new System.Drawing.Size(36, 13);
            this.genrelab.TabIndex = 10;
            this.genrelab.Text = "Genre";
            // 
            // AudioSongEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.genrelab);
            this.Controls.Add(this.GenreComboBox);
            this.Controls.Add(this.HideSearchCheck);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.LyricsTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.ArtistTextBox);
            this.Controls.Add(this.LyricsLab);
            this.Controls.Add(this.TitleLab);
            this.Controls.Add(this.ArtistLab);
            this.Icon = global::VkByNullRemakeFormsGui.Properties.Resources.TempIcon_snd_edit;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "AudioSongEditor";
            this.Text = "Editing Audio";
            this.Load += new System.EventHandler(this.AudioSongEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ArtistLab;
        private System.Windows.Forms.Label TitleLab;
        private System.Windows.Forms.Label LyricsLab;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox LyricsTextBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox HideSearchCheck;
        private System.Windows.Forms.ComboBox GenreComboBox;
        private System.Windows.Forms.Label genrelab;
    }
}