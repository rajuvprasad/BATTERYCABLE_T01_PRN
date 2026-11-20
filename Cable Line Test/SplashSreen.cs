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
    public partial class SplashSreen : Form
    {
        public SplashSreen()
        {
            InitializeComponent();
        }

        Timer tmr;
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            BCC bcc = new BCC();
            bcc.Show();
            //hide this form
            this.Hide();
        }

        private void SplashSreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
    }
}
