using System;
using System.Linq;
using System.Text;
using NullUtilVK.Enums.SafetyEnums;

namespace NullUtilVK.Categories
{
    public partial class Audio
    {
        internal void Help(string Arg)
        {
            if (String.IsNullOrEmpty(Arg))
            {
                this.Log(MessageStatus.Info, LogStrings.Help.Audio.General);
                return;
            }
            if (AudioCommands.GetCommands().Where(c => c.Alias == Arg.ToLower()).Count() > 0)
            {
                var item = AudioCommands.GetCommands().Where(c => c.Alias == Arg.ToLower()).First();
                this.Log(MessageStatus.Info, "Usage: " + item.Alias + " " + item.Info + Environment.NewLine + item.Help);
                return;
            }
            this.Log(MessageStatus.Error, LogStrings.Error.General.UnknownCommand + Arg);
        }

        internal void ConCount(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("count");
                return;
            }
            
            if (String.IsNullOrEmpty(Arg))
            {
                Count();
                return;
            }
            long? UserId = TryConvertLong(Arg);
            if (UserId == null)
                return;
            Count(UserId);
        }

        internal void ConGet(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("get");
                return;
            }
            var args = Arg.Split(' ');
            if (args.Length < 2)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidUsage);
                return;
            }

            long? Id = null;
            if (args[0] == "_")
                Id = null;
            else
            {
                Id = TryConvertLong(args[0]);
                if (Id == null)
                    return;
            }
            int? count = TryConvertInt(args[1]);
            if (count == null)
                return;
            int? offset = null;
            if (args.Length > 2 && args[2] != "_")
            {
                offset = TryConvertInt(args[2]);
                if (offset == null)
                    return;
            }

            Get(Id, null, count, offset);
        }

        internal void ConSearch(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("search");
                return;
            }
            if (Arg == string.Empty)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidUsage);
                return;
            }

            Search(Arg, Count: 100);
        }

        internal void ConFullInfo(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("info");
                return;
            }

            var args = Arg.Split(' ');
            int? index = 0;
            long? audioId = 0;
            long? ownerId = 0;
            VkNet.Model.Attachments.Audio audio;
            if (args.Length == 1)
            {
                index = TryConvertInt(args[0]);
                if (index == null)
                    return;
                if (_LastAudioList == null)
                {
                    this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                    return;
                }
                if (index > _LastAudioList.Count)
                {
                    this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + _LastAudioList.Count + ")");
                    return;
                }
                audio = _LastAudioList[(int)index];
            }
            else
            {
                audioId = TryConvertInt(args[0]);
                if (audioId == null)
                    return;
                ownerId = TryConvertLong(args[1]);
                if (ownerId == null)
                    return;
                audio = GetById((long)ownerId, (long)audioId);
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("Artist");
            sb.Append(" - ");
            sb.Append("Title");
            sb.Append(" - ");
            sb.Append("Duration");
            sb.Append(" - ");
            sb.Append("Genre");
            sb.Append(" - ");
            sb.Append("Audio Id");
            sb.Append(" - ");
            sb.Append("Owner Id");
            sb.Append(" - ");
            sb.Append("Url");
            sb.Append(Environment.NewLine);
            sb.Append(audio.Artist);
            sb.Append(" - ");
            sb.Append(audio.Title);
            sb.Append(" - ");
            sb.Append(this.SecToTime(audio.Duration));
            sb.Append(" - ");
            if (audio.Genre == null)
                sb.Append("No genre");
            else
                sb.Append(audio.Genre);
            sb.Append(" - ");
            sb.Append(audio.Id);
            sb.Append(" - ");
            sb.Append(audio.OwnerId);
            sb.Append(" - ");
            sb.Append(audio.Url.ToString().Split('?')[0]);

            this.Log(MessageStatus.Info, sb.ToString());
        }

        internal void ConGetAlbums(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("albums");
                return;
            }
            if (Arg == string.Empty)
            {
                GetAlbums();
                return;
            }
            var splitted = Arg.Split(' ');
            long? UserId = null;
            UserId = TryConvertLong(splitted[0]);
            if (UserId == null)
                return;
            GetAlbums(UserId);
        }

        internal void ConAdd(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("add");
                return;
            }

            var args = Arg.Split(' ');
            int? index = 0;
            long? audioId = 0;
            long? ownerId = 0;
            VkNet.Model.Attachments.Audio audio;
            if (args.Length == 1)
            {
                index = TryConvertInt(args[0]);
                if (index == null)
                    return;
                if (_LastAudioList == null)
                    this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                if (index > _LastAudioList.Count)
                    this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + _LastAudioList.Count + ")");
                audio = _LastAudioList[(int)index];
            }
            else
            {
                audioId = TryConvertInt(args[0]);
                if (audioId == null)
                    return;
                ownerId = TryConvertLong(args[1]);
                if (ownerId == null)
                    return;
                audio = GetById((long)ownerId, (long)audioId);
            }

            Add(audio);
        }

        internal void ConDelete(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("delete");
                return;
            }

            var args = Arg.Split(' ');
            int? index = 0;
            long? audioId = 0;
            long? ownerId = 0;
            VkNet.Model.Attachments.Audio audio;
            if (args.Length == 1)
            {
                index = TryConvertInt(args[0]);
                if (index == null)
                    return;
                if (_LastAudioList == null)
                    this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                if (index > _LastAudioList.Count)
                    this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + _LastAudioList.Count + ")");
                audio = _LastAudioList[(int)index];
            }
            else
            {
                audioId = TryConvertInt(args[0]);
                if (audioId == null)
                    return;
                ownerId = TryConvertLong(args[1]);
                if (ownerId == null)
                    return;
                audio = GetById((long)ownerId, (long)audioId);
            }
            if (audio.OwnerId != this.UserId)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Audio.Delete);
                return;
            }
            Delete(audio);
        }

        internal void ConDownload(string Arg)
        {
            if (Arg == "?" || Arg == "help")
            {
                Help("download");
                return;
            }

            var args = Arg.Split(' ');
            int? index = 0;
            long? audioId = 0;
            long? ownerId = 0;
            VkNet.Model.Attachments.Audio audio;
            if (args.Length == 1)
            {
                index = TryConvertInt(args[0]);
                if (index == null)
                    return;
                if (_LastAudioList == null)
                    this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                if (index > _LastAudioList.Count)
                    this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + _LastAudioList.Count + ")");
                audio = _LastAudioList[(int)index];
            }
            else
            {
                audioId = TryConvertInt(args[0]);
                if (audioId == null)
                    return;
                ownerId = TryConvertLong(args[1]);
                if (ownerId == null)
                    return;
                audio = GetById((long)ownerId, (long)audioId);
            }

            Download(audio);
        }

        internal int? TryConvertInt(string Value)
        {
            try
            {
                return Convert.ToInt32(Value);
            }
            catch (System.FormatException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Value);
            }
            catch (System.OverflowException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Value);
            }
            return null;
        }

        internal long? TryConvertLong(string Value)
        {
            try
            {
                return Convert.ToInt64(Value);
            }
            catch (System.FormatException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Value);
            }
            catch (System.OverflowException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Value);
            }
            return null;
        }
    }
}
