using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullUtilVK;


namespace VkByNullRemakeNoGui
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Action<NullUtilVK.Enums.SafetyEnums.MessageStatus, string> OutDelegate = PrintConsole;
            var NullApi = new NullUtilVk(OutDelegate);
            string read = String.Empty;
            while (true)
            {
                read = Console.ReadLine().ToLower();
                if (read == "exit" || read == "quit")
                    break;
                NullApi.RawCommand(read);
            }
            NullApi.Dispose();
        }

        public static void PrintConsole(NullUtilVK.Enums.SafetyEnums.MessageStatus status, string text)
        {
            Console.ForegroundColor = status.ConColor;
            Console.Out.Write(text);
            Console.Out.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
