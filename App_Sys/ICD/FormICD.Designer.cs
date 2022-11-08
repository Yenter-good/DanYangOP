namespace App_Sys.ICD
{
    partial class FormICD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormICD));
            this.pnlLeft = new DevComponents.DotNetBar.ExpandablePanel();
            this.gridICD = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.txtSearch = new CIS.ControlLib.Controls.SuperText();
            this.pnlMain = new DevComponents.DotNetBar.ExpandablePanel();
            this.pnlDetail = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtSearchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.txtDays = new DevComponents.Editors.IntegerInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtDiseasesLevel = new DevComponents.Editors.IntegerInput();
            this.txtInsideCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiseasesLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlLeft.Controls.Add(this.gridICD);
            this.pnlLeft.Controls.Add(this.bar1);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.ExpandButtonVisible = false;
            this.pnlLeft.HideControlsWhenCollapsed = true;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(447, 512);
            this.pnlLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlLeft.Style.GradientAngle = 90;
            this.pnlLeft.TabIndex = 4;
            this.pnlLeft.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlLeft.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlLeft.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlLeft.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlLeft.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlLeft.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlLeft.TitleStyle.GradientAngle = 90;
            this.pnlLeft.TitleText = "疾病列表";
            // 
            // gridICD
            // 
            this.gridICD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridICD.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridICD.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridICD.Location = new System.Drawing.Point(0, 79);
            this.gridICD.Name = "gridICD";
            // 
            // 
            // 
            this.gridICD.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridICD.PrimaryGrid.ReadOnly = true;
            this.gridICD.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridICD.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridICD.PrimaryGrid.ShowRowGridIndex = true;
            this.gridICD.Size = new System.Drawing.Size(447, 433);
            this.gridICD.TabIndex = 7;
            this.gridICD.Text = "superGridControl1";
            this.gridICD.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridICD_RowClick);
            this.gridICD.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridICD_RowDoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.DataPropertyName = "Name";
            this.gridColumn1.HeaderText = "疾病名称";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnEdit});
            this.bar1.Location = new System.Drawing.Point(0, 52);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(447, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增";
            this.btnAdd.Tooltip = "新增时请选中一条记录，新增的记录将套用选中记录的ICD编码";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSearch.Location = new System.Drawing.Point(0, 26);
            this.txtSearch.MarkString = null;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(447, 26);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.WatermarkText = "请输入检索码或疾病名称进行检索";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.pnlDetail);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ExpandButtonVisible = false;
            this.pnlMain.HideControlsWhenCollapsed = true;
            this.pnlMain.Location = new System.Drawing.Point(447, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(561, 512);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 8;
            this.pnlMain.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlMain.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlMain.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.TitleStyle.GradientAngle = 90;
            this.pnlMain.TitleText = "详细信息";
            // 
            // pnlDetail
            // 
            this.pnlDetail.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlDetail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlDetail.Controls.Add(this.txtSearchCode);
            this.pnlDetail.Controls.Add(this.labelX7);
            this.pnlDetail.Controls.Add(this.txtCost);
            this.pnlDetail.Controls.Add(this.txtDays);
            this.pnlDetail.Controls.Add(this.labelX6);
            this.pnlDetail.Controls.Add(this.labelX5);
            this.pnlDetail.Controls.Add(this.txtDiseasesLevel);
            this.pnlDetail.Controls.Add(this.txtInsideCode);
            this.pnlDetail.Controls.Add(this.labelX3);
            this.pnlDetail.Controls.Add(this.btnSave);
            this.pnlDetail.Controls.Add(this.labelX4);
            this.pnlDetail.Controls.Add(this.txtCode);
            this.pnlDetail.Controls.Add(this.labelX2);
            this.pnlDetail.Controls.Add(this.txtName);
            this.pnlDetail.Controls.Add(this.labelX1);
            this.pnlDetail.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.ExpandButtonVisible = false;
            this.pnlDetail.HideControlsWhenCollapsed = true;
            this.pnlDetail.Location = new System.Drawing.Point(0, 26);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(561, 486);
            this.pnlDetail.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlDetail.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlDetail.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlDetail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlDetail.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlDetail.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlDetail.Style.GradientAngle = 90;
            this.pnlDetail.TabIndex = 19;
            this.pnlDetail.TitleHeight = 0;
            this.pnlDetail.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlDetail.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlDetail.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlDetail.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlDetail.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlDetail.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlDetail.TitleStyle.GradientAngle = 90;
            this.pnlDetail.TitleText = "Title Bar";
            // 
            // txtSearchCode
            // 
            // 
            // 
            // 
            this.txtSearchCode.Border.Class = "TextBoxBorder";
            this.txtSearchCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSearchCode.Location = new System.Drawing.Point(356, 160);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.PreventEnterBeep = true;
            this.txtSearchCode.Size = new System.Drawing.Size(161, 26);
            this.txtSearchCode.TabIndex = 47;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX7.Location = new System.Drawing.Point(285, 165);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(73, 21);
            this.labelX7.TabIndex = 46;
            this.labelX7.Text = "检索码：";
            // 
            // txtCost
            // 
            // 
            // 
            // 
            this.txtCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCost.Increment = 1D;
            this.txtCost.Location = new System.Drawing.Point(103, 165);
            this.txtCost.Name = "txtCost";
            this.txtCost.ShowUpDown = true;
            this.txtCost.Size = new System.Drawing.Size(161, 21);
            this.txtCost.TabIndex = 45;
            // 
            // txtDays
            // 
            // 
            // 
            // 
            this.txtDays.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDays.Location = new System.Drawing.Point(356, 133);
            this.txtDays.Name = "txtDays";
            this.txtDays.ShowUpDown = true;
            this.txtDays.Size = new System.Drawing.Size(161, 21);
            this.txtDays.TabIndex = 44;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX6.Location = new System.Drawing.Point(270, 133);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(88, 21);
            this.labelX6.TabIndex = 43;
            this.labelX6.Text = "住院天数：";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX5.Location = new System.Drawing.Point(17, 165);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(88, 21);
            this.labelX5.TabIndex = 41;
            this.labelX5.Text = "治疗费用：";
            // 
            // txtDiseasesLevel
            // 
            // 
            // 
            // 
            this.txtDiseasesLevel.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiseasesLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiseasesLevel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiseasesLevel.Location = new System.Drawing.Point(103, 133);
            this.txtDiseasesLevel.Name = "txtDiseasesLevel";
            this.txtDiseasesLevel.ShowUpDown = true;
            this.txtDiseasesLevel.Size = new System.Drawing.Size(161, 21);
            this.txtDiseasesLevel.TabIndex = 40;
            // 
            // txtInsideCode
            // 
            // 
            // 
            // 
            this.txtInsideCode.Border.Class = "TextBoxBorder";
            this.txtInsideCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInsideCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtInsideCode.Location = new System.Drawing.Point(356, 94);
            this.txtInsideCode.Name = "txtInsideCode";
            this.txtInsideCode.PreventEnterBeep = true;
            this.txtInsideCode.Size = new System.Drawing.Size(161, 26);
            this.txtInsideCode.TabIndex = 39;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX3.Location = new System.Drawing.Point(270, 99);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(88, 21);
            this.labelX3.TabIndex = 38;
            this.labelX3.Text = "院内编码：";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(17, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX4.Location = new System.Drawing.Point(17, 133);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(88, 21);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "疾病等级：";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCode.Location = new System.Drawing.Point(103, 94);
            this.txtCode.Name = "txtCode";
            this.txtCode.PreventEnterBeep = true;
            this.txtCode.Size = new System.Drawing.Size(161, 26);
            this.txtCode.TabIndex = 22;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX2.Location = new System.Drawing.Point(17, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(88, 21);
            this.labelX2.TabIndex = 21;
            this.labelX2.Text = "疾病编码：";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtName.Location = new System.Drawing.Point(103, 56);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.Size = new System.Drawing.Size(411, 26);
            this.txtName.TabIndex = 20;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX1.Location = new System.Drawing.Point(17, 56);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 21);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "疾病名称：";
            // 
            // FormICD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 512);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FormICD";
            this.Text = "FormICD";
            this.Shown += new System.EventHandler(this.FormICD_Shown);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiseasesLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel pnlLeft;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridICD;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private CIS.ControlLib.Controls.SuperText txtSearch;
        private DevComponents.DotNetBar.ExpandablePanel pnlMain;
        private DevComponents.DotNetBar.ExpandablePanel pnlDetail;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInsideCode;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.Editors.IntegerInput txtDays;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.IntegerInput txtDiseasesLevel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchCode;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}