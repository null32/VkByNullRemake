using NullUtilVK.Enums.Win;
using System.Collections.Generic;
using System;

namespace NullUtilVK.Model.EventArg.Win
{
    public class FillAudioListEventArgs : EventArgs
    {
        public FillAudioListEventArgs(AudioTabPageBody TabPageBody, int StartIndex, Dictionary<int, string> KnownBitrate = null)
        {
            this.TabPageBody = TabPageBody;
            this.StartIndex = StartIndex;
            this.KnownBitrate = KnownBitrate;
        }

        public AudioTabPageBody TabPageBody;
        public int StartIndex;
        public Dictionary<int, string> KnownBitrate;
    }
}
