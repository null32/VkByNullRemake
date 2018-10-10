using NullUtilVK;
using NullUtilVK.Enums.SafetyEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkByNullRemakeFormsGui.UtilWindows
{
    public partial class Options : Form
    {
        public Options(NullUtilVk MainApi)
        {
            this.MainApi = MainApi;
            InitializeComponent();
        }

        NullUtilVk MainApi;
        List<KeyValuePair<ConfigDefault, object>> NewConfig;

        private void Options_Load(object sender, EventArgs e)
        {
            NewConfig = new List<KeyValuePair<ConfigDefault, object>>();

            OpenLangFileDialog.InitialDirectory = Environment.CurrentDirectory;

            var page = this.MainTabs.TabPages[1];
            page.AutoScroll = true;
            page.AutoScrollMargin = new Size(20, 20);
            page.AutoScrollMinSize = new Size(page.Width, page.Height);
            CalculateCacheSize();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in NewConfig)
            {
                MainApi.Config.SetValue(item.Key, item.Value);
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            NewConfig.Clear();
            this.Close();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in NewConfig)
            {
                MainApi.Config.SetValue(item.Key, item.Value);
            }
            MainApi.Config.WriteConfigToFile();
            this.ApplyBtn.Enabled = false;
        }

        #region General Tab

        private void GeneralLangPathBtn_Click(object sender, EventArgs e)
        {
            if (OpenLangFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!MainApi.Config.IsLangFileOk(OpenLangFileDialog.FileName))
                    return;
                this.GeneralLangTextBox.Text = OpenLangFileDialog.FileName;
            }
        }

        private void GeneralLangPathTextBox_TextChanged(object sender, EventArgs e)
        {
            AddNewConfig(ConfigDefault.LangFilePath, GeneralLangPathTextBox.Text);
        }

        #endregion

        #region Audio Tab

        private void AudioLimitCacheCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.AudioMaxCacheLab.Enabled = this.AudioLimitCacheCheck.Checked;
            this.AudioMaxCacheTextBox.Enabled = this.AudioLimitCacheCheck.Checked;
            AddNewConfig(ConfigDefault.AudioLimitCache, AudioLimitCacheCheck.Checked);
        }

        private void AudioOpenAudioPathBtn_Click(object sender, EventArgs e)
        {
            if (OpenAudioDownFileDiaolog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.AudioDownPathTextBox.Text = OpenAudioDownFileDiaolog.SelectedPath;
            }
        }

        private void AudioDownPathTextBox_TextChanged(object sender, EventArgs e)
        {
            AddNewConfig(ConfigDefault.AudioDownloadDir, AudioDownPathTextBox.Text);
        }

        private void AudioVolumeTextBox_ValueChanged(object sender, EventArgs e)
        {
            AddNewConfig(ConfigDefault.AudioPlayerVolume, AudioVolumeTextBox.Value);
        }

        private void AudioPrecacheStepTextBox_ValueChanged(object sender, EventArgs e)
        {
            AddNewConfig(ConfigDefault.AudioPrecacheStep, AudioPrecacheStepTextBox.Value);
        }

        private void AudioMaxCacheLabTextBox_ValueChanged(object sender, EventArgs e)
        {
            AddNewConfig(ConfigDefault.AudioMaxCacheSizeMB, AudioMaxCacheTextBox.Value);
        }

        private void AudioListDefColorAny_ValueChanged(object sender, EventArgs e)
        {
            AudioDefColorPreview.BackColor = Color.FromArgb(
                Convert.ToInt32(AudioListDefColorR.Value),
                Convert.ToInt32(AudioListDefColorG.Value),
                Convert.ToInt32(AudioListDefColorB.Value));
            AddNewConfig(ConfigDefault.AudioGuiListDefaultColor, new int[]
            {
                Convert.ToInt32(AudioListDefColorR.Value), 
                Convert.ToInt32(AudioListDefColorG.Value), 
                Convert.ToInt32(AudioListDefColorB.Value) 
            });
        }

        private void AudioListPlayColorAny_ValueChanged(object sender, EventArgs e)
        {
            AudioPlayColorPreview.BackColor = Color.FromArgb(
                Convert.ToInt32(AudioListPlayColorR.Value),
                Convert.ToInt32(AudioListPlayColorG.Value),
                Convert.ToInt32(AudioListPlayColorB.Value));
            AddNewConfig(ConfigDefault.AudioGuiListPlayingColor, new int[]
            {
                Convert.ToInt32(AudioListPlayColorR.Value), 
                Convert.ToInt32(AudioListPlayColorG.Value), 
                Convert.ToInt32(AudioListPlayColorB.Value) 
            });
        }

        private async void ClearCacheBtn_Click(object sender, EventArgs e)
        {
            this.AudioClearCacheBtn.Enabled = false;
            MessageBox.Show("Cache will be cleaned in background", "Cache Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainApi.ClientLog(LogStrings.Info.Audio.CacheCleanStarted);

            await Task.Run(() =>
            {
                foreach (var item in MainApi.DB.Select(DBTable.Audio, MainApi.Audio.CacheCount()))
                {
                    MainApi.Audio.DeleteFromCache(Convert.ToInt32((item as object[])[0]));
                }
            });

            MainApi.ClientLog(LogStrings.Info.Audio.CacheCleanFinished);
            this.AudioClearCacheBtn.Enabled = true;
            CalculateCacheSize();
        }

        private async void CalculateCacheSize()
        {
            await Task.Run(() =>
                {
                    var sizeStr = string.Empty;
                    var sizeMb = Convert.ToDouble(MainApi.Audio.CacheSize()) / 1024 / 1024;
                    sizeStr = sizeMb > 1024 ? string.Format("{0:0.#}Gb", sizeMb / 1024) : string.Format("{0:0.#}Mb", sizeMb);
                    UpdateCacheSize(sizeStr);
                });
        }
        private void UpdateCacheSize(string value)
        {
            if (this.AudioCacheSize.InvokeRequired)
            {
                var invokedMethod = new AudioUpdateCacheSize(UpdateCacheSize);
                this.AudioCacheSize.Invoke(invokedMethod, value);
                return;
            }
            this.AudioCacheSize.Text = value;
        }

        #endregion

        void AddNewConfig(ConfigDefault Config, object Value)
        {
            var item = NewConfig.FirstOrDefault(c => c.Key.Key == Config.Key);
            if (item.Value != null)
                NewConfig.Remove(item);
            NewConfig.Add(new KeyValuePair<ConfigDefault, object>(Config, Convert.ChangeType(Value, Config.ValueType)));
            this.ApplyBtn.Enabled = true;
        }

        private void Options_VisibleChanged(object sender, EventArgs e)
        {
            #region General
            this.GeneralLangTextBox.Text = MainApi.Config.GetValue(ConfigDefault.Lang) as string;
            this.GeneralLangPathTextBox.Text = MainApi.Config.GetValue(ConfigDefault.LangFilePath) as string;
            #endregion

            #region Audio
            this.AudioDownPathTextBox.Text = MainApi.Config.GetValue(ConfigDefault.AudioDownloadDir) as string;
            this.AudioVolumeTextBox.Value = Convert.ToDecimal(MainApi.Config.GetValue(ConfigDefault.AudioPlayerVolume));
            this.AudioPrecacheStepTextBox.Value = Convert.ToDecimal(MainApi.Config.GetValue(ConfigDefault.AudioPrecacheStep));
            this.AudioLimitCacheCheck.Checked = (bool)MainApi.Config.GetValue(ConfigDefault.AudioLimitCache);
            this.AudioMaxCacheTextBox.Value = Convert.ToDecimal(MainApi.Config.GetValue(ConfigDefault.AudioMaxCacheSizeMB));
            int[] defColor = MainApi.Config.GetValue(ConfigDefault.AudioGuiListDefaultColor) as int[];
            int[] playColor = MainApi.Config.GetValue(ConfigDefault.AudioGuiListPlayingColor) as int[];

            this.AudioListDefColorR.Value = Convert.ToDecimal(defColor[0]);
            this.AudioListDefColorG.Value = Convert.ToDecimal(defColor[1]);
            this.AudioListDefColorB.Value = Convert.ToDecimal(defColor[2]);

            this.AudioListPlayColorR.Value = Convert.ToDecimal(playColor[0]);
            this.AudioListPlayColorG.Value = Convert.ToDecimal(playColor[1]);
            this.AudioListPlayColorB.Value = Convert.ToDecimal(playColor[2]);
            #endregion
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
    delegate void AudioUpdateCacheSize(string value);
}
