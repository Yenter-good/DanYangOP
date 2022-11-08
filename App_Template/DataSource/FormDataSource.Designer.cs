namespace App_Template
{
    partial class FormDataSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataSource));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.rootNode = new DevComponents.AdvTree.Node();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtSName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.rbtnSDisable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnSEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtSDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtSCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.stabSourceNode = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chkFVisible = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkFReadOnly = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkFRequired = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboFDataType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtFName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtFDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtFCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.stabField = new DevComponents.DotNetBar.SuperTabItem();
            this.pnlIntruduction = new System.Windows.Forms.Panel();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            this.biAddDataSourceNode = new DevComponents.DotNetBar.ButtonItem();
            this.biAddDataField = new DevComponents.DotNetBar.ButtonItem();
            this.biDelete = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ilNode = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.pnlIntruduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superTabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.pnlIntruduction);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(714, 427);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.rootNode});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(221, 427);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTree1_AfterNodeSelect);
            // 
            // rootNode
            // 
            this.rootNode.Expanded = true;
            this.rootNode.Image = ((System.Drawing.Image)(resources.GetObject("rootNode.Image")));
            this.rootNode.Name = "rootNode";
            this.rootNode.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.rootNode.Text = "数据源";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
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
            this.superTabControl1.ControlBox.Visible = false;
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 2);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(489, 425);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stabSourceNode,
            this.stabField});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.labelX15);
            this.superTabControlPanel1.Controls.Add(this.txtSName);
            this.superTabControlPanel1.Controls.Add(this.labelX16);
            this.superTabControlPanel1.Controls.Add(this.rbtnSDisable);
            this.superTabControlPanel1.Controls.Add(this.rbtnSEnable);
            this.superTabControlPanel1.Controls.Add(this.labelX6);
            this.superTabControlPanel1.Controls.Add(this.labelX7);
            this.superTabControlPanel1.Controls.Add(this.txtSDescription);
            this.superTabControlPanel1.Controls.Add(this.labelX5);
            this.superTabControlPanel1.Controls.Add(this.txtSCode);
            this.superTabControlPanel1.Controls.Add(this.labelX1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(489, 395);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.stabSourceNode;
            // 
            // labelX15
            // 
            this.labelX15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(420, 58);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(66, 23);
            this.labelX15.TabIndex = 7;
            this.labelX15.Text = "(必填项)";
            // 
            // txtSName
            // 
            this.txtSName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSName.Border.Class = "TextBoxBorder";
            this.txtSName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSName.Location = new System.Drawing.Point(76, 58);
            this.txtSName.Name = "txtSName";
            this.txtSName.PreventEnterBeep = true;
            this.txtSName.Size = new System.Drawing.Size(339, 23);
            this.txtSName.TabIndex = 6;
            // 
            // labelX16
            // 
            this.labelX16.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(3, 58);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(75, 23);
            this.labelX16.TabIndex = 5;
            this.labelX16.Text = "名称：";
            this.labelX16.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // rbtnSDisable
            // 
            this.rbtnSDisable.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnSDisable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnSDisable.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnSDisable.Location = new System.Drawing.Point(190, 197);
            this.rbtnSDisable.Name = "rbtnSDisable";
            this.rbtnSDisable.Size = new System.Drawing.Size(100, 23);
            this.rbtnSDisable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnSDisable.TabIndex = 3;
            this.rbtnSDisable.Text = "停用";
            // 
            // rbtnSEnable
            // 
            this.rbtnSEnable.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnSEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnSEnable.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnSEnable.Location = new System.Drawing.Point(84, 197);
            this.rbtnSEnable.Name = "rbtnSEnable";
            this.rbtnSEnable.Size = new System.Drawing.Size(100, 23);
            this.rbtnSEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnSEnable.TabIndex = 3;
            this.rbtnSEnable.Text = "启用";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(420, 29);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(66, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "(必填项)";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(3, 197);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "状态：";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSDescription
            // 
            this.txtSDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSDescription.Border.Class = "TextBoxBorder";
            this.txtSDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSDescription.Location = new System.Drawing.Point(76, 87);
            this.txtSDescription.Multiline = true;
            this.txtSDescription.Name = "txtSDescription";
            this.txtSDescription.PreventEnterBeep = true;
            this.txtSDescription.Size = new System.Drawing.Size(339, 104);
            this.txtSDescription.TabIndex = 1;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 87);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "描述：";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtSCode
            // 
            this.txtSCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSCode.Border.Class = "TextBoxBorder";
            this.txtSCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSCode.Location = new System.Drawing.Point(76, 29);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.PreventEnterBeep = true;
            this.txtSCode.Size = new System.Drawing.Size(339, 23);
            this.txtSCode.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "代码：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // stabSourceNode
            // 
            this.stabSourceNode.AttachedControl = this.superTabControlPanel1;
            this.stabSourceNode.GlobalItem = false;
            this.stabSourceNode.Name = "stabSourceNode";
            this.stabSourceNode.Text = "数据源属性";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.chkFVisible);
            this.superTabControlPanel2.Controls.Add(this.chkFReadOnly);
            this.superTabControlPanel2.Controls.Add(this.chkFRequired);
            this.superTabControlPanel2.Controls.Add(this.comboFDataType);
            this.superTabControlPanel2.Controls.Add(this.labelX8);
            this.superTabControlPanel2.Controls.Add(this.labelX11);
            this.superTabControlPanel2.Controls.Add(this.txtFName);
            this.superTabControlPanel2.Controls.Add(this.labelX9);
            this.superTabControlPanel2.Controls.Add(this.labelX10);
            this.superTabControlPanel2.Controls.Add(this.txtFDescription);
            this.superTabControlPanel2.Controls.Add(this.labelX12);
            this.superTabControlPanel2.Controls.Add(this.txtFCode);
            this.superTabControlPanel2.Controls.Add(this.labelX18);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(489, 395);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.stabField;
            // 
            // chkFVisible
            // 
            this.chkFVisible.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkFVisible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFVisible.Location = new System.Drawing.Point(288, 225);
            this.chkFVisible.Name = "chkFVisible";
            this.chkFVisible.Size = new System.Drawing.Size(100, 23);
            this.chkFVisible.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFVisible.TabIndex = 28;
            this.chkFVisible.Text = "可见";
            // 
            // chkFReadOnly
            // 
            this.chkFReadOnly.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkFReadOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFReadOnly.Location = new System.Drawing.Point(182, 225);
            this.chkFReadOnly.Name = "chkFReadOnly";
            this.chkFReadOnly.Size = new System.Drawing.Size(100, 23);
            this.chkFReadOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFReadOnly.TabIndex = 29;
            this.chkFReadOnly.Text = "只读";
            // 
            // chkFRequired
            // 
            this.chkFRequired.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkFRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFRequired.Location = new System.Drawing.Point(76, 225);
            this.chkFRequired.Name = "chkFRequired";
            this.chkFRequired.Size = new System.Drawing.Size(100, 23);
            this.chkFRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFRequired.TabIndex = 30;
            this.chkFRequired.Text = "不能为空";
            // 
            // comboFDataType
            // 
            this.comboFDataType.DisplayMember = "Text";
            this.comboFDataType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboFDataType.FormattingEnabled = true;
            this.comboFDataType.ItemHeight = 18;
            this.comboFDataType.Location = new System.Drawing.Point(76, 86);
            this.comboFDataType.Name = "comboFDataType";
            this.comboFDataType.Size = new System.Drawing.Size(339, 24);
            this.comboFDataType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboFDataType.TabIndex = 27;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(420, 57);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(66, 23);
            this.labelX8.TabIndex = 25;
            this.labelX8.Text = "(必填项)";
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(0, 86);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(78, 23);
            this.labelX11.TabIndex = 23;
            this.labelX11.Text = "数据类型：";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtFName
            // 
            this.txtFName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFName.Border.Class = "TextBoxBorder";
            this.txtFName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFName.Location = new System.Drawing.Point(76, 57);
            this.txtFName.Name = "txtFName";
            this.txtFName.PreventEnterBeep = true;
            this.txtFName.Size = new System.Drawing.Size(339, 23);
            this.txtFName.TabIndex = 24;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(3, 57);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 23;
            this.labelX9.Text = "名称：";
            this.labelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX10
            // 
            this.labelX10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(420, 28);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(66, 23);
            this.labelX10.TabIndex = 19;
            this.labelX10.Text = "(必填项)";
            // 
            // txtFDescription
            // 
            this.txtFDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFDescription.Border.Class = "TextBoxBorder";
            this.txtFDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFDescription.Location = new System.Drawing.Point(76, 115);
            this.txtFDescription.Multiline = true;
            this.txtFDescription.Name = "txtFDescription";
            this.txtFDescription.PreventEnterBeep = true;
            this.txtFDescription.Size = new System.Drawing.Size(339, 104);
            this.txtFDescription.TabIndex = 17;
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(3, 115);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(75, 23);
            this.labelX12.TabIndex = 13;
            this.labelX12.Text = "描述：";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtFCode
            // 
            this.txtFCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFCode.Border.Class = "TextBoxBorder";
            this.txtFCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFCode.Location = new System.Drawing.Point(76, 28);
            this.txtFCode.Name = "txtFCode";
            this.txtFCode.PreventEnterBeep = true;
            this.txtFCode.Size = new System.Drawing.Size(339, 23);
            this.txtFCode.TabIndex = 18;
            // 
            // labelX18
            // 
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(3, 28);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(75, 23);
            this.labelX18.TabIndex = 8;
            this.labelX18.Text = "代码：";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // stabField
            // 
            this.stabField.AttachedControl = this.superTabControlPanel2;
            this.stabField.GlobalItem = false;
            this.stabField.Name = "stabField";
            this.stabField.Text = "字段属性";
            this.stabField.Visible = false;
            // 
            // pnlIntruduction
            // 
            this.pnlIntruduction.Controls.Add(this.labelX14);
            this.pnlIntruduction.Controls.Add(this.labelX13);
            this.pnlIntruduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIntruduction.Location = new System.Drawing.Point(0, 2);
            this.pnlIntruduction.Name = "pnlIntruduction";
            this.pnlIntruduction.Size = new System.Drawing.Size(489, 425);
            this.pnlIntruduction.TabIndex = 5;
            // 
            // labelX14
            // 
            this.labelX14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(64, 46);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(391, 321);
            this.labelX14.TabIndex = 1;
            this.labelX14.Text = "啦啦德玛西亚\r\n啦啦噜啊噜啊\r\n啦啦啦.....................";
            this.labelX14.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX13.Location = new System.Drawing.Point(39, 17);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(137, 23);
            this.labelX13.TabIndex = 0;
            this.labelX13.Text = "数据源管理简介";
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefresh,
            this.biSave,
            this.biAddDataSourceNode,
            this.biAddDataField,
            this.biDelete,
            this.buttonItem5,
            this.buttonItem6});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(714, 41);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biRefresh
            // 
            this.biRefresh.Image = ((System.Drawing.Image)(resources.GetObject("biRefresh.Image")));
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // biSave
            // 
            this.biSave.BeginGroup = true;
            this.biSave.Image = ((System.Drawing.Image)(resources.GetObject("biSave.Image")));
            this.biSave.Name = "biSave";
            this.biSave.Text = "新增数据源节点";
            this.biSave.Click += new System.EventHandler(this.biSave_Click);
            // 
            // biAddDataSourceNode
            // 
            this.biAddDataSourceNode.BeginGroup = true;
            this.biAddDataSourceNode.Image = ((System.Drawing.Image)(resources.GetObject("biAddDataSourceNode.Image")));
            this.biAddDataSourceNode.Name = "biAddDataSourceNode";
            this.biAddDataSourceNode.Text = "新增数据源节点";
            this.biAddDataSourceNode.Click += new System.EventHandler(this.biAddDataSourceNode_Click);
            // 
            // biAddDataField
            // 
            this.biAddDataField.Image = ((System.Drawing.Image)(resources.GetObject("biAddDataField.Image")));
            this.biAddDataField.Name = "biAddDataField";
            this.biAddDataField.Text = "新增字段节点";
            this.biAddDataField.Click += new System.EventHandler(this.biAddDataField_Click);
            // 
            // biDelete
            // 
            this.biDelete.Image = ((System.Drawing.Image)(resources.GetObject("biDelete.Image")));
            this.biDelete.Name = "biDelete";
            this.biDelete.Text = "删除节点";
            this.biDelete.Click += new System.EventHandler(this.biDelete_Click);
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "删除节点";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "删除节点";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "刷新";
            // 
            // ilNode
            // 
            this.ilNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilNode.ImageStream")));
            this.ilNode.TransparentColor = System.Drawing.Color.Transparent;
            this.ilNode.Images.SetKeyName(0, "Node");
            this.ilNode.Images.SetKeyName(1, "Field");
            // 
            // FormDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 468);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FormDataSource";
            this.Text = "数据源维护";
            this.Load += new System.EventHandler(this.FormDataSource_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.pnlIntruduction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem stabSourceNode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSDescription;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSCode;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnSDisable;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnSEnable;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.AdvTree.Node rootNode;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.ButtonItem biAddDataSourceNode;
        private DevComponents.DotNetBar.ButtonItem biAddDataField;
        private DevComponents.DotNetBar.ButtonItem biDelete;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem stabField;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSName;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFName;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFDescription;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFCode;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkFVisible;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkFReadOnly;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkFRequired;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboFDataType;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonItem biSave;
        private DevComponents.AdvTree.Node node1;
        private System.Windows.Forms.ImageList ilNode;
        private System.Windows.Forms.Panel pnlIntruduction;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX13;
    }
}