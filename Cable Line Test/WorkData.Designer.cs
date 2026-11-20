namespace Cable_Line_Test
{
    partial class WorkData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.cb_PartStatus = new System.Windows.Forms.ComboBox();
            this.cb_Result = new System.Windows.Forms.ComboBox();
            this.cb_PartNumber = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblPartStatus = new System.Windows.Forms.Label();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.dgv_Report = new System.Windows.Forms.DataGridView();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PART_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACHINE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OVERALL_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR_MAKER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PART_MAKER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSMISSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR_MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENGINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VARIANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Report)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 681);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_Search);
            this.splitContainer2.Panel1.Controls.Add(this.btn_ExportToExcel);
            this.splitContainer2.Panel1.Controls.Add(this.cb_PartStatus);
            this.splitContainer2.Panel1.Controls.Add(this.cb_Result);
            this.splitContainer2.Panel1.Controls.Add(this.cb_PartNumber);
            this.splitContainer2.Panel1.Controls.Add(this.lblResult);
            this.splitContainer2.Panel1.Controls.Add(this.lblPartStatus);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker_EndDate);
            this.splitContainer2.Panel1.Controls.Add(this.lblEndDate);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker_StartDate);
            this.splitContainer2.Panel1.Controls.Add(this.lblStartDate);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_PartNumber);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_Report);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 646);
            this.splitContainer2.SplitterDistance = 77;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Image = global::Cable_Line_Test.Properties.Resources.search;
            this.btn_Search.Location = new System.Drawing.Point(1059, 22);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(35, 35);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Search, "Search");
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ExportToExcel.FlatAppearance.BorderSize = 0;
            this.btn_ExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportToExcel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportToExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ExportToExcel.Image = global::Cable_Line_Test.Properties.Resources.excelexport;
            this.btn_ExportToExcel.Location = new System.Drawing.Point(1115, 22);
            this.btn_ExportToExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(35, 35);
            this.btn_ExportToExcel.TabIndex = 0;
            this.btn_ExportToExcel.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_ExportToExcel, "Export To Excel");
            this.btn_ExportToExcel.UseVisualStyleBackColor = false;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // cb_PartStatus
            // 
            this.cb_PartStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PartStatus.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_PartStatus.FormattingEnabled = true;
            this.cb_PartStatus.Items.AddRange(new object[] {
            "ALL",
            "ACTIVE",
            "INACTIVE"});
            this.cb_PartStatus.Location = new System.Drawing.Point(821, 43);
            this.cb_PartStatus.Name = "cb_PartStatus";
            this.cb_PartStatus.Size = new System.Drawing.Size(121, 23);
            this.cb_PartStatus.TabIndex = 21;
            // 
            // cb_Result
            // 
            this.cb_Result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Result.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Result.FormattingEnabled = true;
            this.cb_Result.Items.AddRange(new object[] {
            "ALL",
            "OK",
            "NG"});
            this.cb_Result.Location = new System.Drawing.Point(821, 18);
            this.cb_Result.Name = "cb_Result";
            this.cb_Result.Size = new System.Drawing.Size(121, 23);
            this.cb_Result.TabIndex = 20;
            // 
            // cb_PartNumber
            // 
            this.cb_PartNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PartNumber.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_PartNumber.FormattingEnabled = true;
            this.cb_PartNumber.Location = new System.Drawing.Point(126, 29);
            this.cb_PartNumber.Name = "cb_PartNumber";
            this.cb_PartNumber.Size = new System.Drawing.Size(199, 23);
            this.cb_PartNumber.TabIndex = 19;
            this.cb_PartNumber.SelectedIndexChanged += new System.EventHandler(this.cb_PartNumber_SelectedIndexChanged);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(715, 11);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(100, 35);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "RESULT :";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPartStatus
            // 
            this.lblPartStatus.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartStatus.Location = new System.Drawing.Point(693, 36);
            this.lblPartStatus.Name = "lblPartStatus";
            this.lblPartStatus.Size = new System.Drawing.Size(105, 35);
            this.lblPartStatus.TabIndex = 15;
            this.lblPartStatus.Text = "PART STATUS :";
            this.lblPartStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.CalendarFont = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(459, 44);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(216, 23);
            this.dateTimePicker_EndDate.TabIndex = 0;
            this.dateTimePicker_EndDate.TabStop = false;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2017, 12, 29, 0, 0, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(355, 36);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(100, 35);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "END DATE :";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.CalendarFont = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(459, 15);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(216, 23);
            this.dateTimePicker_StartDate.TabIndex = 0;
            this.dateTimePicker_StartDate.TabStop = false;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2017, 12, 29, 0, 0, 0, 0);
            this.dateTimePicker_StartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_StartDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(353, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(93, 35);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "START DATE :";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PartNumber.Location = new System.Drawing.Point(15, 22);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(105, 35);
            this.lbl_PartNumber.TabIndex = 1;
            this.lbl_PartNumber.Text = "PART NUMBER :";
            this.lbl_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Report
            // 
            this.dgv_Report.AllowUserToAddRows = false;
            this.dgv_Report.AllowUserToDeleteRows = false;
            this.dgv_Report.AllowUserToResizeColumns = false;
            this.dgv_Report.AllowUserToResizeRows = false;
            this.dgv_Report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Report.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Report.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Report.ColumnHeadersHeight = 30;
            this.dgv_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlNo,
            this.PART_NUMBER,
            this.MACHINE_ID,
            this.LOT_ID,
            this.DATETIME,
            this.OVERALL_STATUS,
            this.CAR_MAKER,
            this.PART_MAKER,
            this.ALC,
            this.TRANSMISSION,
            this.CAR_MODEL,
            this.ENGINE,
            this.VARIANT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Report.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Report.EnableHeadersVisualStyles = false;
            this.dgv_Report.GridColor = System.Drawing.Color.LightGray;
            this.dgv_Report.Location = new System.Drawing.Point(0, 0);
            this.dgv_Report.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_Report.MultiSelect = false;
            this.dgv_Report.Name = "dgv_Report";
            this.dgv_Report.ReadOnly = true;
            this.dgv_Report.RowHeadersVisible = false;
            this.dgv_Report.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_Report.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Report.Size = new System.Drawing.Size(1264, 565);
            this.dgv_Report.TabIndex = 0;
            this.dgv_Report.TabStop = false;
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
            // PART_NUMBER
            // 
            this.PART_NUMBER.DataPropertyName = "PART_NUMBER";
            this.PART_NUMBER.FillWeight = 80.83756F;
            this.PART_NUMBER.HeaderText = "PART NUMBER";
            this.PART_NUMBER.MinimumWidth = 100;
            this.PART_NUMBER.Name = "PART_NUMBER";
            this.PART_NUMBER.ReadOnly = true;
            // 
            // MACHINE_ID
            // 
            this.MACHINE_ID.DataPropertyName = "MACHINE_ID";
            this.MACHINE_ID.FillWeight = 80.83756F;
            this.MACHINE_ID.HeaderText = "MACHINE ID";
            this.MACHINE_ID.MinimumWidth = 50;
            this.MACHINE_ID.Name = "MACHINE_ID";
            this.MACHINE_ID.ReadOnly = true;
            // 
            // LOT_ID
            // 
            this.LOT_ID.DataPropertyName = "LOT_ID";
            this.LOT_ID.FillWeight = 80.83756F;
            this.LOT_ID.HeaderText = "LOT ID";
            this.LOT_ID.MinimumWidth = 100;
            this.LOT_ID.Name = "LOT_ID";
            this.LOT_ID.ReadOnly = true;
            // 
            // DATETIME
            // 
            this.DATETIME.DataPropertyName = "DATETIME";
            this.DATETIME.FillWeight = 80.83756F;
            this.DATETIME.HeaderText = "CREATED DATE";
            this.DATETIME.MinimumWidth = 100;
            this.DATETIME.Name = "DATETIME";
            this.DATETIME.ReadOnly = true;
            // 
            // OVERALL_STATUS
            // 
            this.OVERALL_STATUS.DataPropertyName = "OVERALL_STATUS";
            this.OVERALL_STATUS.FillWeight = 80.83756F;
            this.OVERALL_STATUS.HeaderText = "STATUS";
            this.OVERALL_STATUS.MinimumWidth = 50;
            this.OVERALL_STATUS.Name = "OVERALL_STATUS";
            this.OVERALL_STATUS.ReadOnly = true;
            // 
            // CAR_MAKER
            // 
            this.CAR_MAKER.DataPropertyName = "CAR_MAKER";
            this.CAR_MAKER.FillWeight = 80.83756F;
            this.CAR_MAKER.HeaderText = "CAR MAKER";
            this.CAR_MAKER.MinimumWidth = 80;
            this.CAR_MAKER.Name = "CAR_MAKER";
            this.CAR_MAKER.ReadOnly = true;
            // 
            // PART_MAKER
            // 
            this.PART_MAKER.DataPropertyName = "PART_MAKER";
            this.PART_MAKER.FillWeight = 80.83756F;
            this.PART_MAKER.HeaderText = "PART MAKER";
            this.PART_MAKER.MinimumWidth = 80;
            this.PART_MAKER.Name = "PART_MAKER";
            this.PART_MAKER.ReadOnly = true;
            // 
            // ALC
            // 
            this.ALC.DataPropertyName = "ALC";
            this.ALC.FillWeight = 80.83756F;
            this.ALC.HeaderText = "ALC CODE";
            this.ALC.MinimumWidth = 50;
            this.ALC.Name = "ALC";
            this.ALC.ReadOnly = true;
            // 
            // TRANSMISSION
            // 
            this.TRANSMISSION.DataPropertyName = "TRANSMISSION";
            this.TRANSMISSION.FillWeight = 80.83756F;
            this.TRANSMISSION.HeaderText = "AT/MT";
            this.TRANSMISSION.MinimumWidth = 50;
            this.TRANSMISSION.Name = "TRANSMISSION";
            this.TRANSMISSION.ReadOnly = true;
            // 
            // CAR_MODEL
            // 
            this.CAR_MODEL.DataPropertyName = "CAR_MODEL";
            this.CAR_MODEL.FillWeight = 80.83756F;
            this.CAR_MODEL.HeaderText = "MODEL";
            this.CAR_MODEL.MinimumWidth = 80;
            this.CAR_MODEL.Name = "CAR_MODEL";
            this.CAR_MODEL.ReadOnly = true;
            // 
            // ENGINE
            // 
            this.ENGINE.DataPropertyName = "ENGINE";
            this.ENGINE.FillWeight = 80.83756F;
            this.ENGINE.HeaderText = "ENGINE";
            this.ENGINE.MinimumWidth = 80;
            this.ENGINE.Name = "ENGINE";
            this.ENGINE.ReadOnly = true;
            // 
            // VARIANT
            // 
            this.VARIANT.DataPropertyName = "VARIANT";
            this.VARIANT.FillWeight = 80.83756F;
            this.VARIANT.HeaderText = "VARIANT";
            this.VARIANT.MinimumWidth = 50;
            this.VARIANT.Name = "VARIANT";
            this.VARIANT.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 31);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
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
            // WorkData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "WorkData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA CONSOLE";
            this.Load += new System.EventHandler(this.WorkData_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Report)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv_Report;
        private System.Windows.Forms.Label lbl_PartNumber;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.ComboBox cb_Result;
        private System.Windows.Forms.ComboBox cb_PartNumber;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblPartStatus;
        private System.Windows.Forms.ComboBox cb_PartStatus;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHINE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OVERALL_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAR_MAKER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_MAKER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSMISSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAR_MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENGINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VARIANT;
    }
}