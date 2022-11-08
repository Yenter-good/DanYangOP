namespace App_OP
{
    partial class FormMedicalInsurance
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
            this.lbCount = new DevComponents.DotNetBar.LabelX();
            this.lbContent = new DevComponents.DotNetBar.LabelX();
            this.btnSend = new DevComponents.DotNetBar.ButtonX();
            this.tbxExplain = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lbCount
            // 
            // 
            // 
            // 
            this.lbCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCount.Location = new System.Drawing.Point(40, 13);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(375, 37);
            this.lbCount.TabIndex = 0;
            this.lbCount.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbContent
            // 
            // 
            // 
            // 
            this.lbContent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbContent.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbContent.Location = new System.Drawing.Point(40, 56);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(375, 70);
            this.lbContent.TabIndex = 1;
            this.lbContent.WordWrap = true;
            // 
            // btnSend
            // 
            this.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSend.Location = new System.Drawing.Point(238, 252);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(113, 34);
            this.btnSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "拒绝接受,继续用药";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbxExplain
            // 
            // 
            // 
            // 
            this.tbxExplain.Border.Class = "TextBoxBorder";
            this.tbxExplain.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxExplain.Location = new System.Drawing.Point(40, 165);
            this.tbxExplain.Multiline = true;
            this.tbxExplain.Name = "tbxExplain";
            this.tbxExplain.PreventEnterBeep = true;
            this.tbxExplain.Size = new System.Drawing.Size(375, 67);
            this.tbxExplain.TabIndex = 3;
            this.tbxExplain.WatermarkText = "在此输入您的反馈信息";
            this.tbxExplain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxExplain_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(103, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 34);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "接受指导意见";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormMedicalInsurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 313);
            this.Controls.Add(this.tbxExplain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.lbCount);
            this.Name = "FormMedicalInsurance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMedicalInsurance";
            this.Shown += new System.EventHandler(this.FormMedicalInsurance_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbCount;
        private DevComponents.DotNetBar.LabelX lbContent;
        private DevComponents.DotNetBar.ButtonX btnSend;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxExplain;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}