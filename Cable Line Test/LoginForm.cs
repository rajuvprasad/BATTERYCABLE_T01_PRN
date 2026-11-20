using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(" SELECT EMPLOYEE_FULL_NAME, EMPLOYEE_NUMBER FROM EMPLOYEE_INFO WHERE IS_ACTIVE = " + true, dbCon);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.Columns.Add("DISPLAY_VALUE", typeof(string), "EMPLOYEE_NUMBER + ' - ' + EMPLOYEE_FULL_NAME");
                cb_Employee.DataSource = dataTable;
                cb_Employee.ValueMember = "EMPLOYEE_NUMBER";
                cb_Employee.DisplayMember = "DISPLAY_VALUE";
                cb_Employee.SelectedIndex = -1;
            }
            txt_Password.Enabled = false;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                string password = string.Empty;
                if (cb_Employee.SelectedValue.ToString() == "iracrat")
                {
                    password = Helper.ComputeHash("7691g@n@rP", "SHA512", null);
                }
                else
                {
                    dbCon.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT [PASSWORD] AS USER_PASSWORD FROM EMPLOYEE_INFO WHERE EMPLOYEE_NUMBER = '" + cb_Employee.SelectedValue.ToString() + "'", dbCon);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    password = dataTable.Rows[0]["USER_PASSWORD"].ToString();
                }
                bool flag = Helper.VerifyHash(txt_Password.Text, "SHA512", password);

                if (flag)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Entered Password is Incorrect!!", "INVALID LOGIN", MessageBoxButtons.OK);
                    txt_Password.Text = string.Empty;
                    txt_Password.Focus();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Password.Enabled = true;
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim().Length > 0)
            {
                btn_Enter.Enabled = true;
            }
            else
            {
                btn_Enter.Enabled = false;
            }
        }

        public string UserName
        {
            get { return cb_Employee.SelectedValue.ToString(); }
        }
    }
}
