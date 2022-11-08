namespace App_OP
{
    partial class FormJournal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgvJournal = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colTreatmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstOrMany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBloodPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournal)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.btnExport);
            this.panelEx1.Controls.Add(this.btnQuery);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.EndTime);
            this.panelEx1.Controls.Add(this.StartTime);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(939, 95);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(268, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(17, 22);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "~";
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(797, 32);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(705, 32);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(479, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 20);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "总接诊人数：0人";
            // 
            // EndTime
            // 
            // 
            // 
            // 
            this.EndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.EndTime.ButtonDropDown.Visible = true;
            this.EndTime.IsPopupCalendarOpen = false;
            this.EndTime.Location = new System.Drawing.Point(306, 32);
            // 
            // 
            // 
            // 
            // 
            // 
            this.EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.EndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EndTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EndTime.MonthCalendar.TodayButtonVisible = true;
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(123, 23);
            this.EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.EndTime.TabIndex = 1;
            this.EndTime.Value = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // StartTime
            // 
            // 
            // 
            // 
            this.StartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.StartTime.ButtonDropDown.Visible = true;
            this.StartTime.IsPopupCalendarOpen = false;
            this.StartTime.Location = new System.Drawing.Point(124, 32);
            // 
            // 
            // 
            // 
            // 
            // 
            this.StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.StartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.StartTime.MonthCalendar.TodayButtonVisible = true;
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(123, 23);
            this.StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StartTime.TabIndex = 0;
            this.StartTime.Value = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.FileName = "门诊日志";
            this.saveFileDialog1.Filter = "EXCEL|*.xls";
            // 
            // dgvJournal
            // 
            this.dgvJournal.AllowUserToAddRows = false;
            this.dgvJournal.AllowUserToDeleteRows = false;
            this.dgvJournal.AllowUserToResizeRows = false;
            this.dgvJournal.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJournal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJournal.ColumnHeadersHeight = 28;
            this.dgvJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvJournal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTreatmentNo,
            this.colPatientName,
            this.colSex,
            this.colAge,
            this.colJob,
            this.colFirstOrMany,
            this.colBloodPressure,
            this.colDA,
            this.colPhone,
            this.colCardNo,
            this.colDiagnosis,
            this.colAddress,
            this.colIDCard,
            this.colUpdateTime,
            this.colDoctorName,
            this.colDeptName,
            this.colRemark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJournal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJournal.EnableHeadersVisualStyles = false;
            this.dgvJournal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvJournal.Location = new System.Drawing.Point(0, 95);
            this.dgvJournal.Name = "dgvJournal";
            this.dgvJournal.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJournal.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJournal.RowHeadersVisible = false;
            this.dgvJournal.RowTemplate.Height = 23;
            this.dgvJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJournal.Size = new System.Drawing.Size(939, 482);
            this.dgvJournal.TabIndex = 12;
            this.dgvJournal.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvJournal_CellMouseDoubleClick);
            // 
            // colTreatmentNo
            // 
            this.colTreatmentNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTreatmentNo.DataPropertyName = "OutpatientNo";
            this.colTreatmentNo.HeaderText = "就诊号";
            this.colTreatmentNo.Name = "colTreatmentNo";
            this.colTreatmentNo.ReadOnly = true;
            this.colTreatmentNo.Width = 74;
            // 
            // colPatientName
            // 
            this.colPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPatientName.DataPropertyName = "PatientName";
            this.colPatientName.HeaderText = "病人姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.Width = 88;
            // 
            // colSex
            // 
            this.colSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSex.DataPropertyName = "Sex";
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 60;
            // 
            // colAge
            // 
            this.colAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAge.DataPropertyName = "Age";
            this.colAge.HeaderText = "年龄";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.Width = 60;
            // 
            // colJob
            // 
            this.colJob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colJob.DataPropertyName = "Job";
            this.colJob.HeaderText = "职业";
            this.colJob.Name = "colJob";
            this.colJob.ReadOnly = true;
            this.colJob.Width = 60;
            // 
            // colFirstOrMany
            // 
            this.colFirstOrMany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFirstOrMany.DataPropertyName = "FirstOrMany";
            this.colFirstOrMany.HeaderText = "初复诊";
            this.colFirstOrMany.Name = "colFirstOrMany";
            this.colFirstOrMany.ReadOnly = true;
            this.colFirstOrMany.Width = 74;
            // 
            // colBloodPressure
            // 
            this.colBloodPressure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBloodPressure.DataPropertyName = "BloodPressure";
            this.colBloodPressure.HeaderText = "血压";
            this.colBloodPressure.Name = "colBloodPressure";
            this.colBloodPressure.ReadOnly = true;
            this.colBloodPressure.Width = 60;
            // 
            // colDA
            // 
            this.colDA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDA.DataPropertyName = "DA";
            this.colDA.HeaderText = "发病日期";
            this.colDA.Name = "colDA";
            this.colDA.ReadOnly = true;
            this.colDA.Width = 88;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPhone.DataPropertyName = "PhoneNumber";
            this.colPhone.HeaderText = "电话";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 60;
            // 
            // colCardNo
            // 
            this.colCardNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCardNo.DataPropertyName = "CardNo";
            this.colCardNo.HeaderText = "卡号";
            this.colCardNo.Name = "colCardNo";
            this.colCardNo.ReadOnly = true;
            this.colCardNo.Width = 60;
            // 
            // colDiagnosis
            // 
            this.colDiagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDiagnosis.DataPropertyName = "Name";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDiagnosis.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDiagnosis.HeaderText = "病人诊断";
            this.colDiagnosis.Name = "colDiagnosis";
            this.colDiagnosis.ReadOnly = true;
            this.colDiagnosis.Width = 88;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "病人地址";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 88;
            // 
            // colIDCard
            // 
            this.colIDCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIDCard.DataPropertyName = "IDCard";
            this.colIDCard.HeaderText = "身份证号";
            this.colIDCard.Name = "colIDCard";
            this.colIDCard.ReadOnly = true;
            this.colIDCard.Width = 88;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUpdateTime.DataPropertyName = "UpdateDate";
            this.colUpdateTime.HeaderText = "就诊时间";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.ReadOnly = true;
            this.colUpdateTime.Width = 88;
            // 
            // colDoctorName
            // 
            this.colDoctorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDoctorName.DataPropertyName = "DoctorName";
            this.colDoctorName.HeaderText = "就诊医生";
            this.colDoctorName.Name = "colDoctorName";
            this.colDoctorName.ReadOnly = true;
            this.colDoctorName.Width = 88;
            // 
            // colDeptName
            // 
            this.colDeptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDeptName.DataPropertyName = "DeptName";
            this.colDeptName.HeaderText = "科室名称";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 88;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 482);
            this.panel1.TabIndex = 20;
            this.panel1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(355, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(238, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(885, 118);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在加载\r\n请稍后";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvJournal);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FormJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊日志";
            this.Shown += new System.EventHandler(this.FormJournal_Shown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput EndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput StartTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTreatmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstOrMany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBloodPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}