using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Model
{
    public class ConsoleCommandBody
    {
        public string Alias;
        public Action<string> Logic;
        public string Info;
        public string Help;
        public bool NeedAuth;
    }
}
