namespace App_Sys
{
    partial class FormSetSysDic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetSysDic));
            this.ribbonClientPanel3 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.gridSysDicDetails = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.colEditCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditDescription = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditDicCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditNo = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ribbonClientPanel2 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnManager = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.ribbonClientPanel5 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.Tree = new DevComponents.AdvTree.AdvTree();
            this.ROOT = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.ribbonClientPanel4 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.ribbonClientPanel3.SuspendLayout();
            this.ribbonClientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.ribbonClientPanel1.SuspendLayout();
            this.ribbonClientPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).BeginInit();
            this.ribbonClientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonClientPanel3
            // 
            this.ribbonClientPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel3.Controls.Add(this.gridSysDicDetails);
            this.ribbonClientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel3.Location = new System.Drawing.Point(179, 27);
            this.ribbonClientPanel3.Name = "ribbonClientPanel3";
            this.ribbonClientPanel3.Size = new System.Drawing.Size(710, 436);
            // 
            // 
            // 
            this.ribbonClientPanel3.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel3.TabIndex = 5;
            this.ribbonClientPanel3.Text = "ribbonClientPanel3";
            // 
            // gridSysDicDetails
            // 
            this.gridSysDicDetails.BackColor = System.Drawing.Color.AliceBlue;
            background1.Color1 = System.Drawing.Color.AliceBlue;
            this.gridSysDicDetails.DefaultVisualStyles.GridPanelStyle.Background = background1;
            this.gridSysDicDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSysDicDetails.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridSysDicDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridSysDicDetails.Location = new System.Drawing.Point(0, 0);
            this.gridSysDicDetails.Name = "gridSysDicDetails";
            // 
            // 
            // 
            this.gridSysDicDetails.PrimaryGrid.AutoGenerateColumns = false;
            this.gridSysDicDetails.PrimaryGrid.Columns.Add(this.colEditCode);
            this.gridSysDicDetails.PrimaryGrid.Columns.Add(this.colEditName);
            this.gridSysDicDetails.PrimaryGrid.Columns.Add(this.colEditDescription);
            this.gridSysDicDetails.PrimaryGrid.Columns.Add(this.colEditDicCode);
            this.gridSysDicDetails.PrimaryGrid.Columns.Add(this.colEditNo);
            this.gridSysDicDetails.PrimaryGrid.MultiSelect = false;
            this.gridSysDicDetails.PrimaryGrid.ReadOnly = true;
            this.gridSysDicDetails.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
            this.gridSysDicDetails.PrimaryGrid.ShowRowGridIndex = true;
            this.gridSysDicDetails.Size = new System.Drawing.Size(710, 436);
            this.gridSysDicDetails.TabIndex = 1;
            this.gridSysDicDetails.Text = "gridSysDicDetails";
            this.gridSysDicDetails.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridSysDicDetails_RowClick);
            this.gridSysDicDetails.DoubleClick += new System.EventHandler(this.gridSysDicDetails_DoubleClick);
            // 
            // colEditCode
            // 
            this.colEditCode.DataPropertyName = "Code";
            this.colEditCode.HeaderText = "编码";
            this.colEditCode.Name = "colEditCode";
            // 
            // colEditName
            // 
            this.colEditName.DataPropertyName = "Value";
            this.colEditName.HeaderText = "名称";
            this.colEditName.Name = "colEditName";
            // 
            // colEditDescription
            // 
            this.colEditDescription.DataPropertyName = "Description";
            this.colEditDescription.HeaderText = "描述";
            this.colEditDescription.Name = "colEditDescription";
            // 
            // colEditDicCode
            // 
            this.colEditDicCode.DataPropertyName = "DicCode";
            this.colEditDicCode.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            this.colEditDicCode.HeaderText = "上级编码";
            this.colEditDicCode.Name = "colEditDicCode";
            // 
            // colEditNo
            // 
            this.colEditNo.DataPropertyName = "No";
            this.colEditNo.HeaderText = "排序";
            this.colEditNo.Name = "colEditNo";
            // 
            // ribbonClientPanel2
            // 
            this.ribbonClientPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel2.Controls.Add(this.bar1);
            this.ribbonClientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonClientPanel2.Location = new System.Drawing.Point(179, 0);
            this.ribbonClientPanel2.Name = "ribbonClientPanel2";
            this.ribbonClientPanel2.Size = new System.Drawing.Size(710, 27);
            // 
            // 
            // 
            this.ribbonClientPanel2.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel2.TabIndex = 4;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
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
            this.bar1.Size = new System.Drawing.Size(710, 27);
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
            this.btnManager.Text = "新增类别";
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.ribbonClientPanel5);
            this.ribbonClientPanel1.Controls.Add(this.ribbonClientPanel4);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(179, 463);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 3;
            this.ribbonClientPanel1.Text = "ribbonClientPanel1";
            // 
            // ribbonClientPanel5
            // 
            this.ribbonClientPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel5.Controls.Add(this.Tree);
            this.ribbonClientPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel5.Location = new System.Drawing.Point(0, 27);
            this.ribbonClientPanel5.Name = "ribbonClientPanel5";
            this.ribbonClientPanel5.Size = new System.Drawing.Size(179, 436);
            // 
            // 
            // 
            this.ribbonClientPanel5.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel5.TabIndex = 15;
            this.ribbonClientPanel5.Text = "ribbonClientPanel5";
            // 
            // Tree
            // 
            this.Tree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.Tree.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.Tree.BackgroundStyle.Class = "TreeBorderKey";
            this.Tree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.Tree.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.Tree.Location = new System.Drawing.Point(0, 0);
            this.Tree.Name = "Tree";
            this.Tree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.ROOT});
            this.Tree.NodesConnector = this.nodeConnector1;
            this.Tree.NodeStyle = this.elementStyle1;
            this.Tree.PathSeparator = ";";
            this.Tree.Size = new System.Drawing.Size(179, 436);
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
            this.ROOT.Text = "所有类别";
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
            // ribbonClientPanel4
            // 
            this.ribbonClientPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel4.Controls.Add(this.bar2);
            this.ribbonClientPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonClientPanel4.Enabled = false;
            this.ribbonClientPanel4.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel4.Name = "ribbonClientPanel4";
            this.ribbonClientPanel4.Size = new System.Drawing.Size(179, 27);
            // 
            // 
            // 
            this.ribbonClientPanel4.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel4.TabIndex = 14;
            this.ribbonClientPanel4.Text = "ribbonClientPanel4";
            // 
            // bar2
            // 
            this.bar2.AccessibleDescription = "bar2 (bar2)";
            this.bar2.AccessibleName = "bar2";
            this.bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.bar2.AntiAlias = true;
            this.bar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.bar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.bar2.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(179, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 0;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.labelItem1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItem1.Height = 5;
            this.labelItem1.Image = ((System.Drawing.Image)(resources.GetObject("labelItem1.Image")));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Stretch = true;
            this.labelItem1.Text = "字典类别";
            this.labelItem1.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormSetSysDic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 463);
            this.Controls.Add(this.ribbonClientPanel3);
            this.Controls.Add(this.ribbonClientPanel2);
            this.Controls.Add(this.ribbonClientPanel1);
            this.Name = "FormSetSysDic";
            this.Text = "字典管理";
            this.ribbonClientPanel3.ResumeLayout(false);
            this.ribbonClientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).EndInit();
            this.ribbonClientPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel3;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnManager;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel5;
        private DevComponents.AdvTree.AdvTree Tree;
        private DevComponents.AdvTree.Node ROOT;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel4;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridSysDicDetails;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditDescription;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditDicCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditNo;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
    }
}