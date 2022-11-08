namespace App_Template
{
    partial class FormAddRange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddRange));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.input_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.input_No = new DevComponents.Editors.IntegerInput();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.input_Search = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_RTypeCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gridDropDown = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.input_No)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDropDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(34, 68);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "Ãû    ³Æ£º";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(34, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "±à    Âë£º";
            // 
            // input_Name
            // 
            // 
            // 
            // 
            this.input_Name.Border.Class = "TextBoxBorder";
            this.input_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Name.Location = new System.Drawing.Point(118, 68);
            this.input_Name.Name = "input_Name";
            this.input_Name.PreventEnterBeep = true;
            this.input_Name.Size = new System.Drawing.Size(232, 21);
            this.input_Name.TabIndex = 9;
            this.input_Name.WatermarkText = "Ãû³Æ";
            // 
            // input_Code
            // 
            // 
            // 
            // 
            this.input_Code.Border.Class = "TextBoxBorder";
            this.input_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Code.Location = new System.Drawing.Point(118, 26);
            this.input_Code.Name = "input_Code";
            this.input_Code.PreventEnterBeep = true;
            this.input_Code.Size = new System.Drawing.Size(232, 21);
            this.input_Code.TabIndex = 8;
            this.input_Code.WatermarkText = "±àÂë";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(34, 150);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 19;
            this.labelX4.Text = "ÅÅ    Ðò£º";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(34, 108);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "ÉÏ¼¶±àÂë£º";
            // 
            // input_No
            // 
            // 
            // 
            // 
            this.input_No.BackgroundStyle.Class = "DateTimeInputBackground";
            this.input_No.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_No.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.input_No.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.input_No.Location = new System.Drawing.Point(118, 152);
            this.input_No.MinValue = 0;
            this.input_No.Name = "input_No";
            this.input_No.Size = new System.Drawing.Size(232, 21);
            this.input_No.TabIndex = 22;
            this.input_No.WatermarkText = "ÅÅÐò";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(275, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "È¡Ïû";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(179, 246);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "È·¶¨";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(34, 192);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 24;
            this.labelX6.Text = "¼ì Ë÷ Âë£º";
            // 
            // input_Search
            // 
            // 
            // 
            // 
            this.input_Search.Border.Class = "TextBoxBorder";
            this.input_Search.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Search.Location = new System.Drawing.Point(118, 194);
            this.input_Search.Name = "input_Search";
            this.input_Search.PreventEnterBeep = true;
            this.input_Search.Size = new System.Drawing.Size(232, 21);
            this.input_Search.TabIndex = 23;
            this.input_Search.WatermarkText = "¼ìË÷Âë";
            // 
            // input_RTypeCode
            // 
            // 
            // 
            // 
            this.input_RTypeCode.Border.Class = "TextBoxBorder";
            this.input_RTypeCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_RTypeCode.Location = new System.Drawing.Point(118, 110);
            this.input_RTypeCode.Name = "input_RTypeCode";
            this.input_RTypeCode.PreventEnterBeep = true;
            this.input_RTypeCode.Size = new System.Drawing.Size(232, 21);
            this.input_RTypeCode.TabIndex = 25;
            this.input_RTypeCode.WatermarkText = "ÉÏ¼¶±àÂë";
            this.input_RTypeCode.TextChanged += new System.EventHandler(this.input_DicCode_TextChanged);
            // 
            // gridDropDown
            // 
            this.gridDropDown.AllowUserToAddRows = false;
            this.gridDropDown.AllowUserToDeleteRows = false;
            this.gridDropDown.AllowUserToResizeRows = false;
            this.gridDropDown.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("ËÎÌå", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDropDown.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDropDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDropDown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.colName,
            this.Description,
            this.Style,
            this.Updater,
            this.UpdateDate,
            this.No,
            this.SearchCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ËÎÌå", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDropDown.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridDropDown.EnableHeadersVisualStyles = false;
            this.gridDropDown.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridDropDown.Location = new System.Drawing.Point(356, 107);
            this.gridDropDown.MultiSelect = false;
            this.gridDropDown.Name = "gridDropDown";
            this.gridDropDown.ReadOnly = true;
            this.gridDropDown.RowHeadersVisible = false;
            this.gridDropDown.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDropDown.RowTemplate.Height = 23;
            this.gridDropDown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDropDown.Size = new System.Drawing.Size(240, 150);
            this.gridDropDown.TabIndex = 26;
            this.gridDropDown.Visible = false;
            this.gridDropDown.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDropDown_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "´úÂë";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // Name
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Ãû³Æ";
            this.colName.Name = "Name";
            this.colName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "ÃèÊö";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            // 
            // Style
            // 
            this.Style.DataPropertyName = "Status";
            this.Style.HeaderText = "Status";
            this.Style.Name = "Style";
            this.Style.ReadOnly = true;
            this.Style.Visible = false;
            // 
            // Updater
            // 
            this.Updater.DataPropertyName = "Updater";
            this.Updater.HeaderText = "Updater";
            this.Updater.Name = "Updater";
            this.Updater.ReadOnly = true;
            this.Updater.Visible = false;
            // 
            // UpdateDate
            // 
            this.UpdateDate.DataPropertyName = "UpdateDate";
            this.UpdateDate.HeaderText = "UpdateDate";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Visible = false;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Visible = false;
            // 
            // SearchCode
            // 
            this.SearchCode.DataPropertyName = "SearchCode";
            this.SearchCode.HeaderText = "SearchCode";
            this.SearchCode.Name = "SearchCode";
            this.SearchCode.ReadOnly = true;
            this.SearchCode.Visible = false;
            // 
            // FormAddTPRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(390, 282);
            this.Controls.Add(this.gridDropDown);
            this.Controls.Add(this.input_RTypeCode);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.input_Search);
            this.Controls.Add(this.input_No);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.input_Name);
            this.Controls.Add(this.input_Code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÖµÓò¹ÜÀí";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormAddTPRange_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.input_No)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDropDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Name;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Code;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.IntegerInput input_No;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Search;
        private DevComponents.DotNetBar.Controls.TextBoxX input_RTypeCode;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridDropDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updater;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchCode;

    }
}