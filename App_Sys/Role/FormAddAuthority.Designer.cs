namespace App_Sys
{
    partial class FormAddAuthority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddAuthority));
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.treeAuthority = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.listUserParameter = new DevComponents.DotNetBar.ListBoxAdv();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.treeAuthority)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelX3.Location = new System.Drawing.Point(12, 22);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(206, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "请点击选择或取消角色参数";
            // 
            // treeAuthority
            // 
            this.treeAuthority.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeAuthority.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeAuthority.BackgroundStyle.Class = "TreeBorderKey";
            this.treeAuthority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeAuthority.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeAuthority.Location = new System.Drawing.Point(17, 65);
            this.treeAuthority.Name = "treeAuthority";
            this.treeAuthority.NodesConnector = this.nodeConnector1;
            this.treeAuthority.NodeStyle = this.elementStyle1;
            this.treeAuthority.PathSeparator = ";";
            this.treeAuthority.Size = new System.Drawing.Size(253, 344);
            this.treeAuthority.Styles.Add(this.elementStyle1);
            this.treeAuthority.TabIndex = 15;
            this.treeAuthority.Text = "advTree1";
            this.treeAuthority.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treeDept_NodeClick);
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
            // listUserParameter
            // 
            this.listUserParameter.AutoScroll = true;
            // 
            // 
            // 
            this.listUserParameter.BackgroundStyle.Class = "ListBoxAdv";
            this.listUserParameter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listUserParameter.ContainerControlProcessDialogKey = true;
            this.listUserParameter.DisplayMember = "Name";
            this.listUserParameter.DragDropSupport = true;
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.ItemTemplateBindings.Add(new DevComponents.DotNetBar.BindingDef("Text", "Name"));
            this.listUserParameter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.listUserParameter.Location = new System.Drawing.Point(288, 65);
            this.listUserParameter.Name = "listUserParameter";
            this.listUserParameter.Size = new System.Drawing.Size(207, 344);
            this.listUserParameter.TabIndex = 16;
            this.listUserParameter.ValueMember = "Code";
            this.listUserParameter.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAdv1_ItemDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(414, 422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(310, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // FormAddAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 459);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.treeAuthority);
            this.Controls.Add(this.listUserParameter);
            this.Controls.Add(this.labelX3);
            this.Name = "FormAddAuthority";
            this.Text = "FormAddAuthority";
            this.Shown += new System.EventHandler(this.FormAddUserDept_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.treeAuthority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.AdvTree.AdvTree treeAuthority;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ListBoxAdv listUserParameter;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
    }
}