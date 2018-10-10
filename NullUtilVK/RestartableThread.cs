using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NullUtilVK
{
    public sealed class RestartableThread
    {
        private Thread _thread;

        public RestartableThread(ThreadStart start)
        {
            _start = start;
        }
        private ThreadStart _start = null;

        public bool IsAlive
        {
            get
            {
                if (_thread != null)
                    return _thread.IsAlive;
                else
                    return false;
            }
        }
        public bool IsBackground;
        public string Name;
        public ThreadPriority Priority;

        public void Start()
        {
            if (_thread != null && _thread.IsAlive)
                throw new System.Exception("Thread is already running");

            _thread = new Thread(_start);
            _thread.IsBackground = IsBackground;
            _thread.Name = Name;
            _thread.Priority = Priority;

            _thread.Start();
        }
    }
}
