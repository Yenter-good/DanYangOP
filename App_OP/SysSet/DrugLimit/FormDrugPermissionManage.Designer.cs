namespace App_OP
{
    partial class FormDrugPermissionManage
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbxDoctor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbxTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbxPatientNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.rbPatientDay = new System.Windows.Forms.RadioButton();
            this.rbPatientMonth = new System.Windows.Forms.RadioButton();
            this.rbAllow = new System.Windows.Forms.RadioButton();
            this.rbBan = new System.Windows.Forms.RadioButton();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDept = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoctor = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTitle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxDept = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.rbDoctorDay = new System.Windows.Forms.RadioButton();
            this.rbDoctorMonth = new System.Windows.Forms.RadioButton();
            this.tbxDoctorNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.cbxNormal = new System.Windows.Forms.RadioButton();
            this.cbxChronic = new System.Windows.Forms.RadioButton();
            this.cbxAll = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitle)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "限制科室：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 153);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 20);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "限制医生：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 300);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 20);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "限制职称：";
            // 
            // tbxDoctor
            // 
            // 
            // 
            // 
            this.tbxDoctor.Border.Class = "TextBoxBorder";
            this.tbxDoctor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDoctor.Location = new System.Drawing.Point(80, 153);
            this.tbxDoctor.Name = "tbxDoctor";
            this.tbxDoctor.PreventEnterBeep = true;
            this.tbxDoctor.Size = new System.Drawing.Size(254, 23);
            this.tbxDoctor.TabIndex = 7;
            this.tbxDoctor.WatermarkText = "在此检索医生";
            this.tbxDoctor.TextChanged += new System.EventHandler(this.tbxDept_TextChanged);
            this.tbxDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDept_KeyDown);
            // 
            // tbxTitle
            // 
            // 
            // 
            // 
            this.tbxTitle.Border.Class = "TextBoxBorder";
            this.tbxTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTitle.Location = new System.Drawing.Point(80, 300);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.PreventEnterBeep = true;
            this.tbxTitle.Size = new System.Drawing.Size(254, 23);
            this.tbxTitle.TabIndex = 8;
            this.tbxTitle.WatermarkText = "在此检索职称";
            this.tbxTitle.TextChanged += new System.EventHandler(this.tbxDept_TextChanged);
            this.tbxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDept_KeyDown);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 465);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(108, 20);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "病人限制数量：";
            // 
            // tbxPatientNumber
            // 
            // 
            // 
            // 
            this.tbxPatientNumber.Border.Class = "TextBoxBorder";
            this.tbxPatientNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPatientNumber.Location = new System.Drawing.Point(111, 462);
            this.tbxPatientNumber.Name = "tbxPatientNumber";
            this.tbxPatientNumber.PreventEnterBeep = true;
            this.tbxPatientNumber.Size = new System.Drawing.Size(54, 23);
            this.tbxPatientNumber.TabIndex = 10;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbPatientDay);
            this.panelEx1.Controls.Add(this.rbPatientMonth);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(171, 462);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(73, 23);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 11;
            // 
            // rbPatientDay
            // 
            this.rbPatientDay.AutoSize = true;
            this.rbPatientDay.Location = new System.Drawing.Point(38, 3);
            this.rbPatientDay.Name = "rbPatientDay";
            this.rbPatientDay.Size = new System.Drawing.Size(39, 18);
            this.rbPatientDay.TabIndex = 15;
            this.rbPatientDay.Text = "日";
            this.rbPatientDay.UseVisualStyleBackColor = true;
            // 
            // rbPatientMonth
            // 
            this.rbPatientMonth.AutoSize = true;
            this.rbPatientMonth.Checked = true;
            this.rbPatientMonth.Location = new System.Drawing.Point(3, 3);
            this.rbPatientMonth.Name = "rbPatientMonth";
            this.rbPatientMonth.Size = new System.Drawing.Size(39, 18);
            this.rbPatientMonth.TabIndex = 15;
            this.rbPatientMonth.TabStop = true;
            this.rbPatientMonth.Text = "月";
            this.rbPatientMonth.UseVisualStyleBackColor = true;
            // 
            // rbAllow
            // 
            this.rbAllow.AutoSize = true;
            this.rbAllow.Location = new System.Drawing.Point(83, 435);
            this.rbAllow.Name = "rbAllow";
            this.rbAllow.Size = new System.Drawing.Size(95, 18);
            this.rbAllow.TabIndex = 19;
            this.rbAllow.Text = "限制为允许";
            this.rbAllow.UseVisualStyleBackColor = true;
            // 
            // rbBan
            // 
            this.rbBan.AutoSize = true;
            this.rbBan.Checked = true;
            this.rbBan.Location = new System.Drawing.Point(184, 435);
            this.rbBan.Name = "rbBan";
            this.rbBan.Size = new System.Drawing.Size(95, 18);
            this.rbBan.TabIndex = 19;
            this.rbBan.TabStop = true;
            this.rbBan.Text = "限制为禁止";
            this.rbBan.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(259, 564);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Name,
            this.col_Code});
            this.dgvDetail.Location = new System.Drawing.Point(335, 335);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(254, 197);
            this.dgvDetail.TabIndex = 21;
            this.dgvDetail.Visible = false;
            // 
            // col_Name
            // 
            this.col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "名称";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Code
            // 
            this.col_Code.DataPropertyName = "Code";
            this.col_Code.HeaderText = "Code";
            this.col_Code.Name = "col_Code";
            this.col_Code.ReadOnly = true;
            this.col_Code.Visible = false;
            // 
            // dgvDept
            // 
            this.dgvDept.AllowUserToAddRows = false;
            this.dgvDept.AllowUserToDeleteRows = false;
            this.dgvDept.AllowUserToResizeColumns = false;
            this.dgvDept.AllowUserToResizeRows = false;
            this.dgvDept.BackgroundColor = System.Drawing.Color.White;
            this.dgvDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDept.ColumnHeadersVisible = false;
            this.dgvDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvDept.Location = new System.Drawing.Point(80, 32);
            this.dgvDept.Name = "dgvDept";
            this.dgvDept.ReadOnly = true;
            this.dgvDept.RowHeadersVisible = false;
            this.dgvDept.RowTemplate.Height = 23;
            this.dgvDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDept.Size = new System.Drawing.Size(254, 106);
            this.dgvDept.TabIndex = 22;
            this.dgvDept.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDept_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dgvDoctor
            // 
            this.dgvDoctor.AllowUserToAddRows = false;
            this.dgvDoctor.AllowUserToDeleteRows = false;
            this.dgvDoctor.AllowUserToResizeColumns = false;
            this.dgvDoctor.AllowUserToResizeRows = false;
            this.dgvDoctor.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctor.ColumnHeadersVisible = false;
            this.dgvDoctor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvDoctor.Location = new System.Drawing.Point(80, 176);
            this.dgvDoctor.Name = "dgvDoctor";
            this.dgvDoctor.ReadOnly = true;
            this.dgvDoctor.RowHeadersVisible = false;
            this.dgvDoctor.RowTemplate.Height = 23;
            this.dgvDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctor.Size = new System.Drawing.Size(254, 106);
            this.dgvDoctor.TabIndex = 23;
            this.dgvDoctor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDoctor_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn4.HeaderText = "Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dgvTitle
            // 
            this.dgvTitle.AllowUserToAddRows = false;
            this.dgvTitle.AllowUserToDeleteRows = false;
            this.dgvTitle.AllowUserToResizeColumns = false;
            this.dgvTitle.AllowUserToResizeRows = false;
            this.dgvTitle.BackgroundColor = System.Drawing.Color.White;
            this.dgvTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitle.ColumnHeadersVisible = false;
            this.dgvTitle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvTitle.Location = new System.Drawing.Point(80, 323);
            this.dgvTitle.Name = "dgvTitle";
            this.dgvTitle.ReadOnly = true;
            this.dgvTitle.RowHeadersVisible = false;
            this.dgvTitle.RowTemplate.Height = 23;
            this.dgvTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTitle.Size = new System.Drawing.Size(254, 106);
            this.dgvTitle.TabIndex = 24;
            this.dgvTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTitle_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn6.HeaderText = "Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // tbxDept
            // 
            // 
            // 
            // 
            this.tbxDept.Border.Class = "TextBoxBorder";
            this.tbxDept.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDept.Location = new System.Drawing.Point(80, 9);
            this.tbxDept.Name = "tbxDept";
            this.tbxDept.PreventEnterBeep = true;
            this.tbxDept.Size = new System.Drawing.Size(254, 23);
            this.tbxDept.TabIndex = 31;
            this.tbxDept.WatermarkText = "在此检索科室";
            this.tbxDept.TextChanged += new System.EventHandler(this.tbxDept_TextChanged);
            this.tbxDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDept_KeyDown);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.rbDoctorDay);
            this.panelEx2.Controls.Add(this.rbDoctorMonth);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(171, 491);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(73, 23);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 43;
            // 
            // rbDoctorDay
            // 
            this.rbDoctorDay.AutoSize = true;
            this.rbDoctorDay.Location = new System.Drawing.Point(38, 3);
            this.rbDoctorDay.Name = "rbDoctorDay";
            this.rbDoctorDay.Size = new System.Drawing.Size(39, 18);
            this.rbDoctorDay.TabIndex = 15;
            this.rbDoctorDay.Text = "日";
            this.rbDoctorDay.UseVisualStyleBackColor = true;
            // 
            // rbDoctorMonth
            // 
            this.rbDoctorMonth.AutoSize = true;
            this.rbDoctorMonth.Checked = true;
            this.rbDoctorMonth.Location = new System.Drawing.Point(3, 3);
            this.rbDoctorMonth.Name = "rbDoctorMonth";
            this.rbDoctorMonth.Size = new System.Drawing.Size(39, 18);
            this.rbDoctorMonth.TabIndex = 15;
            this.rbDoctorMonth.TabStop = true;
            this.rbDoctorMonth.Text = "月";
            this.rbDoctorMonth.UseVisualStyleBackColor = true;
            // 
            // tbxDoctorNumber
            // 
            // 
            // 
            // 
            this.tbxDoctorNumber.Border.Class = "TextBoxBorder";
            this.tbxDoctorNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDoctorNumber.Location = new System.Drawing.Point(111, 491);
            this.tbxDoctorNumber.Name = "tbxDoctorNumber";
            this.tbxDoctorNumber.PreventEnterBeep = true;
            this.tbxDoctorNumber.Size = new System.Drawing.Size(54, 23);
            this.tbxDoctorNumber.TabIndex = 42;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 494);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(108, 20);
            this.labelX5.TabIndex = 41;
            this.labelX5.Text = "医生限制数量：";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.cbxAll);
            this.panelEx3.Controls.Add(this.cbxChronic);
            this.panelEx3.Controls.Add(this.cbxNormal);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(80, 520);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(254, 23);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 53;
            // 
            // cbxNormal
            // 
            this.cbxNormal.AutoSize = true;
            this.cbxNormal.Location = new System.Drawing.Point(11, 2);
            this.cbxNormal.Name = "cbxNormal";
            this.cbxNormal.Size = new System.Drawing.Size(82, 18);
            this.cbxNormal.TabIndex = 0;
            this.cbxNormal.Text = "普通处方";
            this.cbxNormal.UseVisualStyleBackColor = true;
            // 
            // cbxChronic
            // 
            this.cbxChronic.AutoSize = true;
            this.cbxChronic.Location = new System.Drawing.Point(93, 2);
            this.cbxChronic.Name = "cbxChronic";
            this.cbxChronic.Size = new System.Drawing.Size(96, 18);
            this.cbxChronic.TabIndex = 0;
            this.cbxChronic.Text = "慢性病处方";
            this.cbxChronic.UseVisualStyleBackColor = true;
            // 
            // cbxAll
            // 
            this.cbxAll.AutoSize = true;
            this.cbxAll.Location = new System.Drawing.Point(189, 2);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(54, 18);
            this.cbxAll.TabIndex = 0;
            this.cbxAll.Text = "全部";
            this.cbxAll.UseVisualStyleBackColor = true;
            // 
            // FormDrugPermissionManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 593);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.tbxDoctorNumber);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.tbxDept);
            this.Controls.Add(this.dgvTitle);
            this.Controls.Add(this.dgvDoctor);
            this.Controls.Add(this.dgvDept);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbBan);
            this.Controls.Add(this.rbAllow);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.tbxPatientNumber);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.tbxDoctor);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDrugPermissionManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加限制";
            this.Shown += new System.EventHandler(this.FormDrugPermissionManage_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormDrugPermissionManage_MouseClick);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitle)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxDoctor;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxTitle;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxPatientNumber;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.RadioButton rbPatientDay;
        private System.Windows.Forms.RadioButton rbPatientMonth;
        private System.Windows.Forms.RadioButton rbAllow;
        private System.Windows.Forms.RadioButton rbBan;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Code;
        private System.Windows.Forms.DataGridView dgvDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgvDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxDept;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.RadioButton rbDoctorDay;
        private System.Windows.Forms.RadioButton rbDoctorMonth;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxDoctorNumber;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.RadioButton cbxAll;
        private System.Windows.Forms.RadioButton cbxChronic;
        private System.Windows.Forms.RadioButton cbxNormal;
    }
}