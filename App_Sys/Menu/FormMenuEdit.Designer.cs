namespace App_Sys
{
    partial class FormMenuEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuEdit));
            this.input_No = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.input_Text = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.input_RNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.input_FName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboTree1 = new DevComponents.DotNetBar.Controls.ComboTree();
            this.menuRootNode = new DevComponents.AdvTree.Node();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnBrowser = new DevComponents.DotNetBar.ButtonX();
            this.warningBox1 = new DevComponents.DotNetBar.Controls.WarningBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.input_AppCode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.rbtnDisable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbOpenStyle = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(317, 379);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(409, 379);
            // 
            // input_No
            // 
            this.input_No.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.input_No.Border.Class = "TextBoxBorder";
            this.input_No.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_No.Location = new System.Drawing.Point(99, 246);
            this.input_No.Multiline = true;
            this.input_No.Name = "input_No";
            this.input_No.PreventEnterBeep = true;
            this.input_No.Size = new System.Drawing.Size(343, 28);
            this.input_No.TabIndex = 7;
            this.input_No.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 247);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 25);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "排序";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_Text
            // 
            this.input_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.input_Text.Border.Class = "TextBoxBorder";
            this.input_Text.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Text.Location = new System.Drawing.Point(99, 110);
            this.input_Text.Multiline = true;
            this.input_Text.Name = "input_Text";
            this.input_Text.PreventEnterBeep = true;
            this.input_Text.Size = new System.Drawing.Size(343, 28);
            this.input_Text.TabIndex = 5;
            this.input_Text.WatermarkText = "请输入菜单名称";
            this.input_Text.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 111);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 25);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "菜单名称";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(13, 179);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 25);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "程序集";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_RNO
            // 
            this.input_RNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.input_RNO.Border.Class = "TextBoxBorder";
            this.input_RNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_RNO.Location = new System.Drawing.Point(99, 178);
            this.input_RNO.Multiline = true;
            this.input_RNO.Name = "input_RNO";
            this.input_RNO.PreventEnterBeep = true;
            this.input_RNO.Size = new System.Drawing.Size(343, 28);
            this.input_RNO.TabIndex = 5;
            this.input_RNO.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(13, 213);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(80, 25);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "命名空间";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_FName
            // 
            this.input_FName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.input_FName.Border.Class = "TextBoxBorder";
            this.input_FName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_FName.Location = new System.Drawing.Point(99, 212);
            this.input_FName.Multiline = true;
            this.input_FName.Name = "input_FName";
            this.input_FName.PreventEnterBeep = true;
            this.input_FName.Size = new System.Drawing.Size(343, 28);
            this.input_FName.TabIndex = 5;
            this.input_FName.TextChanged += new System.EventHandler(this.input_TextChanged);
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
            this.comboTree1.Location = new System.Drawing.Point(99, 76);
            this.comboTree1.Name = "comboTree1";
            this.comboTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.menuRootNode});
            this.comboTree1.Size = new System.Drawing.Size(343, 28);
            this.comboTree1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboTree1.TabIndex = 10;
            this.comboTree1.WatermarkText = "请选择上级菜单";
            this.comboTree1.TextChanged += new System.EventHandler(this.input_TextChanged);
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
            this.labelX5.Location = new System.Drawing.Point(13, 76);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(80, 25);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "上级菜单";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnBrowser
            // 
            this.btnBrowser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBrowser.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowser.Image")));
            this.btnBrowser.Location = new System.Drawing.Point(448, 113);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBrowser.TabIndex = 9;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // warningBox1
            // 
            this.warningBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.warningBox1.CloseButtonVisible = false;
            this.warningBox1.ColorScheme = DevComponents.DotNetBar.Controls.eWarningBoxColorScheme.Red;
            this.warningBox1.Image = ((System.Drawing.Image)(resources.GetObject("warningBox1.Image")));
            this.warningBox1.Location = new System.Drawing.Point(99, 309);
            this.warningBox1.Name = "warningBox1";
            this.warningBox1.OptionsButtonVisible = false;
            this.warningBox1.Size = new System.Drawing.Size(343, 41);
            this.warningBox1.TabIndex = 8;
            this.warningBox1.Text = "<b>Warning Box</b> control with <i>text-markup</i> support.";
            this.warningBox1.Visible = false;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(13, 42);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(80, 25);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "所属系统";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_AppCode
            // 
            this.input_AppCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_AppCode.AutoItemHeight = false;
            this.input_AppCode.DisplayMember = "Text";
            this.input_AppCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_AppCode.FormattingEnabled = true;
            this.input_AppCode.IntegralHeight = false;
            this.input_AppCode.ItemHeight = 18;
            this.input_AppCode.Location = new System.Drawing.Point(99, 42);
            this.input_AppCode.Name = "input_AppCode";
            this.input_AppCode.Size = new System.Drawing.Size(343, 24);
            this.input_AppCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_AppCode.TabIndex = 11;
            this.input_AppCode.WatermarkText = "请选择系统";
            this.input_AppCode.SelectedIndexChanged += new System.EventHandler(this.input_System_SelectedIndexChanged);
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
            this.rbtnDisable.Location = new System.Drawing.Point(280, 280);
            this.rbtnDisable.Name = "rbtnDisable";
            this.rbtnDisable.Size = new System.Drawing.Size(100, 23);
            this.rbtnDisable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnDisable.TabIndex = 12;
            this.rbtnDisable.Text = "停用";
            this.rbtnDisable.CheckedChanged += new System.EventHandler(this.rbtnEnable_CheckedChanged);
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
            this.rbtnEnable.Location = new System.Drawing.Point(186, 280);
            this.rbtnEnable.Name = "rbtnEnable";
            this.rbtnEnable.Size = new System.Drawing.Size(100, 23);
            this.rbtnEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnEnable.TabIndex = 13;
            this.rbtnEnable.Text = "启用";
            this.rbtnEnable.CheckedChanged += new System.EventHandler(this.rbtnEnable_CheckedChanged);
            // 
            // cmbOpenStyle
            // 
            this.cmbOpenStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOpenStyle.AutoItemHeight = false;
            this.cmbOpenStyle.DisplayMember = "Text";
            this.cmbOpenStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOpenStyle.FormattingEnabled = true;
            this.cmbOpenStyle.IntegralHeight = false;
            this.cmbOpenStyle.ItemHeight = 18;
            this.cmbOpenStyle.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cmbOpenStyle.Location = new System.Drawing.Point(99, 144);
            this.cmbOpenStyle.Name = "cmbOpenStyle";
            this.cmbOpenStyle.Size = new System.Drawing.Size(343, 24);
            this.cmbOpenStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbOpenStyle.TabIndex = 11;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "选项卡模式";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "对话框模式";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "窗口模式";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 147);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(80, 25);
            this.labelX7.TabIndex = 6;
            this.labelX7.Text = "显示方式";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "方法";
            // 
            // FormMenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 422);
            this.Controls.Add(this.rbtnDisable);
            this.Controls.Add(this.rbtnEnable);
            this.Controls.Add(this.cmbOpenStyle);
            this.Controls.Add(this.input_AppCode);
            this.Controls.Add(this.comboTree1);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.warningBox1);
            this.Controls.Add(this.input_No);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.input_FName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.input_RNO);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.input_Text);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "FormMenuEdit";
            this.Text = "设置菜单";
            this.TitleText = "设置菜单";
            this.OKing += new System.EventHandler<CIS.Core.CancelEventArgsExt>(this.FormModuleEdit_OKing);
            this.Load += new System.EventHandler(this.FormModuleEdit_Load);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX7, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.input_Text, 0);
            this.Controls.SetChildIndex(this.labelX6, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.input_RNO, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.input_FName, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.input_No, 0);
            this.Controls.SetChildIndex(this.warningBox1, 0);
            this.Controls.SetChildIndex(this.btnBrowser, 0);
            this.Controls.SetChildIndex(this.comboTree1, 0);
            this.Controls.SetChildIndex(this.input_AppCode, 0);
            this.Controls.SetChildIndex(this.cmbOpenStyle, 0);
            this.Controls.SetChildIndex(this.rbtnEnable, 0);
            this.Controls.SetChildIndex(this.rbtnDisable, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.WarningBox warningBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX input_No;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Text;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX input_RNO;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX input_FName;
        private DevComponents.DotNetBar.ButtonX btnBrowser;
        private DevComponents.DotNetBar.Controls.ComboTree comboTree1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_AppCode;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnDisable;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnEnable;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbOpenStyle;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.AdvTree.Node menuRootNode;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}