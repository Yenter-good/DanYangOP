namespace App_OP
{
    partial class KnowlageTree
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KnowlageTree));
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加到我的词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从我的词库删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodePerson = new DevComponents.AdvTree.Node();
            this.nodeAll = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = false;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.ContextMenuStrip = this.contextMenuStrip1;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodePerson,
            this.nodeAll});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(220, 531);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到我的词库ToolStripMenuItem,
            this.从我的词库删除ToolStripMenuItem,
            this.toolStripSeparator1,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 98);
            // 
            // 添加到我的词库ToolStripMenuItem
            // 
            this.添加到我的词库ToolStripMenuItem.Name = "添加到我的词库ToolStripMenuItem";
            this.添加到我的词库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到我的词库ToolStripMenuItem.Text = "添加到我的词库";
            this.添加到我的词库ToolStripMenuItem.Click += new System.EventHandler(this.添加到我的词库ToolStripMenuItem_Click);
            // 
            // 从我的词库删除ToolStripMenuItem
            // 
            this.从我的词库删除ToolStripMenuItem.Name = "从我的词库删除ToolStripMenuItem";
            this.从我的词库删除ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.从我的词库删除ToolStripMenuItem.Text = "从我的词库删除";
            this.从我的词库删除ToolStripMenuItem.Click += new System.EventHandler(this.从我的词库删除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // nodePerson
            // 
            this.nodePerson.Expanded = true;
            this.nodePerson.Image = ((System.Drawing.Image)(resources.GetObject("nodePerson.Image")));
            this.nodePerson.Name = "nodePerson";
            this.nodePerson.Text = "个人词库";
            // 
            // nodeAll
            // 
            this.nodeAll.Expanded = true;
            this.nodeAll.Image = ((System.Drawing.Image)(resources.GetObject("nodeAll.Image")));
            this.nodeAll.Name = "nodeAll";
            this.nodeAll.Text = "全部词库";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TextBox_16x16.png");
            // 
            // KnowlageTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advTree1);
            this.Name = "KnowlageTree";
            this.Size = new System.Drawing.Size(220, 531);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.Node nodePerson;
        private DevComponents.AdvTree.Node nodeAll;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加到我的词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从我的词库删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}
