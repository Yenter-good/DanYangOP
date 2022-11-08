using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using CIS.Core;

namespace App_OP.Prescription
{
    public partial class HistoryPrescription : UserControl
    {
        public HistoryPrescription()
        {
            InitializeComponent();
        }

        List<OP_Prescription_Detail_HistoryPrescription> detail = new List<OP_Prescription_Detail_HistoryPrescription>();
        List<OP_Prescription> Prescription = new List<OP_Prescription>();

        public FormPrescription form;
        Node LastNode = new Node();
        public void InitData()
        {
            this.dtStartTime.Value = DateTime.Now.AddDays(-7);
            this.dtEndTime.Value = DateTime.Now;

            //this.advTree1.Nodes[0].Nodes.Clear();
            //if (CIS.Core.SysContext.GetCurrPatient.PatientID.AsString("") == "") return;
            //Prescription = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PatientID == CIS.Core.SysContext.GetCurrPatient.PatientID && p.PrescriptionType.In("1", "2", "3", "4", "5", "6", "9")).ToList();
            //string[] TreatmentNo = Prescription.Select(p => p.TreatmentNo).Distinct().ToArray<string>();

            //foreach (string item in TreatmentNo)
            //{
            //    string time = Prescription.Where(p => p.TreatmentNo == item).Select(p => p.UpdateTime).Max().ToString();
            //    Node node = new Node(time);
            //    node.Tag = item;
            //    this.advTree1.Nodes[0].Nodes.Add(node);
            //}
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("还没有选择病人");
                return;
            }
            this.tbxName.Text = SysContext.GetCurrPatient.PatientName;
            this.btnSearch_Click(null, null);
            this.tbxName.SelectAll();
            this.tbxName.Focus();
        }

        private void BuildNewSystem(List<OP_Prescription_Detail_HistoryPrescription> list)
        {
            List<string> prescriptionNo = list.OrderByDescending(p => p.UpdateTime).Select(p => p.PrescriptionNo).Distinct().ToList();
            foreach (var item in prescriptionNo)
            {
                List<OP_Prescription_Detail_HistoryPrescription> tmp = list.Where(p => p.PrescriptionNo == item).OrderBy(p => p.No).ToList();
                Node node = new Node(tmp[0].PrescriptionType);
                node.Tag = tmp;
                node.NodeDoubleClick += Node_NodeDoubleClick;
                nodeNew.Nodes.Add(node);
            }
        }

        private void BuildNewSystem(Node node, List<OP_Prescription_Detail_HistoryPrescription> list)
        {
            List<string> prescriptionNo = list.OrderByDescending(p => p.UpdateTime).Select(p => p.PrescriptionNo).Distinct().ToList();
            foreach (var item in prescriptionNo)
            {
                List<OP_Prescription_Detail_HistoryPrescription> tmp = list.Where(p => p.PrescriptionNo == item).OrderBy(p => p.No).ToList();
                Node node1 = new Node(@"<font color=""#ED1C24"">{0}</font>".FormatWith(tmp[0].PrescriptionType));
                node1.Tag = tmp;
                node1.NodeClick += Node_NodeDoubleClick;
                node.Nodes.Add(node1);
            }
        }

        private void BuildOldSystem(List<OP_Prescription_Detail_HistoryPrescription> list)
        {
            List<string> prescriptionNo = list.OrderByDescending(p => p.PrescriptionNo.AsInt(0)).Select(p => p.PrescriptionNo).Distinct().ToList();
            foreach (var item in prescriptionNo)
            {
                List<OP_Prescription_Detail_HistoryPrescription> tmp = list.Where(p => p.PrescriptionNo == item).OrderBy(p => p.No).ToList();
                Node node = new Node(item + "号处方");
                node.Tag = tmp;
                node.NodeDoubleClick += Node_NodeDoubleClick;
                nodeOld.Nodes.Add(node);
            }
        }

        private void BuildOldSystem(Node node, List<OP_Prescription_Detail_HistoryPrescription> list)
        {
            List<string> prescriptionNo = list.OrderByDescending(p => p.PrescriptionNo.AsInt(0)).Select(p => p.PrescriptionNo).Distinct().ToList();
            foreach (var item in prescriptionNo)
            {
                List<OP_Prescription_Detail_HistoryPrescription> tmp = list.Where(p => p.PrescriptionNo == item).OrderBy(p => p.No).ToList();
                Node node1 = new Node(@"<font color=""#ED1C24"">{0}</font>".FormatWith(item + "号处方"));
                node1.Tag = tmp;
                node1.NodeClick += Node_NodeDoubleClick;
                node.Nodes.Add(node1);
            }
        }

