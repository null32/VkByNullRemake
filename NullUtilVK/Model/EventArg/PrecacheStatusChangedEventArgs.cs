using NullUtilVK.Enums.Win;
using System;

namespace NullUtilVK.Model.EventArg
{
    public class PrecacheStatusChangedEventArgs : EventArgs
    {
        public PrecacheStatusChangedEventArgs(WorkerState Status)
        {
            this.Status = Status;
        }
        public WorkerState Status;
    }
}
