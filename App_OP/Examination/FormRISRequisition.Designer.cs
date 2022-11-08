namespace App_OP.Examination
{
    partial class FormRISRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRISRequisition));
            this.pnlList = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridList = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd_R = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxSearch = new CIS.ControlLib.Controls.SuperText();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnKnowlage = new DevComponents.DotNetBar.ButtonItem();
            this.gridTCSM = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.pnlConditionSummary = new DevComponents.DotNetBar.ExpandablePanel();
            this.tbxConditionSummary = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.pnlJySubList = new DevComponents.DotNetBar.ExpandablePanel();
            this.pnlJyExplanation = new DevComponents.DotNetBar.ExpandablePanel();
            this.tbxExplanation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gridSubList = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDel_R = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave_R = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnClear = new DevComponents.DotNetBar.ButtonItem();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.treeGroup = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.pnlList.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlConditionSummary.SuspendLayout();
            this.pnlJySubList.SuspendLayout();
            this.pnlJyExplanation.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlList
            // 
            this.pnlList.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlList.Controls.Add(this.gridList);
            this.pnlList.Controls.Add(this.tbxSearch);
            this.pnlList.Controls.Add(this.bar1);
            this.pnlList.Controls.Add(this.gridTCSM);
            this.pnlList.Controls.Add(this.pnlConditionSummary);
            this.pnlList.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.ExpandButtonVisible = false;
            this.pnlList.HideControlsWhenCollapsed = true;
            this.pnlList.Location = new System.Drawing.Point(200, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Padding = new System.Windows.Forms.Padding(2);
            this.pnlList.Size = new System.Drawing.Size(619, 592);
            this.pnlList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlList.Style.GradientAngle = 90;
            this.pnlList.TabIndex = 40;
            this.pnlList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlList.TitleStyle.GradientAngle = 90;
            this.pnlList.TitleText = "检查项目列表";
            // 
            // gridList
            // 
            this.gridList.ContextMenuStrip = this.contextMenuStrip1;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridList.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridList.Location = new System.Drawing.Point(2, 81);
            this.gridList.Name = "gridList";
            // 
            // 
            // 
            this.gridList.PrimaryGrid.AutoGenerateColumns = false;
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.gridList.PrimaryGrid.ReadOnly = true;
            this.gridList.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridList.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridList.PrimaryGrid.ShowRowGridIndex = true;
            this.gridList.Size = new System.Drawing.Size(615, 142);
            this.gridList.TabIndex = 33;
            this.gridList.Text = "superGridControl1";
            this.gridList.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridList_RowClick);
            this.gridList.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridList_RowDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd_R});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // btnAdd_R
            // 
            this.btnAdd_R.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd_R.Image")));
            this.btnAdd_R.Name = "btnAdd_R";
            this.btnAdd_R.Size = new System.Drawing.Size(100, 22);
            this.btnAdd_R.Text = "添加";
            this.btnAdd_R.Click += new System.EventHandler(this.btnAdd_R_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "Code";
            this.gridColumn1.Name = "gridJyList_Code";
            this.gridColumn1.Visible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn2.DataPropertyName = "Name";
            this.gridColumn2.HeaderText = "项目名称";
            this.gridColumn2.MinimumWidth = 200;
            this.gridColumn2.Name = "gridJyList_Name";
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "Price";
            this.gridColumn3.HeaderText = "价格";
            this.gridColumn3.Name = "gridJyList_Price";
            // 
            // tbxSearch
            // 
            this.tbxSearch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbxSearch.Border.Class = "TextBoxBorder";
            this.tbxSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.tbxSearch.Location = new System.Drawing.Point(2, 55);
            this.tbxSearch.MarkString = null;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PreventEnterBeep = true;
            this.tbxSearch.Size = new System.Drawing.Size(615, 26);
            this.tbxSearch.TabIndex = 6;
            this.tbxSearch.WatermarkText = "输入拼音码检索项目";
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnKnowlage});
            this.bar1.Location = new System.Drawing.Point(2, 28);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(615, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnKnowlage
            // 
            this.btnKnowlage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnKnowlage.Image = ((System.Drawing.Image)(resources.GetObject("btnKnowlage.Image")));
            this.btnKnowlage.Name = "btnKnowlage";
            this.btnKnowlage.Text = "知识库";
            this.btnKnowlage.Click += new System.EventHandler(this.btnKnowlage_Click);
            // 
            // gridTCSM
            // 
            this.gridTCSM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridTCSM.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridTCSM.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridTCSM.Location = new System.Drawing.Point(2, 223);
            this.gridTCSM.Name = "gridTCSM";
            // 
            // 
            // 
            this.gridTCSM.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.gridTCSM.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.gridTCSM.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.gridTCSM.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.gridTCSM.PrimaryGrid.ReadOnly = true;
            this.gridTCSM.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridTCSM.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridTCSM.PrimaryGrid.ShowRowGridIndex = true;
            this.gridTCSM.Size = new System.Drawing.Size(615, 180);
            this.gridTCSM.TabIndex = 40;
            this.gridTCSM.Visible = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.DataPropertyName = "适应症";
            this.gridColumn6.Name = "适应症";
            this.gridColumn6.Width = 150;
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "采集要求";
            this.gridColumn9.Name = "采集要求";
            // 
            // gridColumn10
            // 
            this.gridColumn10.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn10.DataPropertyName = "套餐说明";
            this.gridColumn10.Name = "套餐说明";
            this.gridColumn10.Width = 150;
            // 
            // gridColumn13
            // 
            this.gridColumn13.DataPropertyName = "准备内容";
            this.gridColumn13.Name = "准备内容";
            this.gridColumn13.Width = 150;
            // 
            // pnlConditionSummary
            // 
            this.pnlConditionSummary.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlConditionSummary.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlConditionSummary.Controls.Add(this.tbxConditionSummary);
            this.pnlConditionSummary.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlConditionSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConditionSummary.ExpandButtonVisible = false;
            this.pnlConditionSummary.HideControlsWhenCollapsed = true;
            this.pnlConditionSummary.Location = new System.Drawing.Point(2, 403);
            this.pnlConditionSummary.Name = "pnlConditionSummary";
            this.pnlConditionSummary.Size = new System.Drawing.Size(615, 187);
            this.pnlConditionSummary.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlConditionSummary.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlConditionSummary.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlConditionSummary.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlConditionSummary.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlConditionSummary.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlConditionSummary.Style.GradientAngle = 90;
            this.pnlConditionSummary.TabIndex = 29;
            this.pnlConditionSummary.TitleHeight = 30;
            this.pnlConditionSummary.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlConditionSummary.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlConditionSummary.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlConditionSummary.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlConditionSummary.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlConditionSummary.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlConditionSummary.TitleStyle.GradientAngle = 90;
            this.pnlConditionSummary.TitleText = "病史摘要";
            // 
            // tbxConditionSummary
            // 
            // 
            // 
            // 
            this.tbxConditionSummary.Border.Class = "TextBoxBorder";
            this.tbxConditionSummary.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxConditionSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxConditionSummary.Location = new System.Drawing.Point(0, 30);
            this.tbxConditionSummary.Multiline = true;
            this.tbxConditionSummary.Name = "tbxConditionSummary";
            this.tbxConditionSummary.PreventEnterBeep = true;
            this.tbxConditionSummary.Size = new System.Drawing.Size(615, 157);
            this.tbxConditionSummary.TabIndex = 4;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // pnlJySubList
            // 
            this.pnlJySubList.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlJySubList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlJySubList.Controls.Add(this.pnlJyExplanation);
            this.pnlJySubList.Controls.Add(this.gridSubList);
            this.pnlJySubList.Controls.Add(this.bar2);
            this.pnlJySubList.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlJySubList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlJySubList.ExpandButtonVisible = false;
            this.pnlJySubList.HideControlsWhenCollapsed = true;
            this.pnlJySubList.Location = new System.Drawing.Point(819, 0);
            this.pnlJySubList.MaximumSize = new System.Drawing.Size(350, 0);
            this.pnlJySubList.MinimumSize = new System.Drawing.Size(300, 0);
            this.pnlJySubList.Name = "pnlJySubList";
            this.pnlJySubList.Padding = new System.Windows.Forms.Padding(2);
            this.pnlJySubList.Size = new System.Drawing.Size(300, 592);
            this.pnlJySubList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJySubList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJySubList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJySubList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlJySubList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlJySubList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlJySubList.Style.GradientAngle = 90;
            this.pnlJySubList.TabIndex = 39;
            this.pnlJySubList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJySubList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJySubList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJySubList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlJySubList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlJySubList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlJySubList.TitleStyle.GradientAngle = 90;
            this.pnlJySubList.TitleText = "申请单信息";
            // 
            // pnlJyExplanation
            // 
            this.pnlJyExplanation.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlJyExplanation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlJyExplanation.Controls.Add(this.tbxExplanation);
            this.pnlJyExplanation.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlJyExplanation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlJyExplanation.ExpandButtonVisible = false;
            this.pnlJyExplanation.HideControlsWhenCollapsed = true;
            this.pnlJyExplanation.Location = new System.Drawing.Point(2, 449);
            this.pnlJyExplanation.Name = "pnlJyExplanation";
            this.pnlJyExplanation.Size = new System.Drawing.Size(296, 141);
            this.pnlJyExplanation.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJyExplanation.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJyExplanation.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJyExplanation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlJyExplanation.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlJyExplanation.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlJyExplanation.Style.GradientAngle = 90;
            this.pnlJyExplanation.TabIndex = 25;
            this.pnlJyExplanation.TitleHeight = 30;
            this.pnlJyExplanation.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJyExplanation.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJyExplanation.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJyExplanation.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlJyExplanation.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlJyExplanation.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlJyExplanation.TitleStyle.GradientAngle = 90;
            this.pnlJyExplanation.TitleText = "医生说明";
            // 
            // tbxExplanation
            // 
            // 
            // 
            // 
            this.tbxExplanation.Border.Class = "TextBoxBorder";
            this.tbxExplanation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxExplanation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxExplanation.Location = new System.Drawing.Point(0, 30);
            this.tbxExplanation.Multiline = true;
            this.tbxExplanation.Name = "tbxExplanation";
            this.tbxExplanation.PreventEnterBeep = true;
            this.tbxExplanation.Size = new System.Drawing.Size(296, 111);
            this.tbxExplanation.TabIndex = 4;
            // 
            // gridSubList
            // 
            this.gridSubList.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.gridSubList.ContextMenuStrip = this.contextMenuStrip2;
            this.gridSubList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSubList.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridSubList.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridSubList.Location = new System.Drawing.Point(2, 55);
            this.gridSubList.Name = "gridSubList";
            // 
            // 
            // 
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.gridSubList.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridSubList.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridSubList.PrimaryGrid.ShowRowGridIndex = true;
            this.gridSubList.Size = new System.Drawing.Size(296, 535);
            this.gridSubList.TabIndex = 17;
            this.gridSubList.Text = "superGridControl1";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel_R,
            this.btnSave_R});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 48);
            // 
            // btnDel_R
            // 
            this.btnDel_R.Image = ((System.Drawing.Image)(resources.GetObject("btnDel_R.Image")));
            this.btnDel_R.Name = "btnDel_R";
            this.btnDel_R.Size = new System.Drawing.Size(100, 22);
            this.btnDel_R.Text = "删除";
            this.btnDel_R.Click += new System.EventHandler(this.btnDel_R_Click);
            // 
            // btnSave_R
            // 
            this.btnSave_R.Image = ((System.Drawing.Image)(resources.GetObject("btnSave_R.Image")));
            this.btnSave_R.Name = "btnSave_R";
            this.btnSave_R.Size = new System.Drawing.Size(100, 22);
            this.btnSave_R.Text = "保存";
            this.btnSave_R.Click += new System.EventHandler(this.btnSave_R_Click);
            // 
            // gridColumn11
            // 
            this.gridColumn11.DataPropertyName = "ID";
            this.gridColumn11.Name = "gridSubList_ID";
            this.gridColumn11.Visible = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn7.DataPropertyName = "ItemCode";
            this.gridColumn7.Name = "gridSubList_Code";
            this.gridColumn7.Visible = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn8.DataPropertyName = "ItemName";
            this.gridColumn8.HeaderText = "待查项目";
            this.gridColumn8.Name = "gridSubList_Name";
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "Number";
            this.gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.gridColumn4.HeaderText = "数量";
            this.gridColumn4.Name = "gridSubList_Number";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DataPropertyName = "Price";
            this.gridColumn5.Name = "gridSubList_Price";
            this.gridColumn5.Visible = false;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Right;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDel,
            this.btnSave,
            this.btnClear});
            this.bar2.Location = new System.Drawing.Point(2, 28);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(296, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 6;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnDel
            // 
            this.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Name = "btnClear";
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.treeGroup);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.MaximumSize = new System.Drawing.Size(250, 0);
            this.expandablePanel1.MinimumSize = new System.Drawing.Size(200, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Padding = new System.Windows.Forms.Padding(2);
            this.expandablePanel1.Size = new System.Drawing.Size(200, 592);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 38;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "检查分类";
            // 
            // treeGroup
            // 
            this.treeGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeGroup.AllowDrop = false;
            this.treeGroup.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeGroup.BackgroundStyle.Class = "TreeBorderKey";
            this.treeGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGroup.DragDropEnabled = false;
            this.treeGroup.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeGroup.Location = new System.Drawing.Point(2, 28);
            this.treeGroup.Name = "treeGroup";
            this.treeGroup.NodesConnector = this.nodeConnector1;
            this.treeGroup.NodeStyle = this.elementStyle1;
            this.treeGroup.PathSeparator = ";";
            this.treeGroup.Size = new System.Drawing.Size(196, 562);
            this.treeGroup.Styles.Add(this.elementStyle1);
            this.treeGroup.TabIndex = 5;
            this.treeGroup.Text = "advTree1";
            this.treeGroup.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.treeGroup_AfterNodeSelect);
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
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // FormRISRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 592);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlJySubList);
            this.Controls.Add(this.expandablePanel1);
            this.Name = "FormRISRequisition";
            this.Shown += new System.EventHandler(this.FormPacsRequisition_Shown);
            this.pnlList.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlConditionSummary.ResumeLayout(false);
            this.pnlJySubList.ResumeLayout(false);
            this.pnlJyExplanation.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel pnlList;
        private CIS.ControlLib.Controls.SuperText tbxSearch;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ExpandablePanel pnlJySubList;
        private DevComponents.DotNetBar.ExpandablePanel pnlJyExplanation;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxExplanation;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridSubList;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.AdvTree.AdvTree treeGroup;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ExpandablePanel pnlConditionSummary;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxConditionSummary;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd_R;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnDel_R;
        private System.Windows.Forms.ToolStripMenuItem btnSave_R;
        private DevComponents.DotNetBar.ButtonItem btnClear;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridList;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridTCSM;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.ButtonItem btnKnowlage;
    }
}