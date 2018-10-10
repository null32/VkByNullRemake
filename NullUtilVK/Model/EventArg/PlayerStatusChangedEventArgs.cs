using NullUtilVK.Enums;
using System;

namespace NullUtilVK.Model.EventArg
{
    public class PlayerStatusChangedEventArgs : EventArgs
    {
        public PlayerStatusChangedEventArgs(PlaybackStatus status)
        {
            this.NewStatus = status;
        }
        public PlaybackStatus NewStatus;
    }
}
