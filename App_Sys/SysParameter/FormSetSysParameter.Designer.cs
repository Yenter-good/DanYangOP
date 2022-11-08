namespace App_Sys
{
    partial class FormSetSysParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetSysParameter));
            this.ribbonClientPanel2 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.gridSysParameter = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.colEditCode = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditValue = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditDescription = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.colEditStatus = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.cbStop = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbNoAllow = new DevComponents.DotNetBar.CheckBoxItem();
            this.ribbonClientPanel2.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonClientPanel2
            // 
            this.ribbonClientPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel2.Controls.Add(this.gridSysParameter);
            this.ribbonClientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel2.Location = new System.Drawing.Point(0, 27);
            this.ribbonClientPanel2.Name = "ribbonClientPanel2";
            this.ribbonClientPanel2.Size = new System.Drawing.Size(889, 436);
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
            this.ribbonClientPanel2.TabIndex = 5;
            this.ribbonClientPanel2.Text = "ribbonClientPanel3";
            // 
            // gridSysParameter
            // 
            this.gridSysParameter.BackColor = System.Drawing.Color.AliceBlue;
            this.gridSysParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSysParameter.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridSysParameter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridSysParameter.Location = new System.Drawing.Point(0, 0);
            this.gridSysParameter.Name = "gridSysParameter";
            // 
            // 
            // 
            this.gridSysParameter.PrimaryGrid.AutoGenerateColumns = false;
            this.gridSysParameter.PrimaryGrid.Columns.Add(this.colEditCode);
            this.gridSysParameter.PrimaryGrid.Columns.Add(this.colEditName);
            this.gridSysParameter.PrimaryGrid.Columns.Add(this.colEditValue);
            this.gridSysParameter.PrimaryGrid.Columns.Add(this.colEditDescription);
            this.gridSysParameter.PrimaryGrid.Columns.Add(this.colEditStatus);
            this.gridSysParameter.PrimaryGrid.MultiSelect = false;
            this.gridSysParameter.PrimaryGrid.ReadOnly = true;
            this.gridSysParameter.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
            this.gridSysParameter.PrimaryGrid.ShowRowGridIndex = true;
            this.gridSysParameter.Size = new System.Drawing.Size(889, 436);
            this.gridSysParameter.TabIndex = 3;
            this.gridSysParameter.Text = "gridSysParameter";
            this.gridSysParameter.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridSysParameter_RowClick);
            this.gridSysParameter.DoubleClick += new System.EventHandler(this.gridSysParameter_DoubleClick);
            // 
            // colEditCode
            // 
            this.colEditCode.DataPropertyName = "ParameterCode";
            this.colEditCode.HeaderText = "参数代码";
            this.colEditCode.Name = "colEditCode";
            // 
            // colEditName
            // 
            this.colEditName.DataPropertyName = "ParameterName";
            this.colEditName.HeaderText = "参数名称";
            this.colEditName.Name = "colEditName";
            // 
            // colEditValue
            // 
            this.colEditValue.DataPropertyName = "ParameterValue";
            this.colEditValue.HeaderText = "参数值";
            this.colEditValue.Name = "colEditValue";
            // 
            // colEditDescription
            // 
            this.colEditDescription.DataPropertyName = "Description";
            this.colEditDescription.HeaderText = "描述";
            this.colEditDescription.Name = "colEditDescription";
            // 
            // colEditStatus
            // 
            this.colEditStatus.DataPropertyName = "Status";
            this.colEditStatus.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            this.colEditStatus.HeaderText = "状态";
            this.colEditStatus.Name = "colEditStatus";
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.bar1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(889, 27);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 4;
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
            this.cbStop,
            this.cbNoAllow});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(889, 27);
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
            // cbStop
            // 
            this.cbStop.Checked = true;
            this.cbStop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStop.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.cbStop.Name = "cbStop";
            this.cbStop.Text = "隐藏停用";
            this.cbStop.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cbStop_CheckedChanged);
            // 
            // cbNoAllow
            // 
            this.cbNoAllow.Checked = true;
            this.cbNoAllow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoAllow.Name = "cbNoAllow";
            this.cbNoAllow.Text = "隐藏不可编辑";
            this.cbNoAllow.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.cbNoAllow_CheckedChanged);
            // 
            // FormSetSysParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 463);
            this.Controls.Add(this.ribbonClientPanel2);
            this.Controls.Add(this.ribbonClientPanel1);
            this.Name = "FormSetSysParameter";
            this.Text = "参数配置";
            this.ribbonClientPanel2.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel2;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridSysParameter;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditCode;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditDescription;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditValue;
        private DevComponents.DotNetBar.SuperGrid.GridColumn colEditStatus;
        private DevComponents.DotNetBar.CheckBoxItem cbStop;
        private DevComponents.DotNetBar.CheckBoxItem cbNoAllow;
    }
}