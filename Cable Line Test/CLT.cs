using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class BCC : Form
    {
        public BCC()
        {
            InitializeComponent();
        }

        private void toolStripBtn_Settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
            this.Show();
        }

        private void toolStripBtn_Test_Click(object sender, EventArgs e)
        {
            this.Hide();
            TestCenter testCenter = new TestCenter();
            testCenter.ShowDialog();
            this.Show();
        }

        private void toolStripBtn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtn_WorkData_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkData workData = new WorkData();
            workData.ShowDialog();
            this.Show();
        }

        private void BCC_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed
            Application.Exit();
        }

        private void BCC_Load(object sender, EventArgs e)
        {
            var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configSettings.AppSettings.Settings;

            if (settings["SCREEN_SIZE"] != null)
            {
                numericUpDown_ScreenSize.Value = Decimal.Parse(settings["SCREEN_SIZE"].Value);
            }
        }

        private void toolStripBtn_Admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.ShowDialog();
            this.Show();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "D:\\Manual\\usermanual.pdf";
            if (File.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageBox.Show("User Manual is missing...");
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupportInfo supportInfo = new SupportInfo();
            supportInfo.Show();
        }

        private void numericUpDown_ScreenSize_ValueChanged(object sender, EventArgs e)
        {
            var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configSettings.AppSettings.Settings;

            // MONITOR/SCREEN Size Setting
            if (settings["SCREEN_SIZE"] == null)
                settings.Add("SCREEN_SIZE", numericUpDown_ScreenSize.Value.ToString());
            else
                settings["SCREEN_SIZE"].Value = numericUpDown_ScreenSize.Value.ToString();

            configSettings.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
