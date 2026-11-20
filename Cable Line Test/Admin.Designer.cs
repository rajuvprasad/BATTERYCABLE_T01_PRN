namespace Cable_Line_Test
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_Employee_List = new System.Windows.Forms.DataGridView();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPLOYEE_FULL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPLOYEE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESIGNATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBILE_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pb_FingerPrint = new System.Windows.Forms.PictureBox();
            this.txt_MobileNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Department = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Designation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_EmpNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt_EmpName = new System.Windows.Forms.TextBox();
            this.lblPartName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_SetMachineID = new System.Windows.Forms.Button();
            this.txt_MachineID = new System.Windows.Forms.TextBox();
            this.lbl_MachineID = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee_List)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FingerPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 31);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1249, 26);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Powered By: IRACRAT. Contact: INFO@IRACRAT.COM, (+91) 99623 44614.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv_Employee_List
            // 
            this.dgv_Employee_List.AllowUserToAddRows = false;
            this.dgv_Employee_List.AllowUserToDeleteRows = false;
            this.dgv_Employee_List.AllowUserToResizeColumns = false;
            this.dgv_Employee_List.AllowUserToResizeRows = false;
            this.dgv_Employee_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Employee_List.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Employee_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Employee_List.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Employee_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Employee_List.ColumnHeadersHeight = 30;
            this.dgv_Employee_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Employee_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlNo,
            this.EMPLOYEE_FULL_NAME,
            this.EMPLOYEE_NUMBER,
            this.DESIGNATION,
            this.DEPARTMENT,
            this.MOBILE_NUMBER,
            this.PASSWORD});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Employee_List.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Employee_List.EnableHeadersVisualStyles = false;
            this.dgv_Employee_List.GridColor = System.Drawing.Color.LightGray;
            this.dgv_Employee_List.Location = new System.Drawing.Point(0, 228);
            this.dgv_Employee_List.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_Employee_List.MultiSelect = false;
            this.dgv_Employee_List.Name = "dgv_Employee_List";
            this.dgv_Employee_List.ReadOnly = true;
            this.dgv_Employee_List.RowHeadersVisible = false;
            this.dgv_Employee_List.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_Employee_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Employee_List.Size = new System.Drawing.Size(1264, 421);
            this.dgv_Employee_List.TabIndex = 0;
            this.dgv_Employee_List.TabStop = false;
            this.dgv_Employee_List.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Employee_List_CellMouseClick);
            this.dgv_Employee_List.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_Employee_List_RowPrePaint);
            this.dgv_Employee_List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Employee_List_KeyDown);
            // 
            // SlNo
            // 
            this.SlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SlNo.FillWeight = 329.9492F;
            this.SlNo.HeaderText = "NO";
            this.SlNo.MinimumWidth = 50;
            this.SlNo.Name = "SlNo";
            this.SlNo.ReadOnly = true;
            this.SlNo.Width = 50;
            // 
            // EMPLOYEE_FULL_NAME
            // 
            this.EMPLOYEE_FULL_NAME.DataPropertyName = "EMPLOYEE_FULL_NAME";
            this.EMPLOYEE_FULL_NAME.FillWeight = 80.83756F;
            this.EMPLOYEE_FULL_NAME.HeaderText = "EMPLOYEE FULL NAME";
            this.EMPLOYEE_FULL_NAME.MinimumWidth = 100;
            this.EMPLOYEE_FULL_NAME.Name = "EMPLOYEE_FULL_NAME";
            this.EMPLOYEE_FULL_NAME.ReadOnly = true;
            // 
            // EMPLOYEE_NUMBER
            // 
            this.EMPLOYEE_NUMBER.DataPropertyName = "EMPLOYEE_NUMBER";
            this.EMPLOYEE_NUMBER.FillWeight = 80.83756F;
            this.EMPLOYEE_NUMBER.HeaderText = "EMPLOYEE NUMBER";
            this.EMPLOYEE_NUMBER.MinimumWidth = 50;
            this.EMPLOYEE_NUMBER.Name = "EMPLOYEE_NUMBER";
            this.EMPLOYEE_NUMBER.ReadOnly = true;
            // 
            // DESIGNATION
            // 
            this.DESIGNATION.DataPropertyName = "DESIGNATION";
            this.DESIGNATION.FillWeight = 80.83756F;
            this.DESIGNATION.HeaderText = "DESIGNATION";
            this.DESIGNATION.MinimumWidth = 100;
            this.DESIGNATION.Name = "DESIGNATION";
            this.DESIGNATION.ReadOnly = true;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.DataPropertyName = "DEPARTMENT";
            this.DEPARTMENT.FillWeight = 80.83756F;
            this.DEPARTMENT.HeaderText = "DEPARTMENT";
            this.DEPARTMENT.MinimumWidth = 100;
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.ReadOnly = true;
            // 
            // MOBILE_NUMBER
            // 
            this.MOBILE_NUMBER.DataPropertyName = "MOBILE_NUMBER";
            this.MOBILE_NUMBER.FillWeight = 80.83756F;
            this.MOBILE_NUMBER.HeaderText = "MOBILE NUMBER";
            this.MOBILE_NUMBER.MinimumWidth = 50;
            this.MOBILE_NUMBER.Name = "MOBILE_NUMBER";
            this.MOBILE_NUMBER.ReadOnly = true;
            // 
            // PASSWORD
            // 
            this.PASSWORD.DataPropertyName = "PASSWORD";
            this.PASSWORD.HeaderText = "PASSWORD";
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.ReadOnly = true;
            this.PASSWORD.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SetMachineID);
            this.panel1.Controls.Add(this.txt_MachineID);
            this.panel1.Controls.Add(this.lbl_MachineID);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pb_FingerPrint);
            this.panel1.Controls.Add(this.txt_MobileNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_Department);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Designation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_EmpNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txt_EmpName);
            this.panel1.Controls.Add(this.lblPartName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 224);
            this.panel1.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.Enabled = false;
            this.txt_Password.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(234, 88);
            this.txt_Password.MaxLength = 16;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(313, 23);
            this.txt_Password.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(128, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 35);
            this.label5.TabIndex = 35;
            this.label5.Text = "PASSWORD :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_FingerPrint
            // 
            this.pb_FingerPrint.BackColor = System.Drawing.Color.White;
            this.pb_FingerPrint.Enabled = false;
            this.pb_FingerPrint.Location = new System.Drawing.Point(644, 30);
            this.pb_FingerPrint.Name = "pb_FingerPrint";
            this.pb_FingerPrint.Size = new System.Drawing.Size(160, 168);
            this.pb_FingerPrint.TabIndex = 33;
            this.pb_FingerPrint.TabStop = false;
            // 
            // txt_MobileNumber
            // 
            this.txt_MobileNumber.Enabled = false;
            this.txt_MobileNumber.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MobileNumber.Location = new System.Drawing.Point(234, 175);
            this.txt_MobileNumber.MaxLength = 10;
            this.txt_MobileNumber.Name = "txt_MobileNumber";
            this.txt_MobileNumber.Size = new System.Drawing.Size(313, 23);
            this.txt_MobileNumber.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 35);
            this.label4.TabIndex = 32;
            this.label4.Text = "MOBILE NUMBER :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Department
            // 
            this.txt_Department.Enabled = false;
            this.txt_Department.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Department.Location = new System.Drawing.Point(234, 146);
            this.txt_Department.MaxLength = 32;
            this.txt_Department.Name = "txt_Department";
            this.txt_Department.Size = new System.Drawing.Size(313, 23);
            this.txt_Department.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 35);
            this.label3.TabIndex = 30;
            this.label3.Text = "DEPARTMENT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Designation
            // 
            this.txt_Designation.Enabled = false;
            this.txt_Designation.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Designation.Location = new System.Drawing.Point(234, 117);
            this.txt_Designation.MaxLength = 32;
            this.txt_Designation.Name = "txt_Designation";
            this.txt_Designation.Size = new System.Drawing.Size(313, 23);
            this.txt_Designation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 35);
            this.label2.TabIndex = 28;
            this.label2.Text = "DESIGNATION :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_EmpNum
            // 
            this.txt_EmpNum.Enabled = false;
            this.txt_EmpNum.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmpNum.Location = new System.Drawing.Point(234, 59);
            this.txt_EmpNum.MaxLength = 8;
            this.txt_EmpNum.Name = "txt_EmpNum";
            this.txt_EmpNum.Size = new System.Drawing.Size(313, 23);
            this.txt_EmpNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 26;
            this.label1.Text = "EMPLOYEE NUMBER :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Cable_Line_Test.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(906, 72);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 32);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "Edit User Details");
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Cable_Line_Test.Properties.Resources.delete1;
            this.btnDelete.Location = new System.Drawing.Point(906, 170);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete User");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Cable_Line_Test.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(906, 25);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAdd, "Add New User");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Image = global::Cable_Line_Test.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(906, 121);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSave, "Save User Details");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt_EmpName
            // 
            this.txt_EmpName.Enabled = false;
            this.txt_EmpName.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmpName.Location = new System.Drawing.Point(234, 30);
            this.txt_EmpName.MaxLength = 64;
            this.txt_EmpName.Name = "txt_EmpName";
            this.txt_EmpName.Size = new System.Drawing.Size(313, 23);
            this.txt_EmpName.TabIndex = 1;
            // 
            // lblPartName
            // 
            this.lblPartName.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartName.Location = new System.Drawing.Point(58, 23);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(170, 35);
            this.lblPartName.TabIndex = 19;
            this.lblPartName.Text = "EMPLOYEE FULL NAME :";
            this.lblPartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SetMachineID
            // 
            this.btn_SetMachineID.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_SetMachineID.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SetMachineID.ForeColor = System.Drawing.Color.White;
            this.btn_SetMachineID.Location = new System.Drawing.Point(1081, 148);
            this.btn_SetMachineID.Name = "btn_SetMachineID";
            this.btn_SetMachineID.Size = new System.Drawing.Size(103, 35);
            this.btn_SetMachineID.TabIndex = 41;
            this.btn_SetMachineID.Text = "SET";
            this.btn_SetMachineID.UseVisualStyleBackColor = false;
            this.btn_SetMachineID.Click += new System.EventHandler(this.btn_SetMachineID_Click);
            // 
            // txt_MachineID
            // 
            this.txt_MachineID.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MachineID.Location = new System.Drawing.Point(1081, 93);
            this.txt_MachineID.MaxLength = 3;
            this.txt_MachineID.Name = "txt_MachineID";
            this.txt_MachineID.Size = new System.Drawing.Size(103, 30);
            this.txt_MachineID.TabIndex = 40;
            this.txt_MachineID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_MachineID
            // 
            this.lbl_MachineID.AutoSize = true;
            this.lbl_MachineID.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MachineID.Location = new System.Drawing.Point(1081, 52);
            this.lbl_MachineID.Name = "lbl_MachineID";
            this.lbl_MachineID.Size = new System.Drawing.Size(94, 19);
            this.lbl_MachineID.TabIndex = 39;
            this.lbl_MachineID.Text = "Machine ID";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Employee_List);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN CONSOLE";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Employee_List)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FingerPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dgv_Employee_List;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_EmpName;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.TextBox txt_EmpNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt_MobileNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Department;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Designation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pb_FingerPrint;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLOYEE_FULL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLOYEE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESIGNATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBILE_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
        private System.Windows.Forms.Button btn_SetMachineID;
        private System.Windows.Forms.TextBox txt_MachineID;
        private System.Windows.Forms.Label lbl_MachineID;
    }
}