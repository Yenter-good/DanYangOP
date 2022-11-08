namespace App_Sys
{
    partial class FormModuleCategoryEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModuleCategoryEdit));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.input_Text = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.input_No = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.warningBox1 = new DevComponents.DotNetBar.Controls.WarningBox();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(18, 44);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 25);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "分类名称";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_Text
            // 
            // 
            // 
            // 
            this.input_Text.Border.Class = "TextBoxBorder";
            this.input_Text.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_Text.Location = new System.Drawing.Point(104, 43);
            this.input_Text.Multiline = true;
            this.input_Text.Name = "input_Text";
            this.input_Text.PreventEnterBeep = true;
            this.input_Text.Size = new System.Drawing.Size(242, 28);
            this.input_Text.TabIndex = 0;
            this.input_Text.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(170, 158);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(18, 78);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 25);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "排序";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // input_No
            // 
            // 
            // 
            // 
            this.input_No.Border.Class = "TextBoxBorder";
            this.input_No.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.input_No.Location = new System.Drawing.Point(104, 77);
            this.input_No.Multiline = true;
            this.input_No.Name = "input_No";
            this.input_No.PreventEnterBeep = true;
            this.input_No.Size = new System.Drawing.Size(242, 28);
            this.input_No.TabIndex = 1;
            this.input_No.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // warningBox1
            // 
            this.warningBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.warningBox1.CloseButtonVisible = false;
            this.warningBox1.ColorScheme = DevComponents.DotNetBar.Controls.eWarningBoxColorScheme.Red;
            this.warningBox1.Image = ((System.Drawing.Image)(resources.GetObject("warningBox1.Image")));
            this.warningBox1.Location = new System.Drawing.Point(104, 111);
            this.warningBox1.Name = "warningBox1";
            this.warningBox1.OptionsButtonVisible = false;
            this.warningBox1.Size = new System.Drawing.Size(242, 41);
            this.warningBox1.TabIndex = 3;
            this.warningBox1.Text = "<b>Warning Box</b> control with <i>text-markup</i> support.";
            this.warningBox1.Visible = false;
            // 
            // FormModuleCategoryEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(415, 207);
            this.Controls.Add(this.warningBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.input_No);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.input_Text);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModuleCategoryEdit";
            this.RenderFormIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置分类";
            this.TitleText = "设置分类";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormModuleCategory_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX input_Text;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX input_No;
        private DevComponents.DotNetBar.Controls.WarningBox warningBox1;
    }
}