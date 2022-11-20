using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using DevComponents.AdvTree;

namespace App_OP
{
    public partial class FormPrescriptionTotal : BaseForm
    {
        public FormPrescriptionTotal()
        {
            InitializeComponent();
        }
        List<OP_Prescription> prescription = new List<OP_Prescription>();
        List<OP_Dic_PrescriptionType> type = new List<OP_Dic_PrescriptionType>();
        string TreatmentNo = "";
        string prescriptionNo = "";
        string prescriptionType = "";
        string HISInterface_PrescriptionNo = "";
        private void InitUI()
        {
            this.dtStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtEndTime.Value = DateTime.Now;
            this.dgvCY.AutoGenerateColumns = false;
            this.dgvXY.AutoGenerateColumns = false;
            this.dgvZL.AutoGenerateColumns = false;

            type = DBHelper.CIS.From<OP_Dic_PrescriptionType>().ToList();
        }

        private void FormPrescriptionTotal_Shown(object sender, EventArgs e)
        {
            InitUI();
            InitDict();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.treePatient.Nodes.Clear();
            if (this.textBoxX1.Text == "")
                prescription = DBHelper.CIS.FromSql(string.Format("SELECT * FROM OP_Prescription WHERE PrescriptionType<>'11' AND PrescriptionType<>'12' AND USERID='{0}' AND UPDATETIME>='{1}' AND UPDATETIME<='{2}' UNION ALL SELECT * FROM OP_Prescription_History WHERE PrescriptionType<>'11' AND PrescriptionType<>'12' AND USERID='{0}' AND UPDATETIME>='{1}' AND UPDATETIME<='{2}'", SysContext.CurrUser.user.Code, this.dtStartTime.Value.ToShortDateString() + " 00:00:00", this.dtEndTime.Value.ToShortDateString() + " 23:59:59")).ToList<OP_Prescription>();
            //prescription = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionType != "11" && p.PrescriptionType != "12" && p.UserID == SysContext.CurrUser.user.Code && p.UpdateTime >= (this.dtStartTime.Value.ToShortDateString() + " 00:00:00").AsDateTime() && p.UpdateTime <= (this.dtEndTime.Value.ToShortDateString() + " 23:59:59").AsDateTime()).ToList();
            else
                prescription = DBHelper.CIS.FromSql(string.Format("SELECT * FROM OP_Prescription WHERE PrescriptionType<>'11' AND PrescriptionType<>'12' AND USERID='{0}' AND (TreatmentNo LIKE '%{1}%' OR PatientName LIKE '%{1}%') AND UPDATETIME>='{2}' AND UPDATETIME<='{3}' UNION ALL SELECT * FROM OP_Prescription_History WHERE PrescriptionType<>'11' AND PrescriptionType<>'12' AND USERID='{0}' AND (TreatmentNo LIKE '%{1}%' OR PatientName LIKE '%{1}%') AND UPDATETIME>='{2}' AND UPDATETIME<='{3}'", SysContext.CurrUser.user.Code, this.textBoxX1.Text, this.dtStartTime.Value.ToShortDateString() + " 00:00:00", this.dtEndTime.Value.ToShortDateString() + " 23:59:59")).ToList<OP_Prescription>();
            //prescription = DBHelper.CIS.From<OP_Prescription>().Where(p => p.PrescriptionType != "11" && p.PrescriptionType != "12" && p.UserID == SysContext.CurrUser.user.Code && (p.TreatmentNo.Contains(this.textBoxX1.Text) || p.PatientName.Contains(this.textBoxX1.Text)) && p.UpdateTime >= (this.dtStartTime.Value.ToShortDateString() + " 00:00:00").AsDateTime() && p.UpdateTime <= (this.dtEndTime.Value.ToShortDateString() + " 23:59:59").AsDateTime()).ToList();

            int HMNum = prescription.Where(p => p.PrescriptionType == "2").Count();
            int MTNum = prescription.Where(p => p.PrescriptionType == "9").Count();
            int WMNum = prescription.Where(p => p.PrescriptionType != "9" && p.PrescriptionType != "2").Count();

            this.lbWMPrescription.Text = WMNum.ToString() + "张西药处方";
            this.lbMTPrescription.Text = MTNum.ToString() + "张治疗处方";
            this.lbHMPrescription.Text = HMNum.ToString() + "张草药处方";
            this.lbPrescription.Text = prescription.Count().ToString() + "张处方";

            prescription.ForEach(p => p.UpdateTime = p.UpdateTime.Value.Date);

            List<DateTime?> time = prescription.Select(p => p.UpdateTime).Distinct().ToList();
            time = time.OrderByDescending(p => p).ToList();
            int PatientNum = 0;
            foreach (DateTime item in time)
            {
                List<OP_Prescription> prescriptionTmp = prescription.Where(p => p.UpdateTime.Value.Date == item).ToList();
                List<string> str = prescriptionTmp.Select(p => p.TreatmentNo).Distinct().ToList();

                Node node = new Node(item.ToShortDateString());
                foreach (string itemString in str)
                {
                    OP_Prescription item1 = prescriptionTmp.Where(p => p.TreatmentNo == itemString).First();
                    Node node1 = new Node(item1.PatientName + " " + item1.TreatmentNo);
                    node1.Tag = item1.TreatmentNo;
                    node.Nodes.Add(node1);
                    PatientNum++;
                }
                this.treePatient.Nodes.Add(node);
            }
            this.treePatient.ExpandAll();
            this.lbPatientNum.Text = PatientNum.ToString() + "个病人";
        }

