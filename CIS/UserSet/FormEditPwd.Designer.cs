namespace CIS
{
    partial class FormEditPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPwd));
            this.txtOldPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPwdOk = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtOldPwd
            // 
            // 
            // 
            // 
            this.txtOldPwd.Border.Class = "TextBoxBorder";
            this.txtOldPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldPwd.Font = new System.Drawing.Font("宋体", 12F);
            this.txtOldPwd.Location = new System.Drawing.Point(96, 18);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.PreventEnterBeep = true;
            this.txtOldPwd.Size = new System.Drawing.Size(237, 26);
            this.txtOldPwd.TabIndex = 0;
            this.txtOldPwd.WatermarkText = "请输入原密码若无则不填";
            // 
            // txtPwd
            // 
            // 
            // 
            // 
            this.txtPwd.Border.Class = "TextBoxBorder";
            this.txtPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPwd.Location = new System.Drawing.Point(96, 57);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.PreventEnterBeep = true;
            this.txtPwd.Size = new System.Drawing.Size(237, 26);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.WatermarkText = "请输入新密码";
            // 
            // txtPwdOk
            // 
            // 
            // 
            // 
            this.txtPwdOk.Border.Class = "TextBoxBorder";
            this.txtPwdOk.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPwdOk.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPwdOk.Location = new System.Drawing.Point(96, 101);
            this.txtPwdOk.Name = "txtPwdOk";
            this.txtPwdOk.PasswordChar = '*';
            this.txtPwdOk.PreventEnterBeep = true;
            this.txtPwdOk.Size = new System.Drawing.Size(237, 26);
            this.txtPwdOk.TabIndex = 2;
            this.txtPwdOk.WatermarkText = "请确认密码";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(12, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(78, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "原密码：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(12, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(78, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "新密码：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(2, 105);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(88, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "确认密码：";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(177, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(258, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormEditPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(211)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(355, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtPwdOk);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Name = "FormEditPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditPwd";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtOldPwd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPwd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPwdOk;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}