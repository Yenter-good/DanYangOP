namespace App_OP
{
    partial class FormDrugPermission
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
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgvDrug = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tabDrugAllow = new DevComponents.DotNetBar.SuperTabItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbxDrug = new CIS.ControlLib.Controls.FindComboBox();
            this.btnAddDrug = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteDrug = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(732, 558);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabDrugAllow});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.dgvDrug);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(732, 528);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabDrugAllow;
            // 
            // dgvDrug
            // 
            this.dgvDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrug.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvDrug.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvDrug.Location = new System.Drawing.Point(0, 0);
            this.dgvDrug.Name = "dgvDrug";
            // 
            // 
            // 
            this.dgvDrug.PrimaryGrid.AutoGenerateColumns = false;
            this.dgvDrug.PrimaryGrid.ColumnGroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.ColumnHeaderClickBehavior.None;
            this.dgvDrug.PrimaryGrid.ColumnHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.ColumnHeaderClickBehavior.None;
            this.dgvDrug.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.dgvDrug.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.dgvDrug.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.dgvDrug.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
            this.dgvDrug.PrimaryGrid.ReadOnly = true;
            this.dgvDrug.Size = new System.Drawing.Size(732, 528);
            this.dgvDrug.TabIndex = 0;
            this.dgvDrug.Text = "superGridControl1";
            this.dgvDrug.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.dgvDrug_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.DataPropertyName = "DrugName";
            this.gridColumn1.HeaderText = "药品名称";
            this.gridColumn1.Name = "gridDrugName";
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "DrugID";
            this.gridColumn2.Name = "gridDrugCode";
            this.gridColumn2.Visible = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "DrugSpecification";
            this.gridColumn3.HeaderText = "规格";
            this.gridColumn3.Name = "gridDrugSpecification";
            this.gridColumn3.Width = 150;
            // 
            // tabDrugAllow
            // 
            this.tabDrugAllow.AttachedControl = this.superTabControlPanel1;
            this.tabDrugAllow.GlobalItem = false;
            this.tabDrugAllow.Name = "tabDrugAllow";
            this.tabDrugAllow.Text = "药品指定适用范围";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(82, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "检索药品：";
            // 
            // cbxDrug
            // 
            this.cbxDrug.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cbxDrug.Border.Class = "TextBoxBorder";
            this.cbxDrug.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxDrug.CanResizePopup = false;
            this.cbxDrug.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbxDrug.DataSource = null;
            this.cbxDrug.DisplayMember = "";
            this.cbxDrug.FilterFields = null;
            this.cbxDrug.FocusOpen = false;
            this.cbxDrug.Location = new System.Drawing.Point(88, 18);
            this.cbxDrug.Name = "cbxDrug";
            this.cbxDrug.PopupBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(199)))), ((int)(((byte)(225)))));
            this.cbxDrug.PopupBorderWidth = new System.Windows.Forms.Padding(1);
            this.cbxDrug.PopupMaximumSize = new System.Drawing.Size(0, 450);
            this.cbxDrug.PopupMinimumSize = new System.Drawing.Size(0, 25);
            this.cbxDrug.PopupOffSet = 2;
            this.cbxDrug.PreventEnterBeep = true;
            this.cbxDrug.ReadOnly = true;
            this.cbxDrug.ShowPopupShadow = true;
            this.cbxDrug.Size = new System.Drawing.Size(391, 23);
            this.cbxDrug.TabIndex = 3;
            this.cbxDrug.ValueMember = null;
            // 
            // btnAddDrug
            // 
            this.btnAddDrug.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddDrug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDrug.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddDrug.Location = new System.Drawing.Point(500, 18);
            this.btnAddDrug.Name = "btnAddDrug";
            this.btnAddDrug.Size = new System.Drawing.Size(90, 23);
            this.btnAddDrug.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddDrug.TabIndex = 1;
            this.btnAddDrug.Text = "添加一个药";
            this.btnAddDrug.Click += new System.EventHandler(this.btnAddDrug_Click);
            // 
            // btnDeleteDrug
            // 
            this.btnDeleteDrug.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteDrug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDrug.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteDrug.Location = new System.Drawing.Point(606, 18);
            this.btnDeleteDrug.Name = "btnDeleteDrug";
            this.btnDeleteDrug.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteDrug.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteDrug.TabIndex = 1;
            this.btnDeleteDrug.Text = "删除一个药";
            this.btnDeleteDrug.Click += new System.EventHandler(this.btnDeleteDrug_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDeleteDrug);
            this.groupBox1.Controls.Add(this.btnAddDrug);
            this.groupBox1.Controls.Add(this.cbxDrug);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Location = new System.Drawing.Point(3, 564);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // FormDrugPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 628);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDrugPermission";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 70);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品使用权限设置";
            this.Shown += new System.EventHandler(this.FormDrugPermission_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabDrugAllow;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvDrug;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private CIS.ControlLib.Controls.FindComboBox cbxDrug;
        private DevComponents.DotNetBar.ButtonX btnAddDrug;
        private DevComponents.DotNetBar.ButtonX btnDeleteDrug;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
    }
}