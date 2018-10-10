using NullUtilVK.Model.Win;
using System.Collections.Generic;

namespace NullUtilVK.Enums.Win
{
    public class AudioTabPageBody
    {
        public AudioTabPageBody()
        {
            LastAudioAction= new FillAudioBody();
            PlayList = new List<VkNet.Model.Attachments.Audio>();
            AlbumList = new List<VkNet.Model.AudioAlbum>();
        }

        public FillAudioBody LastAudioAction;
        public List<VkNet.Model.Attachments.Audio> PlayList;
        public List<VkNet.Model.AudioAlbum> AlbumList;
        public int TotalAudios;
        public VkNet.Model.User User;
        public VkNet.Model.Group Group;
        public int? LastPlayingSongIndex;
    }
}
