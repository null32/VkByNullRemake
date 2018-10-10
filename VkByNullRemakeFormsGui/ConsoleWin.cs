using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NullUtilVK.Enums.SafetyEnums;

namespace VkByNullRemakeFormsGui
{
    public partial class ConsoleWin : Form
    {
        public ConsoleWin()
        {
            InitializeComponent();
        }

        public event EventHandler<UserCommandEventArgs> UserCommand;

        public void WriteConsole(MessageStatus Status, string text)
        {
            if (MainRTB.InvokeRequired)
            {
                var invokedMethod = new WriteConsoleDelegate(WriteConsole);
                this.Invoke(invokedMethod, new object[] { Status, text });
                return;
            }

            //if (Status == MessageStatus.Error)
            //{
            //    MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            MainRTB.AppendText(Environment.NewLine);
            MainRTB.SelectionStart = MainRTB.TextLength;
            MainRTB.SelectionLength = 0;

            MainRTB.SelectionColor = Status.DrawColor;
            MainRTB.AppendText(text);
            MainRTB.SelectionColor = MainRTB.ForeColor;
        }

        private void SumbitBtn_Click(object sender, EventArgs e)
        {
            if (UserCommand != null)
                UserCommand(this, new UserCommandEventArgs() { CommandAndArgs = SumbitTextBox.Text });
            SumbitTextBox.Text = string.Empty;
        }

        private void ConsoleWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }

    public delegate void WriteConsoleDelegate(MessageStatus Status, string text);

    public class UserCommandEventArgs : EventArgs
    {
        public string CommandAndArgs;
    }
}
