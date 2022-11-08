namespace App_OP
{
    partial class FormAllJournal
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvJournal = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.FileName = "门诊日志";
            this.saveFileDialog1.Filter = "EXCEL|*.xls";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(161, 39);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(17, 22);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "~";
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(799, 32);
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
            this.labelX1.Location = new System.Drawing.Point(522, 35);
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
            this.EndTime.Location = new System.Drawing.Point(184, 32);
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
            this.StartTime.Location = new System.Drawing.Point(32, 32);
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
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.comboBoxEx1);
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
            this.panelEx1.Size = new System.Drawing.Size(880, 95);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 12;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(344, 34);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(36, 20);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "科室";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 18;
            this.comboBoxEx1.Location = new System.Drawing.Point(381, 32);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 10;
            // 
            // dgvJournal
            // 
            this.dgvJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJournal.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvJournal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvJournal.Location = new System.Drawing.Point(0, 95);
            this.dgvJournal.Name = "dgvJournal";
            // 
            // 
            // 
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn20);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn19);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn18);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.dgvJournal.PrimaryGrid.ReadOnly = true;
            this.dgvJournal.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.dgvJournal.Size = new System.Drawing.Size(880, 545);
            this.dgvJournal.TabIndex = 17;
            this.dgvJournal.Text = "superGridControl1";
            this.dgvJournal.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.dgvJournal_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "col_ID";
            this.gridColumn1.ReadOnly = true;
            this.gridColumn1.Visible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn2.DataPropertyName = "OutpatientNo";
            this.gridColumn2.HeaderText = "就诊号";
            this.gridColumn2.Name = "col_OutpatientNo";
            this.gridColumn2.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn3.DataPropertyName = "PatientID";
            this.gridColumn3.Name = "col_PatientID";
            this.gridColumn3.ReadOnly = true;
            this.gridColumn3.Visible = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn4.DataPropertyName = "PatientName";
            this.gridColumn4.HeaderText = "病人姓名";
            this.gridColumn4.Name = "col_PatientName";
            this.gridColumn4.ReadOnly = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn5.DataPropertyName = "Sex";
            this.gridColumn5.HeaderText = "性别";
            this.gridColumn5.Name = "col_Sex";
            this.gridColumn5.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn6.DataPropertyName = "Birthday";
            this.gridColumn6.HeaderText = "出生日期";
            this.gridColumn6.Name = "col_Birthday";
            this.gridColumn6.ReadOnly = true;
            this.gridColumn6.Visible = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn7.DataPropertyName = "Age";
            this.gridColumn7.HeaderText = "年龄";
            this.gridColumn7.Name = "col_Age";
            this.gridColumn7.ReadOnly = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn20.DataPropertyName = "Job";
            this.gridColumn20.HeaderText = "职业";
            this.gridColumn20.Name = "col_Job";
            // 
            // gridColumn19
            // 
            this.gridColumn19.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn19.DataPropertyName = "FirstOrMany";
            this.gridColumn19.HeaderText = "初复诊";
            this.gridColumn19.Name = "col_FirstOrMany";
            // 
            // gridColumn14
            // 
            this.gridColumn14.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn14.DataPropertyName = "BloodPressure";
            this.gridColumn14.HeaderText = "血压";
            this.gridColumn14.Name = "col_BloodPressure";
            // 
            // gridColumn15
            // 
            this.gridColumn15.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn15.DataPropertyName = "DA";
            this.gridColumn15.HeaderText = "发病日期";
            this.gridColumn15.Name = "col_DA";
            // 
            // gridColumn16
            // 
            this.gridColumn16.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn16.DataPropertyName = "PhoneNumber";
            this.gridColumn16.HeaderText = "电话";
            this.gridColumn16.Name = "col_PhoneNumber";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn8.DataPropertyName = "CardNo";
            this.gridColumn8.HeaderText = "一卡通号";
            this.gridColumn8.Name = "col_CardNo";
            this.gridColumn8.ReadOnly = true;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn9.DataPropertyName = "Name";
            this.gridColumn9.HeaderText = "病人诊断";
            this.gridColumn9.Name = "col_PatientDiagnosis";
            this.gridColumn9.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn10.DataPropertyName = "Address";
            this.gridColumn10.HeaderText = "病人地址";
            this.gridColumn10.Name = "col_PatientAddress";
            this.gridColumn10.ReadOnly = true;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn12.DataPropertyName = "IDCard";
            this.gridColumn12.HeaderText = "身份证号";
            this.gridColumn12.Name = "col_PatientIDCard";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn11.DataPropertyName = "ProcessTime";
            this.gridColumn11.HeaderText = "就诊时间";
            this.gridColumn11.Name = "col_UpdateDate";
            this.gridColumn11.ReadOnly = true;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn17.DataPropertyName = "DoctorName";
            this.gridColumn17.HeaderText = "医生姓名";
            this.gridColumn17.Name = "col_DoctorName";
            // 
            // gridColumn18
            // 
            this.gridColumn18.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn18.DataPropertyName = "DeptName";
            this.gridColumn18.HeaderText = "科室名称";
            this.gridColumn18.Name = "col_DeptName";
            // 
            // gridColumn13
            // 
            this.gridColumn13.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn13.DataPropertyName = "Remark";
            this.gridColumn13.HeaderText = "备注";
            this.gridColumn13.Name = "col_Remark";
            // 
            // FormAllJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 640);
            this.Controls.Add(this.dgvJournal);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FormAllJournal";
            this.Text = "门诊日志综合查询";
            this.Shown += new System.EventHandler(this.FormAllJournal_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput EndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput StartTime;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvJournal;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20;
    }
}