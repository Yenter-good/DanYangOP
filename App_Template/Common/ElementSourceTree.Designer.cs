namespace App_Template.Common
{
    partial class ElementSourceTree
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
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.node10 = new DevComponents.AdvTree.Node();
            this.node11 = new DevComponents.AdvTree.Node();
            this.node12 = new DevComponents.AdvTree.Node();
            this.node13 = new DevComponents.AdvTree.Node();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(191, 478);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.node1.Text = "数据源";
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
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node3,
            this.node4,
            this.node5,
            this.node6,
            this.node7,
            this.node8,
            this.node9,
            this.node10,
            this.node11,
            this.node12,
            this.node13});
            this.node2.Text = "门诊病历";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Text = "主诉";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Text = "现病史";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "过敏史";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Text = "处理";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.Text = "辅助检查结果";
            // 
            // node8
            // 
            this.node8.Expanded = true;
            this.node8.Name = "node8";
            this.node8.Text = "家族史";
            // 
            // node9
            // 
            this.node9.Expanded = true;
            this.node9.Name = "node9";
            this.node9.Text = "婚育史";
            // 
            // node10
            // 
            this.node10.Expanded = true;
            this.node10.Name = "node10";
            this.node10.Text = "既往史";
            // 
            // node11
            // 
            this.node11.Expanded = true;
            this.node11.Name = "node11";
            this.node11.Text = "个人史";
            // 
            // node12
            // 
            this.node12.Expanded = true;
            this.node12.Name = "node12";
            this.node12.Text = "体格检查";
            // 
            // node13
            // 
            this.node13.Expanded = true;
            this.node13.Name = "node13";
            this.node13.Text = "吸烟史";
            // 
            // ElementSourceTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advTree1);
            this.Name = "ElementSourceTree";
            this.Size = new System.Drawing.Size(191, 478);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.Node node10;
        private DevComponents.AdvTree.Node node11;
        private DevComponents.AdvTree.Node node12;
        private DevComponents.AdvTree.Node node13;
    }
}
