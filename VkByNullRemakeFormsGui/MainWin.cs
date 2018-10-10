using NullUtilVK;
using NullUtilVK.Enums.Win;
using NullUtilVK.Model;
using NullUtilVK.Model.EventArg.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkByNullRemakeFormsGui.Categories;
using VkByNullRemakeFormsGui.UtilWindows;

namespace VkByNullRemakeFormsGui
{
    public partial class MainWindow : Form, ISavable
    {
        NullUtilVk MainApi;
        ConsoleWin ConsoleWindow;
        bool MinimizedToolTipShown = false;

        Dictionary<string, ISavable> Savable;
        string LastSavePath;

        #region
        Audio AudioWin;

        Options OptionsWin;
        #endregion

        public MainWindow()
        {
            Savable = new Dictionary<string, ISavable>();
            Savable.Add("main_win", this);

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MainWindow_Resize(this, EventArgs.Empty);

            ConsoleWindow = new ConsoleWin();
#warning Kostil
            ConsoleWindow.Show();
            ConsoleWindow.Hide();
            //Making console output method
            MainApi = new NullUtilVk(ConsoleWindow.WriteConsole, true);

            MainApi.MainWin.ShowMBox += MainWin_ShowMBox;
            MainApi.MainWin.UpdateInstanceList += MainWin_UpdateInstanceList;
            MainApi.MainWin.UpdateOnLogin += MainWin_UpdateOnLogin;
            MainApi.MainWin.UpdateTextboxex += MainWin_UpdateTextboxex;
            //Event to handle console user input
            ConsoleWindow.UserCommand += HandleUserCommand;

            AudioWin = new Audio(MainApi);
            Savable.Add("audio_win", AudioWin);

            MainApi.MainWin.LoadAuthInstances();
            MainApi.MainWin.CheckAuthorization();
        }

        void MainWin_UpdateTextboxex(object sender, UpdateTextboxexEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new UpdateTextboxex(MainWin_UpdateTextboxex);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            this.InstNameTextBox.Text = e.Instance.Name;
            this.EmailTextBox.Text = e.Instance.EmailOrAccKey;
            this.PassTextBox.Text = e.Instance.PassOrId;
            if (e.Instance.IsNormal)
                NormalLoginRadBtn.Checked = true;
            else
                AltLoginRadBtn.Checked = true;
        }

        void MainWin_UpdateOnLogin(object sender, UpdateOnLoginEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new UpdateOnLogin(MainWin_UpdateOnLogin);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            this.CategoriesFlowPanel.Enabled = e.IsLoggedIn;
            if (e.IsLoggedIn)
            {
                this.LogInBtn.Enabled = false;
                this.LogOutBtn.Enabled = true;
            }
            else
            {
                this.LogInBtn.Enabled =
                    !string.IsNullOrEmpty(this.EmailTextBox.Text) &&
                    !string.IsNullOrEmpty(this.PassTextBox.Text);
                this.LogOutBtn.Enabled = false;
            }
            this.AuthorizationStatusLabel.Text = e.AuthorizerText;
            switch (e.AuthorizerStatus)
            {
                case WorkerState.None:
                    this.AuthorizationStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Cross_16x16;
                    break;
                case WorkerState.Working:
                    this.AuthorizationStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Loading_16x16;
                    this.LogInBtn.Enabled = false;
                    this.LogOutBtn.Enabled = false;
                    break;
                case WorkerState.Done:
                    this.AuthorizationStatusLabel.Image = VkByNullRemakeFormsGui.Properties.Resources.Check_16x16;
                    break;
            }
        }

        void MainWin_UpdateInstanceList(object sender, UpdateInstancesEventArgs e)
        {
            if (this.InvokeRequired)
            {
                var invokedMethod = new UpdateInstances(MainWin_UpdateInstanceList);
                this.Invoke(invokedMethod, sender, e);
                return;
            }
            this.IdentitySelectComBox.Items.Clear();
            if (e.Instances.Count == 0)
            {
                this.IdentitySelectComBox.Items.Add("(new)");
                this.IdentitySelectComBox.SelectedIndex = 0;
            }
            else
            {
                foreach (var item in e.Instances)
                {
                    this.IdentitySelectComBox.Items.Add(item.Name);
                }
                this.IdentitySelectComBox.SelectedIndex = e.SelectedIndex;
            }
        }

        void MainWin_ShowMBox(object sender, ShowMBoxEventArgs e)
        {
            MessageBox.Show(e.Text, e.Caption, e.Buttons, e.Icon);
        }



