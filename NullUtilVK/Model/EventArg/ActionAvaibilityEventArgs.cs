using System;

namespace NullUtilVK.Model.EventArg
{
    public class ActionAvaibilityEventArgs : EventArgs
    {
        public ActionAvaibilityEventArgs(bool NextEnabled, bool PrevEnabled)
        {
            this.NextEnabled = NextEnabled;
            this.PrevEnabled = PrevEnabled;
        }
        public bool NextEnabled;
        public bool PrevEnabled;
    }
}
