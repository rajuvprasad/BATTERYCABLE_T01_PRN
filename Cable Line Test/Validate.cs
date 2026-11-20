using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Cryptography;
using System.IO;

namespace Cable_Line_Test
{
    class ValidateInstall
    {
        public static String GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }

        public static String GetProcessorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;

        }

        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        public static string GetBIOSserNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT SerialNumber FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "BIOS Serial Number: Unknown";
        }

        public static string GetCSProductUUID()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT UUID FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("UUID").ToString();
                }
                catch { }
            }
            return "Computer System Product UUID : Unknown";
        }

        public static string GetDISKDRIVEserNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT SerialNumber FROM Win32_DISKDRIVE");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString().Trim();
                }
                catch { }
            }
            return "DISKDRIVE Serial Number: Unknown";
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static bool isValidCopy()
        {
            int i = 0;
            string key1 = Properties.Settings.Default.Key1;
            string key2 = Properties.Settings.Default.Key2;
            string key3 = Properties.Settings.Default.Key3;
            string key4 = Properties.Settings.Default.Key4;
            string key5 = Properties.Settings.Default.Key5;
            string key6 = Properties.Settings.Default.Key6;

            if (key1 != null && key1 != "" && GetHDDSerialNo().Trim().Equals(Decrypt(key1))) i++;
            if (key2 != null && key2 != "" && GetBIOSserNo().Trim().Equals(Decrypt(key2))) i++;
            if (key3 != null && key3 != "" && GetDISKDRIVEserNo().Trim().Equals(Decrypt(key3))) i++;
            if (key4 != null && key4 != "" && GetCSProductUUID().Trim().Equals(Decrypt(key4))) i++;
            if (key5 != null && key5 != "" && GetMACAddress().Trim().Equals(Decrypt(key5))) i++;
            if (key6 != null && key6 != "" && GetProcessorId().Trim().Equals(Decrypt(key6))) i++;

            if (i >= 3) return true;
            else return false;
        }
    }
}
