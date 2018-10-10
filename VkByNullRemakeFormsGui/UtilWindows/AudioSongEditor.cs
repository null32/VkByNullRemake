using NullUtilVK.Enums.SafetyEnums.VK;
using System;
using System.Windows.Forms;

namespace VkByNullRemakeFormsGui.UtilWindows
{
    public partial class AudioSongEditor : Form
    {
        public AudioSongEditor(NullUtilVK.Categories.Audio AudioApi, VkNet.Model.Attachments.Audio Audio)
        {
            InitializeComponent();
            this._AudioApi = AudioApi;
            this._Audio = Audio;
        }

        private void AudioSongEditor_Load(object sender, EventArgs e)
        {
            this.ArtistTextBox.Text = _Audio.Artist;
            this.TitleTextBox.Text = _Audio.Title;
            if (_Audio.LyricsId != null)
                this.LyricsTextBox.Text = _AudioApi.GetText(Convert.ToInt64(_Audio.LyricsId));
            foreach (var genre in AudioGenre.GetRegistered())
            {
                this.GenreComboBox.Items.Add(genre.ToString());
            }
            this.GenreComboBox.SelectedIndex = this.GenreComboBox.Items.IndexOf(AudioGenre.FromVkNet(_Audio.Genre).Name);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _AudioApi.Edit(Convert.ToInt64(_Audio.Id), Convert.ToInt64(_Audio.OwnerId), this.ArtistTextBox.Text, this.TitleTextBox.Text, AudioGenre.GetByName(this.GenreComboBox.Text), this.LyricsTextBox.Text, this.HideSearchCheck.Checked);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        NullUtilVK.Categories.Audio _AudioApi;
        VkNet.Model.Attachments.Audio _Audio;

    }
}
