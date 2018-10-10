using System;
using System.Collections.Generic;
using System.Linq;

namespace NullUtilVK.Model
{
    public class ConsoleCommands
    {
        private List<ConsoleCommandBody> Commands;
        private Dictionary<string, ConsoleCommands> SubCategories;

        public ConsoleCommands()
        {
            Commands = new List<ConsoleCommandBody>();
            SubCategories = new Dictionary<string, ConsoleCommands>();
        }

        public void AddCommand(string Alias, Action<string> Parser, string Info, string Help, bool NeedAuth)
        {
            if (Commands.Where(c => c.Alias == Alias).Count() > 0)
                throw new ArgumentException("Command (" + Alias + ") is already defined.");
            Commands.Add(new ConsoleCommandBody
            {
                Alias = Alias,
                Logic = Parser,
                Info = Info,
                Help = Help,
                NeedAuth = NeedAuth
            });
        }

        public ConsoleCommands AddCategory(string Alias)
        {
            if (SubCategories.ContainsKey(Alias))
                throw new ArgumentException("Category (" + Alias + ") is already defined.");
            SubCategories.Add(Alias, new ConsoleCommands());

            return GetCategory(Alias);
        }

        public Action<string> GetCommand(string Alias)
        {
            if (Commands.Where(c => c.Alias == Alias).Count() > 0)
                return Commands.First(item => item.Alias == Alias).Logic;
            throw new ArgumentException("Command (" + Alias + ") is not defined.");
        }

        public ConsoleCommands GetCategory(string Alias)
        {
            if (!SubCategories.ContainsKey(Alias))
                throw new ArgumentException("Category (" + Alias + ") is not defined.");
            return SubCategories.First(item => item.Key == Alias).Value;
        }

        public List<ConsoleCommandBody> GetCommands()
        {
            return Commands;
        }

        public Dictionary<string, ConsoleCommands> GetSubCategories()
        {
            return SubCategories;
        }
    }

}
