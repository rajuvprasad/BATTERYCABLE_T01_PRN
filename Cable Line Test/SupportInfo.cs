using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class SupportInfo : Form
    {
        public SupportInfo()
        {
            InitializeComponent();
        }

        private void SupportInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SupportInfo_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
