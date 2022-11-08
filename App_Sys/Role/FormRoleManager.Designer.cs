namespace App_Sys
{
    partial class FormRoleManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoleManager));
            this.pnlRoleList = new DevComponents.DotNetBar.ExpandablePanel();
            this.pnlAllUser = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridAllUser = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxAllUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlCurrUser = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridCurrUser = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxCurrUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gridRole = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridRole_Code = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRole_Name = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridRole_Description = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.barRoleList = new DevComponents.DotNetBar.Bar();
            this.btnRefreshRole = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddRole = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelRole = new DevComponents.DotNetBar.ButtonItem();
            this.btnSet = new DevComponents.DotNetBar.ButtonItem();
            this.pnlRoleSet = new DevComponents.DotNetBar.ExpandablePanel();
            this.menuTree = new DevComponents.AdvTree.AdvTree();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnRoleSetSave = new DevComponents.DotNetBar.ButtonItem();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.pnlRoleList.SuspendLayout();
            this.pnlAllUser.SuspendLayout();
            this.pnlCurrUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barRoleList)).BeginInit();
            this.pnlRoleSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRoleList
            // 
            this.pnlRoleList.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlRoleList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlRoleList.Controls.Add(this.pnlAllUser);
            this.pnlRoleList.Controls.Add(this.pnlCurrUser);
            this.pnlRoleList.Controls.Add(this.gridRole);
            this.pnlRoleList.Controls.Add(this.barRoleList);
            this.pnlRoleList.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlRoleList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRoleList.ExpandButtonVisible = false;
            this.pnlRoleList.HideControlsWhenCollapsed = true;
            this.pnlRoleList.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleList.Name = "pnlRoleList";
            this.pnlRoleList.Padding = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.pnlRoleList.Size = new System.Drawing.Size(530, 530);
            this.pnlRoleList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlRoleList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRoleList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRoleList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlRoleList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlRoleList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlRoleList.Style.GradientAngle = 90;
            this.pnlRoleList.TabIndex = 0;
            this.pnlRoleList.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRoleList.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRoleList.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlRoleList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlRoleList.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlRoleList.TitleStyle.GradientAngle = 90;
            this.pnlRoleList.TitleText = "角色列表";
            // 
            // pnlAllUser
            // 
            this.pnlAllUser.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlAllUser.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlAllUser.Controls.Add(this.gridAllUser);
            this.pnlAllUser.Controls.Add(this.tbxAllUser);
            this.pnlAllUser.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlAllUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAllUser.ExpandButtonVisible = false;
            this.pnlAllUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.pnlAllUser.HideControlsWhenCollapsed = true;
            this.pnlAllUser.Location = new System.Drawing.Point(269, 238);
            this.pnlAllUser.Name = "pnlAllUser";
            this.pnlAllUser.Padding = new System.Windows.Forms.Padding(4);
            this.pnlAllUser.Size = new System.Drawing.Size(256, 292);
            this.pnlAllUser.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlAllUser.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlAllUser.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlAllUser.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlAllUser.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlAllUser.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlAllUser.Style.GradientAngle = 90;
            this.pnlAllUser.TabIndex = 13;
            this.pnlAllUser.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlAllUser.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlAllUser.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlAllUser.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlAllUser.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlAllUser.TitleStyle.GradientAngle = 90;
            this.pnlAllUser.TitleText = "所有用户";
            // 
            // gridAllUser
            // 
            this.gridAllUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAllUser.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridAllUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridAllUser.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridAllUser.Location = new System.Drawing.Point(4, 53);
            this.gridAllUser.Name = "gridAllUser";
            this.gridAllUser.Padding = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gridAllUser.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridAllUser.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.gridAllUser.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.gridAllUser.PrimaryGrid.MultiSelect = false;
            this.gridAllUser.PrimaryGrid.ReadOnly = true;
            this.gridAllUser.PrimaryGrid.RowHeaderWidth = 0;
            this.gridAllUser.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridAllUser.Size = new System.Drawing.Size(248, 235);
            this.gridAllUser.TabIndex = 15;
            this.gridAllUser.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridAllUser_RowDoubleClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.DataPropertyName = "Code";
            this.gridColumn7.HeaderText = "工号";
            this.gridColumn7.Name = "gridAllUser_Code";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn8.DataPropertyName = "Name";
            this.gridColumn8.HeaderText = "姓名";
            this.gridColumn8.Name = "gridAllUser_Name";
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "ID";
            this.gridColumn9.Name = "gridAllUser_ID";
            this.gridColumn9.Visible = false;
            // 
            // tbxAllUser
            // 
            // 
            // 
            // 
            this.tbxAllUser.Border.Class = "TextBoxBorder";
            this.tbxAllUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxAllUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxAllUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.tbxAllUser.Location = new System.Drawing.Point(4, 30);
            this.tbxAllUser.Name = "tbxAllUser";
            this.tbxAllUser.PreventEnterBeep = true;
            this.tbxAllUser.Size = new System.Drawing.Size(248, 23);
            this.tbxAllUser.TabIndex = 13;
            this.tbxAllUser.WatermarkText = "用户过滤 拼音码或工号";
            this.tbxAllUser.TextChanged += new System.EventHandler(this.tbxAllUser_TextChanged);
            // 
            // pnlCurrUser
            // 
            this.pnlCurrUser.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlCurrUser.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlCurrUser.Controls.Add(this.gridCurrUser);
            this.pnlCurrUser.Controls.Add(this.tbxCurrUser);
            this.pnlCurrUser.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlCurrUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCurrUser.ExpandButtonVisible = false;
            this.pnlCurrUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.pnlCurrUser.HideControlsWhenCollapsed = true;
            this.pnlCurrUser.Location = new System.Drawing.Point(5, 238);
            this.pnlCurrUser.Name = "pnlCurrUser";
            this.pnlCurrUser.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCurrUser.Size = new System.Drawing.Size(264, 292);
            this.pnlCurrUser.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlCurrUser.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlCurrUser.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlCurrUser.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlCurrUser.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlCurrUser.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlCurrUser.Style.GradientAngle = 90;
            this.pnlCurrUser.TabIndex = 6;
            this.pnlCurrUser.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlCurrUser.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlCurrUser.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlCurrUser.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlCurrUser.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlCurrUser.TitleStyle.GradientAngle = 90;
            this.pnlCurrUser.TitleText = "角色用户";
            // 
            // gridCurrUser
            // 
            this.gridCurrUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCurrUser.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridCurrUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridCurrUser.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridCurrUser.Location = new System.Drawing.Point(4, 53);
            this.gridCurrUser.Name = "gridCurrUser";
            this.gridCurrUser.Padding = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gridCurrUser.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridCurrUser.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridCurrUser.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.gridCurrUser.PrimaryGrid.MultiSelect = false;
            this.gridCurrUser.PrimaryGrid.ReadOnly = true;
            this.gridCurrUser.PrimaryGrid.RowHeaderWidth = 0;
            this.gridCurrUser.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridCurrUser.Size = new System.Drawing.Size(256, 235);
            this.gridCurrUser.TabIndex = 14;
            this.gridCurrUser.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridCurrUser_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "Code";
            this.gridColumn1.HeaderText = "工号";
            this.gridColumn1.Name = "gridCurrUser_Code";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn2.DataPropertyName = "Name";
            this.gridColumn2.HeaderText = "姓名";
            this.gridColumn2.Name = "gridCurrUser_Name";
            // 
            // gridColumn6
            // 
            this.gridColumn6.DataPropertyName = "ID";
            this.gridColumn6.Name = "gridCurrUser_ID";
            this.gridColumn6.Visible = false;
            // 
            // tbxCurrUser
            // 
            // 
            // 
            // 
            this.tbxCurrUser.Border.Class = "TextBoxBorder";
            this.tbxCurrUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCurrUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxCurrUser.Font = new System.Drawing.Font("宋体", 10.5F);
            this.tbxCurrUser.Location = new System.Drawing.Point(4, 30);
            this.tbxCurrUser.Name = "tbxCurrUser";
            this.tbxCurrUser.PreventEnterBeep = true;
            this.tbxCurrUser.Size = new System.Drawing.Size(256, 23);
            this.tbxCurrUser.TabIndex = 12;
            this.tbxCurrUser.WatermarkText = "用户过滤 拼音码或工号";
            this.tbxCurrUser.TextChanged += new System.EventHandler(this.tbxCurrUser_TextChanged);
            // 
            // gridRole
            // 
            this.gridRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridRole.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridRole.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridRole.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridRole.Location = new System.Drawing.Point(5, 58);
            this.gridRole.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gridRole.Name = "gridRole";
            this.gridRole.Padding = new System.Windows.Forms.Padding(10, 1, 0, 1);
            // 
            // 
            // 
            this.gridRole.PrimaryGrid.Columns.Add(this.gridRole_Code);
            this.gridRole.PrimaryGrid.Columns.Add(this.gridRole_Name);
            this.gridRole.PrimaryGrid.Columns.Add(this.gridRole_Description);
            this.gridRole.PrimaryGrid.ReadOnly = true;
            this.gridRole.PrimaryGrid.RowHeaderWidth = 0;
            this.gridRole.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridRole.Size = new System.Drawing.Size(520, 180);
            this.gridRole.TabIndex = 5;
            this.gridRole.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.gridRole_CellClick);
            // 
            // gridRole_Code
            // 
            this.gridRole_Code.DataPropertyName = "Code";
            this.gridRole_Code.HeaderText = "代码";
            this.gridRole_Code.Name = "gridRole_Code";
            // 
            // gridRole_Name
            // 
            this.gridRole_Name.DataPropertyName = "Name";
            this.gridRole_Name.HeaderText = "角色名称";
            this.gridRole_Name.Name = "gridRole_Name";
            // 
            // gridRole_Description
            // 
            this.gridRole_Description.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridRole_Description.DataPropertyName = "Description";
            this.gridRole_Description.HeaderText = "角色描述";
            this.gridRole_Description.Name = "gridRole_Description";
            // 
            // barRoleList
            // 
            this.barRoleList.AntiAlias = true;
            this.barRoleList.Dock = System.Windows.Forms.DockStyle.Top;
            this.barRoleList.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.barRoleList.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.barRoleList.IsMaximized = false;
            this.barRoleList.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefreshRole,
            this.btnAddRole,
            this.btnDelRole,
            this.btnSet});
            this.barRoleList.Location = new System.Drawing.Point(5, 28);
            this.barRoleList.Name = "barRoleList";
            this.barRoleList.RoundCorners = false;
            this.barRoleList.Size = new System.Drawing.Size(520, 30);
            this.barRoleList.Stretch = true;
            this.barRoleList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barRoleList.TabIndex = 4;
            this.barRoleList.TabStop = false;
            this.barRoleList.Text = "bar1";
            // 
            // btnRefreshRole
            // 
            this.btnRefreshRole.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefreshRole.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshRole.Image")));
            this.btnRefreshRole.Name = "btnRefreshRole";
            this.btnRefreshRole.Text = "刷新";
            this.btnRefreshRole.Click += new System.EventHandler(this.btnRefreshRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddRole.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRole.Image")));
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Text = "添加";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnDelRole
            // 
            this.btnDelRole.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelRole.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRole.Image")));
            this.btnDelRole.Name = "btnDelRole";
            this.btnDelRole.Text = "删除";
            this.btnDelRole.Click += new System.EventHandler(this.btnDelRole_Click);
            // 
            // btnSet
            // 
            this.btnSet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.Name = "btnSet";
            this.btnSet.Text = "角色参数";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // pnlRoleSet
            // 
            this.pnlRoleSet.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlRoleSet.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlRoleSet.Controls.Add(this.menuTree);
            this.pnlRoleSet.Controls.Add(this.bar1);
            this.pnlRoleSet.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlRoleSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoleSet.ExpandButtonVisible = false;
            this.pnlRoleSet.Font = new System.Drawing.Font("宋体", 10.5F);
            this.pnlRoleSet.HideControlsWhenCollapsed = true;
            this.pnlRoleSet.Location = new System.Drawing.Point(530, 0);
            this.pnlRoleSet.Name = "pnlRoleSet";
            this.pnlRoleSet.Padding = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.pnlRoleSet.Size = new System.Drawing.Size(490, 530);
            this.pnlRoleSet.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlRoleSet.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRoleSet.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRoleSet.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlRoleSet.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlRoleSet.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlRoleSet.Style.GradientAngle = 90;
            this.pnlRoleSet.TabIndex = 7;
            this.pnlRoleSet.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRoleSet.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRoleSet.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlRoleSet.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlRoleSet.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlRoleSet.TitleStyle.GradientAngle = 90;
            this.pnlRoleSet.TitleText = "权限分配";
            // 
            // menuTree
            // 
            this.menuTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.menuTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.menuTree.BackgroundStyle.Class = "TreeBorderKey";
            this.menuTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.menuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTree.Font = new System.Drawing.Font("宋体", 10.5F);
            this.menuTree.ImageList = this.imageList;
            this.menuTree.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.menuTree.Location = new System.Drawing.Point(5, 55);
            this.menuTree.Name = "menuTree";
            this.menuTree.NodesConnector = this.nodeConnector1;
            this.menuTree.NodeStyle = this.elementStyle1;
            this.menuTree.PathSeparator = ";";
            this.menuTree.Size = new System.Drawing.Size(480, 475);
            this.menuTree.Styles.Add(this.elementStyle1);
            this.menuTree.TabIndex = 5;
            this.menuTree.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.menuTree_NodeClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "1.ico");
            this.imageList.Images.SetKeyName(1, "2.ico");
            this.imageList.Images.SetKeyName(2, "3.ico");
            this.imageList.Images.SetKeyName(3, "4.ico");
            this.imageList.Images.SetKeyName(4, "5.ico");
            this.imageList.Images.SetKeyName(5, "6.ico");
            this.imageList.Images.SetKeyName(6, "7.ico");
            this.imageList.Images.SetKeyName(7, "8.ico");
            this.imageList.Images.SetKeyName(8, "9.ico");
            this.imageList.Images.SetKeyName(9, "10.ico");
            this.imageList.Images.SetKeyName(10, "11.ico");
            this.imageList.Images.SetKeyName(11, "12.ico");
            this.imageList.Images.SetKeyName(12, "13.ico");
            this.imageList.Images.SetKeyName(13, "14.ico");
            this.imageList.Images.SetKeyName(14, "15.ico");
            this.imageList.Images.SetKeyName(15, "16.ico");
            this.imageList.Images.SetKeyName(16, "17.ico");
            this.imageList.Images.SetKeyName(17, "18.ico");
            this.imageList.Images.SetKeyName(18, "19.ico");
            this.imageList.Images.SetKeyName(19, "20.ico");
            this.imageList.Images.SetKeyName(20, "21.ico");
            this.imageList.Images.SetKeyName(21, "22.ico");
            this.imageList.Images.SetKeyName(22, "23.ico");
            this.imageList.Images.SetKeyName(23, "24.ico");
            this.imageList.Images.SetKeyName(24, "25.ico");
            this.imageList.Images.SetKeyName(25, "26.ico");
            this.imageList.Images.SetKeyName(26, "27.ico");
            this.imageList.Images.SetKeyName(27, "28.ico");
            this.imageList.Images.SetKeyName(28, "29.ico");
            this.imageList.Images.SetKeyName(29, "30.ico");
            this.imageList.Images.SetKeyName(30, "31.ico");
            this.imageList.Images.SetKeyName(31, "32.ico");
            this.imageList.Images.SetKeyName(32, "33.ico");
            this.imageList.Images.SetKeyName(33, "34.ico");
            this.imageList.Images.SetKeyName(34, "35.ico");
            this.imageList.Images.SetKeyName(35, "36.ico");
            this.imageList.Images.SetKeyName(36, "37.ico");
            this.imageList.Images.SetKeyName(37, "38.ico");
            this.imageList.Images.SetKeyName(38, "39.ico");
            this.imageList.Images.SetKeyName(39, "40.ico");
            this.imageList.Images.SetKeyName(40, "41.ico");
            this.imageList.Images.SetKeyName(41, "42.ico");
            this.imageList.Images.SetKeyName(42, "43.ico");
            this.imageList.Images.SetKeyName(43, "44.ico");
            this.imageList.Images.SetKeyName(44, "45.ico");
            this.imageList.Images.SetKeyName(45, "46.ico");
            this.imageList.Images.SetKeyName(46, "47.ico");
            this.imageList.Images.SetKeyName(47, "48.ico");
            this.imageList.Images.SetKeyName(48, "49.ico");
            this.imageList.Images.SetKeyName(49, "50.ico");
            this.imageList.Images.SetKeyName(50, "51.ico");
            this.imageList.Images.SetKeyName(51, "52.ico");
            this.imageList.Images.SetKeyName(52, "53.ico");
            this.imageList.Images.SetKeyName(53, "54.ico");
            this.imageList.Images.SetKeyName(54, "55.ico");
            this.imageList.Images.SetKeyName(55, "56.ico");
            this.imageList.Images.SetKeyName(56, "57.ico");
            this.imageList.Images.SetKeyName(57, "58.ico");
            this.imageList.Images.SetKeyName(58, "59.ico");
            this.imageList.Images.SetKeyName(59, "60.ico");
            this.imageList.Images.SetKeyName(60, "61.ico");
            this.imageList.Images.SetKeyName(61, "62.ico");
            this.imageList.Images.SetKeyName(62, "63.ico");
            this.imageList.Images.SetKeyName(63, "64.ico");
            this.imageList.Images.SetKeyName(64, "65.ico");
            this.imageList.Images.SetKeyName(65, "66.ico");
            this.imageList.Images.SetKeyName(66, "67.ico");
            this.imageList.Images.SetKeyName(67, "68.ico");
            this.imageList.Images.SetKeyName(68, "69.ico");
            this.imageList.Images.SetKeyName(69, "70.ico");
            this.imageList.Images.SetKeyName(70, "71.ico");
            this.imageList.Images.SetKeyName(71, "72.ico");
            this.imageList.Images.SetKeyName(72, "73.ico");
            this.imageList.Images.SetKeyName(73, "74.ico");
            this.imageList.Images.SetKeyName(74, "75.ico");
            this.imageList.Images.SetKeyName(75, "76.ico");
            this.imageList.Images.SetKeyName(76, "77.ico");
            this.imageList.Images.SetKeyName(77, "78.ico");
            this.imageList.Images.SetKeyName(78, "79.ico");
            this.imageList.Images.SetKeyName(79, "80.ico");
            this.imageList.Images.SetKeyName(80, "81.ico");
            this.imageList.Images.SetKeyName(81, "82.ico");
            this.imageList.Images.SetKeyName(82, "83.ico");
            this.imageList.Images.SetKeyName(83, "84.ico");
            this.imageList.Images.SetKeyName(84, "85.ico");
            this.imageList.Images.SetKeyName(85, "86.ico");
            this.imageList.Images.SetKeyName(86, "87.ico");
            this.imageList.Images.SetKeyName(87, "88.ico");
            this.imageList.Images.SetKeyName(88, "89.ico");
            this.imageList.Images.SetKeyName(89, "90.ico");
            this.imageList.Images.SetKeyName(90, "91.ico");
            this.imageList.Images.SetKeyName(91, "92.ico");
            this.imageList.Images.SetKeyName(92, "93.ico");
            this.imageList.Images.SetKeyName(93, "94.ico");
            this.imageList.Images.SetKeyName(94, "95.ico");
            this.imageList.Images.SetKeyName(95, "96.ico");
            this.imageList.Images.SetKeyName(96, "97.ico");
            this.imageList.Images.SetKeyName(97, "98.ico");
            this.imageList.Images.SetKeyName(98, "99.ico");
            this.imageList.Images.SetKeyName(99, "100.ico");
            this.imageList.Images.SetKeyName(100, "101.ico");
            this.imageList.Images.SetKeyName(101, "102.ico");
            this.imageList.Images.SetKeyName(102, "103.ico");
            this.imageList.Images.SetKeyName(103, "104.ico");
            this.imageList.Images.SetKeyName(104, "105.ico");
            this.imageList.Images.SetKeyName(105, "106.ico");
            this.imageList.Images.SetKeyName(106, "107.ico");
            this.imageList.Images.SetKeyName(107, "108.ico");
            this.imageList.Images.SetKeyName(108, "109.ico");
            this.imageList.Images.SetKeyName(109, "110.ico");
            this.imageList.Images.SetKeyName(110, "111.ico");
            this.imageList.Images.SetKeyName(111, "112.ico");
            this.imageList.Images.SetKeyName(112, "113.ico");
            this.imageList.Images.SetKeyName(113, "114.ico");
            this.imageList.Images.SetKeyName(114, "115.ico");
            this.imageList.Images.SetKeyName(115, "116.ico");
            this.imageList.Images.SetKeyName(116, "117.ico");
            this.imageList.Images.SetKeyName(117, "118.ico");
            this.imageList.Images.SetKeyName(118, "119.ico");
            this.imageList.Images.SetKeyName(119, "120.ico");
            this.imageList.Images.SetKeyName(120, "121.ico");
            this.imageList.Images.SetKeyName(121, "122.ico");
            this.imageList.Images.SetKeyName(122, "123.ico");
            this.imageList.Images.SetKeyName(123, "124.ico");
            this.imageList.Images.SetKeyName(124, "125.ico");
            this.imageList.Images.SetKeyName(125, "126.ico");
            this.imageList.Images.SetKeyName(126, "127.ico");
            this.imageList.Images.SetKeyName(127, "128.ico");
            this.imageList.Images.SetKeyName(128, "129.ico");
            this.imageList.Images.SetKeyName(129, "130.ico");
            this.imageList.Images.SetKeyName(130, "131.ico");
            this.imageList.Images.SetKeyName(131, "132.ico");
            this.imageList.Images.SetKeyName(132, "133.ico");
            this.imageList.Images.SetKeyName(133, "134.ico");
            this.imageList.Images.SetKeyName(134, "135.ico");
            this.imageList.Images.SetKeyName(135, "136.ico");
            this.imageList.Images.SetKeyName(136, "137.ico");
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.Transparent;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRoleSetSave});
            this.bar1.Location = new System.Drawing.Point(5, 28);
            this.bar1.Name = "bar1";
            this.bar1.PaddingLeft = 5;
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(480, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnRoleSetSave
            // 
            this.btnRoleSetSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRoleSetSave.Image = ((System.Drawing.Image)(resources.GetObject("btnRoleSetSave.Image")));
            this.btnRoleSetSave.Name = "btnRoleSetSave";
            this.btnRoleSetSave.Text = "保存";
            this.btnRoleSetSave.Click += new System.EventHandler(this.btnRoleSetSave_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "ID";
            this.gridColumn3.Name = "gridAllUser_ID";
            this.gridColumn3.Visible = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn5.DataPropertyName = "Name";
            this.gridColumn5.HeaderText = "姓名";
            this.gridColumn5.Name = "gridAllUser_Name";
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "Code";
            this.gridColumn4.HeaderText = "工号";
            this.gridColumn4.Name = "gridAllUser_Code";
            // 
            // FormRoleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 530);
            this.Controls.Add(this.pnlRoleSet);
            this.Controls.Add(this.pnlRoleList);
            this.Name = "FormRoleManager";
            this.Text = "角色管理";
            this.Shown += new System.EventHandler(this.FormRoleManager_Shown);
            this.pnlRoleList.ResumeLayout(false);
            this.pnlAllUser.ResumeLayout(false);
            this.pnlCurrUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barRoleList)).EndInit();
            this.pnlRoleSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel pnlRoleList;
        private DevComponents.DotNetBar.ExpandablePanel pnlRoleSet;
        private DevComponents.DotNetBar.Bar barRoleList;
        private DevComponents.DotNetBar.ButtonItem btnAddRole;
        private DevComponents.DotNetBar.ButtonItem btnDelRole;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnRoleSetSave;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridRole;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridRole_Code;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridRole_Name;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridRole_Description;
        private DevComponents.AdvTree.AdvTree menuTree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonItem btnRefreshRole;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.ButtonItem btnSet;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.ExpandablePanel pnlCurrUser;
        private DevComponents.DotNetBar.ExpandablePanel pnlAllUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxCurrUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxAllUser;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridCurrUser;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridAllUser;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
    }
}