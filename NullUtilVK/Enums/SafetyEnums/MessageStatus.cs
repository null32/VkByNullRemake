using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Enums.SafetyEnums
{
    public class MessageStatus
    {
        private MessageStatus() { }

        public string Status;
        public ConsoleColor ConColor;
        public Color DrawColor;
        private int Hash;

        private static readonly List<MessageStatus> RegisteredValues = new List<MessageStatus>();
        private static MessageStatus RegisterValue(string Status, ConsoleColor ConColor, Color DrawColor)
        {
            var temp = new MessageStatus()
            {
                Status = Status,
                ConColor = ConColor,
                DrawColor = DrawColor,
                Hash = RegisteredValues.Count
            };
            RegisteredValues.Add(temp);
            return temp;
        }
        private static List<MessageStatus> GetRegisteredValues()
        {
            return RegisteredValues;
        }

        public static bool operator ==(MessageStatus First, MessageStatus Second)
        {
            return First.Hash == Second.Hash;
        }
        public static bool operator !=(MessageStatus First, MessageStatus Second)
        {
            return !(First == Second);
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MessageStatus)
                return (obj as MessageStatus).Hash == this.Hash;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return Hash.GetHashCode();
        }
        public override string ToString()
        {
            return Status;
        }

        public static MessageStatus Error = MessageStatus.RegisterValue("Error", ConsoleColor.Red, Color.Red); //ff0000
        public static MessageStatus Info = MessageStatus.RegisterValue("Info", ConsoleColor.Green, Color.Green); //00ff00
        public static MessageStatus Request = MessageStatus.RegisterValue("Request", ConsoleColor.Cyan, Color.Cyan); //00ffff
        public static MessageStatus Response = MessageStatus.RegisterValue("Response", ConsoleColor.Blue, Color.Blue); //008000 //0080FF
        public static MessageStatus Client = MessageStatus.RegisterValue("Client Console", ConsoleColor.DarkGray, Color.Black); //a9a9a9
    }
}
