namespace App_OP
{
    partial class FormReportEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportEdit));
            this.tbxNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbxItemName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbxAssembly = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbxNameSpace = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboTree1 = new DevComponents.DotNetBar.Controls.ComboTree();
            this.menuRootNode = new DevComponents.AdvTree.Node();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.warningBox1 = new DevComponents.DotNetBar.Controls.WarningBox();
            this.rbtnDisable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbxOpenStyle = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tbxMethod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // tbxNo
            // 
            this.tbxNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxNo.Border.Class = "TextBoxBorder";
            this.tbxNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxNo.Location = new System.Drawing.Point(99, 228);
            this.tbxNo.Multiline = true;
            this.tbxNo.Name = "tbxNo";
            this.tbxNo.PreventEnterBeep = true;
            this.tbxNo.Size = new System.Drawing.Size(343, 28);
            this.tbxNo.TabIndex = 7;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 229);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 25);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "排序";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxItemName
            // 
            this.tbxItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxItemName.Border.Class = "TextBoxBorder";
            this.tbxItemName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxItemName.Location = new System.Drawing.Point(99, 58);
            this.tbxItemName.Multiline = true;
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.PreventEnterBeep = true;
            this.tbxItemName.Size = new System.Drawing.Size(343, 28);
            this.tbxItemName.TabIndex = 5;
            this.tbxItemName.WatermarkText = "请输入项目名称";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 59);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 25);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "项目名称";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(13, 127);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 25);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "程序集";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxAssembly
            // 
            this.tbxAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxAssembly.Border.Class = "TextBoxBorder";
            this.tbxAssembly.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxAssembly.Location = new System.Drawing.Point(99, 126);
            this.tbxAssembly.Multiline = true;
            this.tbxAssembly.Name = "tbxAssembly";
            this.tbxAssembly.PreventEnterBeep = true;
            this.tbxAssembly.Size = new System.Drawing.Size(343, 28);
            this.tbxAssembly.TabIndex = 5;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(13, 161);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(80, 25);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "命名空间";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxNameSpace
            // 
            this.tbxNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxNameSpace.Border.Class = "TextBoxBorder";
            this.tbxNameSpace.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxNameSpace.Location = new System.Drawing.Point(99, 160);
            this.tbxNameSpace.Multiline = true;
            this.tbxNameSpace.Name = "tbxNameSpace";
            this.tbxNameSpace.PreventEnterBeep = true;
            this.tbxNameSpace.Size = new System.Drawing.Size(343, 28);
            this.tbxNameSpace.TabIndex = 5;
            // 
            // comboTree1
            // 
            this.comboTree1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.comboTree1.BackgroundStyle.Class = "TextBoxBorder";
            this.comboTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comboTree1.ButtonDropDown.Visible = true;
            this.comboTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.comboTree1.Location = new System.Drawing.Point(99, 24);
            this.comboTree1.Name = "comboTree1";
            this.comboTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.menuRootNode});
            this.comboTree1.Size = new System.Drawing.Size(343, 28);
            this.comboTree1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboTree1.TabIndex = 10;
            this.comboTree1.WatermarkText = "请选择上级分组";
            // 
            // menuRootNode
            // 
            this.menuRootNode.Name = "menuRootNode";
            this.menuRootNode.Text = "一级菜单项目";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 24);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(80, 25);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "上级分组";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Location = new System.Drawing.Point(237, 338);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 34);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Location = new System.Drawing.Point(339, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 34);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            // 
            // warningBox1
            // 
            this.warningBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.warningBox1.CloseButtonVisible = false;
            this.warningBox1.ColorScheme = DevComponents.DotNetBar.Controls.eWarningBoxColorScheme.Red;
            this.warningBox1.Image = ((System.Drawing.Image)(resources.GetObject("warningBox1.Image")));
            this.warningBox1.Location = new System.Drawing.Point(99, 291);
            this.warningBox1.Name = "warningBox1";
            this.warningBox1.OptionsButtonVisible = false;
            this.warningBox1.Size = new System.Drawing.Size(343, 41);
            this.warningBox1.TabIndex = 8;
            this.warningBox1.Text = "<b>Warning Box</b> control with <i>text-markup</i> support.";
            this.warningBox1.Visible = false;
            // 
            // rbtnDisable
            // 
            this.rbtnDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.rbtnDisable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnDisable.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnDisable.Checked = true;
            this.rbtnDisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtnDisable.CheckValue = "Y";
            this.rbtnDisable.FocusCuesEnabled = false;
            this.rbtnDisable.Location = new System.Drawing.Point(280, 262);
            this.rbtnDisable.Name = "rbtnDisable";
            this.rbtnDisable.Size = new System.Drawing.Size(100, 23);
            this.rbtnDisable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnDisable.TabIndex = 12;
            this.rbtnDisable.Text = "停用";
            // 
            // rbtnEnable
            // 
            this.rbtnEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.rbtnEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnEnable.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnEnable.FocusCuesEnabled = false;
            this.rbtnEnable.Location = new System.Drawing.Point(186, 262);
            this.rbtnEnable.Name = "rbtnEnable";
            this.rbtnEnable.Size = new System.Drawing.Size(100, 23);
            this.rbtnEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnEnable.TabIndex = 13;
            this.rbtnEnable.Text = "启用";
            // 
            // cbxOpenStyle
            // 
            this.cbxOpenStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxOpenStyle.AutoItemHeight = false;
            this.cbxOpenStyle.DisplayMember = "Text";
            this.cbxOpenStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxOpenStyle.FormattingEnabled = true;
            this.cbxOpenStyle.IntegralHeight = false;
            this.cbxOpenStyle.ItemHeight = 18;
            this.cbxOpenStyle.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cbxOpenStyle.Location = new System.Drawing.Point(99, 92);
            this.cbxOpenStyle.Name = "cbxOpenStyle";
            this.cbxOpenStyle.Size = new System.Drawing.Size(343, 24);
            this.cbxOpenStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxOpenStyle.TabIndex = 11;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "文档";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "方法";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "窗体";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "对话框";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 95);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(80, 25);
            this.labelX7.TabIndex = 6;
            this.labelX7.Text = "操作方式";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbxMethod
            // 
            this.tbxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbxMethod.Border.Class = "TextBoxBorder";
            this.tbxMethod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxMethod.Location = new System.Drawing.Point(99, 194);
            this.tbxMethod.Multiline = true;
            this.tbxMethod.Name = "tbxMethod";
            this.tbxMethod.PreventEnterBeep = true;
            this.tbxMethod.Size = new System.Drawing.Size(343, 28);
            this.tbxMethod.TabIndex = 14;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(13, 195);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(80, 25);
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "方法名";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // FormReportEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 387);
            this.Controls.Add(this.tbxMethod);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.rbtnDisable);
            this.Controls.Add(this.rbtnEnable);
            this.Controls.Add(this.cbxOpenStyle);
            this.Controls.Add(this.comboTree1);
            this.Controls.Add(this.warningBox1);
            this.Controls.Add(this.tbxNo);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbxNameSpace);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.tbxAssembly);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormReportEdit";
            this.Text = "设置菜单";
            this.TitleText = "设置菜单";
            this.Load += new System.EventHandler(this.FormMenuEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.WarningBox warningBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxNo;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxItemName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxAssembly;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxNameSpace;
        private DevComponents.DotNetBar.Controls.ComboTree comboTree1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnDisable;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnEnable;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxOpenStyle;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.AdvTree.Node menuRootNode;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxMethod;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}