namespace App_OP
{
    partial class FormPrint
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.EndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.StartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dgvJournal = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.comboBoxEx1);
            this.panelEx1.Controls.Add(this.btnQuery);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.EndTime);
            this.panelEx1.Controls.Add(this.StartTime);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(715, 90);
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
            this.labelX2.Location = new System.Drawing.Point(139, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(17, 22);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "~";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(289, 34);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(152, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(580, 34);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 7;
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
            this.labelX1.Location = new System.Drawing.Point(460, 37);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 18);
            this.labelX1.TabIndex = 6;
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
            this.EndTime.Location = new System.Drawing.Point(160, 34);
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
            this.EndTime.Size = new System.Drawing.Size(123, 21);
            this.EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.EndTime.TabIndex = 5;
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
            this.StartTime.Location = new System.Drawing.Point(12, 34);
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
            this.StartTime.Size = new System.Drawing.Size(123, 21);
            this.StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.StartTime.TabIndex = 4;
            this.StartTime.Value = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // dgvJournal
            // 
            this.dgvJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJournal.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvJournal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvJournal.Location = new System.Drawing.Point(0, 90);
            this.dgvJournal.Name = "dgvJournal";
            // 
            // 
            // 
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.dgvJournal.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.dgvJournal.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.dgvJournal.Size = new System.Drawing.Size(715, 357);
            this.dgvJournal.TabIndex = 5;
            this.dgvJournal.Text = "superGridControl1";
            this.dgvJournal.CellMouseEnter += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellEventArgs>(this.dgvJournal_CellMouseEnter);
            // 
            // gridColumn12
            // 
            this.gridColumn12.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn12.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn12.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn12.HeaderText = "选择";
            this.gridColumn12.Name = "col_Select";
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
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn7.DataPropertyName = "Age";
            this.gridColumn7.HeaderText = "年龄";
            this.gridColumn7.Name = "col_Age";
            this.gridColumn7.ReadOnly = true;
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
            this.gridColumn9.DataPropertyName = "PatientDiagnosis";
            this.gridColumn9.HeaderText = "病人诊断";
            this.gridColumn9.Name = "col_PatientDiagnosis";
            this.gridColumn9.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn10.DataPropertyName = "PatientAddress";
            this.gridColumn10.HeaderText = "病人地址";
            this.gridColumn10.Name = "col_PatientAddress";
            this.gridColumn10.ReadOnly = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn11.DataPropertyName = "UpdateDate";
            this.gridColumn11.HeaderText = "就诊时间";
            this.gridColumn11.Name = "col_UpdateDate";
            this.gridColumn11.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 447);
            this.Controls.Add(this.dgvJournal);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "整体打印";
            this.Shown += new System.EventHandler(this.FormPrint_Shown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvJournal;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput EndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput StartTime;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private System.Windows.Forms.Timer timer1;
    }
}