        private void Node_NodeDoubleClick(object sender, EventArgs e)
        {
            LastNode.Image = null;
            (sender as Node).Image = Properties.Resources.Apply;
            LastNode = sender as Node;
            List<OP_Prescription_Detail_HistoryPrescription> tmp = (sender as Node).Tag as List<OP_Prescription_Detail_HistoryPrescription>;

            //清空草药剂数
            this.textBoxItem1.Enabled = false;
            this.textBoxItem1.Text = "";

            if (tmp[0].ItemType == "1" || tmp[0].ItemType == "2")
            {
                this.dgvXY.DataSource = tmp;
                this.superTabControl1.SelectedTab = this.superTabItem1;
            }
            else if (tmp[0].ItemType == "3")
            {
                this.dgvCY.DataSource = tmp;
                this.textBoxItem1.Enabled = true;
                this.textBoxItem1.Text = tmp[0].HerbalMedicineNum;
                this.superTabControl1.SelectedTab = this.superTabItem2;
            }
            else
            {
                this.dgvZL.DataSource = tmp;
                this.superTabControl1.SelectedTab = this.superTabItem3;
            }
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            //nodeOld.Nodes.Clear();
            //nodeNew.Nodes.Clear();
            //if (e.Node.Nodes.Count != 0 || e.Node.Tag == null) return;
            //string TreatmentNo = e.Node.Tag.ToString();
            //detail = DBHelper.CIS.FromProc("Proc_OP_GetHistoryPrescription_FromDate").AddInParameter("TreatmentNo", DbType.String, TreatmentNo).ToList<OP_Prescription_Detail_HistoryPrescription>();
            //BuildNewSystem(detail.Where(p => p.PrescriptionType != "").ToList());
            //BuildOldSystem(detail.Where(p => p.PrescriptionType == "").ToList());
            if (e.Node.Tag is List<OP_Prescription_Detail_HistoryPrescription>)
            {
                LastNode.Image = null;
                e.Node.Image = Properties.Resources.Apply;
                LastNode = e.Node;
                List<OP_Prescription_Detail_HistoryPrescription> tmp = e.Node.Tag as List<OP_Prescription_Detail_HistoryPrescription>;
                if (tmp[0].ItemType == "1" || tmp[0].ItemType == "2")
                {
                    this.dgvXY.DataSource = tmp;
                    this.superTabControl1.SelectedTab = this.superTabItem1;
                }
                else if (tmp[0].ItemType == "3")
                {
                    this.dgvCY.DataSource = tmp;
                    this.superTabControl1.SelectedTab = this.superTabItem2;
                }
                else
                {
                    this.dgvZL.DataSource = tmp;
                    this.superTabControl1.SelectedTab = this.superTabItem3;
                }
            }
        }

        private void HistoryPrescription_Load(object sender, EventArgs e)
        {
            this.dgvXY.AutoGenerateColumns = false;
            this.dgvCY.AutoGenerateColumns = false;
            this.dgvZL.AutoGenerateColumns = false;

            //this.nodeOld.Style.Font = new System.Drawing.Font(this.nodeOld.Style.Font, System.Drawing.FontStyle.Bold);
            //this.nodeNew.Style.Font = new System.Drawing.Font(this.nodeNew.Style.Font, System.Drawing.FontStyle.Bold);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.dgvXY.EndEdit();
            this.dgvCY.EndEdit();
            this.dgvZL.EndEdit();
            if (this.superTabControl1.SelectedTab == this.superTabItem1)
                form.ImportDrug(this.dgvXY, "XY");
            if (this.superTabControl1.SelectedTab == this.superTabItem2)
                form.ImportDrug(this.dgvCY, "CY", this.textBoxItem1.Text);
            if (this.superTabControl1.SelectedTab == this.superTabItem3)
                form.ImportDrug(this.dgvZL, "ZL");
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (this.superTabControl1.SelectedTab == superTabItem1)
                SetCheckBoxValue(this.dgvXY);
            else if (this.superTabControl1.SelectedTab == superTabItem3)
                SetCheckBoxValue(this.dgvZL);
            else
                SetCheckBoxValue(this.dgvCY);
        }

        private void SetCheckBoxValue(CIS.ControlLib.Controls.myDataGridView dgv)
        {
            bool check = true;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (!item.Cells[0].Value.AsBoolean())
                    check = false;
            }

            if (dgv.Rows.Count == 0)
                check = false;

