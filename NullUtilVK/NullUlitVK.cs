using NullUtilVK.Categories;
using NullUtilVK.Categories.Win;
using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace NullUtilVK
{
    public partial class NullUtilVk : IDisposable
    {
        public NullUtilVk(Action<MessageStatus, string> PrintConsole ,bool IsGui = false)
        {
            //Creating variables
            _PrintConsole = PrintConsole;
            this.IsGui = IsGui;
            _StartupDate = DateTime.Now;
            AuthCreds = new AuthInstance();
            //Setting up enviroment for logging
            LogWriterToDo = new List<string>();
            if (!Directory.Exists(Environment.CurrentDirectory + Constants.LogDirSuffix))
                Directory.CreateDirectory(Environment.CurrentDirectory + Constants.LogDirSuffix);
            File.Create(Environment.CurrentDirectory + Constants.LogDirSuffix + "\\" + _StartupDate.ToString(Constants.LogFileName) + ".log").Dispose();
            //_logger = new RestartableThread(new ThreadStart(LogWriterRun));
            //_logger.IsBackground = true;
            //_logger.Name = "Log Writer Thread";
            //_logger.Priority = ThreadPriority.Lowest;
            _logger = new Thread(new ThreadStart(LogWriterRun));
            _logger.IsBackground = true;
            _logger.Name = "Log Writer Thread";
            _logger.Start();

            Log(MessageStatus.Info, "Initializing NullUtilVk API");
            Log(MessageStatus.Info, "Initialing Vk API");
            _VkApi = new VkApi();
            Log(MessageStatus.Info, "Initialing Vk API succesed");
            //Creating config file if needed
            Log(MessageStatus.Info, "Creating default config if needed");
            Config.Create(ConfigDefault.GetPossibleValues(), ConfigDefault.GetSubCategories());
            Log(MessageStatus.Info, "Creating default config succesed");
            DB.Create();
            //Initializing console commands
            Log(MessageStatus.Info, "Registering console commands");
            _Commands = new ConsoleCommands();
            RegisterConsoleCommands(ref _Commands);
            //_Commands = RegisterConsoleCommands();
            Log(MessageStatus.Info, "Registered " + _Commands.GetCommands().Count.ToString() + " commands successfuly");
            Log(MessageStatus.Info, "Creating lang file");
            //Creating sample lang file
            Config.CreateDefaultLangFile();
            Log(MessageStatus.Info, "Initialized NullUtilVk API");
        }

        #region Public variables

        public bool IsGui { get; private set; }

        public bool IsAuthorize { get; private set; }

        public AuthInstance AuthCreds;

        public long UserId { get; private set; }
        private long GetUserId() { return UserId; }

        #endregion


        #region Categories

        public Audio Audio
        {
            get
            {
                if (_Audio == null)
                    _Audio = new Audio(GetUserId, _VkApi.Invoke, _VkApi.Audio, Util.SecToTime, Util.GetBestFile, Util.GetFolderSize, Log, Config.GetValue, Config.SetValue, _Commands.GetCategory, DB);
                return _Audio;
            }
        }
        private Audio _Audio;

        public User User
        {
            get
            {
                if (_User == null)
                    _User = new User(_VkApi, Log);
                return _User;
            }
        }
        private User _User;

        public Group Group
        {
            get
            {
                if (_Group == null)
                    _Group = new Group(_VkApi, Log);
                return _Group;
            }
        }
        private Group _Group;

        public Config Config
        {
            get
            {
                if (_Config == null)
                    _Config = new Config(Log);
                return _Config;
            }
        }
        private Config _Config;

        public DataBase DB
        {
            get
            {
                if (_DB == null)
                    _DB = new DataBase(Log, Config.GetLangValue);
                return _DB;
            }
        }
        private DataBase _DB;

        Util Util = new Util();
        #endregion

        #region Win Forms Logic
        public MainWin MainWin
        {
            get
            {
                if (_MainWin == null)
                    _MainWin = new MainWin(this);
                return _MainWin;
            }
        }
        private MainWin _MainWin;
        #endregion

        public bool Authorize(string EmailOrPhone, string Pass)
        {
            try
            {
                _VkApi.Authorize(_AppId, EmailOrPhone, Pass, _AppSettings);
            }
            catch (VkNet.Exception.VkApiAuthorizationException)
            {
                Log(MessageStatus.Error, LogStrings.Error.Auth.InvalidPassword);
                return false;
            }
            catch (VkNet.Exception.VkApiException)
            {
                Log(MessageStatus.Error, "No connection/VK servers down");
                return false;
            }
            IsAuthorize = true;
            Log(MessageStatus.Info, LogStrings.Info.Auth.NormSuccess);

            AuthCreds.IsNormal = true;
            AuthCreds.EmailOrAccKey = EmailOrPhone;
            AuthCreds.PassOrId = Pass;

            this.UserId = (long)_VkApi.UserId;
            return true;
        }

        public bool Authorize(string AccKey, long UserId)
        {
            _VkApi.Authorize(AccKey, UserId);
            try
            {
                _VkApi.Account.GetInfo();
            }
            catch (VkNet.Exception.VkApiException)
            {
                Log(MessageStatus.Error, LogStrings.Error.Auth.InvalidAccKey);
                return false;
            }
            IsAuthorize = true;
            Log(MessageStatus.Info, LogStrings.Info.Auth.AltSucess);

            AuthCreds.IsNormal = false;
            AuthCreds.EmailOrAccKey = AccKey;
            AuthCreds.PassOrId = UserId.ToString();

            this.UserId = UserId;
            return true;
        }

        public void LogOut()
        {
            _VkApi = new VkApi();
            IsAuthorize = false;
            Log(MessageStatus.Info, LogStrings.Info.Auth.LogOut);
        }

        public void RawCommand(string CommandAndArgs)
        {
            CommandAndArgs = string.Join(" ", CommandAndArgs.Split(' ').Where(c => c != string.Empty));
            if (CommandAndArgs == String.Empty)
                return;
            Log(MessageStatus.Info, ">> " + CommandAndArgs);
            CommandDigger(_Commands, CommandAndArgs);
        }

        private void CommandDigger(ConsoleCommands Commands, string CommandAndArgs)
        {
            string[] splitted = CommandAndArgs.Split(' ');
            string command = splitted[0];
            string args = string.Empty;
            if (splitted.Length > 1)
            {
                for (int i = 1; i < splitted.Length; i++)
                {
                    args += splitted[i];
                    args += ' ';
                }
                args = args.Remove(args.Length - 1);
            }
            if (Commands.GetSubCategories() != null && Commands.GetSubCategories().ContainsKey(command))
            {
                CommandDigger(Commands.GetSubCategories()[command], args);
                return;
            }
            var targetCommand = Commands.GetCommands().Find(c => c.Alias == command);
            if (targetCommand != null)
            {
                if (targetCommand.NeedAuth && !IsAuthorize)
                {
                    Log(MessageStatus.Error, LogStrings.Error.General.AuthRequired);
                    return;
                }
                else
                {
                    targetCommand.Logic(args);
                    return;
                }
            }
            Log(MessageStatus.Error, LogStrings.Error.General.UnknownCommand + command);
        }

        public void ClientLog(string obj)
        {
            Log(MessageStatus.Client, obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _disposing = true;
            _logger.Join();

            if (disposing)
            {
                if (_MainWin != null)
                    _MainWin.Dispose();
                if (_Audio != null)
                    _Audio.Dispose();
                if (_Config != null)
                    _Config.Dispose();
                if (_DB != null)
                    _DB.Dispose();
            }
        }

        internal void Log(MessageStatus Status, string Txt)
        {
            DateTime logTime = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            
            sb.Append(Environment.NewLine);
            sb.AppendFormat("[{0}] [{1}]: ", logTime.ToString("HH:mm:ss"), Status.Status);

            if (Status == MessageStatus.Request)
                sb.Append(">> ");
            else if (Status == MessageStatus.Response)
                sb.Append("<< ");

            if (Txt.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Count() < 2)
            {
                sb.Append(Txt);
            }
            else
            {
                foreach (var part in Txt.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(part);
                }
            }

            LogWriterToDo.Add(sb.ToString());
            //if (!_logger.IsAlive)
            //{
            //    _logger.Start();
            //}

            _PrintConsole(Status, Txt);
        }

        void LogWriterRun()
        {
            var sw = new StreamWriter(Environment.CurrentDirectory + Constants.LogDirSuffix + "\\" + _StartupDate.ToString(Constants.LogFileName) + ".log", true);
            while (!_disposing || LogWriterToDo.Count > 0)
            {
                Thread.Sleep(3000);
                while (LogWriterToDo.Count > 0)
                {
                    var item = LogWriterToDo.First();
                    sw.Write(item);
                    sw.Flush();
                    LogWriterToDo.Remove(item);
                }
            }
            sw.Close();
        }

        //private RestartableThread _logger;
        private Thread _logger;
        private bool _disposing = false;

        private List<string> LogWriterToDo;
        private DateTime _StartupDate;
        private Action<MessageStatus, string> _PrintConsole;
        private Settings _AppSettings = Settings.Notify | Settings.Friends | Settings.Photos |
                                     Settings.Audio | Settings.Video | Settings.Documents |
                                     Settings.Notes | Settings.Pages | Settings.Status |
                                     Settings.Wall | Settings.Groups | Settings.Messages |
                                     Settings.Notifications | Settings.Status;// | Settings.Offline;
        internal VkApi _VkApi;
        private int _AppId = 4638561;

        internal ConsoleCommands _Commands;

        private string _Version = "2.5.1";
    }
}
