namespace App_Sys.Surgery
{
    partial class SurgeryManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurgeryManager));
            this.pnlLeft = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridSurgery = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.txtSearch = new CIS.ControlLib.Controls.SuperText();
            this.pnlMain = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.treeZY = new DevComponents.AdvTree.AdvTree();
            this.nodeZY = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.treeMZ = new DevComponents.AdvTree.AdvTree();
            this.nodeMZ = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.pnlDetail = new DevComponents.DotNetBar.ExpandablePanel();
            this.checkDept = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtSearchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cbxStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cbxCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbxIncisionType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbxLevel_Inside = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbxLevel_GB = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtDoctorNumber = new DevComponents.Editors.IntegerInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.layoutControlItem12 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem3 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem1 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem2 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem5 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem4 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem8 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem9 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeZY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMZ)).BeginInit();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlLeft.Controls.Add(this.gridSurgery);
            this.pnlLeft.Controls.Add(this.bar1);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.ExpandButtonVisible = false;
            this.pnlLeft.HideControlsWhenCollapsed = true;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(447, 494);
            this.pnlLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlLeft.Style.GradientAngle = 90;
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlLeft.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlLeft.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlLeft.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlLeft.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlLeft.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlLeft.TitleStyle.GradientAngle = 90;
            this.pnlLeft.TitleText = "手术列表";
            // 
            // gridSurgery
            // 
            this.gridSurgery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSurgery.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridSurgery.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridSurgery.Location = new System.Drawing.Point(0, 79);
            this.gridSurgery.Name = "gridSurgery";
            // 
            // 
            // 
            this.gridSurgery.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridSurgery.PrimaryGrid.ReadOnly = true;
            this.gridSurgery.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridSurgery.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridSurgery.PrimaryGrid.ShowRowGridIndex = true;
            this.gridSurgery.Size = new System.Drawing.Size(447, 415);
            this.gridSurgery.TabIndex = 7;
            this.gridSurgery.Text = "superGridControl1";
            this.gridSurgery.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridSurgery_RowClick);
            this.gridSurgery.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridSurgery_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.DataPropertyName = "Name";
            this.gridColumn1.HeaderText = "手术名称";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnEdit});
            this.bar1.Location = new System.Drawing.Point(0, 52);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(447, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSearch.Location = new System.Drawing.Point(0, 26);
            this.txtSearch.MarkString = null;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(447, 26);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.WatermarkText = "请输入检索码或手术名称进行检索";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.expandablePanel1);
            this.pnlMain.Controls.Add(this.pnlDetail);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ExpandButtonVisible = false;
            this.pnlMain.HideControlsWhenCollapsed = true;
            this.pnlMain.Location = new System.Drawing.Point(447, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(548, 494);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 4;
            this.pnlMain.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlMain.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlMain.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.TitleStyle.GradientAngle = 90;
            this.pnlMain.TitleText = "详细信息";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.treeZY);
            this.expandablePanel1.Controls.Add(this.treeMZ);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 281);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(548, 213);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 8;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "开展该手术的科室";
            // 
            // treeZY
            // 
            this.treeZY.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeZY.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeZY.BackgroundStyle.Class = "TreeBorderKey";
            this.treeZY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeZY.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeZY.Font = new System.Drawing.Font("宋体", 12F);
            this.treeZY.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeZY.Location = new System.Drawing.Point(306, 26);
            this.treeZY.Name = "treeZY";
            this.treeZY.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodeZY});
            this.treeZY.NodesConnector = this.nodeConnector2;
            this.treeZY.NodeStyle = this.elementStyle2;
            this.treeZY.PathSeparator = ";";
            this.treeZY.Size = new System.Drawing.Size(306, 187);
            this.treeZY.Styles.Add(this.elementStyle2);
            this.treeZY.TabIndex = 5;
            this.treeZY.Text = "advTree1";
            // 
            // nodeZY
            // 
            this.nodeZY.Expanded = true;
            this.nodeZY.Name = "nodeZY";
            this.nodeZY.Text = "住院";
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
            // treeMZ
            // 
            this.treeMZ.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeMZ.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeMZ.BackgroundStyle.Class = "TreeBorderKey";
            this.treeMZ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeMZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeMZ.Font = new System.Drawing.Font("宋体", 12F);
            this.treeMZ.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeMZ.Location = new System.Drawing.Point(0, 26);
            this.treeMZ.Name = "treeMZ";
            this.treeMZ.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodeMZ});
            this.treeMZ.NodesConnector = this.nodeConnector1;
            this.treeMZ.NodeStyle = this.elementStyle1;
            this.treeMZ.PathSeparator = ";";
            this.treeMZ.Size = new System.Drawing.Size(306, 187);
            this.treeMZ.Styles.Add(this.elementStyle1);
            this.treeMZ.TabIndex = 4;
            this.treeMZ.Text = "advTree1";
            // 
            // nodeMZ
            // 
            this.nodeMZ.Expanded = true;
            this.nodeMZ.Name = "nodeMZ";
            this.nodeMZ.Text = "门诊";
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
            // pnlDetail
            // 
            this.pnlDetail.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlDetail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlDetail.Controls.Add(this.checkDept);
            this.pnlDetail.Controls.Add(this.btnSave);
            this.pnlDetail.Controls.Add(this.txtSearchCode);
            this.pnlDetail.Controls.Add(this.labelX9);
            this.pnlDetail.Controls.Add(this.cbxStatus);
            this.pnlDetail.Controls.Add(this.labelX8);
            this.pnlDetail.Controls.Add(this.cbxCategory);
            this.pnlDetail.Controls.Add(this.labelX6);
            this.pnlDetail.Controls.Add(this.cbxIncisionType);
            this.pnlDetail.Controls.Add(this.labelX7);
            this.pnlDetail.Controls.Add(this.cbxLevel_Inside);
            this.pnlDetail.Controls.Add(this.labelX5);
            this.pnlDetail.Controls.Add(this.cbxLevel_GB);
            this.pnlDetail.Controls.Add(this.labelX4);
            this.pnlDetail.Controls.Add(this.txtDoctorNumber);
            this.pnlDetail.Controls.Add(this.labelX3);
            this.pnlDetail.Controls.Add(this.txtCode);
            this.pnlDetail.Controls.Add(this.labelX2);
            this.pnlDetail.Controls.Add(this.txtName);
            this.pnlDetail.Controls.Add(this.labelX1);
            this.pnlDetail.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetail.ExpandButtonVisible = false;
            this.pnlDetail.HideControlsWhenCollapsed = true;
            this.pnlDetail.Location = new System.Drawing.Point(0, 26);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(548, 255);
            this.pnlDetail.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlDetail.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlDetail.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlDetail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlDetail.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlDetail.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlDetail.Style.GradientAngle = 90;
            this.pnlDetail.TabIndex = 19;
            this.pnlDetail.TitleHeight = 0;
            this.pnlDetail.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlDetail.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlDetail.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlDetail.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlDetail.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlDetail.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlDetail.TitleStyle.GradientAngle = 90;
            this.pnlDetail.TitleText = "Title Bar";
            // 
            // checkDept
            // 
            this.checkDept.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkDept.CheckSignSize = new System.Drawing.Size(18, 20);
            this.checkDept.Font = new System.Drawing.Font("宋体", 12F);
            this.checkDept.Location = new System.Drawing.Point(17, 232);
            this.checkDept.Name = "checkDept";
            this.checkDept.Size = new System.Drawing.Size(100, 23);
            this.checkDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkDept.TabIndex = 38;
            this.checkDept.Text = "全部科室";
            this.checkDept.CheckedChanged += new System.EventHandler(this.checkDept_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(17, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearchCode
            // 
            // 
            // 
            // 
            this.txtSearchCode.Border.Class = "TextBoxBorder";
            this.txtSearchCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSearchCode.Location = new System.Drawing.Point(350, 206);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.PreventEnterBeep = true;
            this.txtSearchCode.Size = new System.Drawing.Size(161, 26);
            this.txtSearchCode.TabIndex = 36;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX9.Location = new System.Drawing.Point(283, 206);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(77, 21);
            this.labelX9.TabIndex = 35;
            this.labelX9.Text = "检索码：";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DisplayMember = "Text";
            this.cbxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxStatus.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.ItemHeight = 21;
            this.cbxStatus.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbxStatus.Location = new System.Drawing.Point(125, 200);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(136, 27);
            this.cbxStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxStatus.TabIndex = 34;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "否";
            this.comboItem1.Value = "";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "是";
            this.comboItem2.Value = "";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX8.Location = new System.Drawing.Point(14, 203);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(124, 21);
            this.labelX8.TabIndex = 33;
            this.labelX8.Text = "是否正常开展：";
            // 
            // cbxCategory
            // 
            this.cbxCategory.DisplayMember = "Text";
            this.cbxCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxCategory.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.ItemHeight = 21;
            this.cbxCategory.Location = new System.Drawing.Point(350, 166);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(161, 27);
            this.cbxCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxCategory.TabIndex = 32;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX6.Location = new System.Drawing.Point(267, 166);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(93, 21);
            this.labelX6.TabIndex = 31;
            this.labelX6.Text = "手术归类：";
            // 
            // cbxIncisionType
            // 
            this.cbxIncisionType.DisplayMember = "Text";
            this.cbxIncisionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxIncisionType.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxIncisionType.FormattingEnabled = true;
            this.cbxIncisionType.ItemHeight = 21;
            this.cbxIncisionType.Location = new System.Drawing.Point(100, 166);
            this.cbxIncisionType.Name = "cbxIncisionType";
            this.cbxIncisionType.Size = new System.Drawing.Size(161, 27);
            this.cbxIncisionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxIncisionType.TabIndex = 30;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX7.Location = new System.Drawing.Point(14, 166);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(88, 21);
            this.labelX7.TabIndex = 29;
            this.labelX7.Text = "切口分类：";
            // 
            // cbxLevel_Inside
            // 
            this.cbxLevel_Inside.DisplayMember = "Text";
            this.cbxLevel_Inside.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxLevel_Inside.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxLevel_Inside.FormattingEnabled = true;
            this.cbxLevel_Inside.ItemHeight = 21;
            this.cbxLevel_Inside.Location = new System.Drawing.Point(350, 130);
            this.cbxLevel_Inside.Name = "cbxLevel_Inside";
            this.cbxLevel_Inside.Size = new System.Drawing.Size(161, 27);
            this.cbxLevel_Inside.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxLevel_Inside.TabIndex = 28;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX5.Location = new System.Drawing.Point(267, 130);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(93, 21);
            this.labelX5.TabIndex = 27;
            this.labelX5.Text = "院内等级：";
            // 
            // cbxLevel_GB
            // 
            this.cbxLevel_GB.DisplayMember = "Text";
            this.cbxLevel_GB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxLevel_GB.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxLevel_GB.FormattingEnabled = true;
            this.cbxLevel_GB.ItemHeight = 21;
            this.cbxLevel_GB.Location = new System.Drawing.Point(100, 130);
            this.cbxLevel_GB.Name = "cbxLevel_GB";
            this.cbxLevel_GB.Size = new System.Drawing.Size(161, 27);
            this.cbxLevel_GB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxLevel_GB.TabIndex = 26;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX4.Location = new System.Drawing.Point(14, 130);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(88, 21);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "手术等级：";
            // 
            // txtDoctorNumber
            // 
            // 
            // 
            // 
            this.txtDoctorNumber.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDoctorNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDoctorNumber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDoctorNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.txtDoctorNumber.Location = new System.Drawing.Point(350, 89);
            this.txtDoctorNumber.Name = "txtDoctorNumber";
            this.txtDoctorNumber.ShowUpDown = true;
            this.txtDoctorNumber.Size = new System.Drawing.Size(161, 26);
            this.txtDoctorNumber.TabIndex = 24;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX3.Location = new System.Drawing.Point(267, 94);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(93, 21);
            this.labelX3.TabIndex = 23;
            this.labelX3.Text = "手术人数：";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCode.Location = new System.Drawing.Point(100, 91);
            this.txtCode.Name = "txtCode";
            this.txtCode.PreventEnterBeep = true;
            this.txtCode.Size = new System.Drawing.Size(161, 26);
            this.txtCode.TabIndex = 22;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX2.Location = new System.Drawing.Point(14, 91);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(88, 21);
            this.labelX2.TabIndex = 21;
            this.labelX2.Text = "手术编码：";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtName.Location = new System.Drawing.Point(100, 53);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.Size = new System.Drawing.Size(411, 26);
            this.txtName.TabIndex = 20;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX1.Location = new System.Drawing.Point(14, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 21);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "手术名称：";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Height = 29;
            this.layoutControlItem12.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Text = "手术名称：";
            this.layoutControlItem12.Width = 100;
            this.layoutControlItem12.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Height = 29;
            this.layoutControlItem3.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Text = "Label:";
            this.layoutControlItem3.Width = 100;
            this.layoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Height = 29;
            this.layoutControlItem1.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Text = "Label:";
            this.layoutControlItem1.Width = 100;
            this.layoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Height = 29;
            this.layoutControlItem2.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Text = "Label:";
            this.layoutControlItem2.Width = 100;
            this.layoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Height = 29;
            this.layoutControlItem5.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Text = "Label:";
            this.layoutControlItem5.Width = 100;
            this.layoutControlItem5.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Height = 29;
            this.layoutControlItem4.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Text = "Label:";
            this.layoutControlItem4.Width = 100;
            this.layoutControlItem4.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Height = 29;
            this.layoutControlItem8.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Text = "Label:";
            this.layoutControlItem8.Width = 100;
            this.layoutControlItem8.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Height = 29;
            this.layoutControlItem9.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Text = "Label:";
            this.layoutControlItem9.Width = 100;
            this.layoutControlItem9.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // SurgeryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 494);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Name = "SurgeryManager";
            this.Text = "SurgeryManager";
            this.Shown += new System.EventHandler(this.SurgeryManager_Shown);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeZY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMZ)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel pnlLeft;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridSurgery;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.Bar bar1;
        private CIS.ControlLib.Controls.SuperText txtSearch;
        private DevComponents.DotNetBar.ExpandablePanel pnlMain;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem3;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem12;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem1;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem2;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem5;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem4;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem8;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem9;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.AdvTree.AdvTree treeZY;
        private DevComponents.AdvTree.Node nodeZY;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.AdvTree.AdvTree treeMZ;
        private DevComponents.AdvTree.Node nodeMZ;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ExpandablePanel pnlDetail;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchCode;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxStatus;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxCategory;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxIncisionType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxLevel_Inside;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxLevel_GB;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IntegerInput txtDoctorNumber;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkDept;
    }
}