using NullUtilVK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkByNullRemakeFormsGui
{
    public interface ISavable
    {
        IDictionary<string, object> SaveInst();
        void LoadInst(Castable values);

        bool IsHidden { get; }
        FormWindowState FormState { get; }
        int WidthI { get; }
        int HeightI { get; }
        int PosX { get; }
        int PosY { get; }
    }
}
