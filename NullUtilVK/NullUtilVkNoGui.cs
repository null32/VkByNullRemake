using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullUtilVK
{
    public partial class NullUtilVk
    {
        //protected ConsoleCommands RegisterConsoleCommands()
        protected void RegisterConsoleCommands(ref ConsoleCommands Commands)
        {
            //ConsoleCommands Commands = new ConsoleCommands();

            Commands.AddCommand("version", this.VersionPrint, "", LogStrings.Help.Version, false);

            Commands.AddCommand("?", this.HelpPrint, "<COMMAND?>", LogStrings.Help.OfHelp, false);
            Commands.AddCommand("help", this.HelpPrint, "<COMMAND?>", LogStrings.Help.OfHelp, false);

            Commands.AddCommand("list", this.ListPrint, "<CATEGORY?>", LogStrings.Help.List, false);
            Commands.AddCommand("ls", this.ListPrint, "<CATEGORY?>", LogStrings.Help.List, false);

            Commands.AddCommand("config", this.SetGetConfig, "[set <CATEGORY> <CONFIG_KEY> <CONFIG_VALUE>]/[get <CATEGORY> <CONFIG_NAME>", LogStrings.Help.Config, false);
            Commands.AddCommand("cfg", this.SetGetConfig, "[set <CATEGORY> <CONFIG_KEY> <CONFIG_VALUE>]/[get <CATEGORY> <CONFIG_NAME>]/[-list]", LogStrings.Help.Config, false);

            Commands.AddCommand("login", this.LogIn, "<LOGIN> <PASSWORD>", LogStrings.Help.Login, false);

            Commands.AddCommand("loginalt", this.LogInAlt, "<ACCESS_KEY> <USER_ID>", LogStrings.Help.Login, false);

            Commands.AddCommand("logout", this.LogOutCon, "", LogStrings.Help.Logout, true);
            #region Audio commands
            var AudioCommands = Commands.AddCategory("audio");

            AudioCommands.AddCommand("?", Audio.Help, "<COMMAND?>", LogStrings.Help.Audio.General, false);
            AudioCommands.AddCommand("help", Audio.Help, "<COMMAND?>", LogStrings.Help.Audio.General, false);

            AudioCommands.AddCommand("count", Audio.ConCount, "<USER_ID?>", LogStrings.Help.Audio.Count, true);

            AudioCommands.AddCommand("get", Audio.ConGet, "<USER_ID?> <COUNT> <OFFSET?>", LogStrings.Help.Audio.Get, true);

            AudioCommands.AddCommand("search", Audio.ConSearch, "<QUERRY>", LogStrings.Help.Audio.Search, true);

            AudioCommands.AddCommand("info", Audio.ConFullInfo, "<AUDIO_ITEM>/<LIST_INDEX>", LogStrings.Help.Audio.Info, true);

            AudioCommands.AddCommand("albums", Audio.ConGetAlbums, "<USER_ID?>", LogStrings.Help.Audio.Albums, true);

            AudioCommands.AddCommand("add", Audio.ConAdd, "<AUDIO_ITEM>/<LIST_INDEX>", LogStrings.Help.Audio.Add, true);

            AudioCommands.AddCommand("delete", Audio.ConDelete, "<AUDIO_ITEM>/<LIST_INDEX>", LogStrings.Help.Audio.Delete, true);

            AudioCommands.AddCommand("download", Audio.ConDownload, "<AUDIO_ITEM>/<LIST_INDEX>", LogStrings.Help.Audio.Download, true);
            #region Audio player commands
            var AudioPlayerCommands = AudioCommands.AddCategory("player");

            AudioPlayerCommands.AddCommand("help", Audio.Player.Help, "<COMMAND?>", LogStrings.Help.Audio.Player.General, false);
            AudioPlayerCommands.AddCommand("?", Audio.Player.Help, "<COMMAND?>", LogStrings.Help.Audio.Player.General, false);

            AudioPlayerCommands.AddCommand("play", Audio.Player.ConPlay, "<START_INDEX?>", LogStrings.Help.Audio.Player.Play, false);

            AudioPlayerCommands.AddCommand("next", Audio.Player.ConNext, "", LogStrings.Help.Audio.Player.Next, false);

            AudioPlayerCommands.AddCommand("prev", Audio.Player.ConPrev, "", LogStrings.Help.Audio.Player.Prev, false);

            AudioPlayerCommands.AddCommand("pause", Audio.Player.ConPause, "", LogStrings.Help.Audio.Player.Pause, false);

            AudioPlayerCommands.AddCommand("resume", Audio.Player.ConPause, "", LogStrings.Help.Audio.Player.Resume, false);

            AudioPlayerCommands.AddCommand("stop", Audio.Player.ConStop, "", LogStrings.Help.Audio.Player.Stop, false);

            AudioPlayerCommands.AddCommand("listadd", Audio.Player.ConAddToPlaylist, "<AUDIO_ITEM>/<LIST_INDEX>, ...", LogStrings.Help.Audio.Player.ListAdd, false);

            AudioPlayerCommands.AddCommand("listdel", Audio.Player.ConDelFromPlaylist, "<AUDIO_ITEM>/<LIST_INDEX>, ...", LogStrings.Help.Audio.Player.ListDel, false);

            AudioPlayerCommands.AddCommand("volume", Audio.Player.ConVolume, "<VOLUME>", LogStrings.Help.Audio.Player.Volume, false);

            AudioPlayerCommands.AddCommand("listshow", Audio.Player.ConShowPL, "", LogStrings.Help.Audio.Player.ShowPl, false);

            AudioPlayerCommands.AddCommand("listshuffle", Audio.Player.ConShufflePL, "", LogStrings.Help.Audio.Player.ShufflePl, false);
            #endregion
            #endregion
            //return Commands;
        }

        private void VersionPrint(string Arg)
        {
            Log(MessageStatus.Info, this._Version);
        }
        private void HelpPrint(string Arg)
        {
            if (String.IsNullOrEmpty(Arg))
            {
                Log(MessageStatus.Info, LogStrings.Help.General);
                return;
            }
            if (_Commands.GetCommands().Where(c => c.Alias == Arg).Count() > 0)
            {
                var item = _Commands.GetCommands().Where(c => c.Alias == Arg.ToLower()).First();
                Log(MessageStatus.Info, "Usage: " + item.Alias + " " + item.Info + Environment.NewLine + item.Help);
                return;
            }
            if (Arg == "-full")
            {
                Log(MessageStatus.Info, ListAllCommands(_Commands).Remove(0, Environment.NewLine.Length));
                return;
            }
            Log(MessageStatus.Error, LogStrings.Error.General.UnknownCommand + Arg);
        }
        private void SetGetConfig(string Arg)
        {
            if (Arg == "-list")
            {
                StringBuilder sb = new StringBuilder();
                foreach (var configItem in ConfigDefault.GetPossibleValues())
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(configItem.Key);
                    sb.Append(" - ");
                    sb.Append(configItem.ValueType.Name);
                    sb.Append(" - ");
                    sb.Append(Config.GetValue(configItem));
                }
                Log(MessageStatus.Info, sb.ToString().Remove(0, Environment.NewLine.Length));
                return;
            }
            var splitted = Arg.Split(' ');
            var option = splitted[0];
            var value = string.Empty;
            var configName = string.Empty;
            if (option == "set")
            {
                configName = splitted[splitted.Length - 2];
            }
            else if (option == "get")
            {
                configName = splitted[splitted.Length - 1];
            }
            else
            {
                Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + option);
                return;
            }
            if ((option == "set" && splitted.Length < 4) || (option == "get" && splitted.Length < 3))
            {
                Log(MessageStatus.Error, LogStrings.Error.General.InvalidUsage);
                return;
            }
#warning Refactor this
            var subCateName = splitted[1];
            var config = ConfigDefault.GetPossibleValues().Find(c => c.SubCategory.ToLower() == subCateName && c.Key.ToLower() == configName);
            if (config != null)
            {
                if (option == "set")
                {
                    value = splitted[splitted.Length - 1];
                    try
                    {
                        Config.SetValue(config, Convert.ChangeType(value, config.ValueType));
                    }
                    catch (FormatException)
                    {
                        Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + value);
                        return;
                    }
                    Log(MessageStatus.Info, string.Format(LogStrings.Info.General.SetConfigValue, config.Key, value));
                    return;
                }
                else
                {
                    Log(MessageStatus.Info, string.Format(LogStrings.Info.General.GetConfigValue, config.Key, Config.GetValue(config)));
                    return;
                }
            }
            else
            {
                Log(MessageStatus.Error, LogStrings.Error.General.InvalidArgument + subCateName + "/" + configName);
            }
        }
        private void ListPrint(string Arg)
        {
            ConsoleCommands commands;
            commands = _Commands;
            var splitted = Arg.Split(' ');
            if (Arg != string.Empty)
                for (int i = 0; i < splitted.Length; i++)
                {
                    if (commands.GetSubCategories().FirstOrDefault(c => c.Key == splitted[i]).Key == null)
                    {
                        Log(MessageStatus.Error, LogStrings.Error.General.UnknownCategory + splitted[i]);
                        return;
                    }
                    commands = commands.GetCategory(splitted[i]);
                }
            StringBuilder sb = new StringBuilder();
            if (commands.GetSubCategories().Count > 0)
            {
                sb.Append("Categories:");
                foreach (var item in commands.GetSubCategories())
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(item.Key);
                }
                sb.Append(Environment.NewLine);
            }
            sb.Append("Commands:");
            foreach (var item in commands.GetCommands())
            {
                sb.Append(Environment.NewLine);
                sb.Append(FormatCommandHelp(item));
            }
            Log(MessageStatus.Info, sb.ToString());
        }

        private void LogIn(string EmailAndPass)
        {
            string[] creds;
            creds = EmailAndPass.Split(' ');
            creds = creds.Where(item => item != String.Empty).ToArray();
            if (creds.Length < 2)
            {
                Log(MessageStatus.Error, LogStrings.Error.General.InvalidUsage);
                return;
            }
            string mail = creds[0];
            string pass = String.Empty;
            for (int i = 1; i < creds.Length; i++)
            {
                pass += creds[i];
                pass += ' ';
            }
            pass = pass.Remove(pass.Length - 1);

            Authorize(mail, pass);
        }
        private void LogInAlt(string AcckeyAndId)
        {
            string[] tempArr = AcckeyAndId.Split(' ');
            if (tempArr.Length < 2)
            {
                Log(MessageStatus.Error, LogStrings.Error.General.InvalidUsage + AcckeyAndId);
                return;
            }
            Authorize(tempArr[0], Convert.ToInt64(tempArr[1]));
        }
        private void LogOutCon(string Ignored)
        {
            this.LogOut();
        }

        private string ListAllCommands(ConsoleCommands Commands, string CategoryName = null)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var command in Commands.GetCommands())
            {
                sb.Append(Environment.NewLine);
                if (CategoryName != null)
                    sb.Append(CategoryName + ' ');
                sb.Append(FormatCommandHelp(command));
            }

            var subcates = Commands.GetSubCategories();
            if (subcates.Count != 0)
                foreach (var subcate in subcates)
                {
                    if (CategoryName != null)
                        sb.Append(ListAllCommands(subcate.Value, CategoryName + ' ' + subcate.Key));
                    else
                        sb.Append(ListAllCommands(subcate.Value, subcate.Key));
                }

            return sb.ToString();
        }
        private string FormatCommandHelp(ConsoleCommandBody item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(item.Alias);
            sb.Append(' ');
            sb.Append(item.Info);
            sb.Append("\t-\t");
            sb.Append(item.Help);
            return sb.ToString();
        }
    }    
}
