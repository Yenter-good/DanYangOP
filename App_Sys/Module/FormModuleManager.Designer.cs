namespace App_Sys
{
    partial class FormModuleManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModuleManager));
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTool = new DevComponents.DotNetBar.Bar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddCategory = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddModule = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTool)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn7.HeaderText = "排序";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn5.HeaderText = "命名空间";
            this.gridColumn5.MinimumWidth = 200;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn4.HeaderText = "程序集";
            this.gridColumn4.MinimumWidth = 100;
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            this.gridColumn3.HeaderText = "上级名称";
            this.gridColumn3.MinimumWidth = 100;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 200;
            // 
            // gridColumn1
            // 
            this.gridColumn1.HeaderText = "模块名称";
            this.gridColumn1.MinimumWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 200;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 1);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.superGridControl1.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle;
            this.superGridControl1.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None;
            this.superGridControl1.PrimaryGrid.ImageList = this.imageList1;
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            this.superGridControl1.PrimaryGrid.ReadOnly = true;
            this.superGridControl1.PrimaryGrid.RowHeaderWidth = 0;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.Size = new System.Drawing.Size(699, 305);
            this.superGridControl1.TabIndex = 4;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.superGridControl1_CellDoubleClick);
            this.superGridControl1.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.superGridControl1_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Cards_16x16.png");
            // 
            // pnlTool
            // 
            this.pnlTool.AccessibleDescription = "bar1 (bar1)";
            this.pnlTool.AccessibleName = "bar1";
            this.pnlTool.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.pnlTool.AntiAlias = true;
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTool.IsMaximized = false;
            this.pnlTool.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRefresh,
            this.btnAddCategory,
            this.btnAddModule,
            this.btnEdit,
            this.btnDelete});
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.RoundCorners = false;
            this.pnlTool.SingleLineColor = System.Drawing.Color.Transparent;
            this.pnlTool.Size = new System.Drawing.Size(699, 27);
            this.pnlTool.Stretch = true;
            this.pnlTool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTool.TabIndex = 12;
            this.pnlTool.TabStop = false;
            this.pnlTool.Text = "bar1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCategory.Image")));
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Text = "新增分类";
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddModule
            // 
            this.btnAddModule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddModule.Enabled = false;
            this.btnAddModule.Image = ((System.Drawing.Image)(resources.GetObject("btnAddModule.Image")));
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Text = "新增模块";
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.superGridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.Size = new System.Drawing.Size(699, 306);
            this.panel1.TabIndex = 13;
            // 
            // FormModuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(699, 333);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTool);
            this.DoubleBuffered = true;
            this.Name = "FormModuleManager";
            this.Text = "模块管理";
            this.Load += new System.EventHandler(this.FormModuleImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTool)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Bar pnlTool;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnAddCategory;
        private DevComponents.DotNetBar.ButtonItem btnAddModule;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private System.Windows.Forms.Panel panel1;
    }
}