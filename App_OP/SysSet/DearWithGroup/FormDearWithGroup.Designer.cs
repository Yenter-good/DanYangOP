namespace App_OP.SysSet.DearWithGroup
{
    partial class FormDearWithGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDearWithGroup));
            this.pnlJyList = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridList = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddItem_R = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxSearch = new CIS.ControlLib.Controls.SuperText();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAddItem = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbxNumber = new DevComponents.DotNetBar.TextBoxItem();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.treeGroup = new DevComponents.AdvTree.AdvTree();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeHospital = new DevComponents.AdvTree.Node();
            this.nodeDept = new DevComponents.AdvTree.Node();
            this.nodeUser = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar5 = new DevComponents.DotNetBar.Bar();
            this.btnAddGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelGroup = new DevComponents.DotNetBar.ButtonItem();
            this.pnlJySubList = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridSubList = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ContexTMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelItem_R = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUp_R = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDown_R = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelItem = new DevComponents.DotNetBar.ButtonItem();
            this.btnUp = new DevComponents.DotNetBar.ButtonItem();
            this.btnDown = new DevComponents.DotNetBar.ButtonItem();
            this.nodeHerbsHospital = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.pnlJyList.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGroup)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar5)).BeginInit();
            this.pnlJySubList.SuspendLayout();
            this.ContexTMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlJyList
            // 
            this.pnlJyList.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlJyList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlJyList.Controls.Add(this.gridList);
            this.pnlJyList.Controls.Add(this.tbxSearch);
            this.pnlJyList.Controls.Add(this.bar1);
            this.pnlJyList.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlJyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJyList.ExpandButtonVisible = false;
            this.pnlJyList.HideControlsWhenCollapsed = true;
            this.pnlJyList.Location = new System.Drawing.Point(257, 0);
            this.pnlJyList.Name = "pnlJyList";
            this.pnlJyList.Padding = new System.Windows.Forms.Padding(2);
            this.pnlJyList.Size = new System.Drawing.Size(296, 482);
            this.pnlJyList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJyList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJyList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJyList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlJyList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlJyList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlJyList.Style.GradientAngle = 90;
            this.pnlJyList.TabIndex = 32;
            this.pnlJyList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJyList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJyList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJyList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlJyList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlJyList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlJyList.TitleStyle.GradientAngle = 90;
            this.pnlJyList.TitleText = "收费项目列表";
            // 
            // gridList
            // 
            this.gridList.ContextMenuStrip = this.contextMenuStrip2;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridList.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridList.Location = new System.Drawing.Point(2, 81);
            this.gridList.Name = "gridList";
            // 
            // 
            // 
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridList.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.gridList.PrimaryGrid.ReadOnly = true;
            this.gridList.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridList.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridList.PrimaryGrid.ShowRowGridIndex = true;
            this.gridList.Size = new System.Drawing.Size(292, 399);
            this.gridList.TabIndex = 7;
            this.gridList.Text = "superGridControl1";
            this.gridList.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridList_RowDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem_R});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            // 
            // btnAddItem_R
            // 
            this.btnAddItem_R.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem_R.Image")));
            this.btnAddItem_R.Name = "btnAddItem_R";
            this.btnAddItem_R.Size = new System.Drawing.Size(124, 22);
            this.btnAddItem_R.Text = "加入分类";
            this.btnAddItem_R.Click += new System.EventHandler(this.btnAddItem_R_Click);
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
            // 
            // 
            // 
            this.tbxSearch.Border.Class = "TextBoxBorder";
            this.tbxSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxSearch.DelayTime = 300;
            this.tbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.tbxSearch.Location = new System.Drawing.Point(2, 55);
            this.tbxSearch.MarkString = null;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PreventEnterBeep = true;
            this.tbxSearch.Size = new System.Drawing.Size(292, 26);
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
            this.btnAddItem,
            this.labelItem1,
            this.tbxNumber});
            this.bar1.Location = new System.Drawing.Point(2, 28);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(292, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAddItem
            // 
            this.btnAddItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Text = "加入分类";
            this.btnAddItem.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "项目数量：";
            // 
            // tbxNumber
            // 
            this.tbxNumber.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Text = "1";
            this.tbxNumber.TextBoxWidth = 100;
            this.tbxNumber.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumber_KeyPress);
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.treeGroup);
            this.expandablePanel1.Controls.Add(this.bar5);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Padding = new System.Windows.Forms.Padding(2);
            this.expandablePanel1.Size = new System.Drawing.Size(257, 482);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 31;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "套餐分类";
            // 
            // treeGroup
            // 
            this.treeGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeGroup.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeGroup.BackgroundStyle.Class = "TreeBorderKey";
            this.treeGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeGroup.ContextMenuStrip = this.contextMenuStrip1;
            this.treeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGroup.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeGroup.Location = new System.Drawing.Point(2, 55);
            this.treeGroup.Name = "treeGroup";
            this.treeGroup.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodeHospital,
            this.nodeDept,
            this.nodeUser});
            this.treeGroup.NodesConnector = this.nodeConnector1;
            this.treeGroup.NodeStyle = this.elementStyle1;
            this.treeGroup.PathSeparator = ";";
            this.treeGroup.Size = new System.Drawing.Size(253, 425);
            this.treeGroup.Styles.Add(this.elementStyle1);
            this.treeGroup.TabIndex = 5;
            this.treeGroup.Text = "advTree1";
            this.treeGroup.Click += new System.EventHandler(this.treeGroup_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 22);
            this.btnAdd.Text = "增加分类";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 22);
            this.btnEdit.Text = "编辑分类";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(124, 22);
            this.btnDel.Text = "删除分类";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // nodeHospital
            // 
            this.nodeHospital.Expanded = true;
            this.nodeHospital.Image = ((System.Drawing.Image)(resources.GetObject("nodeHospital.Image")));
            this.nodeHospital.Name = "nodeHospital";
            this.nodeHospital.TagString = "全院套餐";
            this.nodeHospital.Text = "全院套餐";
            // 
            // nodeDept
            // 
            this.nodeDept.Expanded = true;
            this.nodeDept.Image = ((System.Drawing.Image)(resources.GetObject("nodeDept.Image")));
            this.nodeDept.Name = "nodeDept";
            this.nodeDept.TagString = "科室套餐";
            this.nodeDept.Text = "科室套餐";
            // 
            // nodeUser
            // 
            this.nodeUser.Expanded = true;
            this.nodeUser.Image = ((System.Drawing.Image)(resources.GetObject("nodeUser.Image")));
            this.nodeUser.Name = "nodeUser";
            this.nodeUser.TagString = "个人套餐";
            this.nodeUser.Text = "个人套餐";
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
            // bar5
            // 
            this.bar5.AntiAlias = true;
            this.bar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar5.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar5.IsMaximized = false;
            this.bar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddGroup,
            this.btnEditGroup,
            this.btnDelGroup});
            this.bar5.Location = new System.Drawing.Point(2, 28);
            this.bar5.Name = "bar5";
            this.bar5.Size = new System.Drawing.Size(253, 27);
            this.bar5.Stretch = true;
            this.bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar5.TabIndex = 4;
            this.bar5.TabStop = false;
            this.bar5.Text = "bar5";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Text = "增加分类";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGroup.Image")));
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Text = "编辑分类";
            this.btnEditGroup.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelGroup
            // 
            this.btnDelGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnDelGroup.Image")));
            this.btnDelGroup.Name = "btnDelGroup";
            this.btnDelGroup.Text = "删除分类";
            this.btnDelGroup.Click += new System.EventHandler(this.btnDelGroup_Click);
            // 
            // pnlJySubList
            // 
            this.pnlJySubList.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlJySubList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlJySubList.Controls.Add(this.gridSubList);
            this.pnlJySubList.Controls.Add(this.bar2);
            this.pnlJySubList.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlJySubList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlJySubList.ExpandButtonVisible = false;
            this.pnlJySubList.HideControlsWhenCollapsed = true;
            this.pnlJySubList.Location = new System.Drawing.Point(553, 0);
            this.pnlJySubList.Name = "pnlJySubList";
            this.pnlJySubList.Padding = new System.Windows.Forms.Padding(2);
            this.pnlJySubList.Size = new System.Drawing.Size(387, 482);
            this.pnlJySubList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJySubList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJySubList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJySubList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlJySubList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlJySubList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlJySubList.Style.GradientAngle = 90;
            this.pnlJySubList.TabIndex = 30;
            this.pnlJySubList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlJySubList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlJySubList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlJySubList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlJySubList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlJySubList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlJySubList.TitleStyle.GradientAngle = 90;
            this.pnlJySubList.TitleText = "分类明细列表";
            // 
            // gridSubList
            // 
            this.gridSubList.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.gridSubList.BackColor = System.Drawing.SystemColors.Control;
            this.gridSubList.ContextMenuStrip = this.ContexTMenuStrip3;
            this.gridSubList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSubList.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridSubList.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridSubList.Location = new System.Drawing.Point(2, 55);
            this.gridSubList.Name = "gridSubList";
            // 
            // 
            // 
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.gridSubList.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.gridSubList.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridSubList.PrimaryGrid.ShowRowGridIndex = true;
            this.gridSubList.Size = new System.Drawing.Size(383, 425);
            this.gridSubList.TabIndex = 8;
            this.gridSubList.Text = "superGridControl1";
            // 
            // ContexTMenuStrip3
            // 
            this.ContexTMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelItem_R,
            this.btnUp_R,
            this.btnDown_R});
            this.ContexTMenuStrip3.Name = "ContexTMenuStrip3";
            this.ContexTMenuStrip3.Size = new System.Drawing.Size(125, 70);
            // 
            // btnDelItem_R
            // 
            this.btnDelItem_R.Image = ((System.Drawing.Image)(resources.GetObject("btnDelItem_R.Image")));
            this.btnDelItem_R.Name = "btnDelItem_R";
            this.btnDelItem_R.Size = new System.Drawing.Size(124, 22);
            this.btnDelItem_R.Text = "删除明细";
            this.btnDelItem_R.Click += new System.EventHandler(this.btnDelItem_R_Click);
            // 
            // btnUp_R
            // 
            this.btnUp_R.Image = ((System.Drawing.Image)(resources.GetObject("btnUp_R.Image")));
            this.btnUp_R.Name = "btnUp_R";
            this.btnUp_R.Size = new System.Drawing.Size(124, 22);
            this.btnUp_R.Text = "上移";
            this.btnUp_R.Click += new System.EventHandler(this.btnUp_R_Click);
            // 
            // btnDown_R
            // 
            this.btnDown_R.Image = ((System.Drawing.Image)(resources.GetObject("btnDown_R.Image")));
            this.btnDown_R.Name = "btnDown_R";
            this.btnDown_R.Size = new System.Drawing.Size(124, 22);
            this.btnDown_R.Text = "下移";
            this.btnDown_R.Click += new System.EventHandler(this.btnDown_R_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn7.DataPropertyName = "ID";
            this.gridColumn7.Name = "gridSubList_Code";
            this.gridColumn7.Visible = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn8.DataPropertyName = "Name";
            this.gridColumn8.HeaderText = "项目名称";
            this.gridColumn8.Name = "gridSubList_Name";
            this.gridColumn8.ReadOnly = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "Price";
            this.gridColumn4.HeaderText = "价格";
            this.gridColumn4.Name = "gridSubList_Price";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Right;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSave,
            this.btnDelItem,
            this.btnUp,
            this.btnDown});
            this.bar2.Location = new System.Drawing.Point(2, 28);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(383, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 6;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelItem
            // 
            this.btnDelItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDelItem.Image")));
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Text = "删除明细";
            this.btnDelItem.Click += new System.EventHandler(this.btnItemDel_Click);
            // 
            // btnUp
            // 
            this.btnUp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Name = "btnUp";
            this.btnUp.Text = "上移";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Name = "btnDown";
            this.btnDown.Text = "下移";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // nodeHerbsHospital
            // 
            this.nodeHerbsHospital.Expanded = true;
            this.nodeHerbsHospital.Image = ((System.Drawing.Image)(resources.GetObject("nodeHerbsHospital.Image")));
            this.nodeHerbsHospital.Name = "nodeHerbsHospital";
            this.nodeHerbsHospital.TagString = "全院套餐";
            this.nodeHerbsHospital.Text = "全院套餐";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Image = ((System.Drawing.Image)(resources.GetObject("node2.Image")));
            this.node2.Name = "node2";
            this.node2.TagString = "全院套餐";
            this.node2.Text = "全院套餐";
            // 
            // FormDearWithGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 482);
            this.Controls.Add(this.pnlJyList);
            this.Controls.Add(this.expandablePanel1);
            this.Controls.Add(this.pnlJySubList);
            this.Name = "FormDearWithGroup";
            this.Text = "FormDearWithGroup";
            this.Shown += new System.EventHandler(this.FormDearWithGroup_Shown);
            this.pnlJyList.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeGroup)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar5)).EndInit();
            this.pnlJySubList.ResumeLayout(false);
            this.ContexTMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel pnlJyList;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridList;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private CIS.ControlLib.Controls.SuperText tbxSearch;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAddItem;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.AdvTree.AdvTree treeGroup;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Bar bar5;
        private DevComponents.DotNetBar.ButtonItem btnAddGroup;
        private DevComponents.DotNetBar.ButtonItem btnEditGroup;
        private DevComponents.DotNetBar.ButtonItem btnDelGroup;
        private DevComponents.DotNetBar.ExpandablePanel pnlJySubList;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridSubList;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnDelItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnAddItem_R;
        private System.Windows.Forms.ContextMenuStrip ContexTMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem btnDelItem_R;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbxNumber;
        private DevComponents.DotNetBar.ButtonItem btnUp;
        private DevComponents.DotNetBar.ButtonItem btnDown;
        private System.Windows.Forms.ToolStripMenuItem btnUp_R;
        private System.Windows.Forms.ToolStripMenuItem btnDown_R;
        private DevComponents.AdvTree.Node nodeDept;
        private DevComponents.AdvTree.Node nodeUser;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.AdvTree.Node nodeHospital;
        private DevComponents.AdvTree.Node nodeHerbsHospital;
        private DevComponents.AdvTree.Node node2;
    }
}