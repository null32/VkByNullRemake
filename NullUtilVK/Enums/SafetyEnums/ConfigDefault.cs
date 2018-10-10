using NullUtilVK.Model;
using System;
using System.Collections.Generic;

namespace NullUtilVK.Enums.SafetyEnums
{
    public class ConfigDefault
    {
        private static readonly List<ConfigDefault> PossibleValues = new List<ConfigDefault>();
        private static readonly List<string> SubCategories = new List<string>();

        public string Key;
        public object DefaultValue;
        public string SubCategory;
        public Type ValueType;

        private ConfigDefault() { }

        private static ConfigDefault RegisterPossibleValue(string Key, object DefaultValue, Type ValueType, string SubCategory = null)
        {
            ConfigDefault temp = new ConfigDefault()
            {
                Key = Key,
                DefaultValue = DefaultValue,
                SubCategory = SubCategory,
                ValueType = ValueType
            };

            PossibleValues.Add(temp);
            
            if (SubCategory != null && !SubCategories.Contains(SubCategory))
                SubCategories.Add(SubCategory);

            return temp;
        }

        public static List<ConfigDefault> GetPossibleValues()
        {
            return PossibleValues;
        }

        public static List<string> GetSubCategories()
        {
            return SubCategories;
        }

        public static ConfigDefault Lang = ConfigDefault.RegisterPossibleValue("Lang", "en", typeof(string) , "General");
        public static ConfigDefault LangFilePath = ConfigDefault.RegisterPossibleValue("LangFilePath", Constants.DefaultLangFile, typeof(string), "General");

        public static ConfigDefault AudioDownloadDir = ConfigDefault.RegisterPossibleValue("DownDir", Constants.DefaultAudioDownDir, typeof(string), "Audio");
        public static ConfigDefault AudioPlayerVolume = ConfigDefault.RegisterPossibleValue("PlayerVolume", 0.1, typeof(double), "Audio");
        public static ConfigDefault AudioPrecacheStep = ConfigDefault.RegisterPossibleValue("PrecacheStep", 100, typeof(int), "Audio");
        public static ConfigDefault AudioLimitCache = ConfigDefault.RegisterPossibleValue("LimitCache", false, typeof(bool), "Audio");
        public static ConfigDefault AudioMaxCacheSizeMB = ConfigDefault.RegisterPossibleValue("MaxCacheSizeMB", 300, typeof(int), "Audio");

        public static ConfigDefault AudioGuiListDefaultColor = ConfigDefault.RegisterPossibleValue("GuiListDefaultColor", new int[3] { 255, 255, 255 }, typeof(int[]), "Audio");
        public static ConfigDefault AudioGuiListPlayingColor = ConfigDefault.RegisterPossibleValue("GuiListPlayingColor", new int[3] { 204, 238, 255 }, typeof(int[]), "Audio");
        public static ConfigDefault AudioGuiSearchHistory = ConfigDefault.RegisterPossibleValue("GuiSearchHistory", new string[] { }, typeof(string[]), "Audio");

        public static ConfigDefault AuthList = ConfigDefault.RegisterPossibleValue("AuthList", new List<AuthInstance>(), typeof(List<AuthInstance>));
        
    }
}
