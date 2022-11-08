namespace App_OP.Record
{
    partial class FormHistoryRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistoryRecord));
            this.txWriterControl1 = new CIS.DCWriter.Controls.TxWriterControl();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // txWriterControl1
            // 
            this.txWriterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            this.txWriterControl1.Location = new System.Drawing.Point(0, 30);
            this.txWriterControl1.Name = "txWriterControl1";
            this.txWriterControl1.Size = new System.Drawing.Size(719, 747);
            this.txWriterControl1.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrint,
            this.btnImport});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(719, 30);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "直接打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnImport
            // 
            this.btnImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Name = "btnImport";
            this.btnImport.Text = "导入到现有病历";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormHistoryRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 777);
            this.Controls.Add(this.txWriterControl1);
            this.Controls.Add(this.bar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHistoryRecord";
            this.Text = "历史病历";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FormHistoryRecord_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CIS.DCWriter.Controls.TxWriterControl txWriterControl1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnImport;
    }
}