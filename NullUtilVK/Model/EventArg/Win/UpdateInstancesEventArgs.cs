using System;
using System.Collections.Generic;

namespace NullUtilVK.Model.EventArg.Win
{
    public class UpdateInstancesEventArgs : EventArgs
    {
        public UpdateInstancesEventArgs(List<AuthInstance> insts, int index)
        {
            this.Instances = insts;
            this.SelectedIndex = index;
        }

        public List<AuthInstance> Instances;
        public int SelectedIndex;
    }
}
