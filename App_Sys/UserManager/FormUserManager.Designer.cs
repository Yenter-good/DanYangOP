namespace App_Sys
{
    partial class FormUserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserManager));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.treeDept = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.superText1 = new CIS.ControlLib.Controls.SuperText();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.GridUser = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnStatus = new DevComponents.DotNetBar.ButtonItem();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.gridCell1 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell2 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell3 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell4 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.gridCell5 = new DevComponents.DotNetBar.SuperGrid.GridCell();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加科室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除科室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑科室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.treeDept);
            this.panelEx1.Controls.Add(this.superText1);
            this.panelEx1.Controls.Add(this.bar2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(231, 476);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // treeDept
            // 
            this.treeDept.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeDept.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeDept.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
            this.treeDept.BackgroundStyle.Class = "TreeBorderKey";
            this.treeDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDept.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.treeDept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeDept.Location = new System.Drawing.Point(0, 47);
            this.treeDept.Name = "treeDept";
            this.treeDept.NodesConnector = this.nodeConnector1;
            this.treeDept.NodeStyle = this.elementStyle1;
            this.treeDept.PathSeparator = ";";
            this.treeDept.Size = new System.Drawing.Size(231, 429);
            this.treeDept.Styles.Add(this.elementStyle1);
            this.treeDept.TabIndex = 9;
            this.treeDept.Text = "advTree1";
            this.treeDept.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
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
            // superText1
            // 
            // 
            // 
            // 
            this.superText1.Border.Class = "TextBoxBorder";
            this.superText1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.superText1.Location = new System.Drawing.Point(0, 26);
            this.superText1.MarkString = null;
            this.superText1.Name = "superText1";
            this.superText1.PreventEnterBeep = true;
            this.superText1.Size = new System.Drawing.Size(231, 21);
            this.superText1.TabIndex = 7;
            this.superText1.WatermarkText = "输入拼音码、姓名或工号过滤";
            this.superText1.TextChanged += new System.EventHandler(this.superText1_TextChanged);
            this.superText1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superText1_KeyDown);
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.labelItem1,
            this.buttonItem1});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(231, 26);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 13;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = " ";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Stretch = true;
            this.labelItem1.Text = "科室名称";
            this.labelItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.GridUser);
            this.panelEx3.Controls.Add(this.bar1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(231, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(942, 476);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 5;
            // 
            // GridUser
            // 
            this.GridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridUser.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.GridUser.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.GridUser.Location = new System.Drawing.Point(0, 27);
            this.GridUser.Name = "GridUser";
            // 
            // 
            // 
            this.GridUser.PrimaryGrid.AutoGenerateColumns = false;
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.GridUser.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.GridUser.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.GridUser.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.GridUser.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.GridUser.PrimaryGrid.ShowRowGridIndex = true;
            this.GridUser.Size = new System.Drawing.Size(942, 449);
            this.GridUser.TabIndex = 6;
            this.GridUser.Text = "superGridControl1";
            this.GridUser.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.GridUser_RowClick);
            this.GridUser.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.GridUser_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "Code";
            this.gridColumn1.HeaderText = "用户编码";
            this.gridColumn1.Name = "colUserCode";
            this.gridColumn1.ReadOnly = true;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "Name";
            this.gridColumn2.HeaderText = "用户名称";
            this.gridColumn2.Name = "colUserName";
            this.gridColumn2.ReadOnly = true;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "Type";
            this.gridColumn3.HeaderText = "用户类型";
            this.gridColumn3.Name = "colUserType";
            this.gridColumn3.ReadOnly = true;
            this.gridColumn3.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "JobTitle";
            this.gridColumn4.HeaderText = "用户职称";
            this.gridColumn4.Name = "colUserJob";
            this.gridColumn4.ReadOnly = true;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn6.DataPropertyName = "Status";
            this.gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn6.HeaderText = "是否停用";
            this.gridColumn6.Name = "colStatus";
            this.gridColumn6.ReadOnly = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.gridColumn5.HeaderText = "科室设置";
            this.gridColumn5.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn5.Name = "colEditDept";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.gridColumn7.HeaderText = "用户设置";
            this.gridColumn7.Name = "colEditUser";
            this.gridColumn7.Visible = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            this.gridColumn8.HeaderText = "角色设置";
            this.gridColumn8.Name = "colEditRole";
            this.gridColumn8.Visible = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "ID";
            this.gridColumn9.Name = "colUserID";
            this.gridColumn9.Visible = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.DataPropertyName = "SearchCode";
            this.gridColumn10.Name = "colUserSearchCode";
            this.gridColumn10.Visible = false;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefresh,
            this.btnAdd,
            this.btnEdit,
            this.btnStatus,
            this.checkBoxItem1});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingLeft = 5;
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(942, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "修改";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnStatus.Image")));
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Text = "停用";
            this.btnStatus.Visible = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.checkBoxItem1.Name = "checkBoxItem1";
            this.checkBoxItem1.Text = "隐藏停用用户";
            this.checkBoxItem1.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.checkBoxItem1_CheckedChanged);
            // 
            // gridRow1
            // 
            this.gridRow1.Cells.Add(this.gridCell1);
            this.gridRow1.Cells.Add(this.gridCell2);
            this.gridRow1.Cells.Add(this.gridCell3);
            this.gridRow1.Cells.Add(this.gridCell4);
            this.gridRow1.Cells.Add(this.gridCell5);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加科室ToolStripMenuItem,
            this.删除科室ToolStripMenuItem,
            this.编辑科室ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 增加科室ToolStripMenuItem
            // 
            this.增加科室ToolStripMenuItem.Name = "增加科室ToolStripMenuItem";
            this.增加科室ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加科室ToolStripMenuItem.Text = "增加科室";
            this.增加科室ToolStripMenuItem.Click += new System.EventHandler(this.增加科室ToolStripMenuItem_Click);
            // 
            // 删除科室ToolStripMenuItem
            // 
            this.删除科室ToolStripMenuItem.Name = "删除科室ToolStripMenuItem";
            this.删除科室ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除科室ToolStripMenuItem.Text = "删除科室";
            this.删除科室ToolStripMenuItem.Click += new System.EventHandler(this.删除科室ToolStripMenuItem_Click);
            // 
            // 编辑科室ToolStripMenuItem
            // 
            this.编辑科室ToolStripMenuItem.Name = "编辑科室ToolStripMenuItem";
            this.编辑科室ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑科室ToolStripMenuItem.Text = "编辑科室";
            this.编辑科室ToolStripMenuItem.Click += new System.EventHandler(this.编辑科室ToolStripMenuItem_Click);
            // 
            // FormUserManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1173, 476);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormUserManager";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FormUserManager_Load);
            this.Shown += new System.EventHandler(this.FormUserManager_Shown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.AdvTree.AdvTree treeDept;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl GridUser;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridRow gridRow1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell1;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell2;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell3;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell4;
        private DevComponents.DotNetBar.SuperGrid.GridCell gridCell5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.ButtonItem btnStatus;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加科室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除科室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑科室ToolStripMenuItem;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private CIS.ControlLib.Controls.SuperText superText1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;

    }
}