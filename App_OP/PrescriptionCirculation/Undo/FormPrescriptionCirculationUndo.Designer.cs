
namespace App_OP.PrescriptionCirculation.Undo
{
    partial class FormPrescriptionCirculationUndo
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
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbxReason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(26, 29);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 20);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "撤销原因：";
            // 
            // tbxReason
            // 
            // 
            // 
            // 
            this.tbxReason.Border.Class = "TextBoxBorder";
            this.tbxReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxReason.Location = new System.Drawing.Point(111, 29);
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.PreventEnterBeep = true;
            this.tbxReason.Size = new System.Drawing.Size(262, 94);
            this.tbxReason.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(298, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "提交";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormPrescriptionCirculationUndo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 173);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxReason);
            this.Controls.Add(this.labelX3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrescriptionCirculationUndo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxReason;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}