namespace App_Template
{
    partial class MainTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTemplate));
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.templateDesignControl1 = new App_Template.TemplateDesignControl();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
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
            this.advTree1.ContextMenuStrip = this.contextMenuStrip1;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Left;
            this.advTree1.ImageList = this.imageList1;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 27);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(232, 569);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 1;
            this.advTree1.Text = "advTree1";
            this.advTree1.AfterCellEdit += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_AfterCellEdit);
            this.advTree1.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加模板ToolStripMenuItem,
            this.修改模板ToolStripMenuItem,
            this.删除模板ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
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
            this.node1.Text = "门诊模板";
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
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem4});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1359, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 14;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "增加模板";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "修改模板";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "删除模板";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "增加模板";
            // 
            // templateDesignControl1
            // 
            this.templateDesignControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateDesignControl1.InsertVisible = true;
            this.templateDesignControl1.Location = new System.Drawing.Point(232, 27);
            this.templateDesignControl1.Name = "templateDesignControl1";
            this.templateDesignControl1.Size = new System.Drawing.Size(1127, 569);
            this.templateDesignControl1.TabIndex = 0;
            this.templateDesignControl1.btnSave_Click += new System.EventHandler(this.templateDesignControl1_btnSave_Click);
            // 
            // MainTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 596);
            this.Controls.Add(this.templateDesignControl1);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "MainTemplate";
            this.Text = "MainTemplate";
            this.Shown += new System.EventHandler(this.MainTemplate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除模板ToolStripMenuItem;
        private TemplateDesignControl templateDesignControl1;



    }
}