using System;

namespace NullUtilVK.Model.EventArg.Win
{
    public class SetBitrateEventArgs : EventArgs
    {
        public SetBitrateEventArgs(long Id, long OwnerId, string BitRate)
        {
            this.BitRate = BitRate;
            this.Id = Id;
            this.OwnerId = OwnerId;
        }
        public long Id;
        public long OwnerId;
        public string BitRate;
    }
}
