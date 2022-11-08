namespace App_OP.Record
{
    partial class FormRecordSample
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxMc = new System.Windows.Forms.TextBox();
            this.lblMc = new System.Windows.Forms.Label();
            this.btnOk = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.rbGr = new System.Windows.Forms.RadioButton();
            this.rbKs = new System.Windows.Forms.RadioButton();
            this.rbQy = new System.Windows.Forms.RadioButton();
            this.cbxSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvTemplateSample = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Selected = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Context = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxSharedToDept = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplateSample)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxMc
            // 
            this.tbxMc.Location = new System.Drawing.Point(75, 6);
            this.tbxMc.Name = "tbxMc";
            this.tbxMc.Size = new System.Drawing.Size(386, 23);
            this.tbxMc.TabIndex = 15;
            // 
            // lblMc
            // 
            this.lblMc.AutoSize = true;
            this.lblMc.Location = new System.Drawing.Point(4, 11);
            this.lblMc.Name = "lblMc";
            this.lblMc.Size = new System.Drawing.Size(77, 14);
            this.lblMc.TabIndex = 14;
            this.lblMc.Text = "范文名称：";
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnOk.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnOk.Name = "btnOk";
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOk,
            this.btnClose});
            this.bar1.Location = new System.Drawing.Point(0, 272);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(473, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 20;
            this.bar1.TabStop = false;
            this.bar1.Text = "barButtom";
            // 
            // rbGr
            // 
            this.rbGr.AutoSize = true;
            this.rbGr.Location = new System.Drawing.Point(221, 46);
            this.rbGr.Name = "rbGr";
            this.rbGr.Size = new System.Drawing.Size(53, 18);
            this.rbGr.TabIndex = 18;
            this.rbGr.TabStop = true;
            this.rbGr.Text = "个人";
            this.rbGr.UseVisualStyleBackColor = true;
            // 
            // rbKs
            // 
            this.rbKs.AutoSize = true;
            this.rbKs.Checked = true;
            this.rbKs.Location = new System.Drawing.Point(151, 46);
            this.rbKs.Name = "rbKs";
            this.rbKs.Size = new System.Drawing.Size(53, 18);
            this.rbKs.TabIndex = 17;
            this.rbKs.TabStop = true;
            this.rbKs.Text = "科室";
            this.rbKs.UseVisualStyleBackColor = true;
            // 
            // rbQy
            // 
            this.rbQy.AutoSize = true;
            this.rbQy.Location = new System.Drawing.Point(85, 46);
            this.rbQy.Name = "rbQy";
            this.rbQy.Size = new System.Drawing.Size(53, 18);
            this.rbQy.TabIndex = 16;
            this.rbQy.TabStop = true;
            this.rbQy.Text = "全院";
            this.rbQy.UseVisualStyleBackColor = true;
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            // 
            // 
            // 
            this.cbxSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxSelectAll.Location = new System.Drawing.Point(12, 245);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(56, 20);
            this.cbxSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxSelectAll.TabIndex = 22;
            this.cbxSelectAll.Text = "全选";
            this.cbxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // dgvTemplateSample
            // 
            this.dgvTemplateSample.AllowUserToAddRows = false;
            this.dgvTemplateSample.AllowUserToDeleteRows = false;
            this.dgvTemplateSample.AllowUserToResizeColumns = false;
            this.dgvTemplateSample.AllowUserToResizeRows = false;
            this.dgvTemplateSample.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTemplateSample.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTemplateSample.ColumnHeadersHeight = 25;
            this.dgvTemplateSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTemplateSample.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Context,
            this.ID,
            this.Type,
            this.XML});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTemplateSample.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTemplateSample.EnableHeadersVisualStyles = false;
            this.dgvTemplateSample.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvTemplateSample.Location = new System.Drawing.Point(12, 37);
            this.dgvTemplateSample.Name = "dgvTemplateSample";
            this.dgvTemplateSample.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTemplateSample.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTemplateSample.RowHeadersVisible = false;
            this.dgvTemplateSample.RowTemplate.Height = 23;
            this.dgvTemplateSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplateSample.Size = new System.Drawing.Size(449, 201);
            this.dgvTemplateSample.TabIndex = 23;
            this.dgvTemplateSample.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTempleSample_CellMouseClick);
            // 
            // Selected
            // 
            this.Selected.Checked = true;
            this.Selected.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Selected.CheckValue = null;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Selected.DefaultCellStyle = dataGridViewCellStyle6;
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Width = 45;
            // 
            // Context
            // 
            this.Context.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Context.HeaderText = "内容";
            this.Context.Name = "Context";
            this.Context.ReadOnly = true;
            this.Context.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Context.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // Type
            // 
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Visible = false;
            // 
            // XML
            // 
            this.XML.HeaderText = "格式化文本";
            this.XML.Name = "XML";
            this.XML.ReadOnly = true;
            this.XML.Visible = false;
            // 
            // cbxSharedToDept
            // 
            this.cbxSharedToDept.AutoSize = true;
            // 
            // 
            // 
            this.cbxSharedToDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxSharedToDept.Location = new System.Drawing.Point(82, 244);
            this.cbxSharedToDept.Name = "cbxSharedToDept";
            this.cbxSharedToDept.Size = new System.Drawing.Size(99, 20);
            this.cbxSharedToDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxSharedToDept.TabIndex = 24;
            this.cbxSharedToDept.Text = "共享到科室";
            // 
            // FormRecordSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 301);
            this.Controls.Add(this.cbxSharedToDept);
            this.Controls.Add(this.dgvTemplateSample);
            this.Controls.Add(this.cbxSelectAll);
            this.Controls.Add(this.tbxMc);
            this.Controls.Add(this.lblMc);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.rbGr);
            this.Controls.Add(this.rbKs);
            this.Controls.Add(this.rbQy);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRecordSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "范文";
            this.Shown += new System.EventHandler(this.FormRecordSample_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplateSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMc;
        private System.Windows.Forms.Label lblMc;
        private DevComponents.DotNetBar.ButtonItem btnOk;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.RadioButton rbGr;
        private System.Windows.Forms.RadioButton rbKs;
        private System.Windows.Forms.RadioButton rbQy;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxSelectAll;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTemplateSample;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Context;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn XML;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxSharedToDept;
    }
}