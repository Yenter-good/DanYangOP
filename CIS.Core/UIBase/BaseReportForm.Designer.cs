namespace CIS.Core
{
    partial class BaseReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseReportForm));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintAndSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.txWriterControl1 = new CIS.DCWriter.Controls.TxWriterControl();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSave,
            this.btnPrintAndSave,
            this.btnPrint});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(800, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrintAndSave
            // 
            this.btnPrintAndSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrintAndSave.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAndSave.Image")));
            this.btnPrintAndSave.Name = "btnPrintAndSave";
            this.btnPrintAndSave.Text = "保存并打印";
            this.btnPrintAndSave.Click += new System.EventHandler(this.btnPrintAndSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "直接打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txWriterControl1
            // 
            this.txWriterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txWriterControl1.Location = new System.Drawing.Point(0, 27);
            this.txWriterControl1.Name = "txWriterControl1";
            this.txWriterControl1.Size = new System.Drawing.Size(800, 537);
            this.txWriterControl1.TabIndex = 2;
            // 
            // BaseReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.txWriterControl1);
            this.Controls.Add(this.bar1);
            this.Name = "BaseReportForm";
            this.Text = "BaseReportForm";
            this.Shown += new System.EventHandler(this.BaseReportForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnPrintAndSave;
        private DCWriter.Controls.TxWriterControl txWriterControl1;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
    }
}