using System;
using System.Windows.Forms;

namespace NullUtilVK.Model.EventArg.Win
{
    public class ShowMBoxEventArgs : EventArgs
    {
        public ShowMBoxEventArgs(string Text, string Caption, MessageBoxIcon Icon, MessageBoxButtons Buttons)
        {
            this.Text = Text;
            this.Caption = Caption;
            this.Icon = Icon;
            this.Buttons = Buttons;
        }

        public string Text;
        public string Caption;
        public MessageBoxIcon Icon;
        public MessageBoxButtons Buttons;
    }
}
