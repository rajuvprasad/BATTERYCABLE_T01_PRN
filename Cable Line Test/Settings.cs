using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System;

namespace Cable_Line_Test
{
    public partial class Settings : Form
    {
        //String connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\CLT.accdb;Jet OLEDB:Database Password=mypassword";

        private string action = null;
        private string selectedPartNumber = null;
        private OpenFileDialog ofd;
        private string user = string.Empty;

        private string[] barcodePrintFileNamesArray;
        private DataTable barcodePrintFileNamesDataTable = new DataTable();

        public Settings()
        {
            InitializeComponent();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left, statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = @"D:\PartImage",
                Title = "Browse Image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image Files (*.png, *.gif, *.jpg)|*.png; *.gif*;*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            //user = "Test";
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                user = frm.UserName;

                //MessageBox.Show("Logged in User Name: " + user);

                if (Common.Utils.getPixels(10M) == 0)
                {
                    MessageBox.Show("Monitor/Screen Size is NOT set. Please go to COMPort Settings Form and update Screen Size.");
                    this.Close();
                }

                barcodePrintFileNamesDataTable.Columns.AddRange(new DataColumn[2] { new DataColumn("DISPLAY_MEMBER", typeof(string)), new DataColumn("VALUE_MEMBER", typeof(string)) });
                barcodePrintFileNamesDataTable.PrimaryKey = new DataColumn[] { barcodePrintFileNamesDataTable.Columns["DISPLAY_MEMBER"] };

                loadBarcodePrintFileNamesList();
                display_Parts();
            }
            else
            {
                this.Close();
            }
        }

        private void loadBarcodePrintFileNamesList()
        {
            string barcodePrintFileNames = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BarcodePrintFileNames.txt"));
            if (barcodePrintFileNames.Length > 0)
            {
                barcodePrintFileNamesArray = barcodePrintFileNames.Split(',');
                barcodePrintFileNamesDataTable.Clear();
                DataRow dr = barcodePrintFileNamesDataTable.NewRow();
                dr[0] = " - - Select Barcode Print File Name ";
                dr[1] = "0";
                barcodePrintFileNamesDataTable.Rows.Add(dr);

                foreach (string item in barcodePrintFileNamesArray)
                    if (!barcodePrintFileNamesDataTable.Rows.Contains(item))
                    {
                        dr = barcodePrintFileNamesDataTable.NewRow();
                        dr[0] = item;
                        dr[1] = item;
                        barcodePrintFileNamesDataTable.Rows.Add(dr);
                    }
                cb_PrintFileList.DataSource = barcodePrintFileNamesDataTable;
                cb_PrintFileList.DisplayMember = "DISPLAY_MEMBER";
                cb_PrintFileList.ValueMember = "VALUE_MEMBER";
                cb_PrintFileList.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Barcode Print File Names text file is empty!!");
            }
        }

        private void display_Parts()
        {
            dGV_Parts_Details.DataSource = null;
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PART_DETAILS WHERE IS_ACTIVE = " + true, dbCon);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dGV_Parts_Details.AutoGenerateColumns = false;
                dGV_Parts_Details.DataSource = dataTable;
                dGV_Parts_Details.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dGV_Parts_Details.ClearSelection();
            }

