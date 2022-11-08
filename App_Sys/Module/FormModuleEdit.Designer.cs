namespace App_Sys
{
    partial class FormModuleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModuleEdit));
            this.input_No = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.input_Text = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.input_RNO = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.input_FName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboTree1 = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnBrowser = new DevComponents.DotNetBar.ButtonX();
            this.warningBox1 = new DevComponents.DotNetBar.Controls.WarningBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(288, 286);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 286);
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
            this.input_No.Location = new System.Drawing.Point(99, 179);
            this.input_No.Multiline = true;
            this.input_No.Name = "input_No";
            this.input_No.PreventEnterBeep = true;
            this.input_No.Size = new System.Drawing.Size(314, 28);
            this.input_No.TabIndex = 7;
            this.input_No.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 180);
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
            this.input_Text.Location = new System.Drawing.Point(99, 77);
            this.input_Text.Multiline = true;
            this.input_Text.Name = "input_Text";
            this.input_Text.PreventEnterBeep = true;
            this.input_Text.Size = new System.Drawing.Size(314, 28);
            this.input_Text.TabIndex = 5;
            this.input_Text.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 78);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 25);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "模块名称";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(13, 112);
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
            this.input_RNO.Location = new System.Drawing.Point(99, 111);
            this.input_RNO.Multiline = true;
            this.input_RNO.Name = "input_RNO";
            this.input_RNO.PreventEnterBeep = true;
            this.input_RNO.Size = new System.Drawing.Size(314, 28);
            this.input_RNO.TabIndex = 5;
            this.input_RNO.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(13, 146);
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
            this.input_FName.Location = new System.Drawing.Point(99, 145);
            this.input_FName.Multiline = true;
            this.input_FName.Name = "input_FName";
            this.input_FName.PreventEnterBeep = true;
            this.input_FName.Size = new System.Drawing.Size(314, 28);
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
            this.comboTree1.Location = new System.Drawing.Point(99, 43);
            this.comboTree1.Name = "comboTree1";
            this.comboTree1.Size = new System.Drawing.Size(314, 28);
            this.comboTree1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboTree1.TabIndex = 10;
            this.comboTree1.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 43);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(80, 25);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "所属分类";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnBrowser
            // 
            this.btnBrowser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBrowser.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowser.Image")));
            this.btnBrowser.Location = new System.Drawing.Point(419, 114);
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
            this.warningBox1.Location = new System.Drawing.Point(99, 213);
            this.warningBox1.Name = "warningBox1";
            this.warningBox1.OptionsButtonVisible = false;
            this.warningBox1.Size = new System.Drawing.Size(314, 41);
            this.warningBox1.TabIndex = 8;
            this.warningBox1.Text = "<b>Warning Box</b> control with <i>text-markup</i> support.";
            this.warningBox1.Visible = false;
            // 
            // FormModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.Controls.Add(this.comboTree1);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.warningBox1);
            this.Controls.Add(this.input_No);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.input_FName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.input_RNO);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.input_Text);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "FormModuleEdit";
            this.Text = "设置模块";
            this.TitleText = "设置模块";
            this.OKing += new System.EventHandler<CIS.Core.CancelEventArgsExt>(this.FormModuleEdit_OKing);
            this.Load += new System.EventHandler(this.FormModuleEdit_Load);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.labelX5, 0);
            this.Controls.SetChildIndex(this.input_Text, 0);
            this.Controls.SetChildIndex(this.labelX3, 0);
            this.Controls.SetChildIndex(this.input_RNO, 0);
            this.Controls.SetChildIndex(this.labelX4, 0);
            this.Controls.SetChildIndex(this.input_FName, 0);
            this.Controls.SetChildIndex(this.labelX2, 0);
            this.Controls.SetChildIndex(this.input_No, 0);
            this.Controls.SetChildIndex(this.warningBox1, 0);
            this.Controls.SetChildIndex(this.btnBrowser, 0);
            this.Controls.SetChildIndex(this.comboTree1, 0);
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

    }
}