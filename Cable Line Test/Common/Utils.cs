using System;
using System.Configuration;
using System.Windows.Forms;

namespace Cable_Line_Test.Common
{
    class Utils
    {
        public static double getPPI()
        {
            var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configSettings.AppSettings.Settings;

            if (settings["SCREEN_SIZE"] != null)
            {
                double screenSize = double.Parse(settings["SCREEN_SIZE"].Value);
                return (Math.Sqrt(Math.Pow(Screen.PrimaryScreen.Bounds.Size.Width, 2) + Math.Pow(Screen.PrimaryScreen.Bounds.Size.Height, 2))) / screenSize;
            }
            return 0;
        }

        public static int getPixels(decimal value)
        {
            //return Convert.ToInt32((Convert.ToDouble(value) * 141.212) / 25.4);
            return Convert.ToInt32((Convert.ToDouble(value) * getPPI()) / 25.4);
        }
    }
}
