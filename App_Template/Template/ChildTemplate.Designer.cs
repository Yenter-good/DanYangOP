namespace App_Template
{
    partial class ChildTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildTemplate));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAddFolder = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.templateDesignControl1 = new App_Template.TemplateDesignControl();
            this.childTemplateTree1 = new App_Template.Common.ChildTemplateTree();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TextBox_16x16.png");
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddFolder,
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem4});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1290, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 17;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFolder.Image")));
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Text = "增加组";
            this.btnAddFolder.Click += new System.EventHandler(this.buttonItem5_Click);
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
            this.templateDesignControl1.Location = new System.Drawing.Point(233, 27);
            this.templateDesignControl1.Name = "templateDesignControl1";
            this.templateDesignControl1.Size = new System.Drawing.Size(1057, 486);
            this.templateDesignControl1.TabIndex = 15;
            this.templateDesignControl1.btnSave_Click += new System.EventHandler(this.templateDesignControl1_btnSave_Click);
            // 
            // childTemplateTree1
            // 
            this.childTemplateTree1.Dock = System.Windows.Forms.DockStyle.Left;
            this.childTemplateTree1.Location = new System.Drawing.Point(0, 27);
            this.childTemplateTree1.Name = "childTemplateTree1";
            this.childTemplateTree1.Size = new System.Drawing.Size(233, 486);
            this.childTemplateTree1.TabIndex = 18;
            this.childTemplateTree1.AfterCellEdit += new DevComponents.AdvTree.CellEditEventHandler(this.advTree1_AfterCellEdit);
            this.childTemplateTree1.NodeMouseDown += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.childTemplateTree1_NodeMouseDown);
            // 
            // ChildTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 513);
            this.Controls.Add(this.templateDesignControl1);
            this.Controls.Add(this.childTemplateTree1);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "ChildTemplate";
            this.Text = "ChildTemplate";
            this.Shown += new System.EventHandler(this.ChildTemplate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private TemplateDesignControl templateDesignControl1;
        private DevComponents.DotNetBar.ButtonItem btnAddFolder;
        private Common.ChildTemplateTree childTemplateTree1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
    }
}