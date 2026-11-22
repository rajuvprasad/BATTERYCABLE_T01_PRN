using System;
using System.Data;
using System.Data.OleDb;

namespace Cable_Line_Test.Common
{
    // Brings an existing CLT.accdb (e.g. one kept by install.sh on an upgrade) up to the schema this version of the app expects.
    // Every step checks the database before changing it, so it is safe to run on every start-up.
    class DatabaseSchema
    {
        public static void Upgrade()
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                createPartRunningSerialTable(dbCon);
                makeLotNumberIndexNonUnique(dbCon);
            }
        }

        // Running lot number, one row per part per day (same structure as T0A)
        private static void createPartRunningSerialTable(OleDbConnection dbCon)
        {
            if (tableExists(dbCon, "PART_RUNNING_SERIAL"))
                return;

            execute(dbCon, "CREATE TABLE PART_RUNNING_SERIAL (ID COUNTER CONSTRAINT PrimaryKey PRIMARY KEY, PART_NUMBER TEXT(255), TEST_DAY_DATE DATETIME, " +
                "TEST_DAY_LAST_DATE_TIME DATETIME, TRACEABILITY_CODE TEXT(255), RUNNING_LOT_NUMBER TEXT(255))");
        }

        // Lot numbers reset daily per part, so TESTING_DATA.LOT_NUMBER can no longer have a unique index
        private static void makeLotNumberIndexNonUnique(OleDbConnection dbCon)
        {
            DataTable indexes = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Indexes, new object[] { null, null, null, null, "TESTING_DATA" });
            foreach (DataRow row in indexes.Rows)
            {
                if (row["COLUMN_NAME"].ToString() == "LOT_NUMBER" && Convert.ToBoolean(row["UNIQUE"]))
                {
                    string indexName = row["INDEX_NAME"].ToString();
                    execute(dbCon, "DROP INDEX [" + indexName + "] ON TESTING_DATA");
                    execute(dbCon, "CREATE INDEX [" + indexName + "] ON TESTING_DATA (LOT_NUMBER)");
                    return;
                }
            }
        }

        private static bool tableExists(OleDbConnection dbCon, string tableName)
        {
            DataTable tables = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, tableName, "TABLE" });
            return tables.Rows.Count > 0;
        }

        private static void execute(OleDbConnection dbCon, string sql)
        {
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
