using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Cable_Line_Test
{
    public partial class WorkData : Form
    {
        private DataTable dataTable;
        private string dateFilter = String.Empty;

        public WorkData()
        {
            InitializeComponent();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left, statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);
        }

        private void WorkData_Load(object sender, EventArgs e)
        {
            Fill_PartNumber_Combo();
            dateTimePicker_StartDate.MaxDate = DateTime.Today;
            dateTimePicker_EndDate.MaxDate = DateTime.Today;
            dateTimePicker_StartDate.Value = DateTime.Today;
            dateTimePicker_EndDate.Value = DateTime.Today;
            cb_Result.SelectedIndex = 0;
            cb_PartStatus.SelectedIndex = 0;
            get_Data();
        }

        private string getDateFileter()
        {
            return " RECORD_DATE >= #" + dateTimePicker_StartDate.Value.ToShortDateString() + "# AND RECORD_DATE <= #" + dateTimePicker_EndDate.Value.ToShortDateString() + "# ";
        }

        private void Fill_PartNumber_Combo()
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(" SELECT * FROM PART_DETAILS ", dbCon);
                DataTable cb_DataTable = new DataTable();
                adapter.Fill(cb_DataTable);
                DataRow row = cb_DataTable.NewRow();
                row["PART_NUMBER"] = "ALL";
                cb_DataTable.Rows.InsertAt(row, 0);
                cb_PartNumber.DataSource = cb_DataTable;
                cb_PartNumber.ValueMember = "PART_NUMBER";
                cb_PartNumber.SelectedIndex = 0;
            }
        }

        private void get_Data()
        {
            dgv_Report.DataSource = null;
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                string selectCmdTxt = " SELECT * FROM PART_DETAILS, TESTING_DATA WHERE PART_NUMBER = PARTDETAILS_PART_NUMBER ORDER BY PART_NUMBER, DATETIME ";
                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCmdTxt, dbCon);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.DefaultView.RowFilter = getDateFileter();

                dgv_Report.AutoGenerateColumns = false;
                dgv_Report.DataSource = dataTable;
                dgv_Report.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgv_Report.ClearSelection();
            }
            populate_SerialNumberColumn();
        }

        private void populate_SerialNumberColumn()
        {
            int i = 1;
            foreach (DataGridViewRow row in dgv_Report.Rows)
                row.Cells["SlNo"].Value = i++;
        }

        private void dateTimePicker_StartDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_EndDate.MinDate = dateTimePicker_StartDate.Value;
        }

        private string getSelectedValue(ComboBox comboBox, string columnName)
        {
            DataRowView dataRowView = comboBox.SelectedItem as DataRowView;
            string value = string.Empty;

            if (dataRowView != null)
                value = dataRowView.Row[columnName] as string;

            return value;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_Report.DataSource = null;
            dataTable.DefaultView.RowFilter = String.Empty;
            string searchCriteria = String.Empty;

            searchCriteria = getDateFileter();

            if (!getSelectedValue(cb_PartNumber, "PART_NUMBER").Equals("ALL"))
            {
                searchCriteria += " AND PART_NUMBER = '" + getSelectedValue(cb_PartNumber, "PART_NUMBER") + "'";
            }

            if (!cb_Result.SelectedItem.ToString().Equals("ALL"))
            {
                searchCriteria += " AND OVERALL_STATUS = '" + cb_Result.SelectedItem.ToString() + "'";
            }

            if (getSelectedValue(cb_PartNumber, "PART_NUMBER").Equals("ALL") && !cb_PartStatus.SelectedItem.ToString().Equals("ALL"))
            {
                if (cb_PartStatus.SelectedItem.ToString().Equals("ACTIVE"))
                    searchCriteria += " AND IS_ACTIVE = " + true;
                else
                    searchCriteria += " AND IS_ACTIVE = " + false;
            }
            Console.WriteLine("Search Criteris : " + searchCriteria);
            dataTable.DefaultView.RowFilter = searchCriteria;
            dgv_Report.AutoGenerateColumns = false;
            dgv_Report.DataSource = dataTable;
            dgv_Report.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_Report.ClearSelection();
            populate_SerialNumberColumn();
        }

        private void cb_PartNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!getSelectedValue(cb_PartNumber, "PART_NUMBER").Equals("ALL"))
            {
                bool isActive = false;
                using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = " SELECT IS_ACTIVE FROM PART_DETAILS WHERE PART_NUMBER = @partNumber ";
                    cmd.Parameters.AddWithValue("partNumber", getSelectedValue(cb_PartNumber, "PART_NUMBER"));
                    dbCon.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        isActive = reader.GetBoolean(0);
                    }
                    Console.WriteLine("isActive : " + isActive);
                }
                cb_PartStatus.SelectedIndex = isActive ? cb_PartStatus.FindString("ACTIVE") : cb_PartStatus.FindString("INACTIVE");
                cb_PartStatus.Enabled = false;
            }
            else
            {
                cb_PartStatus.Enabled = true;
            }
        }

        private void ExportToExcel(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "excel file |*.xls";
            sfd.FileName = "Report_" + DateTime.Now.ToString("MMddyyyy_hhmmsstt") + ".xls";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            StreamWriter wr = new StreamWriter(sfd.FileName);
            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
                MessageBox.Show("Report successfully uploaded to Excel");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv_Report.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgv_Report.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            ExportToExcel(dt);
        }
    }
}
