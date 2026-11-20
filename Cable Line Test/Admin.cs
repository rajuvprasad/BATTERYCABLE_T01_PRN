using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class Admin : Form
    {
        private string action = null;
        private string selectedEmpNumber = null;

        public Admin()
        {
            InitializeComponent();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left, statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }

            var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configSettings.AppSettings.Settings;

            if (settings["MACHINE_ID"] != null)
            {
                txt_MachineID.Text = settings["MACHINE_ID"].Value;
            }

            display_Employee_Data();
        }

        private void display_Employee_Data()
        {
            dgv_Employee_List.DataSource = null;
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE_INFO WHERE IS_ACTIVE = " + true, dbCon);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.DefaultView.RowFilter = "EMPLOYEE_NUMBER NOT IN ('iracrat')";

                dgv_Employee_List.AutoGenerateColumns = false;
                dgv_Employee_List.DataSource = dataTable;
                dgv_Employee_List.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgv_Employee_List.ClearSelection();
            }

            int i = 1;
            foreach (DataGridViewRow row in dgv_Employee_List.Rows)
                row.Cells["SlNo"].Value = i++;
        }

        private void dgv_Employee_List_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Employee_List.Rows[e.RowIndex];

                txt_EmpName.Text = row.Cells["EMPLOYEE_FULL_NAME"].Value.ToString();
                txt_EmpNum.Text = row.Cells["EMPLOYEE_NUMBER"].Value.ToString();
                selectedEmpNumber = row.Cells["EMPLOYEE_NUMBER"].Value.ToString();
                txt_Password.Text = row.Cells["PASSWORD"].Value.ToString();
                txt_Designation.Text = row.Cells["DESIGNATION"].Value.ToString();
                txt_Department.Text = row.Cells["DEPARTMENT"].Value.ToString();
                txt_MobileNumber.Text = row.Cells["MOBILE_NUMBER"].Value.ToString();

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                disable_Components();
            }
        }

        private void disable_Components()
        {
            txt_EmpName.Enabled = false;
            txt_EmpNum.Enabled = false;
            txt_Password.Enabled = false;
            txt_Designation.Enabled = false;
            txt_Department.Enabled = false;
            txt_MobileNumber.Enabled = false;
            pb_FingerPrint.Enabled = false;
        }

        private void dgv_Employee_List_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                case Keys.Tab:
                case Keys.Enter:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.End:
                case Keys.Home:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void reset_Form()
        {
            txt_EmpName.Text = string.Empty;
            txt_EmpNum.Text = string.Empty;
            txt_Password.Text = string.Empty;
            txt_Designation.Text = string.Empty;
            txt_Department.Text = string.Empty;
            txt_MobileNumber.Text = string.Empty;
            pb_FingerPrint.Image = null;
        }

        private void dgv_Employee_List_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private bool validate_Components()
        {
            bool rslt = false;

            if (txt_EmpName.Text.Trim() != string.Empty &&
                txt_EmpNum.Text.Trim() != string.Empty &&
                txt_Password.Text.Trim() != string.Empty &&
                txt_Designation.Text.Trim() != string.Empty &&
                txt_Department.Text.Trim() != string.Empty &&
                txt_MobileNumber.Text.Trim() != string.Empty)
            {
                rslt = true;
            }

            return rslt;
        }

        private void enable_Components(String action)
        {
            if (action.Equals("ADD"))
            {
                txt_EmpName.Enabled = true;
                txt_EmpNum.Enabled = true;
                txt_Password.Enabled = true;
                txt_Designation.Enabled = true;
                txt_Department.Enabled = true;
                txt_MobileNumber.Enabled = true;
                pb_FingerPrint.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            else if (action.Equals("EDIT"))
            {
                txt_Password.Enabled = true;
                txt_Designation.Enabled = true;
                txt_Department.Enabled = true;
                txt_MobileNumber.Enabled = true;
                pb_FingerPrint.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                Console.WriteLine("action is null : " + action);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            action = "ADD";
            enable_Components(action);
            dgv_Employee_List.ClearSelection();
            reset_Form();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            action = "EDIT";
            enable_Components(action);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validation = validate_Components();

            if (validation)
                if (action.Equals("ADD"))
                    if (IsEmployeeAlreadyExists())
                        MessageBox.Show("Employee already exists in the database");
                    else
                        Insert_Data();
                else if (action.Equals("EDIT"))
                        Update_Data();
                else
                    Console.WriteLine("action : " + action);
            else
                MessageBox.Show("One or more fields is empty, Please provide all details.");
        }

        private bool IsEmployeeAlreadyExists()
        {
            DataTable dataTable = new DataTable();

            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM EMPLOYEE_INFO", dbCon);
                adapter.Fill(dataTable);
            }

            bool employeeExists = dataTable.Select().ToList().Exists(row => row["EMPLOYEE_NUMBER"].ToString().ToUpper() == txt_EmpNum.Text.ToString().ToUpper());

            return employeeExists;
        }

        private void Insert_Data()
        {
            Console.WriteLine("Password : " + txt_Password.Text.Trim());
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = " INSERT INTO EMPLOYEE_INFO (EMPLOYEE_FULL_NAME, EMPLOYEE_NUMBER, [PASSWORD], DESIGNATION, DEPARTMENT, MOBILE_NUMBER, IS_ACTIVE) " +
                    " VALUES (@empName, @empNum, @pass, @designation, @dept, @mobile, @isActive) ";
                cmd.Parameters.AddWithValue("empName", txt_EmpName.Text.Trim());
                cmd.Parameters.AddWithValue("empNum", txt_EmpNum.Text.Trim());
                string ePass = Helper.ComputeHash(txt_Password.Text, "SHA512", null);
                cmd.Parameters.AddWithValue("pass", ePass);
                cmd.Parameters.AddWithValue("designation", txt_Designation.Text.Trim());
                cmd.Parameters.AddWithValue("dept", txt_Department.Text.Trim());
                cmd.Parameters.AddWithValue("mobile", txt_MobileNumber.Text.Trim());
                cmd.Parameters.AddWithValue("isActive", true);
                dbCon.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("Number of records inserted in the database : " + i);
            }

            MessageBox.Show("Record Inserted Successfully");
            display_Employee_Data();
            disable_Components();
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            reset_Form();
        }

        private void Update_Data()
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = " UPDATE EMPLOYEE_INFO SET [PASSWORD] = @pass, DESIGNATION = @designation, DEPARTMENT = @dept, " +
                    " MOBILE_NUMBER = @mobile WHERE EMPLOYEE_NUMBER = @empNum ";
                string ePass = Helper.ComputeHash(txt_Password.Text, "SHA512", null);
                cmd.Parameters.AddWithValue("pass", ePass);
                cmd.Parameters.AddWithValue("designation", txt_Designation.Text.Trim());
                cmd.Parameters.AddWithValue("dept", txt_Department.Text.Trim());
                cmd.Parameters.AddWithValue("mobile", txt_MobileNumber.Text.Trim());
                cmd.Parameters.AddWithValue("empNum", txt_EmpNum.Text.Trim());
                dbCon.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Record Updated Successfully");
            display_Employee_Data();
            disable_Components();
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            reset_Form();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure, you want to delete user '" + selectedEmpNumber + "' from the database?";
            string title = "Confirm Deletion";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                return;
            }
            else if (result == DialogResult.OK)
            {
                using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = " UPDATE EMPLOYEE_INFO SET IS_ACTIVE = @isActive WHERE EMPLOYEE_NUMBER = @empNum ";
                    cmd.Parameters.AddWithValue("isActive", false);
                    cmd.Parameters.AddWithValue("empNum", selectedEmpNumber);
                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                }
                display_Employee_Data();
                reset_Form();
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void btn_SetMachineID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MachineID.Text))
            {
                MessageBox.Show("Machine ID CANNOT be NULL or empty spaces.");
                txt_MachineID.Text = "";
                txt_MachineID.Select();
            }
            else if (txt_MachineID.Text.Trim().Length != 3)
            {
                MessageBox.Show("Machine ID MUST be three(3) characters in length.");
                txt_MachineID.Text = "";
                txt_MachineID.Select();
            }
            else
            {
                var configSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configSettings.AppSettings.Settings;

                if (settings["MACHINE_ID"] == null)
                    settings.Add("MACHINE_ID", txt_MachineID.Text);
                else if (settings["MACHINE_ID"].Value == txt_MachineID.Text)
                    MessageBox.Show("NEW Machine ID is the same as OLD Machine ID");
                else
                    settings["MACHINE_ID"].Value = txt_MachineID.Text;

                configSettings.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
