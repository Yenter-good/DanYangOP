namespace CIS.ControlLib.Controls
{
    partial class FilterList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxAdv1 = new DevComponents.DotNetBar.ListBoxAdv();
            this.textBoxX1 = new CIS.ControlLib.Controls.SuperText();
            this.SuspendLayout();
            // 
            // listBoxAdv1
            // 
            this.listBoxAdv1.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv1.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv1.ContainerControlProcessDialogKey = true;
            this.listBoxAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAdv1.DragDropSupport = true;
            this.listBoxAdv1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.listBoxAdv1.Location = new System.Drawing.Point(0, 21);
            this.listBoxAdv1.Name = "listBoxAdv1";
            this.listBoxAdv1.Size = new System.Drawing.Size(212, 309);
            this.listBoxAdv1.TabIndex = 1;
            this.listBoxAdv1.Text = "listBoxAdv1";
            this.listBoxAdv1.ItemClick += new System.EventHandler(this.listBoxAdv1_ItemClick);
            this.listBoxAdv1.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAdv1_ItemDoubleClick);
            // 
            // textBoxX1
            // 
            this.textBoxX1.DelayTime = 200;
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxX1.Location = new System.Drawing.Point(0, 0);
            this.textBoxX1.MarkString = "在此输入内容来过滤一下列表";
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(212, 21);
            this.textBoxX1.TabIndex = 0;
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            // 
            // FilterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxAdv1);
            this.Controls.Add(this.textBoxX1);
            this.Name = "FilterList";
            this.Size = new System.Drawing.Size(212, 330);
            this.Load += new System.EventHandler(this.FilterList_Load);
            this.VisibleChanged += new System.EventHandler(this.FilterList_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SuperText textBoxX1;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv1;
    }
}