            this.checkBoxItem1.Checked = check;
        }

        private void SetDGVCheck(CIS.ControlLib.Controls.myDataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
                item.Cells[0].Value = this.checkBoxItem1.Checked;
        }

        private void checkBoxItem1_Click(object sender, EventArgs e)
        {
            if (this.superTabControl1.SelectedTab == superTabItem1)
                SetDGVCheck(this.dgvXY);
            else if (this.superTabControl1.SelectedTab == superTabItem3)
                SetDGVCheck(this.dgvZL);
            else
                SetDGVCheck(this.dgvCY);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.advTree1.Nodes[0].Nodes.Clear();
            //搜索到处方主表
            Prescription = DBHelper.CIS.FromSql(string.Format("SELECT DISTINCT CONVERT(varchar(100),UPDATETIME, 23) AS UpdateTime,TreatmentNo,PatientName FROM OP_Prescription WHERE (Status='1' OR Status='2' OR Status='3') AND (UPDATETIME>='{0}' AND UPDATETIME<='{1}') AND (IDCARD='{2}' OR PatientName LIKE '%{2}%') AND DEPTCODE='{3}' UNION ALL SELECT DISTINCT CONVERT(varchar(100),UPDATETIME, 23) AS UpdateTime,TreatmentNo,PatientName FROM OP_Prescription_History WHERE (Status='1' OR Status='2') AND (UPDATETIME>='{0}' AND UPDATETIME<='{1}') AND (IDCARD='{2}' OR PatientName LIKE '%{2}%') AND DEPTCODE='{3}'", this.dtStartTime.Value.ToShortDateString() + " 00:00:00", this.dtEndTime.Value.ToShortDateString() + " 23:59:59", this.tbxName.Text, SysContext.RunSysInfo.currDept.Code)).ToList<OP_Prescription>();
            //Prescription = DBHelper.CIS.FromSql(string.Format("SELECT DISTINCT CONVERT(varchar(100),FJRQ, 23) AS UpdateTime,JZH AS TreatmentNo,BRXM AS PatientName FROM MZYS_HJMXLSB WHERE (CZJC='1' OR CZJC='2') AND (fjrq>='{0}' AND fjrq<='{1}') AND (ICKH='{2}' OR BRXM LIKE '%{2}%') AND KSBM='{3}' UNION ALL SELECT DISTINCT CONVERT(varchar(100),FJRQ, 23) AS UpdateTime,JZH AS TreatmentNo,BRXM AS PatientName FROM MZYS_HJMXB WHERE (CZJC='1' OR CZJC='2') AND (fjrq>='{0}' AND fjrq<='{1}') AND (ICKH='{2}' OR BRXM LIKE '%{2}%') AND KSBM='{3}' UNION ALL SELECT DISTINCT CONVERT(varchar(100),UPDATETIME, 23) AS UpdateTime,TreatmentNo,PatientName FROM OP_Prescription WHERE (Status='1' OR Status='2') AND (UPDATETIME>='{0}' AND UPDATETIME<='{1}') AND (IDCARD='{2}' OR PatientName LIKE '%{2}%') AND DEPTCODE='{3}' UNION ALL SELECT DISTINCT CONVERT(varchar(100),UPDATETIME, 23) AS UpdateTime,TreatmentNo,PatientName FROM OP_Prescription_History WHERE (Status='1' OR Status='2') AND (UPDATETIME>='{0}' AND UPDATETIME<='{1}') AND (IDCARD='{2}' OR PatientName LIKE '%{2}%') AND DEPTCODE='{3}'", this.dtStartTime.Value.ToShortDateString() + " 00:00:00", this.dtEndTime.Value.ToShortDateString() + " 23:59:59", this.tbxName.Text, SysContext.RunSysInfo.currDept.Code)).ToList<OP_Prescription>();
            //拿出不重复的日期
            List<string> tmp = Prescription.Select(p => p.UpdateTime.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();
            foreach (string item in tmp)  //循环该日期
            {
                List<OP_Prescription> tmp1 = Prescription.Where(p => p.UpdateTime.Value.ToShortDateString() == item).ToList();  //拿到该日期下的所有处方主表
                List<string> str = tmp1.Select(p => p.TreatmentNo).Distinct().ToList();  //拿到该日期下的所有就诊号
                Node node = new Node(item);   //根据就诊号生成node
                foreach (string item1 in str)
                {
                    //获得该就诊号在该日期下的所有处方明细
                    detail = DBHelper.CIS.FromProc("Proc_OP_GetHistoryPrescription_FromDate").AddInParameter("TreatmentNo", DbType.String, item1).AddInParameter("@DateTime", DbType.String, item).ToList<OP_Prescription_Detail_HistoryPrescription>();
                    Node node1 = new Node(tmp1.Where(p => p.TreatmentNo == item1).First().PatientName + " " + item1 + " " + (detail.Count == 0 ? "无历史" : ""));
                    //node1.Tag = item1;

                    BuildNewSystem(node1, detail.Where(p => p.PrescriptionType != "").ToList());
                    BuildOldSystem(node1, detail.Where(p => p.PrescriptionType == "").ToList());
                    node.Nodes.Add(node1);
                }
                this.advTree1.Nodes[0].Nodes.Add(node);
            }
            this.advTree1.ExpandAll();
        }

        private void btnCurrntPatient_Click(object sender, EventArgs e)
        {
            InitData();
        }

    }
}
