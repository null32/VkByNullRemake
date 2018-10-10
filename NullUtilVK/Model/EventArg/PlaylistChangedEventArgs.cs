using NullUtilVK.Enums;
using System;
using System.Collections.Generic;

namespace NullUtilVK.Model.EventArg
{
    public class PlaylistChangedEventArgs : EventArgs
    {
        public PlaylistChangedEventArgs(PlaylistChangeType Type, List<KeyValuePair<int, VkNet.Model.Attachments.Audio>> Audios)
        {
            this.Type = Type;
            this.ChangedItems = Audios;
        }

        public PlaylistChangeType Type;
        public List<KeyValuePair<int, VkNet.Model.Attachments.Audio>> ChangedItems;
    }
}
