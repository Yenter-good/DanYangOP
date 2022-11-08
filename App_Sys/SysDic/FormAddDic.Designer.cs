namespace App_Sys
{
    partial class FormAddDic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDic));
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.input_Description = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.input_Search = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.input_Style = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(34, 110);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "描    述：";
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
            this.labelX2.Text = "类别名称：";
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
            this.labelX1.Text = "类别编码：";
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
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(179, 246);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // input_Description
            // 
            // 
            // 
            // 
            this.input_Description.Border.Class = "TextBoxBorder";
            this.input_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Description.Location = new System.Drawing.Point(118, 110);
            this.input_Description.Name = "input_Description";
            this.input_Description.PreventEnterBeep = true;
            this.input_Description.Size = new System.Drawing.Size(232, 21);
            this.input_Description.TabIndex = 10;
            this.input_Description.WatermarkText = "类别描述";
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
            this.input_Name.WatermarkText = "类别名称";
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
            this.input_Code.WatermarkText = "类别编码";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(34, 194);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 19;
            this.labelX4.Text = "检 索 码：";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(34, 152);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "加载样式：";
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
            this.input_Search.TabIndex = 17;
            this.input_Search.WatermarkText = "检索码";
            // 
            // input_Style
            // 
            this.input_Style.DisplayMember = "Text";
            this.input_Style.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.input_Style.FormattingEnabled = true;
            this.input_Style.ItemHeight = 15;
            this.input_Style.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.input_Style.Location = new System.Drawing.Point(118, 152);
            this.input_Style.Name = "input_Style";
            this.input_Style.Size = new System.Drawing.Size(232, 21);
            this.input_Style.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.input_Style.TabIndex = 21;
            this.input_Style.WatermarkText = "加载样式";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "可编辑";
            this.comboItem1.Value = "1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "不可编辑";
            this.comboItem2.Value = "0";
            // 
            // FormAddDic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(390, 282);
            this.Controls.Add(this.input_Style);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.input_Search);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.input_Description);
            this.Controls.Add(this.input_Name);
            this.Controls.Add(this.input_Code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddDic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddDic";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Description;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Name;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Code;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Search;
        private DevComponents.DotNetBar.Controls.ComboBoxEx input_Style;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}