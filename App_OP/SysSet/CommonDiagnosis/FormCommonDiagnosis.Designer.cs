namespace App_OP.SysSet.CommonDiagnosis
{
    partial class FormCommonDiagnosis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommonDiagnosis));
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridICD = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd_R = new System.Windows.Forms.ToolStripMenuItem();
            this.TypeName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.DiaName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.Type = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.Code = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxSearch = new CIS.ControlLib.Controls.SuperText();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridCommon = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDel_R = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.tbxName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbxCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.expandablePanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.expandablePanel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.gridICD);
            this.expandablePanel1.Controls.Add(this.tbxSearch);
            this.expandablePanel1.Controls.Add(this.bar1);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Padding = new System.Windows.Forms.Padding(2);
            this.expandablePanel1.Size = new System.Drawing.Size(405, 495);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 1;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "ICD过滤";
            // 
            // gridICD
            // 
            this.gridICD.ContextMenuStrip = this.contextMenuStrip1;
            this.gridICD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridICD.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridICD.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridICD.Location = new System.Drawing.Point(2, 81);
            this.gridICD.Name = "gridICD";
            // 
            // 
            // 
            this.gridICD.PrimaryGrid.AutoGenerateColumns = false;
            this.gridICD.PrimaryGrid.Columns.Add(this.TypeName);
            this.gridICD.PrimaryGrid.Columns.Add(this.DiaName);
            this.gridICD.PrimaryGrid.Columns.Add(this.Type);
            this.gridICD.PrimaryGrid.Columns.Add(this.Code);
            this.gridICD.PrimaryGrid.ReadOnly = true;
            this.gridICD.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridICD.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridICD.PrimaryGrid.ShowRowGridIndex = true;
            this.gridICD.Size = new System.Drawing.Size(401, 412);
            this.gridICD.TabIndex = 7;
            this.gridICD.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridICD_RowDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd_R});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // btnAdd_R
            // 
            this.btnAdd_R.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd_R.Image")));
            this.btnAdd_R.Name = "btnAdd_R";
            this.btnAdd_R.Size = new System.Drawing.Size(160, 22);
            this.btnAdd_R.Text = "添加到常用诊断";
            this.btnAdd_R.Click += new System.EventHandler(this.btnAdd_R_Click);
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "";
            this.TypeName.HeaderText = "类型";
            this.TypeName.Name = "TypeName";
            // 
            // DiaName
            // 
            this.DiaName.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.DiaName.DataPropertyName = "Name";
            this.DiaName.HeaderText = "诊断名称";
            this.DiaName.Name = "DiaName";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.Name = "Type";
            this.Type.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.Name = "Code";
            this.Code.Visible = false;
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
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(5);
            this.tbxSearch.MarkString = null;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PreventEnterBeep = true;
            this.tbxSearch.Size = new System.Drawing.Size(401, 26);
            this.tbxSearch.TabIndex = 6;
            this.tbxSearch.WatermarkText = "请输入拼音码或诊断关键字";
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd});
            this.bar1.Location = new System.Drawing.Point(2, 28);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(401, 27);
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
            this.btnAdd.Text = "添加到常用诊断";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.gridCommon);
            this.expandablePanel2.Controls.Add(this.panel1);
            this.expandablePanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel2.ExpandButtonVisible = false;
            this.expandablePanel2.HideControlsWhenCollapsed = true;
            this.expandablePanel2.Location = new System.Drawing.Point(405, 0);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(518, 495);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 5;
            this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "自定义诊断";
            // 
            // gridCommon
            // 
            this.gridCommon.ContextMenuStrip = this.contextMenuStrip2;
            this.gridCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCommon.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridCommon.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridCommon.Location = new System.Drawing.Point(0, 81);
            this.gridCommon.Name = "gridCommon";
            // 
            // 
            // 
            this.gridCommon.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.gridCommon.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.gridCommon.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridCommon.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridCommon.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridCommon.PrimaryGrid.ReadOnly = true;
            this.gridCommon.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridCommon.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridCommon.PrimaryGrid.ShowRowGridIndex = true;
            this.gridCommon.Size = new System.Drawing.Size(518, 414);
            this.gridCommon.TabIndex = 8;
            this.gridCommon.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridCommon_RowDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel_R});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 26);
            // 
            // btnDel_R
            // 
            this.btnDel_R.Image = ((System.Drawing.Image)(resources.GetObject("btnDel_R.Image")));
            this.btnDel_R.Name = "btnDel_R";
            this.btnDel_R.Size = new System.Drawing.Size(148, 22);
            this.btnDel_R.Text = "删除常用诊断";
            this.btnDel_R.Click += new System.EventHandler(this.btnDel_R_Click);
            // 
            // gridColumn6
            // 
            this.gridColumn6.HeaderText = "类型";
            this.gridColumn6.Name = "gridCommon_Type";
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "ID";
            this.gridColumn3.Name = "gridCommon_ID";
            this.gridColumn3.Visible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "Code";
            this.gridColumn1.HeaderText = "ICD编码";
            this.gridColumn1.Name = "gridCommon_Code";
            this.gridColumn1.Visible = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn2.DataPropertyName = "Name";
            this.gridColumn2.HeaderText = "诊断名称";
            this.gridColumn2.Name = "gridCommon_Name";
            // 
            // gridColumn7
            // 
            this.gridColumn7.DataPropertyName = "Type";
            this.gridColumn7.Name = "Type";
            this.gridColumn7.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.tbxCode);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 55);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(436, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxName
            // 
            // 
            // 
            // 
            this.tbxName.Border.Class = "TextBoxBorder";
            this.tbxName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxName.Location = new System.Drawing.Point(286, 14);
            this.tbxName.Name = "tbxName";
            this.tbxName.PreventEnterBeep = true;
            this.tbxName.Size = new System.Drawing.Size(144, 23);
            this.tbxName.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(223, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "诊断名称：";
            // 
            // tbxCode
            // 
            // 
            // 
            // 
            this.tbxCode.Border.Class = "TextBoxBorder";
            this.tbxCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCode.Location = new System.Drawing.Point(69, 14);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.PreventEnterBeep = true;
            this.tbxCode.Size = new System.Drawing.Size(144, 23);
            this.tbxCode.TabIndex = 1;
            this.tbxCode.Text = "A00.999";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(6, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "诊断代码：";
            // 
            // FormCommonDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 495);
            this.Controls.Add(this.expandablePanel2);
            this.Controls.Add(this.expandablePanel1);
            this.DoubleBuffered = true;
            this.Name = "FormCommonDiagnosis";
            this.Text = "FormCommonDiagnosis";
            this.Shown += new System.EventHandler(this.FormCommonDiagnosis_Shown);
            this.expandablePanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.expandablePanel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridICD;
        private DevComponents.DotNetBar.SuperGrid.GridColumn TypeName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn DiaName;
        private CIS.ControlLib.Controls.SuperText tbxSearch;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridCommon;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxCode;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd_R;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnDel_R;
        private DevComponents.DotNetBar.SuperGrid.GridColumn Type;
        private DevComponents.DotNetBar.SuperGrid.GridColumn Code;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
    }
}