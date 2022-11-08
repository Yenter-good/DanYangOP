namespace App_OP
{
    partial class FormReportManage
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
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRow2 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
            this.advTree3 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector3 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
            this.lbHospitalCount = new DevComponents.DotNetBar.LabelX();
            this.btnSearchHospitalized = new DevComponents.DotNetBar.ButtonX();
            this.dtHospitalizedEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtHospitalizedStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tabHospitalized = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnInfectionSearch = new DevComponents.DotNetBar.ButtonX();
            this.dtInfectionEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtInfectionStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tabInfection = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.advTree2 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.btnChronicSearch = new DevComponents.DotNetBar.ButtonX();
            this.dtChronicEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtChronicStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tabChronic = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.panelEx5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree3)).BeginInit();
            this.panelEx6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtHospitalizedEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHospitalizedStartTime)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInfectionEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInfectionStartTime)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).BeginInit();
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtChronicEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChronicStartTime)).BeginInit();
            this.SuspendLayout();
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle;
            this.superGridControl1.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.superGridControl1.PrimaryGrid.ReadOnly = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowRowHeaders = false;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.Size = new System.Drawing.Size(250, 578);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.superGridControl1_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.HeaderText = "报卡日志";
            this.gridColumn1.Name = "";
            // 
            // gridRow2
            // 
            this.gridRow2.Cells.Add(this.gridCell1);
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(250, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(614, 578);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 5;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabInfection,
            this.tabChronic,
            this.tabHospitalized});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.panelEx5);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(614, 548);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tabHospitalized;
            // 
            // panelEx5
            // 
            this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx5.Controls.Add(this.advTree3);
            this.panelEx5.Controls.Add(this.panelEx6);
            this.panelEx5.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx5.Location = new System.Drawing.Point(0, 0);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(251, 548);
            this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx5.Style.GradientAngle = 90;
            this.panelEx5.TabIndex = 4;
            // 
            // advTree3
            // 
            this.advTree3.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree3.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree3.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree3.Location = new System.Drawing.Point(0, 137);
            this.advTree3.Name = "advTree3";
            this.advTree3.NodesConnector = this.nodeConnector3;
            this.advTree3.NodeStyle = this.elementStyle3;
            this.advTree3.PathSeparator = ";";
            this.advTree3.Size = new System.Drawing.Size(251, 411);
            this.advTree3.Styles.Add(this.elementStyle3);
            this.advTree3.TabIndex = 4;
            this.advTree3.Text = "advTree3";
            this.advTree3.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree3_NodeDoubleClick);
            // 
            // nodeConnector3
            // 
            this.nodeConnector3.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panelEx6
            // 
            this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx6.Controls.Add(this.lbHospitalCount);
            this.panelEx6.Controls.Add(this.btnSearchHospitalized);
            this.panelEx6.Controls.Add(this.dtHospitalizedEndTime);
            this.panelEx6.Controls.Add(this.dtHospitalizedStartTime);
            this.panelEx6.Controls.Add(this.labelX5);
            this.panelEx6.Controls.Add(this.labelX6);
            this.panelEx6.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx6.Location = new System.Drawing.Point(0, 0);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(251, 137);
            this.panelEx6.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx6.Style.GradientAngle = 90;
            this.panelEx6.TabIndex = 0;
            // 
            // lbHospitalCount
            // 
            this.lbHospitalCount.AutoSize = true;
            // 
            // 
            // 
            this.lbHospitalCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHospitalCount.Location = new System.Drawing.Point(17, 100);
            this.lbHospitalCount.Name = "lbHospitalCount";
            this.lbHospitalCount.Size = new System.Drawing.Size(0, 0);
            this.lbHospitalCount.TabIndex = 3;
            // 
            // btnSearchHospitalized
            // 
            this.btnSearchHospitalized.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchHospitalized.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchHospitalized.Location = new System.Drawing.Point(154, 95);
            this.btnSearchHospitalized.Name = "btnSearchHospitalized";
            this.btnSearchHospitalized.Size = new System.Drawing.Size(75, 28);
            this.btnSearchHospitalized.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchHospitalized.TabIndex = 2;
            this.btnSearchHospitalized.Text = "查询";
            this.btnSearchHospitalized.Click += new System.EventHandler(this.btnSearchHospitalized_Click);
            // 
            // dtHospitalizedEndTime
            // 
            // 
            // 
            // 
            this.dtHospitalizedEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtHospitalizedEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtHospitalizedEndTime.ButtonDropDown.Visible = true;
            this.dtHospitalizedEndTime.IsPopupCalendarOpen = false;
            this.dtHospitalizedEndTime.Location = new System.Drawing.Point(113, 56);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtHospitalizedEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedEndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtHospitalizedEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtHospitalizedEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtHospitalizedEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtHospitalizedEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHospitalizedEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtHospitalizedEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtHospitalizedEndTime.Name = "dtHospitalizedEndTime";
            this.dtHospitalizedEndTime.Size = new System.Drawing.Size(116, 23);
            this.dtHospitalizedEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtHospitalizedEndTime.TabIndex = 1;
            // 
            // dtHospitalizedStartTime
            // 
            // 
            // 
            // 
            this.dtHospitalizedStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtHospitalizedStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtHospitalizedStartTime.ButtonDropDown.Visible = true;
            this.dtHospitalizedStartTime.IsPopupCalendarOpen = false;
            this.dtHospitalizedStartTime.Location = new System.Drawing.Point(113, 20);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtHospitalizedStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedStartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtHospitalizedStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtHospitalizedStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtHospitalizedStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtHospitalizedStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHospitalizedStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtHospitalizedStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHospitalizedStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtHospitalizedStartTime.Name = "dtHospitalizedStartTime";
            this.dtHospitalizedStartTime.Size = new System.Drawing.Size(116, 23);
            this.dtHospitalizedStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtHospitalizedStartTime.TabIndex = 1;
            this.dtHospitalizedStartTime.Value = new System.DateTime(2017, 9, 21, 0, 0, 0, 0);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(38, 59);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(79, 20);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "结束时间：";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(38, 23);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(79, 20);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "开始时间：";
            // 
            // tabHospitalized
            // 
            this.tabHospitalized.AttachedControl = this.superTabControlPanel3;
            this.tabHospitalized.GlobalItem = false;
            this.tabHospitalized.Name = "tabHospitalized";
            this.tabHospitalized.Text = "住院登记单统计";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panelEx1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(614, 548);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabInfection;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.advTree1);
            this.panelEx1.Controls.Add(this.panelEx7);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(251, 548);
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
            this.advTree1.Location = new System.Drawing.Point(0, 163);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(251, 385);
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
            // panelEx7
            // 
            this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx7.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx7.Location = new System.Drawing.Point(0, 137);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(251, 26);
            this.panelEx7.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx7.Style.GradientAngle = 90;
            this.panelEx7.TabIndex = 8;
            this.panelEx7.Text = "姓名后跟有\"需要申报\",则可双击申报";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnInfectionSearch);
            this.panelEx2.Controls.Add(this.dtInfectionEndTime);
            this.panelEx2.Controls.Add(this.dtInfectionStartTime);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(251, 137);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // btnInfectionSearch
            // 
            this.btnInfectionSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInfectionSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInfectionSearch.Location = new System.Drawing.Point(154, 95);
            this.btnInfectionSearch.Name = "btnInfectionSearch";
            this.btnInfectionSearch.Size = new System.Drawing.Size(75, 28);
            this.btnInfectionSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInfectionSearch.TabIndex = 2;
            this.btnInfectionSearch.Text = "查询";
            this.btnInfectionSearch.Click += new System.EventHandler(this.btnInfectionSearch_Click);
            // 
            // dtInfectionEndTime
            // 
            // 
            // 
            // 
            this.dtInfectionEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtInfectionEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtInfectionEndTime.ButtonDropDown.Visible = true;
            this.dtInfectionEndTime.IsPopupCalendarOpen = false;
            this.dtInfectionEndTime.Location = new System.Drawing.Point(113, 56);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtInfectionEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionEndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtInfectionEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtInfectionEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtInfectionEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtInfectionEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInfectionEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtInfectionEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtInfectionEndTime.Name = "dtInfectionEndTime";
            this.dtInfectionEndTime.Size = new System.Drawing.Size(116, 23);
            this.dtInfectionEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInfectionEndTime.TabIndex = 1;
            // 
            // dtInfectionStartTime
            // 
            // 
            // 
            // 
            this.dtInfectionStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtInfectionStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtInfectionStartTime.ButtonDropDown.Visible = true;
            this.dtInfectionStartTime.IsPopupCalendarOpen = false;
            this.dtInfectionStartTime.Location = new System.Drawing.Point(113, 20);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtInfectionStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionStartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtInfectionStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtInfectionStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtInfectionStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtInfectionStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtInfectionStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtInfectionStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInfectionStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtInfectionStartTime.Name = "dtInfectionStartTime";
            this.dtInfectionStartTime.Size = new System.Drawing.Size(116, 23);
            this.dtInfectionStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInfectionStartTime.TabIndex = 1;
            this.dtInfectionStartTime.Value = new System.DateTime(2017, 9, 21, 0, 0, 0, 0);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(38, 59);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "结束时间：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(38, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "开始时间：";
            // 
            // tabInfection
            // 
            this.tabInfection.AttachedControl = this.superTabControlPanel1;
            this.tabInfection.GlobalItem = false;
            this.tabInfection.Name = "tabInfection";
            this.tabInfection.Text = "传染病申报统计";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.panelEx3);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(614, 548);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabChronic;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.advTree2);
            this.panelEx3.Controls.Add(this.panelEx8);
            this.panelEx3.Controls.Add(this.panelEx4);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(252, 548);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 4;
            // 
            // advTree2
            // 
            this.advTree2.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree2.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree2.Location = new System.Drawing.Point(0, 163);
            this.advTree2.Name = "advTree2";
            this.advTree2.NodesConnector = this.nodeConnector2;
            this.advTree2.NodeStyle = this.elementStyle2;
            this.advTree2.PathSeparator = ";";
            this.advTree2.Size = new System.Drawing.Size(252, 385);
            this.advTree2.Styles.Add(this.elementStyle2);
            this.advTree2.TabIndex = 4;
            this.advTree2.Text = "advTree2";
            this.advTree2.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panelEx8
            // 
            this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx8.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx8.Location = new System.Drawing.Point(0, 137);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(252, 26);
            this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx8.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx8.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx8.Style.GradientAngle = 90;
            this.panelEx8.TabIndex = 12;
            this.panelEx8.Text = "姓名后跟有\"需要申报\",则可双击申报";
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.btnChronicSearch);
            this.panelEx4.Controls.Add(this.dtChronicEndTime);
            this.panelEx4.Controls.Add(this.dtChronicStartTime);
            this.panelEx4.Controls.Add(this.labelX3);
            this.panelEx4.Controls.Add(this.labelX4);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(252, 137);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            // 
            // btnChronicSearch
            // 
            this.btnChronicSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChronicSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChronicSearch.Location = new System.Drawing.Point(154, 95);
            this.btnChronicSearch.Name = "btnChronicSearch";
            this.btnChronicSearch.Size = new System.Drawing.Size(75, 28);
            this.btnChronicSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChronicSearch.TabIndex = 2;
            this.btnChronicSearch.Text = "查询";
            this.btnChronicSearch.Click += new System.EventHandler(this.btnInfectionSearch_Click);
            // 
            // dtChronicEndTime
            // 
            // 
            // 
            // 
            this.dtChronicEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtChronicEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtChronicEndTime.ButtonDropDown.Visible = true;
            this.dtChronicEndTime.IsPopupCalendarOpen = false;
            this.dtChronicEndTime.Location = new System.Drawing.Point(113, 56);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtChronicEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicEndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtChronicEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtChronicEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtChronicEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtChronicEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtChronicEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtChronicEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtChronicEndTime.Name = "dtChronicEndTime";
            this.dtChronicEndTime.Size = new System.Drawing.Size(116, 23);
            this.dtChronicEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtChronicEndTime.TabIndex = 1;
            // 
            // dtChronicStartTime
            // 
            // 
            // 
            // 
            this.dtChronicStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtChronicStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtChronicStartTime.ButtonDropDown.Visible = true;
            this.dtChronicStartTime.IsPopupCalendarOpen = false;
            this.dtChronicStartTime.Location = new System.Drawing.Point(113, 20);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtChronicStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicStartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtChronicStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtChronicStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtChronicStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtChronicStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtChronicStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtChronicStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtChronicStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtChronicStartTime.Name = "dtChronicStartTime";
            this.dtChronicStartTime.Size = new System.Drawing.Size(116, 23);
            this.dtChronicStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtChronicStartTime.TabIndex = 1;
            this.dtChronicStartTime.Value = new System.DateTime(2017, 9, 21, 0, 0, 0, 0);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(38, 59);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 20);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "结束时间：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(38, 23);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(79, 20);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "开始时间：";
            // 
            // tabChronic
            // 
            this.tabChronic.AttachedControl = this.superTabControlPanel2;
            this.tabChronic.GlobalItem = false;
            this.tabChronic.Name = "tabChronic";
            this.tabChronic.Text = "慢性病申报统计";
            // 
            // FormReportManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 578);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.superGridControl1);
            this.DoubleBuffered = true;
            this.Name = "FormReportManage";
            this.Text = "FormReportManage";
            this.Shown += new System.EventHandler(this.FormReportManage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree3)).EndInit();
            this.panelEx6.ResumeLayout(false);
            this.panelEx6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtHospitalizedEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHospitalizedStartTime)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInfectionEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInfectionStartTime)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).EndInit();
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtChronicEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChronicStartTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow2;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabInfection;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabChronic;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnInfectionSearch;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtInfectionEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtInfectionStartTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.AdvTree.AdvTree advTree2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonX btnChronicSearch;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtChronicEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtChronicStartTime;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tabHospitalized;
        private DevComponents.DotNetBar.PanelEx panelEx5;
        private DevComponents.AdvTree.AdvTree advTree3;
        private DevComponents.AdvTree.NodeConnector nodeConnector3;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.PanelEx panelEx6;
        private DevComponents.DotNetBar.LabelX lbHospitalCount;
        private DevComponents.DotNetBar.ButtonX btnSearchHospitalized;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHospitalizedEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHospitalizedStartTime;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.PanelEx panelEx8;
        private DevComponents.DotNetBar.PanelEx panelEx7;
    }
}