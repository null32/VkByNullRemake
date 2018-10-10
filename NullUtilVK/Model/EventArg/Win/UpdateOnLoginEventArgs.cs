using NullUtilVK.Enums.Win;
using System;

namespace NullUtilVK.Model.EventArg.Win
{
    public class UpdateOnLoginEventArgs : EventArgs
    {
        public UpdateOnLoginEventArgs(bool IsLoggedIn, WorkerState State, string Status)
        {
            this.IsLoggedIn = IsLoggedIn;
            this.AuthorizerStatus = State;
            this.AuthorizerText = Status;
        }

        public bool IsLoggedIn;
        public WorkerState AuthorizerStatus;
        public string AuthorizerText;
    }
}
