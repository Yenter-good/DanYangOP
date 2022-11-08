namespace App_OP
{
    partial class FormRecordStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordStatistic));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.cbxDoctor = new CIS.ControlLib.Controls.FindComboBox();
            this.cbxDept = new CIS.ControlLib.Controls.FindComboBox();
            this.lbCount = new DevComponents.DotNetBar.LabelX();
            this.rbAllRecord = new System.Windows.Forms.RadioButton();
            this.rbNoRecord = new System.Windows.Forms.RadioButton();
            this.rbHasRecord = new System.Windows.Forms.RadioButton();
            this.btnSearchRecord = new DevComponents.DotNetBar.ButtonX();
            this.dtRecordStatisticEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtRecordStatisticStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.txWriterControl1 = new CIS.DCWriter.Controls.TxWriterControl();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtRecordStatisticEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRecordStatisticStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.advTree1);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(252, 621);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 263);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(252, 358);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 4;
            this.advTree1.Text = "advTree1";
            this.advTree1.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
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
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.cbxDoctor);
            this.panelEx2.Controls.Add(this.cbxDept);
            this.panelEx2.Controls.Add(this.lbCount);
            this.panelEx2.Controls.Add(this.rbAllRecord);
            this.panelEx2.Controls.Add(this.rbNoRecord);
            this.panelEx2.Controls.Add(this.rbHasRecord);
            this.panelEx2.Controls.Add(this.btnSearchRecord);
            this.panelEx2.Controls.Add(this.dtRecordStatisticEndTime);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.dtRecordStatisticStartTime);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(252, 263);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cbxDoctor.Border.Class = "TextBoxBorder";
            this.cbxDoctor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxDoctor.CanResizePopup = false;
            this.cbxDoctor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbxDoctor.DataSource = null;
            this.cbxDoctor.DisplayMember = "";
            this.cbxDoctor.FilterFields = null;
            this.cbxDoctor.FocusOpen = false;
            this.cbxDoctor.Location = new System.Drawing.Point(106, 138);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.PopupBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(199)))), ((int)(((byte)(225)))));
            this.cbxDoctor.PopupBorderWidth = new System.Windows.Forms.Padding(1);
            this.cbxDoctor.PopupMaximumSize = new System.Drawing.Size(0, 450);
            this.cbxDoctor.PopupMinimumSize = new System.Drawing.Size(0, 25);
            this.cbxDoctor.PopupOffSet = 2;
            this.cbxDoctor.PreventEnterBeep = true;
            this.cbxDoctor.ReadOnly = true;
            this.cbxDoctor.ShowPopupShadow = true;
            this.cbxDoctor.Size = new System.Drawing.Size(116, 23);
            this.cbxDoctor.TabIndex = 11;
            this.cbxDoctor.ValueMember = null;
            this.cbxDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxDept_KeyDown);
            // 
            // cbxDept
            // 
            this.cbxDept.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cbxDept.Border.Class = "TextBoxBorder";
            this.cbxDept.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxDept.CanResizePopup = false;
            this.cbxDept.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbxDept.DataSource = null;
            this.cbxDept.DisplayMember = "";
            this.cbxDept.FilterFields = null;
            this.cbxDept.FocusOpen = false;
            this.cbxDept.Location = new System.Drawing.Point(106, 96);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.PopupBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(199)))), ((int)(((byte)(225)))));
            this.cbxDept.PopupBorderWidth = new System.Windows.Forms.Padding(1);
            this.cbxDept.PopupMaximumSize = new System.Drawing.Size(0, 450);
            this.cbxDept.PopupMinimumSize = new System.Drawing.Size(0, 25);
            this.cbxDept.PopupOffSet = 2;
            this.cbxDept.PreventEnterBeep = true;
            this.cbxDept.ReadOnly = true;
            this.cbxDept.ShowPopupShadow = true;
            this.cbxDept.Size = new System.Drawing.Size(116, 23);
            this.cbxDept.TabIndex = 11;
            this.cbxDept.ValueMember = null;
            this.cbxDept.TextChanged += new System.EventHandler(this.cbxDept_TextChanged);
            this.cbxDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxDept_KeyDown);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            // 
            // 
            // 
            this.lbCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCount.Location = new System.Drawing.Point(94, 228);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 0);
            this.lbCount.TabIndex = 10;
            this.lbCount.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // rbAllRecord
            // 
            this.rbAllRecord.AutoSize = true;
            this.rbAllRecord.Checked = true;
            this.rbAllRecord.Location = new System.Drawing.Point(195, 206);
            this.rbAllRecord.Name = "rbAllRecord";
            this.rbAllRecord.Size = new System.Drawing.Size(53, 18);
            this.rbAllRecord.TabIndex = 9;
            this.rbAllRecord.TabStop = true;
            this.rbAllRecord.Text = "全部";
            this.rbAllRecord.UseVisualStyleBackColor = true;
            this.rbAllRecord.CheckedChanged += new System.EventHandler(this.rbHasRecord_CheckedChanged);
            // 
            // rbNoRecord
            // 
            this.rbNoRecord.AutoSize = true;
            this.rbNoRecord.Location = new System.Drawing.Point(102, 206);
            this.rbNoRecord.Name = "rbNoRecord";
            this.rbNoRecord.Size = new System.Drawing.Size(95, 18);
            this.rbNoRecord.TabIndex = 9;
            this.rbNoRecord.Text = "未填写病历";
            this.rbNoRecord.UseVisualStyleBackColor = true;
            this.rbNoRecord.CheckedChanged += new System.EventHandler(this.rbHasRecord_CheckedChanged);
            // 
            // rbHasRecord
            // 
            this.rbHasRecord.AutoSize = true;
            this.rbHasRecord.Location = new System.Drawing.Point(9, 206);
            this.rbHasRecord.Name = "rbHasRecord";
            this.rbHasRecord.Size = new System.Drawing.Size(95, 18);
            this.rbHasRecord.TabIndex = 9;
            this.rbHasRecord.Text = "已填写病历";
            this.rbHasRecord.UseVisualStyleBackColor = true;
            this.rbHasRecord.CheckedChanged += new System.EventHandler(this.rbHasRecord_CheckedChanged);
            // 
            // btnSearchRecord
            // 
            this.btnSearchRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchRecord.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchRecord.Location = new System.Drawing.Point(147, 166);
            this.btnSearchRecord.Name = "btnSearchRecord";
            this.btnSearchRecord.Size = new System.Drawing.Size(75, 28);
            this.btnSearchRecord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchRecord.TabIndex = 7;
            this.btnSearchRecord.Text = "查询";
            this.btnSearchRecord.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // dtRecordStatisticEndTime
            // 
            // 
            // 
            // 
            this.dtRecordStatisticEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtRecordStatisticEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtRecordStatisticEndTime.ButtonDropDown.Visible = true;
            this.dtRecordStatisticEndTime.IsPopupCalendarOpen = false;
            this.dtRecordStatisticEndTime.Location = new System.Drawing.Point(106, 54);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtRecordStatisticEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticEndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtRecordStatisticEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtRecordStatisticEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtRecordStatisticEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtRecordStatisticEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtRecordStatisticEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtRecordStatisticEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtRecordStatisticEndTime.Name = "dtRecordStatisticEndTime";
            this.dtRecordStatisticEndTime.Size = new System.Drawing.Size(116, 23);
            this.dtRecordStatisticEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRecordStatisticEndTime.TabIndex = 5;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(31, 141);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(65, 20);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "选择医生";
            // 
            // dtRecordStatisticStartTime
            // 
            // 
            // 
            // 
            this.dtRecordStatisticStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtRecordStatisticStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtRecordStatisticStartTime.ButtonDropDown.Visible = true;
            this.dtRecordStatisticStartTime.IsPopupCalendarOpen = false;
            this.dtRecordStatisticStartTime.Location = new System.Drawing.Point(106, 12);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtRecordStatisticStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticStartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtRecordStatisticStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtRecordStatisticStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtRecordStatisticStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtRecordStatisticStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtRecordStatisticStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtRecordStatisticStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRecordStatisticStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtRecordStatisticStartTime.Name = "dtRecordStatisticStartTime";
            this.dtRecordStatisticStartTime.Size = new System.Drawing.Size(116, 23);
            this.dtRecordStatisticStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRecordStatisticStartTime.TabIndex = 6;
            this.dtRecordStatisticStartTime.Value = new System.DateTime(2017, 9, 21, 0, 0, 0, 0);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(31, 99);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(65, 20);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "选择科室";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 20);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "结束时间：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 20);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "开始时间：";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(252, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(640, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "打印病历";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // txWriterControl1
            // 
            this.txWriterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txWriterControl1.Location = new System.Drawing.Point(252, 27);
            this.txWriterControl1.Name = "txWriterControl1";
            this.txWriterControl1.Size = new System.Drawing.Size(640, 594);
            this.txWriterControl1.TabIndex = 8;
            // 
            // FormRecordStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 621);
            this.Controls.Add(this.txWriterControl1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FormRecordStatistic";
            this.Text = "FormRecordStatistic";
            this.Shown += new System.EventHandler(this.FormRecordStatistic_Shown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtRecordStatisticEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRecordStatisticStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSearchRecord;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtRecordStatisticEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtRecordStatisticStartTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbCount;
        private System.Windows.Forms.RadioButton rbNoRecord;
        private System.Windows.Forms.RadioButton rbHasRecord;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private CIS.ControlLib.Controls.FindComboBox cbxDoctor;
        private CIS.ControlLib.Controls.FindComboBox cbxDept;
        private System.Windows.Forms.RadioButton rbAllRecord;
        private CIS.DCWriter.Controls.TxWriterControl txWriterControl1;
    }
}