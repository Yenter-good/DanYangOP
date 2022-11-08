namespace App_OP
{
    partial class FormDoctorInfo
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labPatientNum = new DevComponents.DotNetBar.LabelX();
            this.labDeptPatientsNum = new DevComponents.DotNetBar.LabelX();
            this.labPatientsProportion = new DevComponents.DotNetBar.LabelX();
            this.labRecordsNum = new DevComponents.DotNetBar.LabelX();
            this.labRecordsProportion = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labRecordsProportionM = new DevComponents.DotNetBar.LabelX();
            this.labRecordsNumM = new DevComponents.DotNetBar.LabelX();
            this.labPatientsProportionM = new DevComponents.DotNetBar.LabelX();
            this.labDeptPatientsNumM = new DevComponents.DotNetBar.LabelX();
            this.labPatientsNumM = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labRecordsProportion);
            this.groupPanel1.Controls.Add(this.labRecordsNum);
            this.groupPanel1.Controls.Add(this.labPatientsProportion);
            this.groupPanel1.Controls.Add(this.labDeptPatientsNum);
            this.groupPanel1.Controls.Add(this.labPatientNum);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(2, 8);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(596, 118);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "当日信息";
            // 
            // labPatientNum
            // 
            this.labPatientNum.AutoSize = true;
            this.labPatientNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labPatientNum.Location = new System.Drawing.Point(35, 12);
            this.labPatientNum.Name = "labPatientNum";
            this.labPatientNum.Size = new System.Drawing.Size(91, 18);
            this.labPatientNum.TabIndex = 0;
            this.labPatientNum.Text = "接诊人数：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labDeptPatientsNum
            // 
            this.labDeptPatientsNum.AutoSize = true;
            this.labDeptPatientsNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labDeptPatientsNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labDeptPatientsNum.Location = new System.Drawing.Point(235, 12);
            this.labDeptPatientsNum.Name = "labDeptPatientsNum";
            this.labDeptPatientsNum.Size = new System.Drawing.Size(105, 18);
            this.labDeptPatientsNum.TabIndex = 2;
            this.labDeptPatientsNum.Text = "科室总人数：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labPatientsProportion
            // 
            this.labPatientsProportion.AutoSize = true;
            this.labPatientsProportion.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labPatientsProportion.Location = new System.Drawing.Point(426, 12);
            this.labPatientsProportion.Name = "labPatientsProportion";
            this.labPatientsProportion.Size = new System.Drawing.Size(91, 18);
            this.labPatientsProportion.TabIndex = 2;
            this.labPatientsProportion.Text = "接诊比例：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labRecordsNum
            // 
            this.labRecordsNum.AutoSize = true;
            this.labRecordsNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labRecordsNum.Location = new System.Drawing.Point(35, 48);
            this.labRecordsNum.Name = "labRecordsNum";
            this.labRecordsNum.Size = new System.Drawing.Size(119, 18);
            this.labRecordsNum.TabIndex = 2;
            this.labRecordsNum.Text = "病历书写数量：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labRecordsProportion
            // 
            this.labRecordsProportion.AutoSize = true;
            this.labRecordsProportion.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labRecordsProportion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labRecordsProportion.Location = new System.Drawing.Point(235, 48);
            this.labRecordsProportion.Name = "labRecordsProportion";
            this.labRecordsProportion.Size = new System.Drawing.Size(119, 18);
            this.labRecordsProportion.TabIndex = 2;
            this.labRecordsProportion.Text = "病历书写比例：<font color=\"#ED1C24\">{0}</font>";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labRecordsProportionM);
            this.groupPanel2.Controls.Add(this.labRecordsNumM);
            this.groupPanel2.Controls.Add(this.labPatientsProportionM);
            this.groupPanel2.Controls.Add(this.labDeptPatientsNumM);
            this.groupPanel2.Controls.Add(this.labPatientsNumM);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(1, 134);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(596, 118);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "本月信息";
            // 
            // labRecordsProportionM
            // 
            this.labRecordsProportionM.AutoSize = true;
            this.labRecordsProportionM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labRecordsProportionM.Location = new System.Drawing.Point(235, 48);
            this.labRecordsProportionM.Name = "labRecordsProportionM";
            this.labRecordsProportionM.Size = new System.Drawing.Size(119, 18);
            this.labRecordsProportionM.TabIndex = 2;
            this.labRecordsProportionM.Text = "病历书写比例：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labRecordsNumM
            // 
            this.labRecordsNumM.AutoSize = true;
            this.labRecordsNumM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labRecordsNumM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labRecordsNumM.Location = new System.Drawing.Point(35, 48);
            this.labRecordsNumM.Name = "labRecordsNumM";
            this.labRecordsNumM.Size = new System.Drawing.Size(119, 18);
            this.labRecordsNumM.TabIndex = 2;
            this.labRecordsNumM.Text = "病历书写数量：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labPatientsProportionM
            // 
            this.labPatientsProportionM.AutoSize = true;
            this.labPatientsProportionM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labPatientsProportionM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labPatientsProportionM.Location = new System.Drawing.Point(426, 12);
            this.labPatientsProportionM.Name = "labPatientsProportionM";
            this.labPatientsProportionM.Size = new System.Drawing.Size(91, 18);
            this.labPatientsProportionM.TabIndex = 2;
            this.labPatientsProportionM.Text = "接诊比例：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labDeptPatientsNumM
            // 
            this.labDeptPatientsNumM.AutoSize = true;
            this.labDeptPatientsNumM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labDeptPatientsNumM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labDeptPatientsNumM.Location = new System.Drawing.Point(235, 12);
            this.labDeptPatientsNumM.Name = "labDeptPatientsNumM";
            this.labDeptPatientsNumM.Size = new System.Drawing.Size(105, 18);
            this.labDeptPatientsNumM.TabIndex = 2;
            this.labDeptPatientsNumM.Text = "科室总人数：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labPatientsNumM
            // 
            this.labPatientsNumM.AutoSize = true;
            this.labPatientsNumM.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labPatientsNumM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labPatientsNumM.Location = new System.Drawing.Point(35, 12);
            this.labPatientsNumM.Name = "labPatientsNumM";
            this.labPatientsNumM.Size = new System.Drawing.Size(91, 18);
            this.labPatientsNumM.TabIndex = 0;
            this.labPatientsNumM.Text = "接诊人数：<font color=\"#ED1C24\">{0}</font>";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(39, 263);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(63, 18);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "注意：<font color=\"#ED1C24\">{0}</font>";
            this.labelX1.Visible = false;
            // 
            // FormDoctorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 293);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoctorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医生信息";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labRecordsProportion;
        private DevComponents.DotNetBar.LabelX labRecordsNum;
        private DevComponents.DotNetBar.LabelX labPatientsProportion;
        private DevComponents.DotNetBar.LabelX labDeptPatientsNum;
        private DevComponents.DotNetBar.LabelX labPatientNum;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labRecordsProportionM;
        private DevComponents.DotNetBar.LabelX labRecordsNumM;
        private DevComponents.DotNetBar.LabelX labPatientsProportionM;
        private DevComponents.DotNetBar.LabelX labDeptPatientsNumM;
        private DevComponents.DotNetBar.LabelX labPatientsNumM;
    }
}