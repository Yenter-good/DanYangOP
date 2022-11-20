
namespace App_OP.PrescriptionCirculation.TakeDrugResult
{
    partial class FormTakeDrugResultPreview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrescription = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManuNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAprvNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescription)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrescription
            // 
            this.dgvPrescription.AllowUserToAddRows = false;
            this.dgvPrescription.AllowUserToDeleteRows = false;
            this.dgvPrescription.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrescription.ColumnHeadersHeight = 30;
            this.dgvPrescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrescription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colSpec,
            this.colCount,
            this.colManuNum,
            this.colPrdrName,
            this.colBchNo,
            this.colAprvNo,
            this.colWhite});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescription.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvPrescription.Location = new System.Drawing.Point(0, 0);
            this.dgvPrescription.Name = "dgvPrescription";
            this.dgvPrescription.ReadOnly = true;
            this.dgvPrescription.RowHeadersVisible = false;
            this.dgvPrescription.RowTemplate.Height = 23;
            this.dgvPrescription.Size = new System.Drawing.Size(1033, 450);
            this.dgvPrescription.TabIndex = 4;
            // 
            // colName
            // 
            this.colName.HeaderText = "药品名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colSpec
            // 
            this.colSpec.HeaderText = "规格";
            this.colSpec.Name = "colSpec";
            this.colSpec.ReadOnly = true;
            this.colSpec.Width = 150;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 70;
            // 
            // colManuNum
            // 
            this.colManuNum.HeaderText = "生产批号";
            this.colManuNum.Name = "colManuNum";
            this.colManuNum.ReadOnly = true;
            this.colManuNum.Width = 120;
            // 
            // colPrdrName
            // 
            this.colPrdrName.HeaderText = "生产厂家";
            this.colPrdrName.Name = "colPrdrName";
            this.colPrdrName.ReadOnly = true;
            this.colPrdrName.Width = 150;
            // 
            // colBchNo
            // 
            this.colBchNo.HeaderText = "批次号";
            this.colBchNo.Name = "colBchNo";
            this.colBchNo.ReadOnly = true;
            // 
            // colAprvNo
            // 
            this.colAprvNo.HeaderText = "批准文号";
            this.colAprvNo.Name = "colAprvNo";
            this.colAprvNo.ReadOnly = true;
            this.colAprvNo.Width = 120;
            // 
            // colWhite
            // 
            this.colWhite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWhite.HeaderText = "";
            this.colWhite.Name = "colWhite";
            this.colWhite.ReadOnly = true;
            // 
            // FormTakeDrugResultPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 450);
            this.Controls.Add(this.dgvPrescription);
            this.DoubleBuffered = true;
            this.Name = "FormTakeDrugResultPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "双流转处方预览";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPrescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManuNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAprvNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhite;
    }
}