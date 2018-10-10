using System;

namespace NullUtilVK.Model.EventArg.Win
{
    public class TabRemoveEventArgs : EventArgs
    {
        public TabRemoveEventArgs(int Index)
        {
            this.Index = Index;
        }
        public int Index;
    }
}