        private void treePatient_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            this.dgvPrescription.Rows.Clear();
            if (e.Node.Tag == null) return;
            List<OP_Prescription> tmp = prescription.Where(p => p.TreatmentNo == e.Node.Tag.ToString()).ToList();
            TreatmentNo = e.Node.Tag.ToString();
            foreach (OP_Prescription item in tmp)
            {
                int i = this.dgvPrescription.Rows.Add();
                DataGridViewRow row = this.dgvPrescription.Rows[i];
                row.Cells["colName"].Value = type.Where(p => p.Code == item.PrescriptionType).First().Name;
                row.Cells["colPrescriptionNo"].Value = item.PrescriptionNo;
                row.Cells["colNum"].Value = item.RecordNumber;
                row.Cells["colPrescriptionType"].Value = item.PrescriptionType;
                row.Cells["colHISInterface_PrescriptionNo"].Value = item.HISInterface_PrescriptionNo;
            }
        }

        private void dgvPrescription_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dgvPrescription.Rows[e.RowIndex];
            string _PrescriptionNo = row.Cells["colPrescriptionNo"].Value.ToString();
            string _PrescriptionType = row.Cells["colPrescriptionType"].Value.ToString();
            HISInterface_PrescriptionNo = row.Cells["colHISInterface_PrescriptionNo"].Value.ToString();
            prescriptionNo = _PrescriptionNo;
            prescriptionType = _PrescriptionType;
            //List<OP_Prescription_Detail> detail = DBHelper.CIS.From<OP_Prescription_Detail>().Where(p => p.PrescriptionNo == _PrescriptionNo).ToList();
            List<OP_Prescription_Detail> detail = DBHelper.CIS.FromSql(string.Format("SELECT * FROM OP_Prescription_Detail WHERE PRESCRIPTIONNO='{0}' UNION ALL SELECT * FROM OP_Prescription_Detail_History WHERE PRESCRIPTIONNO='{0}'", _PrescriptionNo)).ToList<OP_Prescription_Detail>();
            if (_PrescriptionType == "2")
            {
                this.dgvCY.DataSource = detail;
                this.superTabControl1.SelectedTab = this.tabCY;
                this.panelEx2.Text = detail.Count.ToString() + "个草药" + Environment.NewLine + "总计：" + detail.Sum(p => p.Total).AsFloat().ToString() + "元";
            }
            else if (_PrescriptionType == "9")
            {
                this.dgvZL.DataSource = detail;
                this.superTabControl1.SelectedTab = this.tabZL;
                this.panelEx2.Text = detail.Count.ToString() + "项治疗" + Environment.NewLine + "总计：" + detail.Sum(p => p.Total).AsFloat().ToString() + "元";
            }
            else
            {
                this.dgvXY.DataSource = detail;
                this.superTabControl1.SelectedTab = this.tabXY;
                this.panelEx2.Text = detail.Count.ToString() + "个西药" + Environment.NewLine + "总计：" + detail.Sum(p => p.Total).AsFloat().ToString() + "元";
            }
        }


        /// <summary>
        /// 初始化用法和间隔字典
        /// </summary>
        private void InitDict()
        {
            List<IView_HIS_DrugUsage> Usage = DBHelper.CIS.From<IView_HIS_DrugUsage>().ToList();
            this.XY_colYF.DataSource = Usage.Where(p => p.Type == "1").ToList();
            this.XY_colYF.DisplayMember = "Name";
            this.XY_colYF.ValueMember = "Code";
            this.CY_colYF.DisplayMember = "Name";
            this.CY_colYF.ValueMember = "Code";
            this.CY_colYF.DataSource = Usage.Where(p => p.Type == "2").ToList();


            List<OP_Dic_Interval> Interval = DBHelper.CIS.From<OP_Dic_Interval>().ToList();
            this.XY_colJG.DataSource = Interval.Where(p => p.IsWesternMedicine == 0).ToList();
            this.XY_colJG.DisplayMember = "Name";
            this.XY_colJG.ValueMember = "Code";

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("需皮试", "Y");
            dict.Add("继续使用", "N");
            dict.Add("不需皮试", "X");
            BindingSource PSBZ = new BindingSource();//皮试标志
            this.XY_colPS.DisplayMember = "Key";
            this.XY_colPS.ValueMember = "Value";
            PSBZ.DataSource = dict;
            this.XY_colPS.DataSource = PSBZ;
        }

        private void btnPrite_Click(object sender, EventArgs e)
        {
            this.btnPrite.Expanded = !this.btnPrite.Expanded;

        }

        private void btnPrescriptionPrite_Click(object sender, EventArgs e)
        {
            if (prescriptionNo == "" || prescriptionType == "") return;
            Print.PrescriptionPrint(prescriptionNo, prescriptionType, HISInterface_PrescriptionNo, OutpatientNo: TreatmentNo, IsView: true, selectAll: true);
        }

        private void btnSpecialPrite_Click(object sender, EventArgs e)
        {
            if (prescriptionNo == "" || prescriptionType == "") return;
            Print.PrescriptionPrint(prescriptionNo, prescriptionType, HISInterface_PrescriptionNo, OutpatientNo: TreatmentNo, IsView: true, IsSpecialPrite: true, selectAll: true);
        }
    }
}
