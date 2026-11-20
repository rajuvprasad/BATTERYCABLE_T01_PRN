using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable_Line_Test.Common
{
    internal static class Constants
    {
        //public const string machineID = "MT1";

        public const string dbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\CLT.accdb;Jet OLEDB:Database Password=mypassword; OLE DB Services=-1";

        public const string tmpLabelPrintFileName = "EOL_LABEL_PRNTR_FILE.prn";

        public const string printerName = "EOL_LABEL_PRNTR";
    }
}
