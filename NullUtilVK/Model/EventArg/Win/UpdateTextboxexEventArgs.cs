using System;
namespace NullUtilVK.Model.EventArg.Win
{
    public class UpdateTextboxexEventArgs : EventArgs
    {
        public UpdateTextboxexEventArgs(AuthInstance Instance, int Index)
        {
            this.Instance = Instance;
            this.SelectedIndex = Index;
        }

        public AuthInstance Instance;
        public int SelectedIndex;
    }
}