            int i = 1;
            foreach (DataGridViewRow row in dGV_Parts_Details.Rows)
                row.Cells["SlNo"].Value = i++;
        }

        private void reset_LineDetails()
        {
            dGV_DIO_Line_Details.DataSource = null;
            if (dGV_DIO_Line_Details.Rows.Count > 0)
            {
                dGV_DIO_Line_Details.Rows.Clear();
                dGV_DIO_Line_Details.Refresh();
            }

            for (int i = 0; i < 24;)
            {
                dGV_DIO_Line_Details.Rows.Add(++i, "", "99", "");
            }
            dGV_DIO_Line_Details.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dGV_DIO_Line_Details.ClearSelection();
            dGV_DIO_Line_Details.Enabled = false;
        }

        private void dGV_Parts_Details_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGV_Parts_Details.Rows[e.RowIndex];
                string imagePath = row.Cells["IMAGE_PATH"].Value.ToString();
                string barcodePrintFileName = row.Cells["BARCODE_PRN_FILE_NAME"].Value.ToString();

                txt_CarMaker.Text = row.Cells["CAR_MAKER"].Value.ToString();
                txt_PartName.Text = row.Cells["PART_NAME"].Value.ToString();
                txt_PartNumber.Text = row.Cells["PART_NUMBER"].Value.ToString();
                selectedPartNumber = row.Cells["PART_NUMBER"].Value.ToString();
                txt_ALC.Text = row.Cells["ALC"].Value.ToString();
                if (!string.IsNullOrEmpty(barcodePrintFileName))
                    cb_PrintFileList.SelectedIndex = cb_PrintFileList.FindString(barcodePrintFileName);
                cb_Transmission.SelectedIndex = cb_Transmission.FindString(row.Cells["TRANSMISSION"].Value.ToString());
                txt_CarModel.Text = row.Cells["CAR_MODEL"].Value.ToString();
                txt_Engine.Text = row.Cells["ENGINE"].Value.ToString();
                txt_Variant.Text = row.Cells["VARIANT"].Value.ToString();
                txt_ImagePath.Text = imagePath;
                if (imagePath.Length > 0)
                {
                    pictureBox_PartImage.Image = Image.FromFile(imagePath);
                    resizePictureBoxImage(pictureBox_PartImage);
                }
                else
                {
                    pictureBox_PartImage.Image = null;
                    pictureBox_PartImage.Invalidate();
                }
 
                using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                {
                    dbCon.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM DIGITAL_IO_LINE_DETAILS ORDER BY SL_NO", dbCon);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataTable.DefaultView.RowFilter = "DILD_PART_NUMBER = '" + selectedPartNumber + "'";

                    dGV_DIO_Line_Details.AutoGenerateColumns = false;
                    dGV_DIO_Line_Details.DataSource = dataTable;
                    dGV_DIO_Line_Details.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                    dGV_DIO_Line_Details.ClearSelection();
                    dGV_DIO_Line_Details.Enabled = false;
                }

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnImage.Enabled = false;
                btnSave.Enabled = false;
                disable_Components();
            }
        }

        private void dGV_DIO_Line_Details_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dGV_DIO_Line_Details.Columns["LINE"].Index)
                {
                    DataGridViewRow row = dGV_DIO_Line_Details.Rows[e.RowIndex];
                    int i = e.RowIndex + 1;
                    if (row.Cells["LINE"].Value.ToString().Equals("99"))
                        row.Cells["LINE"].Value = i.ToString();
                    else if (row.Cells["LINE"].Value.ToString().Equals(i.ToString()))
                        row.Cells["LINE"].Value = "R" + i.ToString();
                    else
                        row.Cells["LINE"].Value = "99";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            action = "ADD";
            enable_Components(action);
            dGV_Parts_Details.ClearSelection();

            reset_Form();
            dGV_DIO_Line_Details.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            action = "EDIT";
            enable_Components(action);
        }

        private bool isPartOrALCExists()
        {
            DataTable dataTable = new DataTable();

            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            {
                dbCon.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM PART_DETAILS", dbCon);
                adapter.Fill(dataTable);
            }

            bool partNumberExists = dataTable.Select().ToList().Exists(row => row["PART_NUMBER"].ToString().ToUpper() == txt_PartNumber.Text.ToString().ToUpper());
            bool alcExists = dataTable.Select().ToList().Exists(row => row["ALC"].ToString().ToUpper() == txt_ALC.Text.ToString().ToUpper());

            return (partNumberExists || alcExists);
        }

        private bool isLineSelected()
        {
            foreach (DataGridViewRow row in dGV_DIO_Line_Details.Rows)
            {
                if (!row.Cells["LINE"].Value.ToString().Equals("99"))
                    return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validation = validate_Components();

            if (validation)
                if (action.Equals("ADD"))
                    if (isPartOrALCExists())
                        MessageBox.Show("Part Number/ALC Code already exists in the database");
                    else if (!isLineSelected())
                        MessageBox.Show("At least one input/output line need to be selected");
                    else
                        insert_Data();
                else if (action.Equals("EDIT"))
                    if (!isLineSelected())
                        MessageBox.Show("At least one input/output line need to be selected");
                    else
                        update_Data();
                else
                    Console.WriteLine("action : " + action);
            else
                MessageBox.Show("One or more fields is empty, Please provide all details.");
        }

        private DateTime GetDateWithoutMilliseconds(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        private void insert_Data()
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = " INSERT INTO PART_DETAILS (CAR_MAKER, PART_NAME, PART_NUMBER, ALC, TRANSMISSION, CAR_MODEL, ENGINE, VARIANT, " +
                    " IMAGE_PATH, BARCODE_PRN_FILE_NAME, CREATED_BY, CREATION_DATE, MODIFIED_BY, MODIFIED_DATE, IS_ACTIVE) " +
                    " VALUES (@carMaker, @partName, @partNumber, @alc, @transmission, @carModel, @engine, @variant, " +
                    " @imagePath, @barcodePrintFileName, @createdBy, @creationDate, @modifiedBy, @modifiedDate, @isActive) ";
                cmd.Parameters.AddWithValue("carMaker", txt_CarMaker.Text.Trim());
                cmd.Parameters.AddWithValue("partName", txt_PartName.Text.Trim());
                cmd.Parameters.AddWithValue("partNumber", txt_PartNumber.Text.Trim());
                cmd.Parameters.AddWithValue("alc", txt_ALC.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("transmission", cb_Transmission.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("carModel", txt_CarModel.Text.Trim());
                cmd.Parameters.AddWithValue("engine", txt_Engine.Text.Trim());
                cmd.Parameters.AddWithValue("variant", txt_Variant.Text.Trim());
                cmd.Parameters.AddWithValue("imagePath", txt_ImagePath.Text);
                cmd.Parameters.AddWithValue("barcodePrintFileName", cb_PrintFileList.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("createdBy", user);
                cmd.Parameters.AddWithValue("creationDate", GetDateWithoutMilliseconds(DateTime.Now));
                cmd.Parameters.AddWithValue("modifiedBy", user);
                cmd.Parameters.AddWithValue("modifiedDate", GetDateWithoutMilliseconds(DateTime.Now));
                cmd.Parameters.AddWithValue("isActive", true);
                dbCon.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("Number of records inserted in the database : " + i);
            }

            foreach (DataGridViewRow row in dGV_DIO_Line_Details.Rows)
                using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                using (var cmd = dbCon.CreateCommand())
                {
                    cmd.CommandText = " INSERT INTO DIGITAL_IO_LINE_DETAILS (SL_NO, OUT_TITLE, IN_TITLE, LINE, DILD_PART_NUMBER) " +
                        " VALUES (@slNo, @outTitle, @inTitle, @line, @partNumber) ";
                    cmd.Parameters.AddWithValue("slNo", row.Cells["SL_NO"].Value.ToString());
                    cmd.Parameters.AddWithValue("outTitle", row.Cells["OUT_TITLE"].Value.ToString().Trim());
                    cmd.Parameters.AddWithValue("inTitle", row.Cells["IN_TITLE"].Value.ToString().Trim());
                    cmd.Parameters.AddWithValue("line", row.Cells["LINE"].Value.ToString());
                    cmd.Parameters.AddWithValue("partNumber", txt_PartNumber.Text.Trim());
                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                }
            MessageBox.Show("Record Inserted Successfully");
            display_Parts();
            disable_Components();
            btnSave.Enabled = false;
            btnImage.Enabled = false;
            reset_Form();
        }

        private void update_Data()
        {
            using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = " UPDATE PART_DETAILS SET CAR_MAKER = @carMaker, PART_NAME = @partName, TRANSMISSION = @transmission, " +
                    " CAR_MODEL = @carModel, ENGINE = @engine, VARIANT = @variant, IMAGE_PATH = @imagePath, BARCODE_PRN_FILE_NAME = @barcodePrintFileName, " +
                    " MODIFIED_BY = @modifiedBy, MODIFIED_DATE = @modifiedDate WHERE PART_NUMBER = @partNumber ";
                cmd.Parameters.AddWithValue("carMaker", txt_CarMaker.Text.Trim());
                cmd.Parameters.AddWithValue("partName", txt_PartName.Text.Trim());
                cmd.Parameters.AddWithValue("transmission", cb_Transmission.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("carModel", txt_CarModel.Text.Trim());
                cmd.Parameters.AddWithValue("engine", txt_Engine.Text.Trim());
                cmd.Parameters.AddWithValue("variant", txt_Variant.Text.Trim());
                cmd.Parameters.AddWithValue("imagePath", txt_ImagePath.Text);
                cmd.Parameters.AddWithValue("barcodePrintFileName", cb_PrintFileList.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("modifiedBy", user);
                cmd.Parameters.AddWithValue("modifiedDate", GetDateWithoutMilliseconds(DateTime.Now));
                cmd.Parameters.AddWithValue("partNumber", txt_PartNumber.Text.Trim());
                dbCon.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("dGV_DIO_Line_Details.Rows.Count : " + dGV_DIO_Line_Details.Rows.Count);
            foreach (DataGridViewRow row in dGV_DIO_Line_Details.Rows)
                using (OleDbConnection dbCon = new OleDbConnection(Properties.Settings.Default.CLTConnectionString))
                    using (var cmd = dbCon.CreateCommand())
                    {
                        cmd.CommandText = " UPDATE DIGITAL_IO_LINE_DETAILS SET OUT_TITLE = @outTitle, IN_TITLE = @inTitle, LINE = @line " +
                        " WHERE DILD_PART_NUMBER = @partNumber AND SL_NO =  @slNo ";
                        cmd.Parameters.AddWithValue("outTitle", row.Cells["OUT_TITLE"].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("inTitle", row.Cells["IN_TITLE"].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("line", row.Cells["LINE"].Value.ToString());
                        cmd.Parameters.AddWithValue("partNumber", txt_PartNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("slNo", row.Cells["SL_NO"].Value);
                        dbCon.Open();
                        cmd.ExecuteNonQuery();
                    }
            MessageBox.Show("Record Updated Successfully");
            display_Parts();
            disable_Components();
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnImage.Enabled = false;
            reset_Form();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure, you want to delete "+ selectedPartNumber + " Part Number from the database?";
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
                    cmd.CommandText = " UPDATE PART_DETAILS SET IS_ACTIVE = @isActive WHERE PART_NUMBER = @partNumber ";
                    cmd.Parameters.AddWithValue("isActive", false);
                    cmd.Parameters.AddWithValue("partNumber", selectedPartNumber);
                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                }
                display_Parts();
                reset_Form();
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnImage.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private bool validate_Components()
        {
            bool rslt = false;

            if (txt_CarMaker.Text.Trim() != string.Empty &&
                txt_ALC.Text.Trim() != string.Empty &&
                txt_PartName.Text.Trim() != string.Empty &&
                txt_PartNumber.Text.Trim() != string.Empty &&
                txt_CarModel.Text.Trim() != string.Empty &&
                txt_Engine.Text.Trim() != string.Empty &&
                txt_Variant.Text.Trim() != string.Empty &&
                cb_Transmission.SelectedIndex != -1 &&
                cb_PrintFileList.SelectedIndex >= 1)
            {
                rslt = true;
            }

            return rslt;
        }

        private void enable_Components(String action)
        {
            if (action.Equals("ADD"))
            {
                txt_CarMaker.Enabled = true;
                txt_ALC.Enabled = true;
                cb_PrintFileList.Enabled = true;
                txt_PartName.Enabled = true;
                txt_PartNumber.Enabled = true;
                cb_Transmission.Enabled = true;
                txt_CarModel.Enabled = true;
                txt_Engine.Enabled = true;
                txt_Variant.Enabled = true;
                dGV_DIO_Line_Details.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnImage.Enabled = true;
            }
            else if (action.Equals("EDIT"))
            {
                txt_CarMaker.Enabled = true;
                cb_PrintFileList.Enabled = true;
                txt_PartName.Enabled = true;
                cb_Transmission.Enabled = true;
                txt_CarModel.Enabled = true;
                txt_Engine.Enabled = true;
                txt_Variant.Enabled = true;
                dGV_DIO_Line_Details.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnImage.Enabled = true;
            }
            else
            {
                Console.WriteLine("action is null : " + action);
            }
        }

        private void disable_Components()
        {
            txt_CarMaker.Enabled = false;
            txt_ALC.Enabled = false;
            cb_PrintFileList.Enabled = false;
            txt_PartName.Enabled = false;
            txt_PartNumber.Enabled = false;
            cb_Transmission.Enabled = false;
            txt_CarModel.Enabled = false;
            txt_Engine.Enabled = false;
            txt_Variant.Enabled = false;
            dGV_DIO_Line_Details.Enabled = false;
        }

        private void dGV_Parts_Details_KeyDown(object sender, KeyEventArgs e)
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
            txt_CarMaker.Text = string.Empty;
            txt_ALC.Text = string.Empty;
            cb_PrintFileList.SelectedIndex = -1;
            txt_PartName.Text = string.Empty;
            txt_PartNumber.Text = string.Empty;
            cb_Transmission.SelectedIndex = -1;
            txt_CarModel.Text = string.Empty;
            txt_Engine.Text = string.Empty;
            txt_Variant.Text = string.Empty;
            txt_ImagePath.Text = string.Empty;
            pictureBox_PartImage.Image = null;

            reset_LineDetails();
        }

        private void dGV_Parts_Details_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                pictureBox_PartImage.Image = Image.FromFile(ofd.FileName);
                resizePictureBoxImage(pictureBox_PartImage);
                txt_ImagePath.Text = ofd.FileName;
            }
        }

        private void resizePictureBoxImage(PictureBox pictureBox)
        {
            var imageSize = pictureBox.Image.Size;
            var fitSize = pictureBox.ClientSize;
            pictureBox.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
        }
    }
}
