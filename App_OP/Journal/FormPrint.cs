using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.ControlLib.Controls;

namespace App_OP
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        List<OP_Prescription_Detail> Prescription = new List<OP_Prescription_Detail>();
        myTab tab = new myTab();
        PopupControlHost pop = null;
        DevComponents.DotNetBar.SuperGrid.GridCell SelectCell;

        private void InitUI()
        {
            List<IView_Dept> list = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1).ToList();
            this.comboBoxEx1.ValueMember = "Code";
            this.comboBoxEx1.DisplayMember = "Name";
            this.comboBoxEx1.DataSource = list;

            this.dgvJournal.PrimaryGrid.AutoGenerateColumns = false;
            this.StartTime.Value = DateTime.Now.AddDays(-1);
            this.EndTime.Value = DateTime.Now;
        }

        private void FormPrint_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //List<OP_Journal> list = DBHelper.CIS.From<OP_Journal>().Where(p => p.DeptCode == this.comboBoxEx1.SelectedValue.ToString() && p.UpdateDate > this.StartTime.Value && p.UpdateDate < this.EndTime.Value).ToList();
            //this.dgvJournal.PrimaryGrid.DataSource = list;
            //this.labelX1.Text = "总接诊人数：" + list.Count + "人";
            //this.dgvJournal.PrimaryGrid.ClearSelectedCells();
            //if (list.Count < 1) return;
            //string[] OutpatientNo = list.Select(p => p.OutpatientNo).ToArray();
            //for (int i = 0; i < OutpatientNo.Length; i++)
            //    OutpatientNo[i] = "'" + OutpatientNo[i] + "'";

            //Prescription = DBHelper.CIS.FromSql(string.Format("SELECT * FROM OP_Prescription_Detail WHERE TreatmentNo IN ({0})", string.Join(",", OutpatientNo))).ToList<OP_Prescription_Detail>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pop.Opacity += 0.1;
            if (pop.Opacity >= 1)
                this.timer1.Enabled = false;
        }

        private void dgvJournal_CellMouseEnter(object sender, DevComponents.DotNetBar.SuperGrid.GridCellEventArgs e)
        {

            if (e.GridCell.GridRow.Index < 0) return;
            if (pop == null)
            {
                pop = new PopupControlHost(tab);
                pop.CanResize = true;
            }
            if (e.GridCell.ColumnIndex != 4)
            {
                pop.Close();
                return;
            }
            if (e.GridCell == SelectCell)
                return;
            tab.XYDataSource = Prescription.Where(p => p.TreatmentNo == e.GridCell.GridRow.Cells["col_OutpatientNo"].Value.ToString() && (p.ItemType == "1" || p.ItemType == "2")).ToList();
            tab.CYDataSource = Prescription.Where(p => p.TreatmentNo == e.GridCell.GridRow.Cells["col_OutpatientNo"].Value.ToString() && p.ItemType == "3").ToList();
            tab.ZLDataSource = Prescription.Where(p => p.TreatmentNo == e.GridCell.GridRow.Cells["col_OutpatientNo"].Value.ToString() && p.ItemType == "4").ToList();
            pop.Opacity = 0;
            this.timer1.Enabled = true;
            Point point = this.dgvJournal.PointToScreen(new Point(e.GridCell.Bounds.Right - e.GridCell.Bounds.Width / 2, e.GridCell.Bounds.Bottom));
            pop.Show(point);
            SelectCell = e.GridCell;
        }
    }
}
