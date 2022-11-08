namespace App_Template
{
    partial class FormRangeType
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRangeType));
            this.gridTPRange = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.colEditCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditRTypeCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditNo = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnManager = new DevComponents.DotNetBar.ButtonItem();
            this.Tree = new DevComponents.AdvTree.AdvTree();
            this.ROOT = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTPRange
            // 
            this.gridTPRange.BackColor = System.Drawing.Color.AliceBlue;
            background1.Color1 = System.Drawing.Color.AliceBlue;
            this.gridTPRange.DefaultVisualStyles.GridPanelStyle.Background = background1;
            this.gridTPRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTPRange.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridTPRange.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridTPRange.Location = new System.Drawing.Point(0, 27);
            this.gridTPRange.Name = "gridTPRange";
            // 
            // 
            // 
            this.gridTPRange.PrimaryGrid.AutoGenerateColumns = false;
            this.gridTPRange.PrimaryGrid.Columns.Add(this.colEditCode);
            this.gridTPRange.PrimaryGrid.Columns.Add(this.colEditName);
            this.gridTPRange.PrimaryGrid.Columns.Add(this.colEditRTypeCode);
            this.gridTPRange.PrimaryGrid.Columns.Add(this.colEditNo);
            borderColor1.Bottom = System.Drawing.Color.Transparent;
            borderColor1.Left = System.Drawing.Color.Transparent;
            borderColor1.Right = System.Drawing.Color.Transparent;
            borderColor1.Top = System.Drawing.Color.Transparent;
            this.gridTPRange.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor1;
            this.gridTPRange.PrimaryGrid.MultiSelect = false;
            this.gridTPRange.PrimaryGrid.ReadOnly = true;
            this.gridTPRange.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
            this.gridTPRange.PrimaryGrid.ShowRowGridIndex = true;
            this.gridTPRange.Size = new System.Drawing.Size(699, 436);
            this.gridTPRange.TabIndex = 1;
            this.gridTPRange.Text = "gridTPRange";
            this.gridTPRange.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridTPRange_RowClick);
            this.gridTPRange.DoubleClick += new System.EventHandler(this.gridTPRange_DoubleClick);
            // 
            // colEditCode
            // 
            this.colEditCode.DataPropertyName = "Code";
            this.colEditCode.HeaderText = "编码";
            this.colEditCode.Name = "colEditCode";
            // 
            // colEditName
            // 
            this.colEditName.DataPropertyName = "Name";
            this.colEditName.FillWeight = 200;
            this.colEditName.HeaderText = "名称";
            this.colEditName.Name = "colEditName";
            this.colEditName.Width = 150;
            // 
            // colEditRTypeCode
            // 
            this.colEditRTypeCode.DataPropertyName = "RangeTypeCode";
            this.colEditRTypeCode.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            this.colEditRTypeCode.FillWeight = 200;
            this.colEditRTypeCode.HeaderText = "上级编码";
            this.colEditRTypeCode.Name = "colEditRTypeCode";
            this.colEditRTypeCode.Width = 150;
            // 
            // colEditNo
            // 
            this.colEditNo.DataPropertyName = "No";
            this.colEditNo.HeaderText = "排序";
            this.colEditNo.Name = "colEditNo";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefresh,
            this.btnAdd,
            this.btnDel,
            this.btnEdit,
            this.btnManager});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(699, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BeginGroup = true;
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnManager
            // 
            this.btnManager.BeginGroup = true;
            this.btnManager.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnManager.Image = ((System.Drawing.Image)(resources.GetObject("btnManager.Image")));
            this.btnManager.Name = "btnManager";
            this.btnManager.Text = "新增值域类型";
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // Tree
            // 
            this.Tree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.Tree.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.Tree.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
            this.Tree.BackgroundStyle.Class = "TreeBorderKey";
            this.Tree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.Tree.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.Tree.Location = new System.Drawing.Point(0, 27);
            this.Tree.Name = "Tree";
            this.Tree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.ROOT});
            this.Tree.NodesConnector = this.nodeConnector1;
            this.Tree.NodeStyle = this.elementStyle1;
            this.Tree.PathSeparator = ";";
            this.Tree.Size = new System.Drawing.Size(189, 436);
            this.Tree.Styles.Add(this.elementStyle1);
            this.Tree.TabIndex = 0;
            this.Tree.Text = "Tree";
            this.Tree.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeClick);
            this.Tree.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
            this.Tree.Scroll += new System.Windows.Forms.ScrollEventHandler(this.advTree1_Scroll);
            // 
            // ROOT
            // 
            this.ROOT.Expanded = true;
            this.ROOT.Image = ((System.Drawing.Image)(resources.GetObject("ROOT.Image")));
            this.ROOT.Name = "ROOT";
            this.ROOT.Text = "所有类型";
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
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Tree);
            this.splitContainer1.Panel1.Controls.Add(this.bar2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridTPRange);
            this.splitContainer1.Panel2.Controls.Add(this.bar1);
            this.splitContainer1.Size = new System.Drawing.Size(889, 463);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 11;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem5});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(189, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 7;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "值域类型";
            // 
            // FormRangeType
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(889, 463);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "FormRangeType";
            this.Text = "值域管理";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnManager;
        private DevComponents.AdvTree.AdvTree Tree;
        private DevComponents.AdvTree.Node ROOT;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridTPRange;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditRTypeCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
    }
}