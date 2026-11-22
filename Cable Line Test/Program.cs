using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var assembly = typeof(Program).Assembly;
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            var guid = attribute.Value;

            using (Mutex mutex = new Mutex(false, "Global\\" + guid))
            {
                if (!mutex.WaitOne(0, false))
                    return;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    Common.DatabaseSchema.Upgrade();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not update the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Application.Run(new BCC());
            }
        }
    }
}
