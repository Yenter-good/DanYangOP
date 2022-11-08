namespace App_OP.Prescription
{
    partial class FormAddAgent
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbxName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbxIDCard = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.tbxPurpose = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(196, 54);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(94, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "经办人姓名：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(168, 104);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(122, 20);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "经办人身份证号：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(196, 154);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(94, 20);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "经办人性别：";
            // 
            // tbxName
            // 
            // 
            // 
            // 
            this.tbxName.Border.Class = "TextBoxBorder";
            this.tbxName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxName.Location = new System.Drawing.Point(296, 51);
            this.tbxName.Name = "tbxName";
            this.tbxName.PreventEnterBeep = true;
            this.tbxName.Size = new System.Drawing.Size(169, 23);
            this.tbxName.TabIndex = 0;
            // 
            // tbxIDCard
            // 
            // 
            // 
            // 
            this.tbxIDCard.Border.Class = "TextBoxBorder";
            this.tbxIDCard.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxIDCard.Location = new System.Drawing.Point(296, 102);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.PreventEnterBeep = true;
            this.tbxIDCard.Size = new System.Drawing.Size(169, 23);
            this.tbxIDCard.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(390, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "提交";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxSex
            // 
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知"});
            this.cbxSex.Location = new System.Drawing.Point(296, 153);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(169, 22);
            this.cbxSex.TabIndex = 2;
            // 
            // tbxPurpose
            // 
            // 
            // 
            // 
            this.tbxPurpose.Border.Class = "TextBoxBorder";
            this.tbxPurpose.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPurpose.Location = new System.Drawing.Point(296, 203);
            this.tbxPurpose.Name = "tbxPurpose";
            this.tbxPurpose.PreventEnterBeep = true;
            this.tbxPurpose.Size = new System.Drawing.Size(169, 23);
            this.tbxPurpose.TabIndex = 5;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(211, 206);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 20);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "用药目的：";
            // 
            // FormAddAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 309);
            this.Controls.Add(this.tbxPurpose);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cbxSex);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxIDCard);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加经办人";
            this.Shown += new System.EventHandler(this.FormAddAgent_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxName;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxIDCard;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.ComboBox cbxSex;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxPurpose;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}