        //File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Console input handler
        private void HandleUserCommand(object sender, UserCommandEventArgs e)
        {
            MainApi.RawCommand(e.CommandAndArgs);
        }
        //Login: Normal <-> Alt
        private void LoginMethodChanged(object sender, EventArgs e)
        {
            this.NormalLoginRadBtn.Checked = !this.AltLoginRadBtn.Checked;
            if (AltLoginRadBtn.Checked)
            {
                EmailLab.Text = "Access Key";
                PassLab.Text = "User ID";
                ShowPassCheck.Enabled = false;
                PassTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                EmailLab.Text = "Email/Phone";
                PassLab.Text = "Password";
                ShowPassCheck.Enabled = true;
                PassTextBox.UseSystemPasswordChar = !ShowPassCheck.Checked;
            }
        }
        //Checking for fields' input
        private void InstAttribsTextChanged(object sender, EventArgs e)
        {
            if (!MainApi.IsAuthorize)
            {
                this.LogInBtn.Enabled = 
                    !string.IsNullOrEmpty(this.EmailTextBox.Text) &&
                    !string.IsNullOrEmpty(this.PassTextBox.Text);
            }
            this.InstAddBtn.Enabled =
                !string.IsNullOrEmpty(this.EmailTextBox.Text) &&
                !string.IsNullOrEmpty(this.PassTextBox.Text) &&
                !string.IsNullOrEmpty(this.InstNameTextBox.Text);
            this.InstUpdateBtn.Enabled =
                !string.IsNullOrEmpty(this.EmailTextBox.Text) &&
                !string.IsNullOrEmpty(this.PassTextBox.Text) &&
                !string.IsNullOrEmpty(this.InstNameTextBox.Text) &&
                (string)this.IdentitySelectComBox.SelectedItem == this.InstNameTextBox.Text;
            this.InstRemoveBtn.Enabled = this.IdentitySelectComBox.Items.Count > 0 && (string)this.IdentitySelectComBox.SelectedItem != "(new)";
        }
        //Show pass switch
        private void ShowPassCheck_CheckedChanged(object sender, EventArgs e)
        {
            PassTextBox.UseSystemPasswordChar = !ShowPassCheck.Checked;
        }
        //Selected identity changed
        private void IdentitySelectComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainApi.MainWin.SelectAuthInstance(IdentitySelectComBox.SelectedIndex);
        }
        //Inst Add
        private void InstAddBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.InstAdd(new AuthInstance(this.InstNameLab.Text, this.EmailTextBox.Text, this.PassTextBox.Text, this.NormalLoginRadBtn.Checked));
        }
        //Inst Del
        private void InstRemoveBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.InstDel(new AuthInstance(this.InstNameLab.Text, this.EmailTextBox.Text, this.PassTextBox.Text, this.NormalLoginRadBtn.Checked));
        }
        //Inst Upd
        private void InstUpdateBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.InstUpd(new AuthInstance(this.InstNameLab.Text, this.EmailTextBox.Text, this.PassTextBox.Text, this.NormalLoginRadBtn.Checked));
        }
        //Tools -> Console
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsoleWindow.Show();
            ConsoleWindow.BringToFront();
        }
        //Categories -> Audio
        private void AudioCategoryBtn_Click(object sender, EventArgs e)
        {
            AudioWin.ShowContent();
            AudioWin.WindowState = FormWindowState.Normal;
            AudioWin.BringToFront();
        }
        //Log in
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.Login(new AuthInstance(this.InstNameLab.Text, this.EmailTextBox.Text, this.PassTextBox.Text, this.NormalLoginRadBtn.Checked));
        }
        //Log out
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            MainApi.MainWin.Logout();
        }
        //Before this closes
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AudioWin != null)
                AudioWin.SaveState();
            foreach (var item in Savable)
            {
                var mda = item.Value;
                (mda as Form).Hide();
            }
            this.Hide();
            MainApi.Dispose();
        }
        //Icon -> Exit
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Icon -> Categories -> Audio
        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioWin.ShowContent();
            AudioWin.WindowState = FormWindowState.Normal;
            AudioWin.BringToFront();
        }
        //Icon's Menu
        private void NotifuIconMenu_Opening(object sender, CancelEventArgs e)
        {
            categoriesToolStripMenuItem.Enabled = MainApi.IsAuthorize;
        }
        //Action on window resizing
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MainNotifyIcon.Visible = true;
                if (!MinimizedToolTipShown)
                {
                    MainNotifyIcon.ShowBalloonTip(500);
                    MinimizedToolTipShown = true;
                }
                this.Hide();
                _IsHidden = true;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                MainNotifyIcon.Visible = false;
                _IsHidden = false;
            }
        }
        //Icon -> Restore
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        //same
        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        //Tools -> Options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OptionsWin == null)
                OptionsWin = new Options(MainApi);
            OptionsWin.Show();
            OptionsWin.BringToFront();
        }
        //File -> Save
        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastSavePath != null)
            {
                var ValuesToSave = new Dictionary<string, object>();
                foreach (var pair in Savable)
                {
                    ValuesToSave.Add(pair.Key, (pair.Value as ISavable).SaveInst());
                }
                Stream FileStream = File.OpenWrite(LastSavePath);
                await MainApi.Config.Save(ValuesToSave, FileStream);
                FileStream.Close();
            }
            else
            {
                saveAsToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }
        //File -> Save As
        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var ValuesToSave = new Dictionary<string, IDictionary<string, object>>();
            var ValuesToSave = new Dictionary<string, object>();

            foreach (var pair in Savable)
            {
                ValuesToSave.Add(pair.Key, (pair.Value as ISavable).SaveInst());
            }
            SaveFileDialog.InitialDirectory = LastSavePath == null ? Environment.CurrentDirectory : LastSavePath;

            if (SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Stream FileStream;
                if ((FileStream = SaveFileDialog.OpenFile()) != null)
                {
                    await MainApi.Config.Save(ValuesToSave, FileStream);
                    FileStream.Close();
                }
            }
            LastSavePath = SaveFileDialog.FileName;
        }
        //File -> Open
        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openToolStripMenuItem.Enabled = false;
            OpenFileDialog.InitialDirectory = LastSavePath == null ? Environment.CurrentDirectory : LastSavePath;
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var Props = MainApi.Config.Load(OpenFileDialog.FileName);
                (this as ISavable).LoadInst(Props["main_win"] as Castable);
                await Task.Run(() =>
                    {
                        while (!MainApi.IsAuthorize) ;
                    });
                foreach (var pair in (Dictionary<string, Castable>)Props)
                {
                    if (pair.Key == "main_win")
                        continue;
                    if (pair.Value["is_hidden"] == false)
                        (Savable[pair.Key] as Form).Show();

                    Savable[pair.Key].LoadInst(pair.Value);
                }
            }
            this.openToolStripMenuItem.Enabled = true;
        }
        //File -> New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region ISavable
        public IDictionary<string, object> SaveInst()
        {
            var Values = new Dictionary<string, object>();

            Values.Add("is_hidden", (this as ISavable).IsHidden);
            Values.Add("width", (this as ISavable).WidthI);
            Values.Add("height", (this as ISavable).HeightI);
            Values.Add("pos_x", (this as ISavable).PosX);
            Values.Add("pos_y", (this as ISavable).PosY);

            Values.Add("login", MainApi.IsAuthorize);
            if (MainApi.IsAuthorize)
            {
                Values.Add("is_normal", MainApi.AuthCreds.IsNormal);
                Values.Add("email_or_key", MainApi.AuthCreds.EmailOrAccKey);
                Values.Add("pass_or_id", MainApi.AuthCreds.PassOrId);
            }

            return Values;
        }

        public void LoadInst(Castable values)
        {
            if (values["is_hidden"])
                this.WindowState = FormWindowState.Minimized;
            else
                this.WindowState = FormWindowState.Normal;
            this.Width = values["width"];
            this.Height = values["height"];
            this.Left = values["pos_x"];
            this.Top = values["pos_y"];

            if (values["login"])
            {
                MainApi.MainWin.Login(new AuthInstance()
                {
                    IsNormal = values["is_normal"],
                    EmailOrAccKey = values["email_or_key"], 
                    PassOrId = values["pass_or_id"]
                });
            }
        }

        public bool IsHidden
        {
            get { return _IsHidden; }
        }
        bool _IsHidden;
        public FormWindowState FormState
        {
            get { return this.WindowState; }
        }
        public int WidthI
        {
            get { return this.Width; }
        }
        public int HeightI
        {
            get { return this.Height; }
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
    }
    //For form's stuff updating
    delegate void UpdateInstances(object sender, UpdateInstancesEventArgs e);
    delegate void UpdateOnLogin(object sender, UpdateOnLoginEventArgs e);
    delegate void UpdateTextboxex(object sender, UpdateTextboxexEventArgs e);
}
