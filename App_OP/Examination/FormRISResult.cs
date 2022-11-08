using System;
using System.Data;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using App_OP.Examination;
using App_OP.Examination.PACSShare.Notice;
using App_OP.Examination.PACSShare.Token;
using App_OP.Examination.PACSShare.ViewOtherHos;

namespace App_OP
{
    public partial class FormRISResult : BaseForm
    {
        private Dictionary<string, List<YJ_PACS_DR>> _mapper;
        List<vzd_tcsm> tcsm; //套餐说明
        private DREqu _drequ = new DREqu();

        public FormRISResult()
        {
            InitializeComponent();
            _mapper = new Dictionary<string, List<YJ_PACS_DR>>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.tbxName.Text == "")
                return;
            string sql;
            //            if (this.tbxName.Text == "")
            //            {
            //                sql = $@"
            //select a.TreatmentNo,b.IDCard,a.PatientName,a.Sex,a.UpdateTime,a.UserName,b.DeptName as DeptCode,a.PrescriptionNo from OP_Prescription a
            //left join op_journal b on a.TreatmentNo=b.OutpatientNo
            //where PrescriptionType='12' and UpdateTime>='{this.dtStartTime.Value.Date}' and UpdateTime<'{this.dtEndTime.Value.Date.AddDays(1)}'
            //union
            //select a.TreatmentNo,b.IDCard,a.PatientName,a.Sex,a.UpdateTime,a.UserName,b.DeptName as DeptCode,a.PrescriptionNo from OP_Prescription a
            //left join op_journal b on a.TreatmentNo=b.OutpatientNo
            //where PrescriptionType='12' and UpdateTime>='{this.dtStartTime.Value.Date}' and UpdateTime<'{this.dtEndTime.Value.Date.AddDays(1)}'";
            //            }
            //            else
            //            //            {

            //            sql = $@"
            //select * from yj_pacs_dr where idnumber='{this.tbxName.Text}' and indate>='{this.dtStartTime.Value.Date}' and indate<'{this.dtEndTime.Value.Date.AddDays(1)}'";

            //            sql = $@"
            //select a.TreatmentNo,b.IDCard,a.PatientName,a.Sex,a.UpdateTime,a.UserName,b.DeptName as DeptCode,a.PrescriptionNo from OP_Prescription a
            //left join op_journal b on a.TreatmentNo=b.OutpatientNo
            //where a.IDCard='{this.tbxName.Text}' and PrescriptionType='12' and Status='2' and UpdateTime>='{this.dtStartTime.Value.Date}' and UpdateTime<'{this.dtEndTime.Value.Date.AddDays(1)}'
            //union
            //select a.TreatmentNo,b.IDCard,a.PatientName,a.Sex,a.UpdateTime,a.UserName,b.DeptName as DeptCode,a.PrescriptionNo from OP_Prescription_History a
            //left join op_journal_history b on a.TreatmentNo=b.OutpatientNo
            //where a.IDCard='{this.tbxName.Text}' and PrescriptionType='12' and Status='2' and UpdateTime>='{this.dtStartTime.Value.Date}' and UpdateTime<'{this.dtEndTime.Value.Date.AddDays(1)}'";
            //}

            var result = DBHelper.CIS.From<YJ_PACS_DR>().Where(p => (p.IDNUMBER == this.tbxName.Text || p.PatientName == this.tbxName.Text) && p.INDATE >= this.dtStartTime.Value.Date && p.INDATE < this.dtEndTime.Value.Date.AddDays(1)).ToList();

