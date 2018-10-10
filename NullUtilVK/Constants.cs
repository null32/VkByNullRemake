using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK
{
    class Constants
    {
        public const string LangDirSuffix = "\\lang";
        public static readonly string DefaultLangFile = Environment.CurrentDirectory + "\\lang\\english.json";

        public static readonly string ConfigFilePath = Environment.CurrentDirectory + "\\config.json";
        public static readonly string DBFilePath = Environment.CurrentDirectory + "\\main.sqlite";

        public const string AudioDownDirSuffix = "\\Download\\Audio";
        public static readonly string DefaultAudioDownDir = Environment.CurrentDirectory + "\\Download\\Audio";

        public const string LogFileName = "yyyy-MM-dd@HH-mm-ss";
        public const string LogDirSuffix = "\\log";

        public const string CacheDirSuffix = "\\cache";
        public const string CacheDirAudioSuffix = "\\cache\\audio";
    }
}
