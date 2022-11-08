namespace App_OP
{
    partial class FormLISResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLISResult));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.tbxSearch = new CIS.ControlLib.Controls.SuperText();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem4 = new DevComponents.DotNetBar.ControlContainerItem();
            this.btnSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btnKnowlage = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labDoctorName = new DevComponents.DotNetBar.LabelItem();
            this.labAge = new DevComponents.DotNetBar.LabelItem();
            this.labSex = new DevComponents.DotNetBar.LabelItem();
            this.labTechnician = new DevComponents.DotNetBar.LabelItem();
            this.labCheck = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem3 = new DevComponents.DotNetBar.ControlContainerItem();
            this.gridPatient = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridResult = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择当前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入到病历ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Controls.Add(this.tbxSearch);
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem3,
            this.controlContainerItem4,
            this.btnSearch,
            this.btnKnowlage,
            this.labelItem1,
            this.labDoctorName,
            this.labAge,
            this.labSex,
            this.labTechnician,
            this.labCheck,
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1353, 34);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
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
            this.tbxSearch.DelayTime = 200;
            this.tbxSearch.Location = new System.Drawing.Point(120, 4);
            this.tbxSearch.MarkString = null;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PreventEnterBeep = true;
            this.tbxSearch.Size = new System.Drawing.Size(186, 25);
            this.tbxSearch.TabIndex = 10;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "输入身份证号查询";
            // 
            // controlContainerItem4
            // 
            this.controlContainerItem4.AllowItemResize = false;
            this.controlContainerItem4.Control = this.tbxSearch;
            this.controlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem4.Name = "controlContainerItem4";
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Symbol = "";
            this.btnSearch.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSearch.SymbolSize = 16F;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnKnowlage
            // 
            this.btnKnowlage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnKnowlage.Name = "btnKnowlage";
            this.btnKnowlage.Symbol = "";
            this.btnKnowlage.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKnowlage.Text = "知识库";
            this.btnKnowlage.Click += new System.EventHandler(this.btnKnowlage_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "                   ";
            // 
            // labDoctorName
            // 
            this.labDoctorName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDoctorName.Name = "labDoctorName";
            this.labDoctorName.Text = "医生姓名：";
            // 
            // labAge
            // 
            this.labAge.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAge.Name = "labAge";
            this.labAge.Text = "病人年龄：";
            // 
            // labSex
            // 
            this.labSex.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSex.Name = "labSex";
            this.labSex.Text = "病人性别：";
            // 
            // labTechnician
            // 
            this.labTechnician.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTechnician.Name = "labTechnician";
            this.labTechnician.Text = "检验人员：";
            // 
            // labCheck
            // 
            this.labCheck.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCheck.Name = "labCheck";
            this.labCheck.Text = "审核人员：";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonItem1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.buttonItem1.SymbolSize = 17F;
            this.buttonItem1.Text = "导入到病历";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // controlContainerItem3
            // 
            this.controlContainerItem3.AllowItemResize = false;
            this.controlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem3.Name = "controlContainerItem3";
            // 
            // gridPatient
            // 
            this.gridPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPatient.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridPatient.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridPatient.Location = new System.Drawing.Point(0, 30);
            this.gridPatient.Name = "gridPatient";
            // 
            // 
            // 
            // 
            // 
            // 
            this.gridPatient.PrimaryGrid.ColumnHeader.AllowSelection = false;
            this.gridPatient.PrimaryGrid.ColumnHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.ColumnHeaderClickBehavior.None;
            this.gridPatient.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.gridPatient.PrimaryGrid.Columns.Add(this.gridColumn12);
            this.gridPatient.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.gridPatient.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.gridPatient.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.gridPatient.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle;
            this.gridPatient.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None;
            this.gridPatient.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.gridPatient.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.gridPatient.PrimaryGrid.MultiSelect = false;
            this.gridPatient.PrimaryGrid.ReadOnly = true;
            this.gridPatient.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridPatient.PrimaryGrid.ShowTreeButtons = true;
            this.gridPatient.Size = new System.Drawing.Size(629, 592);
            this.gridPatient.TabIndex = 5;
            this.gridPatient.RowClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs>(this.gridPatient_RowClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn5.DataPropertyName = "ReceiveDate";
            this.gridColumn5.HeaderText = "报告日期";
            this.gridColumn5.Name = "ReceiveDate";
            this.gridColumn5.Width = 150;
            // 
            // gridColumn12
            // 
            this.gridColumn12.HeaderText = "身份证号";
            this.gridColumn12.Name = "IDCard";
            this.gridColumn12.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.DataPropertyName = "PatientName";
            this.gridColumn6.FillWeight = 150;
            this.gridColumn6.HeaderText = "姓名";
            this.gridColumn6.MinimumWidth = 20;
            this.gridColumn6.Name = "PatientName";
            this.gridColumn6.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.HeaderText = "就诊号";
            this.gridColumn4.MinimumWidth = 60;
            this.gridColumn4.Name = "TreatmentNo";
            this.gridColumn4.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.HeaderText = "科室名称";
            this.gridColumn1.MinimumWidth = 60;
            this.gridColumn1.Name = "DeptName";
            this.gridColumn1.Width = 70;
            // 
            // gridResult
            // 
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridResult.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridResult.Location = new System.Drawing.Point(629, 34);
            this.gridResult.Name = "gridResult";
            // 
            // 
            // 
            this.gridResult.PrimaryGrid.AutoGenerateColumns = false;
            // 
            // 
            // 
            this.gridResult.PrimaryGrid.ColumnHeader.AllowSelection = false;
            this.gridResult.PrimaryGrid.ColumnHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.ColumnHeaderClickBehavior.None;
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn11);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.gridResult.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.gridResult.PrimaryGrid.RowHeaderIndexOffset = 1;
            this.gridResult.PrimaryGrid.RowHeaderWidth = 0;
            this.gridResult.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.gridResult.PrimaryGrid.ShowRowGridIndex = true;
            this.gridResult.Size = new System.Drawing.Size(724, 591);
            this.gridResult.TabIndex = 6;
            this.gridResult.Text = "superGridControl1";
            this.gridResult.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.gridResult_CellClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn3.HeaderText = "选择";
            this.gridColumn3.Name = "Select";
            this.gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.None;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn7.DataPropertyName = "itemname";
            this.gridColumn7.HeaderText = "项目名称";
            this.gridColumn7.Name = "Detail_Name";
            // 
            // gridColumn8
            // 
            this.gridColumn8.DataPropertyName = "ReportValue";
            this.gridColumn8.HeaderText = "值";
            this.gridColumn8.Name = "Detail_Value";
            this.gridColumn8.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.DataPropertyName = "unit";
            this.gridColumn9.HeaderText = "单位";
            this.gridColumn9.Name = "Detail_Unit";
            this.gridColumn9.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.DataPropertyName = "RESULT_FLAG";
            this.gridColumn11.HeaderText = " 标识";
            this.gridColumn11.Name = "Detail_Flag";
            this.gridColumn11.Width = 40;
            // 
            // gridColumn10
            // 
            this.gridColumn10.DataPropertyName = "RefRange";
            this.gridColumn10.HeaderText = "参考范围";
            this.gridColumn10.MinimumWidth = 100;
            this.gridColumn10.Name = "Detail_Range";
            this.gridColumn10.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "Checker";
            this.gridColumn2.HeaderText = "检验人员";
            this.gridColumn2.Name = "Checker";
            this.gridColumn2.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择当前行ToolStripMenuItem,
            this.导入到病历ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 选择当前行ToolStripMenuItem
            // 
            this.选择当前行ToolStripMenuItem.Name = "选择当前行ToolStripMenuItem";
            this.选择当前行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.选择当前行ToolStripMenuItem.Text = "选择当前行";
            // 
            // 导入到病历ToolStripMenuItem
            // 
            this.导入到病历ToolStripMenuItem.Name = "导入到病历ToolStripMenuItem";
            this.导入到病历ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导入到病历ToolStripMenuItem.Text = "导入到病历";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.checkBoxX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(629, 625);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(724, 31);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(90, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(111, 26);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "导入到病历";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxX1.Location = new System.Drawing.Point(17, 4);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(67, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 0;
            this.checkBoxX1.Text = "全选";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.gridPatient);
            this.panelEx2.Controls.Add(this.panelEx3);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx2.Location = new System.Drawing.Point(0, 34);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(629, 622);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 17;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(629, 30);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            this.panelEx3.Text = "就诊列表";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonItem2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.buttonItem2.SymbolSize = 17F;
            this.buttonItem2.Text = "导入到病历";
            // 
            // FormLISResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 656);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.bar1);
            this.Name = "FormLISResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验检查查询";
            this.Load += new System.EventHandler(this.FormLISResult_Load);
            this.Shown += new System.EventHandler(this.FormLISResult_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridPatient;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridResult;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem3;
        private CIS.ControlLib.Controls.SuperText tbxSearch;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem4;
        private DevComponents.DotNetBar.ButtonItem btnSearch;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择当前行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入到病历ToolStripMenuItem;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labDoctorName;
        private DevComponents.DotNetBar.LabelItem labCheck;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.LabelItem labTechnician;
        private DevComponents.DotNetBar.LabelItem labAge;
        private DevComponents.DotNetBar.LabelItem labSex;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12;
        private DevComponents.DotNetBar.ButtonItem btnKnowlage;
    }
}