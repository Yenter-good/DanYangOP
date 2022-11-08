namespace CIS.Core
{
    partial class NavgateDialogBase
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
            this.btnPre = new DevComponents.DotNetBar.LabelX();
            this.btnNext = new DevComponents.DotNetBar.LabelX();
            this.inputGO = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.inputGO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPre
            // 
            // 
            // 
            // 
            this.btnPre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnPre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPre.Location = new System.Drawing.Point(10, 243);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(23, 23);
            this.btnPre.Symbol = "";
            this.btnPre.SymbolSize = 12F;
            this.btnPre.TabIndex = 2;
            // 
            // btnNext
            // 
            // 
            // 
            // 
            this.btnNext.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Location = new System.Drawing.Point(71, 243);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.Symbol = "";
            this.btnNext.SymbolSize = 12F;
            this.btnNext.TabIndex = 3;
            // 
            // inputGO
            // 
            // 
            // 
            // 
            this.inputGO.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inputGO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inputGO.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inputGO.Location = new System.Drawing.Point(31, 243);
            this.inputGO.Name = "inputGO";
            this.inputGO.Size = new System.Drawing.Size(39, 23);
            this.inputGO.TabIndex = 5;
            // 
            // NavgateDialogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 286);
            this.Controls.Add(this.inputGO);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Name = "NavgateDialogBase";
            this.Text = "NavgateDialogBase";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnPre, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.inputGO, 0);
            ((System.ComponentModel.ISupportInitialize)(this.inputGO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevComponents.DotNetBar.LabelX btnPre;
        protected DevComponents.DotNetBar.LabelX btnNext;
        protected DevComponents.Editors.IntegerInput inputGO;

    }
}