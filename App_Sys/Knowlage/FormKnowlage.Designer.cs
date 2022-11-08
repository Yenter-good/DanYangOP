namespace App_Sys
{
    partial class FormKnowlage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKnowlage));
            this.tvKnowlageNode = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加新分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加新知识节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增关系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.sbDelCategoty = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.sbAddCategoty = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.listBoxAdv2 = new DevComponents.DotNetBar.ListBoxAdv();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnSelectSource = new DevComponents.DotNetBar.ButtonX();
            this.tbxDataSource = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbxMultiSplitStr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.radioMultiSelect = new System.Windows.Forms.RadioButton();
            this.radioSingleSelect = new System.Windows.Forms.RadioButton();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbxKnowlageName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.filterList1 = new CIS.ControlLib.Controls.FilterList();
            this.sbDelKnowlageNode = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.sbAddKnowlageNode = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.flyoutAddCategory = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            this.flyoutAddNode = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            this.flyoutAddSource = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tvKnowlageNode)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvKnowlageNode
            // 
            this.tvKnowlageNode.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvKnowlageNode.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tvKnowlageNode.BackgroundStyle.Class = "TreeBorderKey";
            this.tvKnowlageNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvKnowlageNode.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvKnowlageNode.ImageList = this.imageList1;
            this.tvKnowlageNode.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.tvKnowlageNode.Location = new System.Drawing.Point(0, 0);
            this.tvKnowlageNode.Name = "tvKnowlageNode";
            this.tvKnowlageNode.NodesConnector = this.nodeConnector1;
            this.tvKnowlageNode.NodeStyle = this.elementStyle1;
            this.tvKnowlageNode.PathSeparator = ";";
            this.tvKnowlageNode.Size = new System.Drawing.Size(227, 506);
            this.tvKnowlageNode.Styles.Add(this.elementStyle1);
            this.tvKnowlageNode.TabIndex = 0;
            this.tvKnowlageNode.Text = "advTree1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Suggestion_16x16.png");
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加新分类ToolStripMenuItem,
            this.增加新知识节点ToolStripMenuItem,
            this.新增关系ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // 增加新分类ToolStripMenuItem
            // 
            this.增加新分类ToolStripMenuItem.Name = "增加新分类ToolStripMenuItem";
            this.增加新分类ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.增加新分类ToolStripMenuItem.Text = "增加新分类";
            // 
            // 增加新知识节点ToolStripMenuItem
            // 
            this.增加新知识节点ToolStripMenuItem.Name = "增加新知识节点ToolStripMenuItem";
            this.增加新知识节点ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.增加新知识节点ToolStripMenuItem.Text = "增加新知识节点";
            // 
            // 新增关系ToolStripMenuItem
            // 
            this.新增关系ToolStripMenuItem.Name = "新增关系ToolStripMenuItem";
            this.新增关系ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新增关系ToolStripMenuItem.Text = "新增关系";
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
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(227, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(468, 506);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 2;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.sbDelCategoty);
            this.superTabControlPanel1.Controls.Add(this.sbAddCategoty);
            this.superTabControlPanel1.Controls.Add(this.listBoxAdv2);
            this.superTabControlPanel1.Controls.Add(this.btnReset);
            this.superTabControlPanel1.Controls.Add(this.labelX7);
            this.superTabControlPanel1.Controls.Add(this.btnSave);
            this.superTabControlPanel1.Controls.Add(this.btnSelectSource);
            this.superTabControlPanel1.Controls.Add(this.tbxDataSource);
            this.superTabControlPanel1.Controls.Add(this.tbxMultiSplitStr);
            this.superTabControlPanel1.Controls.Add(this.labelX4);
            this.superTabControlPanel1.Controls.Add(this.radioMultiSelect);
            this.superTabControlPanel1.Controls.Add(this.radioSingleSelect);
            this.superTabControlPanel1.Controls.Add(this.labelX3);
            this.superTabControlPanel1.Controls.Add(this.labelX2);
            this.superTabControlPanel1.Controls.Add(this.tbxKnowlageName);
            this.superTabControlPanel1.Controls.Add(this.labelX1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(468, 478);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // sbDelCategoty
            // 
            // 
            // 
            // 
            this.sbDelCategoty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sbDelCategoty.Location = new System.Drawing.Point(361, 302);
            this.sbDelCategoty.Name = "sbDelCategoty";
            this.sbDelCategoty.Size = new System.Drawing.Size(25, 23);
            this.sbDelCategoty.Symbol = "";
            this.sbDelCategoty.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(200)))));
            this.sbDelCategoty.TabIndex = 31;
            this.sbDelCategoty.Text = "symbolBox2";
            this.sbDelCategoty.MouseEnter += new System.EventHandler(this.sbAddCategoty_MouseEnter);
            this.sbDelCategoty.MouseLeave += new System.EventHandler(this.sbAddCategoty_MouseLeave);
            // 
            // sbAddCategoty
            // 
            // 
            // 
            // 
            this.sbAddCategoty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sbAddCategoty.Location = new System.Drawing.Point(361, 273);
            this.sbAddCategoty.Name = "sbAddCategoty";
            this.sbAddCategoty.Size = new System.Drawing.Size(25, 23);
            this.sbAddCategoty.Symbol = "";
            this.sbAddCategoty.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(200)))));
            this.sbAddCategoty.TabIndex = 30;
            this.sbAddCategoty.Text = "symbolBox1";
            this.sbAddCategoty.MouseEnter += new System.EventHandler(this.sbAddCategoty_MouseEnter);
            this.sbAddCategoty.MouseLeave += new System.EventHandler(this.sbAddCategoty_MouseLeave);
            // 
            // listBoxAdv2
            // 
            this.listBoxAdv2.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv2.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv2.CheckStateMember = null;
            this.listBoxAdv2.ContainerControlProcessDialogKey = true;
            this.listBoxAdv2.DragDropSupport = true;
            this.listBoxAdv2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.listBoxAdv2.Location = new System.Drawing.Point(182, 270);
            this.listBoxAdv2.Name = "listBoxAdv2";
            this.listBoxAdv2.Size = new System.Drawing.Size(176, 112);
            this.listBoxAdv2.TabIndex = 29;
            this.listBoxAdv2.Text = "listBoxAdv2";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(283, 418);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "重置";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(83, 270);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(68, 18);
            this.labelX7.TabIndex = 27;
            this.labelX7.Text = "所属分类：";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(182, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectSource.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectSource.Location = new System.Drawing.Point(357, 215);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(58, 21);
            this.btnSelectSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectSource.TabIndex = 9;
            this.btnSelectSource.Text = "选择";
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // tbxDataSource
            // 
            this.tbxDataSource.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbxDataSource.Border.Class = "TextBoxBorder";
            this.tbxDataSource.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDataSource.Enabled = false;
            this.tbxDataSource.Location = new System.Drawing.Point(182, 215);
            this.tbxDataSource.Name = "tbxDataSource";
            this.tbxDataSource.PreventEnterBeep = true;
            this.tbxDataSource.ReadOnly = true;
            this.tbxDataSource.Size = new System.Drawing.Size(176, 21);
            this.tbxDataSource.TabIndex = 7;
            // 
            // tbxMultiSplitStr
            // 
            // 
            // 
            // 
            this.tbxMultiSplitStr.Border.Class = "TextBoxBorder";
            this.tbxMultiSplitStr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxMultiSplitStr.Enabled = false;
            this.tbxMultiSplitStr.Location = new System.Drawing.Point(182, 162);
            this.tbxMultiSplitStr.Name = "tbxMultiSplitStr";
            this.tbxMultiSplitStr.PreventEnterBeep = true;
            this.tbxMultiSplitStr.Size = new System.Drawing.Size(146, 21);
            this.tbxMultiSplitStr.TabIndex = 7;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(83, 164);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 18);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "多选分隔符：";
            // 
            // radioMultiSelect
            // 
            this.radioMultiSelect.AutoSize = true;
            this.radioMultiSelect.BackColor = System.Drawing.Color.Transparent;
            this.radioMultiSelect.Location = new System.Drawing.Point(281, 110);
            this.radioMultiSelect.Name = "radioMultiSelect";
            this.radioMultiSelect.Size = new System.Drawing.Size(47, 16);
            this.radioMultiSelect.TabIndex = 5;
            this.radioMultiSelect.Text = "多选";
            this.radioMultiSelect.UseVisualStyleBackColor = false;
            // 
            // radioSingleSelect
            // 
            this.radioSingleSelect.AutoSize = true;
            this.radioSingleSelect.BackColor = System.Drawing.Color.Transparent;
            this.radioSingleSelect.Checked = true;
            this.radioSingleSelect.Location = new System.Drawing.Point(182, 110);
            this.radioSingleSelect.Name = "radioSingleSelect";
            this.radioSingleSelect.Size = new System.Drawing.Size(47, 16);
            this.radioSingleSelect.TabIndex = 4;
            this.radioSingleSelect.TabStop = true;
            this.radioSingleSelect.Text = "单选";
            this.radioSingleSelect.UseVisualStyleBackColor = false;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(83, 110);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "选择类型：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(83, 218);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "数据源：";
            // 
            // tbxKnowlageName
            // 
            // 
            // 
            // 
            this.tbxKnowlageName.Border.Class = "TextBoxBorder";
            this.tbxKnowlageName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxKnowlageName.Location = new System.Drawing.Point(182, 53);
            this.tbxKnowlageName.Name = "tbxKnowlageName";
            this.tbxKnowlageName.PreventEnterBeep = true;
            this.tbxKnowlageName.Size = new System.Drawing.Size(146, 21);
            this.tbxKnowlageName.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(83, 56);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(93, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "知识节点名称：";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "知识节点维护";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.filterList1);
            this.superTabControlPanel2.Controls.Add(this.sbDelKnowlageNode);
            this.superTabControlPanel2.Controls.Add(this.sbAddKnowlageNode);
            this.superTabControlPanel2.Controls.Add(this.comboBoxEx1);
            this.superTabControlPanel2.Controls.Add(this.buttonX1);
            this.superTabControlPanel2.Controls.Add(this.buttonX2);
            this.superTabControlPanel2.Controls.Add(this.labelX5);
            this.superTabControlPanel2.Controls.Add(this.labelX6);
            this.superTabControlPanel2.Controls.Add(this.textBoxX3);
            this.superTabControlPanel2.Controls.Add(this.labelX8);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(468, 478);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // filterList1
            // 
            this.filterList1.DataSource = null;
            this.filterList1.DisplayMember = "";
            this.filterList1.Location = new System.Drawing.Point(182, 166);
            this.filterList1.Name = "filterList1";
            this.filterList1.Size = new System.Drawing.Size(172, 246);
            this.filterList1.TabIndex = 34;
            this.filterList1.ValueMember = "";
            // 
            // sbDelKnowlageNode
            // 
            // 
            // 
            // 
            this.sbDelKnowlageNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sbDelKnowlageNode.Location = new System.Drawing.Point(360, 219);
            this.sbDelKnowlageNode.Name = "sbDelKnowlageNode";
            this.sbDelKnowlageNode.Size = new System.Drawing.Size(25, 23);
            this.sbDelKnowlageNode.Symbol = "";
            this.sbDelKnowlageNode.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(200)))));
            this.sbDelKnowlageNode.TabIndex = 33;
            this.sbDelKnowlageNode.Text = "symbolBox3";
            this.sbDelKnowlageNode.MouseEnter += new System.EventHandler(this.sbAddCategoty_MouseEnter);
            this.sbDelKnowlageNode.MouseLeave += new System.EventHandler(this.sbAddCategoty_MouseLeave);
            // 
            // sbAddKnowlageNode
            // 
            // 
            // 
            // 
            this.sbAddKnowlageNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sbAddKnowlageNode.Location = new System.Drawing.Point(360, 190);
            this.sbAddKnowlageNode.Name = "sbAddKnowlageNode";
            this.sbAddKnowlageNode.Size = new System.Drawing.Size(25, 23);
            this.sbAddKnowlageNode.Symbol = "";
            this.sbAddKnowlageNode.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(200)))));
            this.sbAddKnowlageNode.TabIndex = 32;
            this.sbAddKnowlageNode.Text = "symbolBox4";
            this.sbAddKnowlageNode.MouseEnter += new System.EventHandler(this.sbAddCategoty_MouseEnter);
            this.sbAddKnowlageNode.MouseLeave += new System.EventHandler(this.sbAddCategoty_MouseLeave);
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(182, 110);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(146, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 24;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(283, 418);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 23;
            this.buttonX1.Text = "重置";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(182, 418);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 22;
            this.buttonX2.Text = "保存";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(74, 166);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(105, 18);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "拥有的知识节点：";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(92, 112);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(68, 18);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "上级分类：";
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.Location = new System.Drawing.Point(182, 55);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.textBoxX3.Size = new System.Drawing.Size(146, 21);
            this.textBoxX3.TabIndex = 13;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(92, 58);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(68, 18);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "分类名称：";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "分类维护";
            // 
            // flyoutAddCategory
            // 
            this.flyoutAddCategory.DisplayMode = DevComponents.DotNetBar.Controls.eFlyoutDisplayMode.MouseClick;
            this.flyoutAddCategory.DropShadow = false;
            this.flyoutAddCategory.Parent = this;
            this.flyoutAddCategory.PointerSide = DevComponents.DotNetBar.Controls.ePointerSide.Left;
            this.flyoutAddCategory.FlyoutShown += new System.EventHandler(this.flyoutAddCategory_FlyoutShown);
            // 
            // flyoutAddNode
            // 
            this.flyoutAddNode.DisplayMode = DevComponents.DotNetBar.Controls.eFlyoutDisplayMode.MouseClick;
            this.flyoutAddNode.DropShadow = false;
            this.flyoutAddNode.Parent = this;
            this.flyoutAddNode.PointerSide = DevComponents.DotNetBar.Controls.ePointerSide.Left;
            this.flyoutAddNode.FlyoutShown += new System.EventHandler(this.flyoutAddCategory_FlyoutShown);
            // 
            // flyoutAddSource
            // 
            this.flyoutAddSource.DisplayMode = DevComponents.DotNetBar.Controls.eFlyoutDisplayMode.MouseClick;
            this.flyoutAddSource.DropShadow = false;
            this.flyoutAddSource.Parent = this;
            this.flyoutAddSource.PointerSide = DevComponents.DotNetBar.Controls.ePointerSide.Left;
            this.flyoutAddSource.FlyoutShown += new System.EventHandler(this.flyoutAddCategory_FlyoutShown);
            // 
            // FormKnowlage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(695, 506);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.tvKnowlageNode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKnowlage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "知识节点";
            this.Shown += new System.EventHandler(this.FormKnowlage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tvKnowlageNode)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree tvKnowlageNode;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加新分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加新知识节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增关系ToolStripMenuItem;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.RadioButton radioMultiSelect;
        private System.Windows.Forms.RadioButton radioSingleSelect;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxKnowlageName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxMultiSplitStr;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnSelectSource;
        private DevComponents.DotNetBar.Controls.Flyout flyoutAddCategory;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv2;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.SymbolBox sbDelKnowlageNode;
        private DevComponents.DotNetBar.Controls.SymbolBox sbAddKnowlageNode;
        private DevComponents.DotNetBar.Controls.SymbolBox sbDelCategoty;
        private DevComponents.DotNetBar.Controls.SymbolBox sbAddCategoty;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxDataSource;
        private CIS.ControlLib.Controls.FilterList filterList1;
        private DevComponents.DotNetBar.Controls.Flyout flyoutAddNode;
        private DevComponents.DotNetBar.Controls.Flyout flyoutAddSource;
    }
}