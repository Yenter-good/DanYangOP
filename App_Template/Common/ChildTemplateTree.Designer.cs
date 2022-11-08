namespace App_Template.Common
{
    partial class ChildTemplateTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildTemplateTree));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.node4 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TextBox_16x16.png");
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Image = ((System.Drawing.Image)(resources.GetObject("node1.Image")));
            this.node1.Name = "node1";
            this.node1.Text = "门诊子模板";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Image = ((System.Drawing.Image)(resources.GetObject("node2.Image")));
            this.node2.Name = "node2";
            this.node2.Text = "门诊子模板";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Image = ((System.Drawing.Image)(resources.GetObject("node3.Image")));
            this.node3.Name = "node3";
            this.node3.Text = "门诊子模板";
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
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.advTree1.ForeColor = System.Drawing.Color.Black;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(185, 427);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.AfterCellEdit += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_AfterCellEdit);
            this.advTree1.NodeDragStart += new System.EventHandler(this.advTree1_NodeDragStart);
            this.advTree1.NodeMouseDown += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeMouseDown);
            this.advTree1.NodeMouseUp += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeMouseUp);
            this.advTree1.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加组ToolStripMenuItem,
            this.增加模板ToolStripMenuItem,
            this.修改模板ToolStripMenuItem,
            this.删除模板ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 增加组ToolStripMenuItem
            // 
            this.增加组ToolStripMenuItem.Name = "增加组ToolStripMenuItem";
            this.增加组ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加组ToolStripMenuItem.Text = "增加组";
            this.增加组ToolStripMenuItem.Click += new System.EventHandler(this.增加组ToolStripMenuItem_Click);
            // 
            // 增加模板ToolStripMenuItem
            // 
            this.增加模板ToolStripMenuItem.Name = "增加模板ToolStripMenuItem";
            this.增加模板ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加模板ToolStripMenuItem.Text = "增加模板";
            this.增加模板ToolStripMenuItem.Click += new System.EventHandler(this.增加模板ToolStripMenuItem_Click);
            // 
            // 修改模板ToolStripMenuItem
            // 
            this.修改模板ToolStripMenuItem.Name = "修改模板ToolStripMenuItem";
            this.修改模板ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改模板ToolStripMenuItem.Text = "修改模板";
            this.修改模板ToolStripMenuItem.Click += new System.EventHandler(this.修改模板ToolStripMenuItem_Click);
            // 
            // 删除模板ToolStripMenuItem
            // 
            this.删除模板ToolStripMenuItem.Name = "删除模板ToolStripMenuItem";
            this.删除模板ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除模板ToolStripMenuItem.Text = "删除模板";
            this.删除模板ToolStripMenuItem.Click += new System.EventHandler(this.删除模板ToolStripMenuItem_Click);
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Image = ((System.Drawing.Image)(resources.GetObject("node4.Image")));
            this.node4.Name = "node4";
            this.node4.Text = "门诊子模板";
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
            // ChildTemplateTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advTree1);
            this.Name = "ChildTemplateTree";
            this.Size = new System.Drawing.Size(185, 427);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除模板ToolStripMenuItem;
    }
}
