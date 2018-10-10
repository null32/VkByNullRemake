using System;
using System.Collections.Generic;

namespace NullUtilVK.Enums.SafetyEnums
{
    public class Localization
    {
        private static readonly List<Localization> PossibleValues = new List<Localization>();

        public string Key;
        public string Value;

        private Localization() { }

        private static Localization RegisterPossibleValue(string Key, string Value)
        {
            Localization temp = new Localization()
            {
                Key = Key,
                Value = Value
            };

            PossibleValues.Add(temp);

            return temp;
        }

        public static List<Localization> GetPossibleValues()
        {
            return PossibleValues;
        }

        public static Localization LangName = Localization.RegisterPossibleValue("lang", "en");

        public static Localization GuiFile = Localization.RegisterPossibleValue("GuiFile", "File");
        public static Localization GuiTools = Localization.RegisterPossibleValue("GuiTools", "Tools");
        public static Localization GuiHelp = Localization.RegisterPossibleValue("GuiHelp", "Help");
        public static Localization GuiAudio = Localization.RegisterPossibleValue("GuiAudio", "Audio");
        public static Localization GuiInstName = Localization.RegisterPossibleValue("GuiInstName", "Instance Name");
        public static Localization GuiEmail = Localization.RegisterPossibleValue("GuiEmail", "Email/Phone");
        public static Localization GuiPass = Localization.RegisterPossibleValue("GuiPass", "Password");
        public static Localization GuiAccKey = Localization.RegisterPossibleValue("GuiAccKey", "Access Key");
        public static Localization GuiUserId = Localization.RegisterPossibleValue("GuiUserId", "User ID");
        public static Localization GuiLoginType = Localization.RegisterPossibleValue("GuiLoginType", "Login Type");
        public static Localization GuiLoginNormal = Localization.RegisterPossibleValue("GuiLoginNormal", "Normal");
        public static Localization GuiLoginAlt = Localization.RegisterPossibleValue("GuiLoginAlt", "Alternative");
        public static Localization GuiPassShow = Localization.RegisterPossibleValue("GuiPassShow", "Show Password");
        public static Localization GuiAdd = Localization.RegisterPossibleValue("GuiAdd", "Add");
        public static Localization GuiRemove = Localization.RegisterPossibleValue("GuiRemove", "Remove");
        public static Localization GuiUpdate = Localization.RegisterPossibleValue("GuiUpdate", "Update");
        public static Localization GuiLogin = Localization.RegisterPossibleValue("GuiLogin", "Log In");
        public static Localization GuiLogout = Localization.RegisterPossibleValue("GuiLogout", "Log Out");
    }
}
