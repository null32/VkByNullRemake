using NullUtilVK.Enums.SafetyEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories
{
    public partial class AudioPlayer
    {
        internal void Help(string Arg)
        {
            if (String.IsNullOrEmpty(Arg))
            {
                this.Log(MessageStatus.Info, LogStrings.Help.Audio.Player.General);
                return;
            }
            if (PlayerCommands.GetCommands().Where(c => c.Alias == Arg.ToLower()).Count() > 0)
            {
                var item = PlayerCommands.GetCommands().Where(c => c.Alias == Arg.ToLower()).First();
                this.Log(MessageStatus.Info, "Usage: " + item.Alias + " " + item.Info + Environment.NewLine + item.Help);
                return;
            }
            this.Log(MessageStatus.Error, LogStrings.Error.General.UnknownCommand + Arg);
        }

        internal void ConPlay(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("play");
                return;
            }
            Play(TryConvertInt(Arg));
        }

        internal void ConNext(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("next");
                return;
            }
            Next();
        }
        internal void ConPrev(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("prev");
                return;
            }
            Prev();
        }
        internal void ConPause(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("pause");
                return;
            }
            Pause();
        }
        internal void ConResume(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("resume");
                return;
            }
            Resume();
        }
        internal void ConStop(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("stop");
                return;
            }
            Stop();
        }

        internal void ConAddToPlaylist(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("listadd");
                return;
            }
            if (Arg == "all")
            {
                AddToPlaylist(GetLastAudioList());
                return;
            }
            List<string> Values = new List<string>();
            if (Arg.Contains(','))
            {
                foreach (var item in Arg.Split(','))
                {
                    Values.Add(item);
                }
            }
            else
            {
                Values.Add(Arg);
            }
            List<VkNet.Model.Attachments.Audio> audios = new List<VkNet.Model.Attachments.Audio>();
            foreach (var audioItem in Values)
            {
                var args = audioItem.Split(' ');
                int? index = 0;
                long? audioId = 0;
                long? ownerId = 0;
                VkNet.Model.Attachments.Audio audio;
                if (args.Length == 1)
                {
                    index = TryConvertInt(args[0]);
                    if (index == null)
                        return;
                    if (GetLastAudioList() == null)
                        this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                    if (index > GetLastAudioList().Count)
                        this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + GetLastAudioList().Count + ")");
                    audio = GetLastAudioList()[(int)index];
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
                audios.Add(audio);
            }
            AddToPlaylist(audios);
        }

        internal void ConDelFromPlaylist(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("listdel");
                return;
            }
            if (Arg == "all")
            {
                ClearPlaylist();
                return;
            }
            List<string> Values = new List<string>();
            if (Arg.Contains(','))
            {
                foreach (var item in Arg.Split(','))
                {
                    Values.Add(item);
                }
            }
            else
            {
                Values.Add(Arg);
            }
            List<VkNet.Model.Attachments.Audio> audios = new List<VkNet.Model.Attachments.Audio>();
            foreach (var audioItem in Values)
            {
                var args = audioItem.Split(' ');
                int? index = 0;
                long? audioId = 0;
                long? ownerId = 0;
                VkNet.Model.Attachments.Audio audio;
                if (args.Length == 1)
                {
                    index = TryConvertInt(args[0]);
                    if (index == null)
                        return;
                    if (GetLastAudioList() == null)
                        this.Log(MessageStatus.Error, LogStrings.Error.Audio.ListUndefined);
                    if (index > GetLastAudioList().Count)
                        this.Log(MessageStatus.Error, LogStrings.Error.General.IndefOutOfBounds + " [" + index + "] & (" + GetLastAudioList().Count + ")");
                    audio = GetLastAudioList()[(int)index];
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
                audios.Add(audio);
            }
            RemoveFromPlaylist(audios);
        }

        internal void ConVolume(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("volume");
                return;
            }
            double volume;
            try
            {
                volume = Convert.ToDouble(Arg);
            }
            catch (System.FormatException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Arg);
                return;
            }
            catch (System.OverflowException)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + Arg);
                return;
            }
            Volume = volume;
        }

        internal void ConShowPL(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("listshow");
                return;
            }
            if (_PlayList == null)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Audio.Player.EmptyPlaylist);
                return;
            }
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var audio in _PlayList)
            {
                sb.Append(Environment.NewLine);
                sb.Append(i + ".");
                sb.Append(audio.Artist);
                sb.Append(" - ");
                sb.Append(audio.Title);
                sb.Append(" - ");
                sb.Append(this.SecToTime(audio.Duration));
                i++;
            }
            if (sb.ToString() == string.Empty)
                this.Log(MessageStatus.Info, LogStrings.Error.Audio.Player.EmptyPlaylist);
            else
                this.Log(MessageStatus.Info, sb.ToString().Remove(0, Environment.NewLine.Length));
        }

        internal void ConShufflePL(string Arg)
        {
            if (Arg == "help" || Arg == "?")
            {
                Help("listshuffle");
                return;
            }
            if (_PlayList == null)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Audio.Player.EmptyPlaylist);
                return;
            }
            ShufflePlaylist();
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
