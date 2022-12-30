
namespace App_OP.PrescriptionCirculation
{
    partial class FormPrescriptionCirculationStatistic
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrescriptionCirculationStatistic));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dtEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.fcbDoctorName = new CIS.ControlLib.Controls.FindComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvWesternMedicine = new CIS.ControlLib.Controls.myDataGridView();
            this.XY_colID = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colName = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colGG = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colYL = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colYLDW = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colYF = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.XY_colJG = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colDay = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colSL = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colGGDW = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.XY_colYPCD = new App_OP.Prescription.DataGridViewTextBoxExtColumn();
            this.colWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treePatient = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWesternMedicine)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treePatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnQuery);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.dtEndDate);
            this.panelEx1.Controls.Add(this.dtStartDate);
            this.panelEx1.Controls.Add(this.fcbDoctorName);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(799, 100);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(679, 36);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(501, 44);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(14, 18);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "~";
            // 
            // dtEndDate
            // 
            // 
            // 
            // 
            this.dtEndDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEndDate.ButtonDropDown.Visible = true;
            this.dtEndDate.IsPopupCalendarOpen = false;
            this.dtEndDate.Location = new System.Drawing.Point(516, 36);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtEndDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            this.dtEndDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndDate.MonthCalendar.TodayButtonVisible = true;
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(112, 23);
            this.dtEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEndDate.TabIndex = 2;
            this.dtEndDate.Value = new System.DateTime(2022, 12, 8, 0, 0, 0, 0);
            // 
            // dtStartDate
            // 
            // 
            // 
            // 
            this.dtStartDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStartDate.ButtonDropDown.Visible = true;
            this.dtStartDate.IsPopupCalendarOpen = false;
            this.dtStartDate.Location = new System.Drawing.Point(385, 36);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtStartDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.DisplayMonth = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            this.dtStartDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStartDate.MonthCalendar.TodayButtonVisible = true;
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(112, 23);
            this.dtStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStartDate.TabIndex = 2;
            this.dtStartDate.Value = new System.DateTime(2022, 12, 8, 0, 0, 0, 0);
            // 
            // fcbDoctorName
            // 
            // 
            // 
            // 
            this.fcbDoctorName.Border.Class = "TextBoxBorder";
            this.fcbDoctorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fcbDoctorName.CanResizePopup = false;
            this.fcbDoctorName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fcbDoctorName.DataSource = null;
            this.fcbDoctorName.DisplayMember = "";
            this.fcbDoctorName.FilterFields = null;
            this.fcbDoctorName.FocusOpen = false;
            this.fcbDoctorName.Location = new System.Drawing.Point(112, 36);
            this.fcbDoctorName.Name = "fcbDoctorName";
            this.fcbDoctorName.PopupBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(199)))), ((int)(((byte)(225)))));
            this.fcbDoctorName.PopupBorderWidth = new System.Windows.Forms.Padding(1);
            this.fcbDoctorName.PopupMaximumSize = new System.Drawing.Size(0, 450);
            this.fcbDoctorName.PopupMinimumSize = new System.Drawing.Size(0, 25);
            this.fcbDoctorName.PopupOffSet = 2;
            this.fcbDoctorName.PreventEnterBeep = true;
            this.fcbDoctorName.ReadOnly = true;
            this.fcbDoctorName.ShowPopupShadow = true;
            this.fcbDoctorName.Size = new System.Drawing.Size(157, 23);
            this.fcbDoctorName.TabIndex = 0;
            this.fcbDoctorName.ValueMember = null;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(329, 39);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(50, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "日期：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(43, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "医生姓名：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvWesternMedicine);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 462);
            this.panel1.TabIndex = 4;
            // 
            // dgvWesternMedicine
            // 
            this.dgvWesternMedicine.AllowUserToAddRows = false;
            this.dgvWesternMedicine.AllowUserToDeleteRows = false;
            this.dgvWesternMedicine.AllowUserToResizeColumns = false;
            this.dgvWesternMedicine.AllowUserToResizeRows = false;
            this.dgvWesternMedicine.BackgroundColor = System.Drawing.Color.White;
            this.dgvWesternMedicine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWesternMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWesternMedicine.ColumnHeadersHeight = 25;
            this.dgvWesternMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWesternMedicine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XY_colID,
            this.XY_colName,
            this.XY_colGG,
            this.XY_colYL,
            this.XY_colYLDW,
            this.XY_colYF,
            this.XY_colJG,
            this.colDay,
            this.XY_colSL,
            this.XY_colGGDW,
            this.XY_colYPCD,
            this.colWhite});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(216)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWesternMedicine.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWesternMedicine.Delay = 100;
            this.dgvWesternMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWesternMedicine.EnableHeadersVisualStyles = false;
            this.dgvWesternMedicine.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvWesternMedicine.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvWesternMedicine.Location = new System.Drawing.Point(247, 0);
            this.dgvWesternMedicine.Name = "dgvWesternMedicine";
            this.dgvWesternMedicine.PaintEnhancedSelection = false;
            this.dgvWesternMedicine.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWesternMedicine.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWesternMedicine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWesternMedicine.RowTemplate.Height = 23;
            this.dgvWesternMedicine.SelectAllSignVisible = false;
            this.dgvWesternMedicine.Size = new System.Drawing.Size(552, 462);
            this.dgvWesternMedicine.TabIndex = 9;
            this.dgvWesternMedicine.UseCustomBackgroundColor = true;
            // 
            // XY_colID
            // 
            this.XY_colID.DataPropertyName = "ID";
            this.XY_colID.HeaderText = "ID";
            this.XY_colID.Name = "XY_colID";
            this.XY_colID.ReadOnly = true;
            this.XY_colID.Tag1 = "";
            this.XY_colID.Tag2 = null;
            this.XY_colID.Tag3 = null;
            this.XY_colID.Tag4 = null;
            this.XY_colID.Visible = false;
            // 
            // XY_colName
            // 
            this.XY_colName.DataPropertyName = "ItemName";
            this.XY_colName.HeaderText = "名称";
            this.XY_colName.MinimumWidth = 150;
            this.XY_colName.Name = "XY_colName";
            this.XY_colName.ReadOnly = true;
            this.XY_colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colName.Tag1 = "medicareItemName";
            this.XY_colName.Tag2 = "hospitalItemName";
            this.XY_colName.Tag3 = null;
            this.XY_colName.Tag4 = null;
            this.XY_colName.Width = 200;
            // 
            // XY_colGG
            // 
            this.XY_colGG.DataPropertyName = "Specification";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.XY_colGG.DefaultCellStyle = dataGridViewCellStyle2;
            this.XY_colGG.HeaderText = "规格";
            this.XY_colGG.Name = "XY_colGG";
            this.XY_colGG.ReadOnly = true;
            this.XY_colGG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colGG.Tag1 = "specification";
            this.XY_colGG.Tag2 = null;
            this.XY_colGG.Tag3 = null;
            this.XY_colGG.Tag4 = null;
            this.XY_colGG.Width = 110;
            // 
            // XY_colYL
            // 
            this.XY_colYL.DataPropertyName = "Amount";
            this.XY_colYL.HeaderText = "一次用量";
            this.XY_colYL.Name = "XY_colYL";
            this.XY_colYL.ReadOnly = true;
            this.XY_colYL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colYL.Tag1 = "";
            this.XY_colYL.Tag2 = null;
            this.XY_colYL.Tag3 = null;
            this.XY_colYL.Tag4 = null;
            // 
            // XY_colYLDW
            // 
            this.XY_colYLDW.DataPropertyName = "DosageUnit";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.XY_colYLDW.DefaultCellStyle = dataGridViewCellStyle3;
            this.XY_colYLDW.HeaderText = "单位";
            this.XY_colYLDW.Name = "XY_colYLDW";
            this.XY_colYLDW.ReadOnly = true;
            this.XY_colYLDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colYLDW.Tag1 = null;
            this.XY_colYLDW.Tag2 = null;
            this.XY_colYLDW.Tag3 = null;
            this.XY_colYLDW.Tag4 = null;
            this.XY_colYLDW.Width = 45;
            // 
            // XY_colYF
            // 
            this.XY_colYF.DataPropertyName = "Usage";
            this.XY_colYF.DropDownHeight = 106;
            this.XY_colYF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XY_colYF.DropDownWidth = 121;
            this.XY_colYF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XY_colYF.HeaderText = "用法";
            this.XY_colYF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.XY_colYF.IntegralHeight = false;
            this.XY_colYF.ItemHeight = 16;
            this.XY_colYF.Name = "XY_colYF";
            this.XY_colYF.ReadOnly = true;
            this.XY_colYF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.XY_colYF.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XY_colYF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colYF.Width = 120;
            // 
            // XY_colJG
            // 
            this.XY_colJG.DataPropertyName = "Frequency";
            this.XY_colJG.DropDownHeight = 106;
            this.XY_colJG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XY_colJG.DropDownWidth = 121;
            this.XY_colJG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XY_colJG.HeaderText = "间隔";
            this.XY_colJG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.XY_colJG.IntegralHeight = false;
            this.XY_colJG.ItemHeight = 16;
            this.XY_colJG.Name = "XY_colJG";
            this.XY_colJG.ReadOnly = true;
            this.XY_colJG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.XY_colJG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XY_colJG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colJG.Width = 80;
            // 
            // colDay
            // 
            this.colDay.HeaderText = "天数";
            this.colDay.Name = "colDay";
            this.colDay.ReadOnly = true;
            this.colDay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDay.Tag1 = null;
            this.colDay.Tag2 = null;
            this.colDay.Tag3 = null;
            this.colDay.Tag4 = null;
            this.colDay.Width = 45;
            // 
            // XY_colSL
            // 
            this.XY_colSL.DataPropertyName = "Number";
            this.XY_colSL.HeaderText = "数量";
            this.XY_colSL.Name = "XY_colSL";
            this.XY_colSL.ReadOnly = true;
            this.XY_colSL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colSL.Tag1 = "amount";
            this.XY_colSL.Tag2 = null;
            this.XY_colSL.Tag3 = null;
            this.XY_colSL.Tag4 = null;
            this.XY_colSL.Width = 45;
            // 
            // XY_colGGDW
            // 
            this.XY_colGGDW.DataPropertyName = "PackingUnit";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.XY_colGGDW.DefaultCellStyle = dataGridViewCellStyle4;
            this.XY_colGGDW.HeaderText = "单位";
            this.XY_colGGDW.Name = "XY_colGGDW";
            this.XY_colGGDW.ReadOnly = true;
            this.XY_colGGDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colGGDW.Tag1 = "specUnit";
            this.XY_colGGDW.Tag2 = null;
            this.XY_colGGDW.Tag3 = null;
            this.XY_colGGDW.Tag4 = null;
            this.XY_colGGDW.Width = 45;
            // 
            // XY_colYPCD
            // 
            this.XY_colYPCD.DataPropertyName = "ProductionSites";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.XY_colYPCD.DefaultCellStyle = dataGridViewCellStyle5;
            this.XY_colYPCD.HeaderText = "药品产地";
            this.XY_colYPCD.Name = "XY_colYPCD";
            this.XY_colYPCD.ReadOnly = true;
            this.XY_colYPCD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XY_colYPCD.Tag1 = null;
            this.XY_colYPCD.Tag2 = null;
            this.XY_colYPCD.Tag3 = null;
            this.XY_colYPCD.Tag4 = null;
            // 
            // colWhite
            // 
            this.colWhite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWhite.HeaderText = "";
            this.colWhite.Name = "colWhite";
            this.colWhite.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treePatient);
            this.panel2.Controls.Add(this.bar2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 462);
            this.panel2.TabIndex = 10;
            // 
            // treePatient
            // 
            this.treePatient.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treePatient.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treePatient.BackgroundStyle.Class = "TreeBorderKey";
            this.treePatient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePatient.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treePatient.Location = new System.Drawing.Point(0, 27);
            this.treePatient.Name = "treePatient";
            this.treePatient.NodesConnector = this.nodeConnector1;
            this.treePatient.NodeStyle = this.elementStyle1;
            this.treePatient.PathSeparator = ";";
            this.treePatient.Size = new System.Drawing.Size(247, 435);
            this.treePatient.Styles.Add(this.elementStyle1);
            this.treePatient.TabIndex = 0;
            this.treePatient.Text = "advTree1";
            this.treePatient.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treePatient_NodeDoubleClick);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrint});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(247, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 8;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FormPrescriptionCirculationStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FormPrescriptionCirculationStatistic";
            this.Text = "处方流转统计";
            this.Shown += new System.EventHandler(this.FormPrescriptionCirculationStatistic_Shown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWesternMedicine)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treePatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private CIS.ControlLib.Controls.FindComboBox fcbDoctorName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEndDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStartDate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.AdvTree.AdvTree treePatient;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        public CIS.ControlLib.Controls.myDataGridView dgvWesternMedicine;
        private Prescription.DataGridViewTextBoxExtColumn XY_colID;
        private Prescription.DataGridViewTextBoxExtColumn XY_colName;
        private Prescription.DataGridViewTextBoxExtColumn XY_colGG;
        private Prescription.DataGridViewTextBoxExtColumn XY_colYL;
        private Prescription.DataGridViewTextBoxExtColumn XY_colYLDW;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn XY_colYF;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn XY_colJG;
        private Prescription.DataGridViewTextBoxExtColumn colDay;
        private Prescription.DataGridViewTextBoxExtColumn XY_colSL;
        private Prescription.DataGridViewTextBoxExtColumn XY_colGGDW;
        private Prescription.DataGridViewTextBoxExtColumn XY_colYPCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhite;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
    }
}