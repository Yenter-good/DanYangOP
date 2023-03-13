
namespace App_OP.Record
{
    partial class FormRecordMTL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordMTL));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnPacsResult = new DevComponents.DotNetBar.ButtonItem();
            this.biEcgQueryReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnSpecialSymbol = new DevComponents.DotNetBar.ButtonItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnHistory = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem5,
            this.buttonItem1,
            this.buttonItem3,
            this.buttonItem4,
            this.btnPrint,
            this.btnHistory,
            this.buttonItem2,
            this.btnPacsResult,
            this.biEcgQueryReport,
            this.btnSpecialSymbol});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1019, 30);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 13;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "开始编辑";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "保存病历";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "提交病历";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "删除病历";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "打印病历";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "检验结果查询";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // btnPacsResult
            // 
            this.btnPacsResult.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPacsResult.Image = ((System.Drawing.Image)(resources.GetObject("btnPacsResult.Image")));
            this.btnPacsResult.Name = "btnPacsResult";
            this.btnPacsResult.Text = "检查结果查询";
            this.btnPacsResult.Click += new System.EventHandler(this.btnPacsResult_Click);
            // 
            // biEcgQueryReport
            // 
            this.biEcgQueryReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biEcgQueryReport.Image = ((System.Drawing.Image)(resources.GetObject("biEcgQueryReport.Image")));
            this.biEcgQueryReport.Name = "biEcgQueryReport";
            this.biEcgQueryReport.Text = "心电报告查询";
            this.biEcgQueryReport.Visible = false;
            this.biEcgQueryReport.Click += new System.EventHandler(this.biEcgQueryReport_Click);
            // 
            // btnSpecialSymbol
            // 
            this.btnSpecialSymbol.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSpecialSymbol.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecialSymbol.Image")));
            this.btnSpecialSymbol.Name = "btnSpecialSymbol";
            this.btnSpecialSymbol.Text = "特殊符号";
            this.btnSpecialSymbol.Click += new System.EventHandler(this.btnSpecialSymbol_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 30);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1019, 513);
            this.panelMain.TabIndex = 14;
            // 
            // btnHistory
            // 
            this.btnHistory.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Text = "数据调阅";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // FormRecordMTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 543);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FormRecordMTL";
            this.Text = "FormRecordMTL";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem btnPacsResult;
        private DevComponents.DotNetBar.ButtonItem biEcgQueryReport;
        private DevComponents.DotNetBar.ButtonItem btnSpecialSymbol;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private System.Windows.Forms.Panel panelMain;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem btnHistory;
    }
}