            var treatmentnos = result.Select(p => p.HisPatientID).Distinct();
            this.dataGridView1.Rows.Clear();
            foreach (var treatmentno in treatmentnos)
            {
                var first = result.FirstOrDefault(p => p.HisPatientID == treatmentno);
                if (first == null)
                    continue;
                var newrow = this.dataGridView1.Rows[this.dataGridView1.Rows.Add()];
                newrow.Cells[colJZH.Index].Value = first.HisPatientID;
                newrow.Cells[colIDCard.Index].Value = first.IDNUMBER;
                newrow.Cells[colName.Index].Value = first.PatientName;
                newrow.Cells[colSex.Index].Value = first.SexName;
                newrow.Cells[colDate.Index].Value = first.INDATE.ToShortDateString();
                newrow.Cells[colDoctor.Index].Value = first.ReqDoctorName;
                newrow.Cells[colDeptName.Index].Value = first.ReqDepartmentName;

                newrow.Tag = first;

                _mapper[treatmentno] = result.Where(p => p.HisPatientID == treatmentno).Distinct(_drequ).ToList();
            }
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            if (!SysContext.Session.ContainsKey("CurrPatient"))
            {
                AlertBox.Info("请先选择病人");
                return;
            }
            System.Diagnostics.Process ie = new System.Diagnostics.Process();
            ie.StartInfo.FileName = "IEXPLORE.EXE";
            ie.StartInfo.Arguments = string.Format("http://192.168.1.233:8080/PacsWebDisplay/PacsWebDisplay/PacsWebDisplay.action?ClinicPatientID={0}", SysContext.GetCurrPatient.OutpatientNo);
            ie.Start();

            //string url = string.Format("http://192.168.1.233:8080/PacsWebDisplay/PacsWebDisplay/PacsWebDisplay.action?ClinicPatientID={0}", SysContext.GetCurrPatient.OutpatientNo);
            //Process.Start(url);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string jzh = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            System.Diagnostics.Process ie = new System.Diagnostics.Process();
            ie.StartInfo.FileName = "IEXPLORE.EXE";
            ie.StartInfo.Arguments = string.Format("http://192.168.1.233:8080/PacsWebDisplay/PacsWebDisplay/PacsWebDisplay.action?ClinicPatientID={0}", jzh);
            ie.Start();
        }
        private void FormRISResult_Shown(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            if (SysContext.GetCurrPatient != null)
                this.tbxName.Text = SysContext.GetCurrPatient.IDCard;
            this.dtEndTime.Value = DateTime.Now;
            this.dtStartTime.Value = DateTime.Now.AddMonths(-1);
            this.btnSearch_Click(null, null);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dr = this.dataGridView1.Rows[e.RowIndex].Tag as YJ_PACS_DR;

            var details = _mapper[dr.HisPatientID];

            this.dataGridView2.Rows.Clear();
            foreach (var detail in details)
            {
                var newrow = this.dataGridView2.Rows[this.dataGridView2.Rows.Add()];
                newrow.Cells[colItemName.Index].Value = detail.JCXMMC;
                newrow.Cells[colDateTime.Index].Value = detail.INDATE;
                newrow.Tag = detail;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dataGridView2.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0];
            var code = (selectedRow.Tag as YJ_PACS_DR).JCXMBM;

            if (tcsm == null)
                tcsm = DBHelper.CIS.From<vzd_tcsm>().ToList();

            var knowlage = tcsm.FirstOrDefault(p => p.ItemCode == code);
            if (knowlage == null)
            {
                AlertBox.Info("该项目没有知识库");
                return;
            }

            FormKnowlage form = new FormKnowlage();
            form.IsLIS = true;
            form.Init(knowlage);
            form.ShowDialog();
        }

        private void btnOutHos_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dataGridView1.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("未选择记录");
                return;
            }

            var model = (selectedRows[0] as DataGridViewRow).Tag as YJ_PACS_DR;

            TokenHelper token = new TokenHelper();
            token.Handler();
            ViewOtherHosHelper view = new ViewOtherHosHelper();
            var url = view.Handler(model.IDNUMBER, "", model.PatientName, model.HisPatientID);
            if (!string.IsNullOrEmpty(url))
                Process.Start(url);
            else
                MessageBox.Show("影像调阅失败");
        }
    }

    public class DREqu : IEqualityComparer<YJ_PACS_DR>
    {
        public bool Equals(YJ_PACS_DR x, YJ_PACS_DR y)
        {
            if (x.JCXMBM == y.JCXMBM)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(YJ_PACS_DR obj)
        {
            return obj.JCXMBM.GetHashCode();
        }
    }
}
