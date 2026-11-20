using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable_Line_Test.Resources
{
    internal static class Constants
    {
        public const string machineID = "T01";

        public const string dbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\CLT.accdb;Jet OLEDB:Database Password=mypassword; OLE DB Services=-1";

        public static class Messages
        {
            public const string System_Ready = "System is ready for BarCode scanning of Master Battery Cable.";
            public const string Connect_NG_Master = "Please INSERT NG Master Battery Cable of the Selected Part Number";
            public const string Connect_Test_Cable = "Please INSERT Test Battery Cable of the Selected Part Number";
            public const string NG_Master_Pass = "NG Master Cable Test Passed";
            public const string NG_Master_Fail = "NG Master Cable Test Failed";
            public const string Test_Cable_Pass = "Battery Cable Test Passed";
            public const string Test_Cable_Fail = "Battery Cable Test Failed";
        }

        public static class TestStatus
        {
            public const string Ready = "READY";
            public const string Start = "START";
            public const string Pass = "PASS";
            public const string Fail = "FAIL";
            public const string Changed = "CHANGED";
        }

        public static class LineStatus
        {
            public const string Pass = "PASS";
            public const string Changed = "CHANGED";
            public const String Open = "OPEN";
        }

    }
}
