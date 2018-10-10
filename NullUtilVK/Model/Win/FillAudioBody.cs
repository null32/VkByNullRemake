using NullUtilVK.Enums.Win;

namespace NullUtilVK.Model.Win
{
    public class FillAudioBody
    {
        public FillAudioBody() { Index = 0; Type = FillAudioType.None; }
        public FillAudioBody(int Index, FillAudioType Type, long? UserId = null, long? GroupId = null, long? AlbumId = null, string SearchQuerry = null, bool? IsArtist = null)
        {
            this.Index = Index;
            this.Type = Type;
            this.UserId = UserId;
            this.GroupId = GroupId;
            this.AlbumId = AlbumId;
            this.SearchQuerry = SearchQuerry;
            this.IsArtist = IsArtist;
        }

        public int Index;
        public FillAudioType Type;
        public long? UserId;
        public long? GroupId;
        public long? AlbumId;
        public string SearchQuerry;
        public bool? IsArtist;
    }
}
