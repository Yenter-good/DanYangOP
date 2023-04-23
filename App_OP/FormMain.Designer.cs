namespace App_OP
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.barTop = new DevComponents.DotNetBar.Bar();
            this.btnQChange = new DevComponents.DotNetBar.ButtonItem();
            this.btnQAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnSearch = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnCallPatient = new DevComponents.DotNetBar.ButtonItem();
            this.btnSEMR = new DevComponents.DotNetBar.ButtonItem();
            this.btnHealthRecords = new DevComponents.DotNetBar.ButtonItem();
            this.lblName = new DevComponents.DotNetBar.LabelItem();
            this.lblSex = new DevComponents.DotNetBar.LabelItem();
            this.lblAge = new DevComponents.DotNetBar.LabelItem();
            this.lblIdentity = new DevComponents.DotNetBar.LabelItem();
            this.lblCategory = new DevComponents.DotNetBar.LabelItem();
            this.btnExistsEmergency = new DevComponents.DotNetBar.ButtonItem();
            this.btnIPRecordView = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.pnlRight = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgvPrescription = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextPrescription = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打印选中处方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印膏方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预览选中处方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.召回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中处方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripCopyPrescription = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.查看双流转处方信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看双流转处方审核结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看双流转取药结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnUndoPrescription = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelPrescription = new DevComponents.DotNetBar.ButtonItem();
            this.dgvZDDetail = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicareCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnosisType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnosisSpecialFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChronic = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.SplitterBottom = new DevComponents.DotNetBar.ExpandableSplitter();
            this.dgvZD = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbxZDFilter = new CIS.ControlLib.Controls.SuperText();
            this.barDiagnosisChoose = new DevComponents.DotNetBar.Bar();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.btnCommonICD = new DevComponents.DotNetBar.ButtonItem();
            this.btnHMDiagnosis = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.btnICD = new DevComponents.DotNetBar.ButtonItem();
            this.btnHMSymptom = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelDiagnosis = new DevComponents.DotNetBar.ButtonItem();
            this.tabMain = new DevComponents.DotNetBar.SuperTabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.barTop)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.contextPrescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZDDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barDiagnosisChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // barTop
            // 
            this.barTop.AntiAlias = true;
            this.barTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTop.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.barTop.IsMaximized = false;
            this.barTop.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnQChange,
            this.btnQAdd,
            this.btnSearch,
            this.buttonItem4,
            this.btnCallPatient,
            this.btnSEMR,
            this.btnHealthRecords,
            this.lblName,
            this.lblSex,
            this.lblAge,
            this.lblIdentity,
            this.lblCategory,
            this.btnExistsEmergency,
            this.btnIPRecordView,
            this.buttonItem1,
            this.buttonItem2});
            this.barTop.Location = new System.Drawing.Point(1, 1);
            this.barTop.Name = "barTop";
            this.barTop.Size = new System.Drawing.Size(1787, 38);
            this.barTop.Stretch = true;
            this.barTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barTop.TabIndex = 0;
            this.barTop.TabStop = false;
            // 
            // btnQChange
            // 
            this.btnQChange.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnQChange.Image = ((System.Drawing.Image)(resources.GetObject("btnQChange.Image")));
            this.btnQChange.Name = "btnQChange";
            this.btnQChange.Text = "转往他科";
            this.btnQChange.Click += new System.EventHandler(this.btnQChange_Click);
            // 
            // btnQAdd
            // 
            this.btnQAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnQAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnQAdd.Image")));
            this.btnQAdd.Name = "btnQAdd";
            this.btnQAdd.Text = "回单号";
            this.btnQAdd.Visible = false;
            this.btnQAdd.Click += new System.EventHandler(this.btnQAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSearch.FontBold = true;
            this.btnSearch.ForeColor = System.Drawing.Color.Red;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "选择患者";
            this.btnSearch.Click += new System.EventHandler(this.btnChoosePatient_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "就诊结束";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // btnCallPatient
            // 
            this.btnCallPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCallPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnCallPatient.Image")));
            this.btnCallPatient.Name = "btnCallPatient";
            this.btnCallPatient.Text = "叫号";
            this.btnCallPatient.Click += new System.EventHandler(this.btnCallPatient_Click);
            // 
            // btnSEMR
            // 
            this.btnSEMR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSEMR.Image = ((System.Drawing.Image)(resources.GetObject("btnSEMR.Image")));
            this.btnSEMR.Name = "btnSEMR";
            this.btnSEMR.Text = "妇幼专科病历";
            this.btnSEMR.Visible = false;
            this.btnSEMR.Click += new System.EventHandler(this.btnSEMR_Click);
            // 
            // btnHealthRecords
            // 
            this.btnHealthRecords.Name = "btnHealthRecords";
            this.btnHealthRecords.Text = "健康档案";
            this.btnHealthRecords.Click += new System.EventHandler(this.btnHealthRecords_Click);
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.PaddingLeft = 100;
            this.lblName.Text = "姓名：";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblSex
            // 
            this.lblSex.Name = "lblSex";
            this.lblSex.Text = "性别：";
            // 
            // lblAge
            // 
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "年龄：";
            // 
            // lblIdentity
            // 
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Text = "身份：";
            // 
            // lblCategory
            // 
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "号别：";
            // 
            // btnExistsEmergency
            // 
            this.btnExistsEmergency.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.btnExistsEmergency.ForeColor = System.Drawing.Color.Red;
            this.btnExistsEmergency.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnExistsEmergency.Name = "btnExistsEmergency";
            this.btnExistsEmergency.Text = "存在危急值";
            this.btnExistsEmergency.Visible = false;
            this.btnExistsEmergency.Click += new System.EventHandler(this.btnExistsEmergency_Click);
            // 
            // btnIPRecordView
            // 
            this.btnIPRecordView.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.btnIPRecordView.Image = ((System.Drawing.Image)(resources.GetObject("btnIPRecordView.Image")));
            this.btnIPRecordView.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnIPRecordView.Name = "btnIPRecordView";
            this.btnIPRecordView.Text = "住院病历调阅";
            this.btnIPRecordView.Click += new System.EventHandler(this.btnIPRecordView_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "麻醉记录调阅";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "重症护理记录单";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlRight.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlRight.Controls.Add(this.expandablePanel1);
            this.pnlRight.Controls.Add(this.dgvZDDetail);
            this.pnlRight.Controls.Add(this.dgvChronic);
            this.pnlRight.Controls.Add(this.SplitterBottom);
            this.pnlRight.Controls.Add(this.dgvZD);
            this.pnlRight.Controls.Add(this.tbxZDFilter);
            this.pnlRight.Controls.Add(this.barDiagnosisChoose);
            this.pnlRight.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.ExpandButtonVisible = false;
            this.pnlRight.Expanded = false;
            this.pnlRight.ExpandedBounds = new System.Drawing.Rectangle(1041, 25, 200, 368);
            this.pnlRight.HideControlsWhenCollapsed = true;
            this.pnlRight.Location = new System.Drawing.Point(1519, 39);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(269, 666);
            this.pnlRight.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlRight.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRight.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRight.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlRight.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnlRight.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnlRight.Style.GradientAngle = 90;
            this.pnlRight.TabIndex = 9;
            this.pnlRight.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlRight.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlRight.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlRight.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.pnlRight.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlRight.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlRight.TitleStyle.GradientAngle = 90;
            this.pnlRight.TitleText = "诊断信息";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.dgvPrescription);
            this.expandablePanel1.Controls.Add(this.bar1);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.expandablePanel1.Location = new System.Drawing.Point(5, 370);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(259, 291);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 0;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "已开处方信息";
            // 
            // dgvPrescription
            // 
            this.dgvPrescription.ContextMenuStrip = this.contextPrescription;
            background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            background1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvPrescription.DefaultVisualStyles.RowStyles.Selected.RowHeaderStyle.Background = background1;
            this.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescription.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvPrescription.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dgvPrescription.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvPrescription.Location = new System.Drawing.Point(0, 50);
            this.dgvPrescription.Name = "dgvPrescription";
            // 
            // 
            // 
            this.dgvPrescription.PrimaryGrid.AllowSelection = false;
            this.dgvPrescription.PrimaryGrid.AutoGenerateColumns = false;
            // 
            // 
            // 
            this.dgvPrescription.PrimaryGrid.ColumnHeader.RowHeight = 26;
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn16);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn13);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn19);
            this.dgvPrescription.PrimaryGrid.Columns.Add(this.gridColumn20);
            this.dgvPrescription.PrimaryGrid.ReadOnly = true;
            this.dgvPrescription.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.dgvPrescription.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.dgvPrescription.PrimaryGrid.ShowRowGridIndex = true;
            this.dgvPrescription.Size = new System.Drawing.Size(259, 241);
            this.dgvPrescription.TabIndex = 7;
            this.dgvPrescription.Text = "superGridControl1";
            this.dgvPrescription.RowDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs>(this.dgvPrescription_RowDoubleClick);
            this.dgvPrescription.RowMouseEnter += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowEventArgs>(this.dgvPrescription_RowMouseEnter);
            // 
            // contextPrescription
            // 
            this.contextPrescription.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印选中处方ToolStripMenuItem,
            this.打印膏方ToolStripMenuItem,
            this.预览选中处方ToolStripMenuItem,
            this.toolStripSeparator1,
            this.召回ToolStripMenuItem,
            this.删除选中处方ToolStripMenuItem,
            this.stripCopyPrescription,
            this.toolStripSeparator2,
            this.查看双流转处方信息ToolStripMenuItem,
            this.查看双流转处方审核结果ToolStripMenuItem,
            this.查看双流转取药结果ToolStripMenuItem});
            this.contextPrescription.Name = "contextPrescription";
            this.contextPrescription.Size = new System.Drawing.Size(209, 214);
            // 
            // 打印选中处方ToolStripMenuItem
            // 
            this.打印选中处方ToolStripMenuItem.Name = "打印选中处方ToolStripMenuItem";
            this.打印选中处方ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.打印选中处方ToolStripMenuItem.Text = "直接打印(不预览)";
            this.打印选中处方ToolStripMenuItem.Click += new System.EventHandler(this.打印选中处方ToolStripMenuItem_Click);
            // 
            // 打印膏方ToolStripMenuItem
            // 
            this.打印膏方ToolStripMenuItem.Name = "打印膏方ToolStripMenuItem";
            this.打印膏方ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.打印膏方ToolStripMenuItem.Text = "打印膏方";
            this.打印膏方ToolStripMenuItem.Click += new System.EventHandler(this.打印膏方ToolStripMenuItem_Click);
            // 
            // 预览选中处方ToolStripMenuItem
            // 
            this.预览选中处方ToolStripMenuItem.Name = "预览选中处方ToolStripMenuItem";
            this.预览选中处方ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.预览选中处方ToolStripMenuItem.Text = "预览选中处方";
            this.预览选中处方ToolStripMenuItem.Click += new System.EventHandler(this.预览选中处方ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // 召回ToolStripMenuItem
            // 
            this.召回ToolStripMenuItem.Name = "召回ToolStripMenuItem";
            this.召回ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.召回ToolStripMenuItem.Text = "召回";
            this.召回ToolStripMenuItem.Click += new System.EventHandler(this.召回ToolStripMenuItem_Click);
            // 
            // 删除选中处方ToolStripMenuItem
            // 
            this.删除选中处方ToolStripMenuItem.Name = "删除选中处方ToolStripMenuItem";
            this.删除选中处方ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.删除选中处方ToolStripMenuItem.Text = "删除选中处方";
            this.删除选中处方ToolStripMenuItem.Click += new System.EventHandler(this.删除选中处方ToolStripMenuItem_Click);
            // 
            // stripCopyPrescription
            // 
            this.stripCopyPrescription.Name = "stripCopyPrescription";
            this.stripCopyPrescription.Size = new System.Drawing.Size(208, 22);
            this.stripCopyPrescription.Text = "复制处方";
            this.stripCopyPrescription.Click += new System.EventHandler(this.stripCopyPrescription_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // 查看双流转处方信息ToolStripMenuItem
            // 
            this.查看双流转处方信息ToolStripMenuItem.Name = "查看双流转处方信息ToolStripMenuItem";
            this.查看双流转处方信息ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.查看双流转处方信息ToolStripMenuItem.Text = "查看双流转处方信息";
            this.查看双流转处方信息ToolStripMenuItem.Click += new System.EventHandler(this.查看双流转处方信息ToolStripMenuItem_Click);
            // 
            // 查看双流转处方审核结果ToolStripMenuItem
            // 
            this.查看双流转处方审核结果ToolStripMenuItem.Name = "查看双流转处方审核结果ToolStripMenuItem";
            this.查看双流转处方审核结果ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.查看双流转处方审核结果ToolStripMenuItem.Text = "查看双流转处方审核结果";
            this.查看双流转处方审核结果ToolStripMenuItem.Click += new System.EventHandler(this.查看双流转处方审核结果ToolStripMenuItem_Click);
            // 
            // 查看双流转取药结果ToolStripMenuItem
            // 
            this.查看双流转取药结果ToolStripMenuItem.Name = "查看双流转取药结果ToolStripMenuItem";
            this.查看双流转取药结果ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.查看双流转取药结果ToolStripMenuItem.Text = "查看双流转取药结果";
            this.查看双流转取药结果ToolStripMenuItem.Click += new System.EventHandler(this.查看双流转取药结果ToolStripMenuItem_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn1.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.gridColumn1.DataPropertyName = "Burette";
            this.gridColumn1.HeaderText = "处方(检查检验)名称";
            this.gridColumn1.Name = "col_Name";
            this.gridColumn1.ReadOnly = true;
            this.gridColumn1.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.gridColumn2.DataPropertyName = "RecordNumber";
            this.gridColumn2.DefaultNewRowCellValue = "";
            this.gridColumn2.HeaderText = "数量";
            this.gridColumn2.Name = "col_Num";
            this.gridColumn2.ReadOnly = true;
            this.gridColumn2.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            this.gridColumn16.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn16.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            this.gridColumn16.FillWeight = 20;
            this.gridColumn16.HeaderText = "";
            this.gridColumn16.Name = "col_StatusName";
            this.gridColumn16.ReadOnly = true;
            this.gridColumn16.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            this.gridColumn16.Width = 25;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "PrescriptionNo";
            this.gridColumn3.HeaderText = "处方编号";
            this.gridColumn3.Name = "col_ItemCode";
            this.gridColumn3.Visible = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.DataPropertyName = "Status";
            this.gridColumn4.HeaderText = "操作进程";
            this.gridColumn4.Name = "col_Status";
            this.gridColumn4.Visible = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.DataPropertyName = "ID";
            this.gridColumn12.Name = "col_ID";
            this.gridColumn12.Visible = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.DataPropertyName = "PrescriptionType";
            this.gridColumn13.Name = "col_PrescriptionType";
            this.gridColumn13.Visible = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.DataPropertyName = "HISInterface_PrescriptionNo";
            this.gridColumn19.Name = "col_HISInterface_PrescriptionNo";
            this.gridColumn19.Visible = false;
            // 
            // gridColumn20
            // 
            this.gridColumn20.DataPropertyName = "UserID";
            this.gridColumn20.Name = "col_DoctorCode";
            this.gridColumn20.Visible = false;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrint,
            this.btnUndoPrescription,
            this.btnDelPrescription});
            this.bar1.Location = new System.Drawing.Point(0, 26);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(259, 24);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "打印选中项";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUndoPrescription
            // 
            this.btnUndoPrescription.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUndoPrescription.Image = ((System.Drawing.Image)(resources.GetObject("btnUndoPrescription.Image")));
            this.btnUndoPrescription.Name = "btnUndoPrescription";
            this.btnUndoPrescription.Text = "召回";
            this.btnUndoPrescription.Click += new System.EventHandler(this.btnUndoPrescription_Click);
            // 
            // btnDelPrescription
            // 
            this.btnDelPrescription.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelPrescription.Image = ((System.Drawing.Image)(resources.GetObject("btnDelPrescription.Image")));
            this.btnDelPrescription.Name = "btnDelPrescription";
            this.btnDelPrescription.Text = "删除处方";
            this.btnDelPrescription.Click += new System.EventHandler(this.btnDelPrescription_Click);
            // 
            // dgvZDDetail
            // 
            this.dgvZDDetail.AllowUserToAddRows = false;
            this.dgvZDDetail.AllowUserToDeleteRows = false;
            this.dgvZDDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZDDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZDDetail.ColumnHeadersHeight = 28;
            this.dgvZDDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvZDDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colCode,
            this.colName,
            this.colMedicareCode,
            this.DiagnosisType,
            this.DiagnosisSpecialFlag});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZDDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZDDetail.EnableHeadersVisualStyles = false;
            this.dgvZDDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvZDDetail.Location = new System.Drawing.Point(-200, 108);
            this.dgvZDDetail.Name = "dgvZDDetail";
            this.dgvZDDetail.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZDDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvZDDetail.RowHeadersVisible = false;
            this.dgvZDDetail.RowTemplate.Height = 23;
            this.dgvZDDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZDDetail.Size = new System.Drawing.Size(473, 230);
            this.dgvZDDetail.TabIndex = 1;
            this.dgvZDDetail.Visible = false;
            this.dgvZDDetail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvZDDetail_CellFormatting);
            this.dgvZDDetail.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvZDDetail_CellMouseDoubleClick);
            this.dgvZDDetail.VisibleChanged += new System.EventHandler(this.dgvZDDetail_VisibleChanged);
            this.dgvZDDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvZDDetail_KeyDown);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "Type";
            this.Column1.HeaderText = "类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "ICD";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 70;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "诊断名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colMedicareCode
            // 
            this.colMedicareCode.DataPropertyName = "MedicareCode";
            this.colMedicareCode.HeaderText = "医保编码";
            this.colMedicareCode.Name = "colMedicareCode";
            this.colMedicareCode.ReadOnly = true;
            // 
            // DiagnosisType
            // 
            this.DiagnosisType.DataPropertyName = "Type";
            this.DiagnosisType.HeaderText = "诊断类型";
            this.DiagnosisType.Name = "DiagnosisType";
            this.DiagnosisType.ReadOnly = true;
            this.DiagnosisType.Visible = false;
            // 
            // DiagnosisSpecialFlag
            // 
            this.DiagnosisSpecialFlag.DataPropertyName = "SpecialFlag";
            this.DiagnosisSpecialFlag.HeaderText = "特殊标志 0正常 1慢病 2传染病";
            this.DiagnosisSpecialFlag.Name = "DiagnosisSpecialFlag";
            this.DiagnosisSpecialFlag.ReadOnly = true;
            this.DiagnosisSpecialFlag.Visible = false;
            // 
            // dgvChronic
            // 
            this.dgvChronic.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvChronic.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvChronic.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dgvChronic.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvChronic.Location = new System.Drawing.Point(5, 267);
            this.dgvChronic.Name = "dgvChronic";
            // 
            // 
            // 
            this.dgvChronic.PrimaryGrid.AutoGenerateColumns = false;
            // 
            // 
            // 
            this.dgvChronic.PrimaryGrid.ColumnHeader.RowHeight = 26;
            this.dgvChronic.PrimaryGrid.Columns.Add(this.gridColumn14);
            this.dgvChronic.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.dgvChronic.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.dgvChronic.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.dgvChronic.PrimaryGrid.RowHeaderWidth = 20;
            this.dgvChronic.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.dgvChronic.Size = new System.Drawing.Size(259, 103);
            this.dgvChronic.TabIndex = 28;
            this.dgvChronic.Text = "superGridControl1";
            this.dgvChronic.Visible = false;
            this.dgvChronic.CellMouseDown += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.dgvChronic_CellMouseDown);
            this.dgvChronic.CellMouseUp += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.dgvChronic_CellMouseUp);
            // 
            // gridColumn14
            // 
            this.gridColumn14.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn14.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn14.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn14.HeaderText = "选择";
            this.gridColumn14.Name = "MXB_Select";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            this.gridColumn11.DataPropertyName = "Code";
            this.gridColumn11.HeaderText = "";
            this.gridColumn11.Name = "MXB_Code";
            this.gridColumn11.Visible = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn9.DataPropertyName = "Name";
            this.gridColumn9.HeaderText = "医保审批信息";
            this.gridColumn9.Name = "MXB_Name";
            this.gridColumn9.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.DataPropertyName = "Type";
            this.gridColumn10.Name = "MXB_Type";
            this.gridColumn10.Visible = false;
            // 
            // SplitterBottom
            // 
            this.SplitterBottom.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.SplitterBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.SplitterBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.SplitterBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.SplitterBottom.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.SplitterBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.SplitterBottom.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.SplitterBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.SplitterBottom.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.SplitterBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.SplitterBottom.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.SplitterBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.SplitterBottom.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(200)))), ((int)(((byte)(103)))));
            this.SplitterBottom.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(135)))));
            this.SplitterBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.SplitterBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.SplitterBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.SplitterBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.SplitterBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.SplitterBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.SplitterBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.SplitterBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.SplitterBottom.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.SplitterBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.SplitterBottom.Location = new System.Drawing.Point(5, 262);
            this.SplitterBottom.Name = "SplitterBottom";
            this.SplitterBottom.Size = new System.Drawing.Size(259, 5);
            this.SplitterBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.SplitterBottom.TabIndex = 36;
            this.SplitterBottom.TabStop = false;
            this.SplitterBottom.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterBottom_SplitterMoved);
            // 
            // dgvZD
            // 
            this.dgvZD.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvZD.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvZD.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dgvZD.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dgvZD.Location = new System.Drawing.Point(5, 106);
            this.dgvZD.MinimumSize = new System.Drawing.Size(0, 150);
            this.dgvZD.Name = "dgvZD";
            this.dgvZD.Padding = new System.Windows.Forms.Padding(3);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dgvZD.PrimaryGrid.ColumnHeader.RowHeight = 26;
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn15);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn17);
            this.dgvZD.PrimaryGrid.Columns.Add(this.gridColumn18);
            this.dgvZD.Size = new System.Drawing.Size(259, 156);
            this.dgvZD.TabIndex = 32;
            this.dgvZD.Text = "superGridControl1";
            this.dgvZD.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.dgvZD_CellClick);
            this.dgvZD.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.dgvZD_CellValueChanged);
            this.dgvZD.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.dgvZD_EndEdit);
            // 
            // gridColumn5
            // 
            this.gridColumn5.DataPropertyName = "ID";
            this.gridColumn5.Name = "ID";
            this.gridColumn5.Visible = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn6.DataPropertyName = "Name";
            this.gridColumn6.HeaderText = "诊断名称";
            this.gridColumn6.Name = "ZDMC";
            this.gridColumn6.ReadOnly = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn7.DataPropertyName = "Status";
            this.gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            this.gridColumn7.HeaderText = "是否确诊";
            this.gridColumn7.Name = "Status";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.ColumnHeader;
            this.gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn8.DataPropertyName = "IsMain";
            this.gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn8.HeaderText = "主";
            this.gridColumn8.Name = "IsMain";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Name = "ICD";
            this.gridColumn15.Visible = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.DataPropertyName = "IsHMDiagnosis";
            this.gridColumn17.Name = "IsHMDiagnosis";
            this.gridColumn17.Visible = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.DataPropertyName = "Type";
            this.gridColumn18.HeaderText = "Type";
            this.gridColumn18.Name = "Type";
            this.gridColumn18.Visible = false;
            // 
            // tbxZDFilter
            // 
            // 
            // 
            // 
            this.tbxZDFilter.Border.Class = "TextBoxBorder";
            this.tbxZDFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxZDFilter.DelayTime = 100;
            this.tbxZDFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxZDFilter.Location = new System.Drawing.Point(5, 83);
            this.tbxZDFilter.MarkString = null;
            this.tbxZDFilter.Name = "tbxZDFilter";
            this.tbxZDFilter.PreventEnterBeep = true;
            this.tbxZDFilter.Size = new System.Drawing.Size(259, 23);
            this.tbxZDFilter.TabIndex = 31;
            this.tbxZDFilter.WatermarkText = "请输入拼音码检索诊断信息";
            this.tbxZDFilter.TextChanged += new System.EventHandler(this.tbxZDFilter_TextChanged);
            this.tbxZDFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxZDFilter_KeyDown);
            // 
            // barDiagnosisChoose
            // 
            this.barDiagnosisChoose.AntiAlias = true;
            this.barDiagnosisChoose.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDiagnosisChoose.DockSide = DevComponents.DotNetBar.eDockSide.Right;
            this.barDiagnosisChoose.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.barDiagnosisChoose.IsMaximized = false;
            this.barDiagnosisChoose.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer2,
            this.btnDelDiagnosis});
            this.barDiagnosisChoose.Location = new System.Drawing.Point(5, 31);
            this.barDiagnosisChoose.Name = "barDiagnosisChoose";
            this.barDiagnosisChoose.PaddingBottom = 3;
            this.barDiagnosisChoose.PaddingLeft = 3;
            this.barDiagnosisChoose.PaddingRight = 3;
            this.barDiagnosisChoose.PaddingTop = 3;
            this.barDiagnosisChoose.Size = new System.Drawing.Size(259, 52);
            this.barDiagnosisChoose.Stretch = true;
            this.barDiagnosisChoose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barDiagnosisChoose.TabIndex = 30;
            this.barDiagnosisChoose.TabStop = false;
            this.barDiagnosisChoose.Text = "bar1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCommonICD,
            this.btnHMDiagnosis});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnCommonICD
            // 
            this.btnCommonICD.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnCommonICD.Image = ((System.Drawing.Image)(resources.GetObject("btnCommonICD.Image")));
            this.btnCommonICD.Name = "btnCommonICD";
            this.btnCommonICD.Text = "常用诊断";
            this.btnCommonICD.Click += new System.EventHandler(this.btnICD_Click);
            // 
            // btnHMDiagnosis
            // 
            this.btnHMDiagnosis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHMDiagnosis.Image = ((System.Drawing.Image)(resources.GetObject("btnHMDiagnosis.Image")));
            this.btnHMDiagnosis.Name = "btnHMDiagnosis";
            this.btnHMDiagnosis.Text = "中医诊断";
            this.btnHMDiagnosis.Click += new System.EventHandler(this.btnICD_Click);
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnICD,
            this.btnHMSymptom});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnICD
            // 
            this.btnICD.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnICD.Checked = true;
            this.btnICD.Image = ((System.Drawing.Image)(resources.GetObject("btnICD.Image")));
            this.btnICD.Name = "btnICD";
            this.btnICD.Text = "ICD诊断";
            this.btnICD.Click += new System.EventHandler(this.btnICD_Click);
            // 
            // btnHMSymptom
            // 
            this.btnHMSymptom.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHMSymptom.Image = ((System.Drawing.Image)(resources.GetObject("btnHMSymptom.Image")));
            this.btnHMSymptom.Name = "btnHMSymptom";
            this.btnHMSymptom.Text = "中医证候";
            this.btnHMSymptom.Click += new System.EventHandler(this.btnICD_Click);
            // 
            // btnDelDiagnosis
            // 
            this.btnDelDiagnosis.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelDiagnosis.Image = ((System.Drawing.Image)(resources.GetObject("btnDelDiagnosis.Image")));
            this.btnDelDiagnosis.Name = "btnDelDiagnosis";
            this.btnDelDiagnosis.Text = "删除诊断";
            this.btnDelDiagnosis.Click += new System.EventHandler(this.btnDelDiagnosis_Click);
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
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(1, 39);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(5);
            this.tabMain.ReorderTabsEnabled = true;
            this.tabMain.SelectedTabFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = -1;
            this.tabMain.Size = new System.Drawing.Size(1514, 666);
            this.tabMain.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tabMain.TabFont = new System.Drawing.Font("宋体", 15F);
            this.tabMain.TabHorizontalSpacing = 2;
            this.tabMain.TabIndex = 16;
            this.tabMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tabMain.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tabMain_SelectedTabChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 2000;
            this.toolTip1.ReshowDelay = 100;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(200)))), ((int)(((byte)(103)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(135)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(57)))), ((int)(((byte)(120)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(1515, 39);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(4, 666);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 37;
            this.expandableSplitter1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1789, 706);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.barTop);
            this.DoubleBuffered = true;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barTop)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.contextPrescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZDDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barDiagnosisChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar barTop;
        private DevComponents.DotNetBar.ExpandablePanel pnlRight;
        private DevComponents.DotNetBar.SuperTabControl tabMain;
        private DevComponents.DotNetBar.ButtonItem btnQChange;
        private DevComponents.DotNetBar.ButtonItem btnQAdd;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvZDDetail;
        private DevComponents.DotNetBar.ButtonItem btnSearch;
        private DevComponents.DotNetBar.LabelItem lblName;
        private DevComponents.DotNetBar.LabelItem lblSex;
        private DevComponents.DotNetBar.LabelItem lblAge;
        private DevComponents.DotNetBar.LabelItem lblIdentity;
        private DevComponents.DotNetBar.LabelItem lblCategory;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvZD;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private CIS.ControlLib.Controls.SuperText tbxZDFilter;
        private DevComponents.DotNetBar.Bar barDiagnosisChoose;
        private DevComponents.DotNetBar.ButtonItem btnCommonICD;
        private DevComponents.DotNetBar.ButtonItem btnICD;
        private DevComponents.DotNetBar.ButtonItem btnDelDiagnosis;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvChronic;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvPrescription;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnDelPrescription;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.ButtonItem btnUndoPrescription;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13;
        private System.Windows.Forms.ContextMenuStrip contextPrescription;
        private System.Windows.Forms.ToolStripMenuItem 打印选中处方ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预览选中处方ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 召回ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中处方ToolStripMenuItem;
        private FastReport.Report report1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnCallPatient;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ButtonItem btnHMDiagnosis;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ButtonItem btnHMSymptom;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17;
        private DevComponents.DotNetBar.ExpandableSplitter SplitterBottom;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18;
        private System.Windows.Forms.ToolStripMenuItem 打印膏方ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20;
        private DevComponents.DotNetBar.ButtonItem btnSEMR;
        private System.Windows.Forms.ToolStripMenuItem stripCopyPrescription;
        private DevComponents.DotNetBar.ButtonItem btnIPRecordView;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem btnExistsEmergency;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 查看双流转处方信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看双流转处方审核结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看双流转取药结果ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicareCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnosisType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnosisSpecialFlag;
        private DevComponents.DotNetBar.ButtonItem btnHealthRecords;
    }
}