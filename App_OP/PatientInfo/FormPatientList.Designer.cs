namespace App_OP.PatientInfo
{
    partial class FormPatientList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientList));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.tbxSearch = new CIS.ControlLib.Controls.SuperText();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.pnlBottom = new DevComponents.DotNetBar.PanelEx();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.tabMain = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.gridDept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择此病人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制姓名ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.复制就诊号ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn23 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tabDept = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.gridPersonnel = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn22 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tabPersonnel = new DevComponents.DotNetBar.SuperTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Controls.Add(this.tbxSearch);
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.controlContainerItem1});
            this.bar1.Location = new System.Drawing.Point(1, 1);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(951, 32);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // tbxSearch
            // 
            // 
            // 
            // 
            this.tbxSearch.Border.Class = "TextBoxBorder";
            this.tbxSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxSearch.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.tbxSearch.Location = new System.Drawing.Point(150, 2);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSearch.MarkString = null;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PreventEnterBeep = true;
            this.tbxSearch.Size = new System.Drawing.Size(348, 27);
            this.tbxSearch.TabIndex = 1;
            this.tbxSearch.WatermarkText = "输入姓名、身份证号、拼音首字母、卡号检索";
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // labelItem1
            // 
            this.labelItem1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingLeft = 40;
            this.labelItem1.Text = "检索条件：";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.tbxSearch;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // pnlBottom
            // 
            this.pnlBottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlBottom.Controls.Add(this.radioButton2);
            this.pnlBottom.Controls.Add(this.radioButton1);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(1, 490);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.pnlBottom.Size = new System.Drawing.Size(951, 41);
            this.pnlBottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlBottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlBottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlBottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlBottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlBottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlBottom.Style.GradientAngle = 90;
            this.pnlBottom.TabIndex = 6;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(107, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 19);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "昨天";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(35, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "今天";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(840, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(733, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabMain
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabMain.ControlBox.MenuBox.Name = "";
            this.tabMain.ControlBox.Name = "";
            this.tabMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabMain.ControlBox.MenuBox,
            this.tabMain.ControlBox.CloseBox});
            this.tabMain.ControlBox.Visible = false;
            this.tabMain.Controls.Add(this.superTabControlPanel1);
            this.tabMain.Controls.Add(this.superTabControlPanel2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("宋体", 12F);
            this.tabMain.Location = new System.Drawing.Point(1, 33);
            this.tabMain.Name = "tabMain";
            this.tabMain.ReorderTabsEnabled = true;
            this.tabMain.SelectedTabFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(951, 457);
            this.tabMain.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.TabIndex = 10;
            this.tabMain.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabDept,
            this.tabPersonnel,
            this.buttonItem1});
            this.tabMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.tabMain.Text = "superTabControl1";
            this.tabMain.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tabMain_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.gridDept);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(951, 426);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabDept;
            // 
            // gridDept
            // 
            this.gridDept.ContextMenuStrip = this.contextMenuStrip1;
            this.gridDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridDept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridDept.Location = new System.Drawing.Point(0, 0);
            this.gridDept.Name = "gridDept";
            // 
            // 
            // 
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn23);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn19);
            this.gridDept.PrimaryGrid.Columns.Add(this.gridColumn21);
            this.gridDept.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle;
            this.gridDept.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None;
            this.gridDept.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.gridDept.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.gridDept.PrimaryGrid.MultiSelect = false;
            this.gridDept.PrimaryGrid.ReadOnly = true;
            this.gridDept.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridDept.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridDept.PrimaryGrid.ShowTreeButtons = true;
            this.gridDept.Size = new System.Drawing.Size(951, 426);
            this.gridDept.TabIndex = 0;
            this.gridDept.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridDept_RowDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择此病人ToolStripMenuItem,
            this.信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 选择此病人ToolStripMenuItem
            // 
            this.选择此病人ToolStripMenuItem.Name = "选择此病人ToolStripMenuItem";
            this.选择此病人ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.选择此病人ToolStripMenuItem.Text = "选择此病人";
            this.选择此病人ToolStripMenuItem.Click += new System.EventHandler(this.选择此病人ToolStripMenuItem_Click);
            // 
            // 信息ToolStripMenuItem
            // 
            this.信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制姓名ToolStripMenuItem1,
            this.复制就诊号ToolStripMenuItem1});
            this.信息ToolStripMenuItem.Name = "信息ToolStripMenuItem";
            this.信息ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.信息ToolStripMenuItem.Text = "信息";
            // 
            // 复制姓名ToolStripMenuItem1
            // 
            this.复制姓名ToolStripMenuItem1.Name = "复制姓名ToolStripMenuItem1";
            this.复制姓名ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.复制姓名ToolStripMenuItem1.Text = "复制姓名";
            this.复制姓名ToolStripMenuItem1.Click += new System.EventHandler(this.复制姓名ToolStripMenuItem1_Click);
            // 
            // 复制就诊号ToolStripMenuItem1
            // 
            this.复制就诊号ToolStripMenuItem1.Name = "复制就诊号ToolStripMenuItem1";
            this.复制就诊号ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.复制就诊号ToolStripMenuItem1.Text = "复制就诊号";
            this.复制就诊号ToolStripMenuItem1.Click += new System.EventHandler(this.复制就诊号ToolStripMenuItem1_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn2.DataPropertyName = "OutpatientNo";
            this.gridColumn2.HeaderText = "就诊号";
            this.gridColumn2.Name = "gridDept_OutpatientNo";
            // 
            // gridColumn23
            // 
            this.gridColumn23.DataPropertyName = "DoctorName";
            this.gridColumn23.HeaderText = "首诊医生";
            this.gridColumn23.Name = "gridDept_FirstDoctor";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn8.DataPropertyName = "PayType";
            this.gridColumn8.HeaderText = "身份类别";
            this.gridColumn8.MinimumWidth = 120;
            this.gridColumn8.Name = "gridDept_PayType";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn1.DataPropertyName = "PatientName";
            this.gridColumn1.HeaderText = "姓名";
            this.gridColumn1.MinimumWidth = 120;
            this.gridColumn1.Name = "gridDept_PatientName";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn3.DataPropertyName = "Age";
            this.gridColumn3.HeaderText = "年龄";
            this.gridColumn3.MinimumWidth = 80;
            this.gridColumn3.Name = "gridDept_Age";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn9.DataPropertyName = "Sex";
            this.gridColumn9.HeaderText = "性别";
            this.gridColumn9.MinimumWidth = 80;
            this.gridColumn9.Name = "gridDept_Sex";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn5.DataPropertyName = "RegisterNo";
            this.gridColumn5.HeaderText = "挂号序号";
            this.gridColumn5.Name = "gridDept_RegisterNo";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn6.DataPropertyName = "Category";
            this.gridColumn6.HeaderText = "号别";
            this.gridColumn6.MinimumWidth = 80;
            this.gridColumn6.Name = "gridDept_Category";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn7.DataPropertyName = "EmerencyFlag";
            this.gridColumn7.HeaderText = "是否急诊";
            this.gridColumn7.Name = "gridDept_EmerencyFlag";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn4.DataPropertyName = "DeptName";
            this.gridColumn4.HeaderText = "挂号科室";
            this.gridColumn4.MinimumWidth = 100;
            this.gridColumn4.Name = "gridDept_DeptName";
            // 
            // gridColumn19
            // 
            this.gridColumn19.DataPropertyName = "SearchCode";
            this.gridColumn19.Name = "gridDept_SearchCode";
            this.gridColumn19.Visible = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.DataPropertyName = "IDCard";
            this.gridColumn21.Name = "gridDept_IDCard";
            this.gridColumn21.Visible = false;
            // 
            // tabDept
            // 
            this.tabDept.AttachedControl = this.superTabControlPanel1;
            this.tabDept.GlobalItem = false;
            this.tabDept.Name = "tabDept";
            this.tabDept.Text = "科   室";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.gridPersonnel);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 31);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(951, 426);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabPersonnel;
            // 
            // gridPersonnel
            // 
            this.gridPersonnel.ContextMenuStrip = this.contextMenuStrip1;
            this.gridPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPersonnel.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridPersonnel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridPersonnel.Location = new System.Drawing.Point(0, 0);
            this.gridPersonnel.Name = "gridPersonnel";
            // 
            // 
            // 
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn18);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn20);
            this.gridPersonnel.PrimaryGrid.Columns.Add(this.gridColumn22);
            this.gridPersonnel.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle;
            this.gridPersonnel.PrimaryGrid.FrozenColumnCount = 3;
            this.gridPersonnel.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None;
            this.gridPersonnel.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.gridPersonnel.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.gridPersonnel.PrimaryGrid.MultiSelect = false;
            this.gridPersonnel.PrimaryGrid.ReadOnly = true;
            this.gridPersonnel.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridPersonnel.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridPersonnel.PrimaryGrid.ShowTreeButtons = true;
            this.gridPersonnel.Size = new System.Drawing.Size(951, 426);
            this.gridPersonnel.TabIndex = 1;
            this.gridPersonnel.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.gridPersonnel_RowDoubleClick);
            // 
            // gridColumn10
            // 
            this.gridColumn10.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn10.DataPropertyName = "OutpatientNo";
            this.gridColumn10.HeaderText = "就诊号";
            this.gridColumn10.Name = "gridDept_OutpatientNo";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn11.DataPropertyName = "PayType";
            this.gridColumn11.HeaderText = "身份类别";
            this.gridColumn11.MinimumWidth = 120;
            this.gridColumn11.Name = "gridDept_PayType";
            // 
            // gridColumn12
            // 
            this.gridColumn12.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn12.DataPropertyName = "PatientName";
            this.gridColumn12.HeaderText = "姓名";
            this.gridColumn12.MinimumWidth = 120;
            this.gridColumn12.Name = "gridDept_PatientName";
            // 
            // gridColumn13
            // 
            this.gridColumn13.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn13.DataPropertyName = "Age";
            this.gridColumn13.HeaderText = "年龄";
            this.gridColumn13.MinimumWidth = 80;
            this.gridColumn13.Name = "gridDept_Age";
            // 
            // gridColumn14
            // 
            this.gridColumn14.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn14.DataPropertyName = "Sex";
            this.gridColumn14.HeaderText = "性别";
            this.gridColumn14.MinimumWidth = 80;
            this.gridColumn14.Name = "gridDept_Sex";
            // 
            // gridColumn15
            // 
            this.gridColumn15.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn15.DataPropertyName = "RegisterNo";
            this.gridColumn15.HeaderText = "挂号序号";
            this.gridColumn15.Name = "gridDept_RegisterNo";
            // 
            // gridColumn16
            // 
            this.gridColumn16.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn16.DataPropertyName = "Category";
            this.gridColumn16.HeaderText = "号别";
            this.gridColumn16.MinimumWidth = 80;
            this.gridColumn16.Name = "gridDept_Category";
            // 
            // gridColumn17
            // 
            this.gridColumn17.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn17.DataPropertyName = "EmerencyFlag";
            this.gridColumn17.HeaderText = "是否急诊";
            this.gridColumn17.Name = "gridDept_EmerencyFlag";
            // 
            // gridColumn18
            // 
            this.gridColumn18.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn18.DataPropertyName = "DeptName";
            this.gridColumn18.HeaderText = "挂号科室";
            this.gridColumn18.MinimumWidth = 100;
            this.gridColumn18.Name = "gridDept_DeptName";
            // 
            // gridColumn20
            // 
            this.gridColumn20.DataPropertyName = "SearchCode";
            this.gridColumn20.Name = "gridDept_SearchCode";
            this.gridColumn20.Visible = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.DataPropertyName = "IDCard";
            this.gridColumn22.Name = "gridDept_IDCard";
            this.gridColumn22.Visible = false;
            // 
            // tabPersonnel
            // 
            this.tabPersonnel.AttachedControl = this.superTabControlPanel2;
            this.tabPersonnel.GlobalItem = false;
            this.tabPersonnel.Name = "tabPersonnel";
            this.tabPersonnel.Text = "本   人";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "刷新";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // FormPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 532);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.bar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPatientList";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "患者列表";
            this.Shown += new System.EventHandler(this.FormPatientList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.PanelEx pnlBottom;
        private DevComponents.DotNetBar.SuperTabControl tabMain;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabDept;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabPersonnel;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridDept;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21;
        private CIS.ControlLib.Controls.SuperText tbxSearch;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridPersonnel;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn22;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn23;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择此病人ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制姓名ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 复制就诊号ToolStripMenuItem1;
    }
}