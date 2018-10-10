using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkByNullRemakeFormsGui.UtilWindows
{
    public partial class AudioTextShower : Form
    {
        public AudioTextShower(string Title, string Text)
        {
            InitializeComponent();
            this.Text = Title;
            this.MainTextBox.Lines = Text.Split('\n');
        }
    }
}
