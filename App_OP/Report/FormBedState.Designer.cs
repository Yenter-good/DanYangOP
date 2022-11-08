
namespace App_OP.Report
{
    partial class FormBedState
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
            this.dgvBed = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colNurseStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBedState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbxDeptName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBed)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBed
            // 
            this.dgvBed.AllowUserToAddRows = false;
            this.dgvBed.AllowUserToDeleteRows = false;
            this.dgvBed.BackgroundColor = System.Drawing.Color.White;
            this.dgvBed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBed.ColumnHeadersHeight = 30;
            this.dgvBed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNurseStation,
            this.colBedNo,
            this.colBedState,
            this.colWhite});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBed.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBed.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBed.Location = new System.Drawing.Point(0, 100);
            this.dgvBed.Name = "dgvBed";
            this.dgvBed.ReadOnly = true;
            this.dgvBed.RowHeadersVisible = false;
            this.dgvBed.RowTemplate.Height = 23;
            this.dgvBed.Size = new System.Drawing.Size(662, 402);
            this.dgvBed.TabIndex = 0;
            // 
            // colNurseStation
            // 
            this.colNurseStation.DataPropertyName = "NurseStationName";
            this.colNurseStation.HeaderText = "病区";
            this.colNurseStation.Name = "colNurseStation";
            this.colNurseStation.ReadOnly = true;
            this.colNurseStation.Width = 200;
            // 
            // colBedNo
            // 
            this.colBedNo.DataPropertyName = "BedNo";
            this.colBedNo.HeaderText = "床号";
            this.colBedNo.Name = "colBedNo";
            this.colBedNo.ReadOnly = true;
            this.colBedNo.Width = 200;
            // 
            // colBedState
            // 
            this.colBedState.DataPropertyName = "BedState";
            this.colBedState.HeaderText = "状态";
            this.colBedState.Name = "colBedState";
            this.colBedState.ReadOnly = true;
            this.colBedState.Width = 200;
            // 
            // colWhite
            // 
            this.colWhite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWhite.HeaderText = "";
            this.colWhite.Name = "colWhite";
            this.colWhite.ReadOnly = true;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(20, 65);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "总床位数：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(201, 65);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "空闲床位数：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(413, 65);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(94, 20);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "占用床位数：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(20, 27);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(79, 20);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "临床科室：";
            // 
            // cbxDeptName
            // 
            this.cbxDeptName.DisplayMember = "Text";
            this.cbxDeptName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeptName.FormattingEnabled = true;
            this.cbxDeptName.ItemHeight = 18;
            this.cbxDeptName.Location = new System.Drawing.Point(105, 24);
            this.cbxDeptName.Name = "cbxDeptName";
            this.cbxDeptName.Size = new System.Drawing.Size(190, 24);
            this.cbxDeptName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxDeptName.TabIndex = 2;
            this.cbxDeptName.SelectedIndexChanged += new System.EventHandler(this.cbxDeptName_SelectedIndexChanged);
            // 
            // FormBedState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 502);
            this.Controls.Add(this.cbxDeptName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgvBed);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBedState";
            this.Padding = new System.Windows.Forms.Padding(0, 100, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "床位状态";
            this.Shown += new System.EventHandler(this.FormBedState_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBed;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNurseStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBedState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhite;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxDeptName;
    }
}