namespace App_Template.ElementLIB
{
    partial class FormElementLIB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormElementLIB));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tvElementLIB = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.tbxFilter = new CIS.ControlLib.Controls.SuperText();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAddFolder = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddElement = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.radioIP = new System.Windows.Forms.RadioButton();
            this.radioOP = new System.Windows.Forms.RadioButton();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.tokenTag = new DevComponents.DotNetBar.Controls.TokenEditor();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbxWubiCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbxSpellCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbxSearchCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbxName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WriteControl = new App_Template.Common.ElementDesignControl();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvElementLIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tvElementLIB);
            this.panelEx1.Controls.Add(this.tbxFilter);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(221, 468);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // tvElementLIB
            // 
            this.tvElementLIB.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvElementLIB.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tvElementLIB.BackgroundStyle.BorderColor = System.Drawing.Color.Transparent;
            this.tvElementLIB.BackgroundStyle.Class = "TreeBorderKey";
            this.tvElementLIB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvElementLIB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvElementLIB.ImageList = this.imageList1;
            this.tvElementLIB.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.tvElementLIB.Location = new System.Drawing.Point(0, 31);
            this.tvElementLIB.Name = "tvElementLIB";
            this.tvElementLIB.NodesConnector = this.nodeConnector1;
            this.tvElementLIB.NodeStyle = this.elementStyle1;
            this.tvElementLIB.PathSeparator = ";";
            this.tvElementLIB.Size = new System.Drawing.Size(221, 437);
            this.tvElementLIB.Styles.Add(this.elementStyle1);
            this.tvElementLIB.TabIndex = 2;
            this.tvElementLIB.Text = "advTree1";
            this.tvElementLIB.BeforeNodeSelect += new DevComponents.AdvTree.AdvTreeNodeCancelEventHandler(this.tvElementLIB_BeforeNodeSelect);
            this.tvElementLIB.BeforeNodeDrop += new DevComponents.AdvTree.TreeDragDropEventHandler(this.tvElementLIB_BeforeNodeDrop);
            this.tvElementLIB.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.tvElementLIB_NodeClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TextBox_16x16.png");
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
            // tbxFilter
            // 
            this.tbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxFilter.Border.Class = "TextBoxBorder";
            this.tbxFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFilter.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("tbxFilter.ButtonCustom.Image")));
            this.tbxFilter.ButtonCustom.Visible = true;
            this.tbxFilter.Location = new System.Drawing.Point(3, 4);
            this.tbxFilter.MarkString = null;
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.PreventEnterBeep = true;
            this.tbxFilter.Size = new System.Drawing.Size(215, 23);
            this.tbxFilter.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 31);
            this.panel1.TabIndex = 3;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddFolder,
            this.btnAddElement,
            this.btnDel});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(221, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFolder.Image")));
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Text = "添加组";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnAddElement
            // 
            this.btnAddElement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddElement.Image = ((System.Drawing.Image)(resources.GetObject("btnAddElement.Image")));
            this.btnAddElement.Name = "btnAddElement";
            this.btnAddElement.Text = "添加元素";
            this.btnAddElement.Click += new System.EventHandler(this.btnAddElement_Click);
            // 
            // btnDel
            // 
            this.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.comboBoxEx1);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.radioIP);
            this.panelEx2.Controls.Add(this.radioOP);
            this.panelEx2.Controls.Add(this.btnReset);
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.Controls.Add(this.tokenTag);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.tbxWubiCode);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.tbxSpellCode);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.tbxSearchCode);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.tbxName);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 186);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(492, 309);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.panelEx2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Top;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 16;
            // 
            // radioIP
            // 
            this.radioIP.AutoSize = true;
            this.radioIP.Location = new System.Drawing.Point(173, 267);
            this.radioIP.Name = "radioIP";
            this.radioIP.Size = new System.Drawing.Size(53, 18);
            this.radioIP.TabIndex = 13;
            this.radioIP.Text = "住院";
            this.radioIP.UseVisualStyleBackColor = true;
            // 
            // radioOP
            // 
            this.radioOP.AutoSize = true;
            this.radioOP.Checked = true;
            this.radioOP.Location = new System.Drawing.Point(92, 267);
            this.radioOP.Name = "radioOP";
            this.radioOP.Size = new System.Drawing.Size(53, 18);
            this.radioOP.TabIndex = 12;
            this.radioOP.TabStop = true;
            this.radioOP.Text = "门诊";
            this.radioOP.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(280, 267);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "清空";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(392, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tokenTag
            // 
            this.tokenTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenTag.AutoSizeHeight = false;
            // 
            // 
            // 
            this.tokenTag.BackgroundStyle.Class = "DateTimeInputBackground";
            this.tokenTag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tokenTag.Location = new System.Drawing.Point(92, 161);
            this.tokenTag.Name = "tokenTag";
            this.tokenTag.Size = new System.Drawing.Size(375, 95);
            this.tokenTag.TabIndex = 9;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(11, 159);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "特征码：";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxWubiCode
            // 
            this.tbxWubiCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxWubiCode.Border.Class = "TextBoxBorder";
            this.tbxWubiCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxWubiCode.Location = new System.Drawing.Point(92, 132);
            this.tbxWubiCode.Name = "tbxWubiCode";
            this.tbxWubiCode.PreventEnterBeep = true;
            this.tbxWubiCode.Size = new System.Drawing.Size(375, 23);
            this.tbxWubiCode.TabIndex = 7;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(11, 130);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "五笔码：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxSpellCode
            // 
            this.tbxSpellCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxSpellCode.Border.Class = "TextBoxBorder";
            this.tbxSpellCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxSpellCode.Location = new System.Drawing.Point(92, 103);
            this.tbxSpellCode.Name = "tbxSpellCode";
            this.tbxSpellCode.PreventEnterBeep = true;
            this.tbxSpellCode.Size = new System.Drawing.Size(375, 23);
            this.tbxSpellCode.TabIndex = 5;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(11, 103);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "拼音码：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxSearchCode
            // 
            this.tbxSearchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxSearchCode.Border.Class = "TextBoxBorder";
            this.tbxSearchCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxSearchCode.Location = new System.Drawing.Point(92, 74);
            this.tbxSearchCode.Name = "tbxSearchCode";
            this.tbxSearchCode.PreventEnterBeep = true;
            this.tbxSearchCode.Size = new System.Drawing.Size(375, 23);
            this.tbxSearchCode.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(11, 76);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "检索码：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxName.Border.Class = "TextBoxBorder";
            this.tbxName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxName.Location = new System.Drawing.Point(92, 45);
            this.tbxName.Name = "tbxName";
            this.tbxName.PreventEnterBeep = true;
            this.tbxName.Size = new System.Drawing.Size(375, 23);
            this.tbxName.TabIndex = 1;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(11, 44);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "名称：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelEx1);
            this.splitContainer1.Panel1.Controls.Add(this.bar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.WriteControl);
            this.splitContainer1.Panel2.Controls.Add(this.panelEx2);
            this.splitContainer1.Size = new System.Drawing.Size(717, 495);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 24;
            // 
            // WriteControl
            // 
            this.WriteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteControl.Location = new System.Drawing.Point(0, 0);
            this.WriteControl.Name = "WriteControl";
            this.WriteControl.Size = new System.Drawing.Size(492, 186);
            this.WriteControl.TabIndex = 8;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(11, 15);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 14;
            this.labelX6.Text = "类型：";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 17;
            this.comboBoxEx1.Location = new System.Drawing.Point(92, 15);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(375, 23);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 15;
            // 
            // FormElementLIB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 495);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "FormElementLIB";
            this.Text = "元素库";
            this.Shown += new System.EventHandler(this.FormElementLIB_Shown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvElementLIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private Common.ElementDesignControl WriteControl;
        private CIS.ControlLib.Controls.SuperText tbxFilter;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAddFolder;
        private DevComponents.DotNetBar.ButtonItem btnAddElement;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.TokenEditor tokenTag;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxWubiCode;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxSpellCode;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxSearchCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.AdvTree.AdvTree tvElementLIB;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton radioIP;
        private System.Windows.Forms.RadioButton radioOP;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX6;
    }
}