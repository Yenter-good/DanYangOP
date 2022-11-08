using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using CIS.Core;

namespace App_OP
{
    public partial class FormRecordStatistic : BaseForm
    {
        public FormRecordStatistic()
        {
            InitializeComponent();
        }

        List<OP_MedicalRecordsExt> list = new List<OP_MedicalRecordsExt>();

        private void InitUI()
        {
            this.dtRecordStatisticStartTime.Value = DateTime.Now.AddDays(-7);
            this.dtRecordStatisticEndTime.Value = DateTime.Now;
            this.rbHasRecord.Checked = true;

            this.cbxDept.DataSource = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1).ToDataTable();
            this.cbxDept.DisplayMember = "Name";
            this.cbxDept.ValueMember = "Code";
            this.cbxDept.FilterFields = new string[] { "SearchCode" };
        }

        private void FormRecordStatistic_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            if (this.cbxDept.SelectedValue == null || this.cbxDoctor.SelectedValue == null)
            {
                CIS.Core.AlertBox.Info("未选择科室和医生,无法查询");
                return;
            }
            string user = this.cbxDoctor.SelectedValue.ToString();
            string dept = this.cbxDept.SelectedValue.ToString();
            string Start = this.dtRecordStatisticStartTime.Value.ToShortDateString() + " 00:00:00";
            string End = this.dtRecordStatisticEndTime.Value.ToShortDateString() + " 23:59:59";
            if (user == "*")
                list = DBHelper.CIS.FromProc("Proc_OP_GetHistoryRecord_Ext").AddInParameter("Type", DbType.String, user).AddInParameter("StartTime", DbType.String, Start).AddInParameter("EndTime", DbType.String, End).AddInParameter("SearchString", DbType.String, dept).ToList<OP_MedicalRecordsExt>();
            //list = DBHelper.CIS.FromSql(string.Format("select b.id as RecordID,a.* from op_journal a left join dbo.OP_MedicalRecords b on a.OutpatientNo=b.TreatmentNo where a.UpdateDate>'{0}' and a.UpdateDate<'{1}' and a.DeptCode='{2}'", Start, End, dept)).ToList<OP_MedicalRecordsExt>();
            else
                list = DBHelper.CIS.FromProc("Proc_OP_GetHistoryRecord_Ext").AddInParameter("Type", DbType.String, user).AddInParameter("StartTime", DbType.String, Start).AddInParameter("EndTime", DbType.String, End).AddInParameter("SearchString", DbType.String, user).ToList<OP_MedicalRecordsExt>();
            //list = DBHelper.CIS.FromSql(string.Format("select b.id as RecordID,a.* from op_journal a left join dbo.OP_MedicalRecords b on a.OutpatientNo=b.TreatmentNo where a.UpdateDate>'{0}' and a.UpdateDate<'{1}' and a.DoctorNo='{2}'", Start, End, user)).ToList<OP_MedicalRecordsExt>();
            this.rbHasRecord_CheckedChanged(this.rbAllRecord.Checked ? this.rbAllRecord : this.rbHasRecord.Checked ? this.rbHasRecord : this.rbNoRecord.Checked ? this.rbNoRecord : null, null);
        }

        private void cbxDept_TextChanged(object sender, EventArgs e)
        {
            string value = this.cbxDept.SelectedValue.ToString();
            DataTable user = DBHelper.CIS.From<IView_User>().Where(p => p.Dept_Code == value).ToDataTable();
            DataRow row = user.NewRow();
            user.Rows.InsertAt(row, 0);
            user.Rows[0]["Name"] = "全部";
            user.Rows[0]["Code"] = "*";
            user.Rows[0]["SearchCode"] = "QB";

            this.cbxDoctor.DataSource = user;
            this.cbxDoctor.DisplayMember = "Name";
            this.cbxDoctor.ValueMember = "Code";
            this.cbxDoctor.FilterFields = new string[] { "SearchCode" };
        }

        private void cbxDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == this.cbxDept)
            {
                if (e.KeyCode == Keys.Enter)
                    this.cbxDoctor.ShowPopup();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                    this.btnSearchRecord.Focus();
            }
        }

        private void rbHasRecord_CheckedChanged(object sender, EventArgs e)
        {
            this.advTree1.Nodes.Clear();

            if (this.cbxDept.SelectedValue == null || this.cbxDoctor.SelectedValue == null)
                return;

            List<OP_MedicalRecordsExt> tmp = new List<OP_MedicalRecordsExt>();
            if (sender == this.rbHasRecord)
                tmp = list.Where(p => p.RecordID != null).ToList();
            else if (sender == this.rbNoRecord)
                tmp = list.Where(p => p.RecordID == null).ToList();
            else
                tmp = list;

            int HasRecord = tmp.Where(p => p.RecordID != null).Count();
            this.lbCount.Text = string.Format("总计：{0}人", tmp.Count.ToString()) + Environment.NewLine + string.Format("{0}人有病历,{1}人没病历", HasRecord, tmp.Count - HasRecord);

            this.lbCount.Left = this.panelEx2.Width / 2 - this.lbCount.Width / 2;

            string user = this.cbxDoctor.SelectedValue.ToString();

            List<string> time = tmp.Select(p => p.UpdateDate.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();
            foreach (string item in time)
            {
                List<OP_MedicalRecordsExt> record = new List<OP_MedicalRecordsExt>();
                if (user == "*")
                    record = tmp.Where(p => p.UpdateDate.Value.ToShortDateString() == item).OrderBy(p => p.DeptCode).ToList();
                else
                    record = tmp.Where(p => p.UpdateDate.Value.ToShortDateString() == item).OrderBy(p => p.RecordID).ToList();

                Node node = new Node(item);
                foreach (OP_MedicalRecordsExt item1 in record)
                {
                    Node node1 = new Node();
                    node1.Text = item1.PatientName + string.Format(@"     <b><font color=""#ED1C24"">{0}</font></b>", item1.RecordID != null ? "有病历" : "");
                    node1.Tag = item1;
                    node.Nodes.Add(node1);
                }
                this.advTree1.Nodes.Add(node);
            }
            this.advTree1.ExpandAll();
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag == null) return;

            string recordID = (e.Node.Tag as OP_MedicalRecordsExt).RecordID;
            if (recordID == null) return;
            OP_MedicalRecords record = DBHelper.CIS.FromSql(string.Format("SELECT * FROM OP_MedicalRecords WHERE ID='{0}' UNION ALL SELECT * FROM OP_MedicalRecords_History WHERE ID='{0}'", recordID)).First<OP_MedicalRecords>();
            this.txWriterControl1.LoadDocumentFromString(record.XML, "XML");
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FilePrintPreview, true, null);
        }
    }

    public class OP_MedicalRecordsExt : OP_Journal
    {
        public string RecordID { get; set; }
    }
}
