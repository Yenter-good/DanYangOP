using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.AdvTree;
using CIS.Core;

namespace App_OP.Record
{
    public partial class HistoryRecordTree : UserControl
    {
        public HistoryRecordTree()
        {
            InitializeComponent();
        }
        public FormMain formMain
        { get; set; }

        public void InitRecord()
        {
            this.dtStartTime.Value = DateTime.Now.AddDays(-7);
            this.dtEndTime.Value = DateTime.Now;
            if (SysContext.GetCurrPatient != null)
                this.tbxName.Text = SysContext.GetCurrPatient.PatientName;
            //this.advTree1.Nodes[0].Nodes.Clear();
            //if (SysContext.GetCurrPatient == null)
            //    return;
            //string PatientID = SysContext.GetCurrPatient.PatientID;
            //string TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            //List<OP_MedicalRecords> recodes = DBHelper.CIS.From<OP_MedicalRecords>().Where(p => p.PatientID == PatientID || p.TreatmentNo == TreatmentNo).ToList();
            //foreach (OP_MedicalRecords item in recodes)
            //{
            //    Node node = new Node(string.Format("[{0}]", item.Type == 1 ? "复诊" : "初诊") + item.PatientName + " " + item.TreatmentNo);
            //    node.Tag = item.XML;
            //    this.advTree1.Nodes[0].Nodes.Add(node);
            //}
            //this.advTree1.ExpandAll();
            this.btnSearch_Click(null, null);
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                FormHistoryRecord form = new FormHistoryRecord(formMain);
                form.InitDocument(e.Node.Tag.ToString());
                form.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.advTree1.Nodes[0].Nodes.Clear();
            // List<OP_MedicalRecords> recodes = DBHelper.CIS.From<OP_MedicalRecords>().Where(p => p.DeptCode == CIS.Core.SysContext.RunSysInfo.currDept.Code && (p.PatientName.Contains(this.tbxName.Text) || p.TreatmentNo == this.tbxName.Text) && p.UpdateTime >= this.dtStartTime.Value && p.UpdateTime <= DateTime.Parse((this.dtEndTime.Value.ToShortDateString() + " 23:59:59"))).ToList();
            List<OP_MedicalRecords> recodes = new List<OP_MedicalRecords>();
            List<OP_MedicalRecords> recodesOwnDept = new List<OP_MedicalRecords>();
            List<OP_MedicalRecords> recodesOtherDept = new List<OP_MedicalRecords>();
            if (this.cbxFindOtherDept.Checked)
            //这里返回的userid是医生姓名,deptcode是科室名称,方便显示
            {
                recodes = DBHelper.CIS.FromProc("Proc_OP_GetHistoryRecord_OtherDoctor").AddInParameter("DeptCode", DbType.String, SysContext.RunSysInfo.currDept.Code).AddInParameter("SearchString", DbType.String, this.tbxName.Text).AddInParameter("StartTime", DbType.DateTime, this.dtStartTime.Value).AddInParameter("EndTime", DbType.DateTime, DateTime.Parse((this.dtEndTime.Value.ToShortDateString() + " 23:59:59"))).ToList<OP_MedicalRecords>();
                recodesOwnDept = recodes.Where(p => p.DeptCode == SysContext.RunSysInfo.currDept.Name).ToList();
                recodesOtherDept = recodes.Where(p => p.DeptCode != SysContext.RunSysInfo.currDept.Name).ToList();
            }
            else
            {
                recodes = DBHelper.CIS.FromProc("Proc_OP_GetHistoryRecord").AddInParameter("DeptCode", DbType.String, SysContext.RunSysInfo.currDept.Code).AddInParameter("SearchString", DbType.String, this.tbxName.Text).AddInParameter("StartTime", DbType.DateTime, this.dtStartTime.Value).AddInParameter("EndTime", DbType.DateTime, DateTime.Parse((this.dtEndTime.Value.ToShortDateString() + " 23:59:59"))).ToList<OP_MedicalRecords>();
                recodesOwnDept = recodes.Where(p => p.DeptCode == SysContext.RunSysInfo.currDept.Code).ToList();
            }

            #region 先生成本科室的所有历史病人病历
            List<string> tmp = recodesOwnDept.Select(p => p.UpdateTime.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();
            foreach (string item in tmp)
            {
                List<OP_MedicalRecords> recode = recodesOwnDept.Where(p => p.UpdateTime.Value.ToShortDateString() == item).ToList();
                Node node = new Node(item);
                foreach (OP_MedicalRecords item1 in recode)
                {
                    Node node1 = new Node(string.Format("[{0}]", (item1.Type == 1 ? "复诊" : "初诊")) + item1.PatientName + " " + item1.TreatmentNo);
                    node1.Tag = item1.XML;
                    node.Nodes.Add(node1);
                }
                this.advTree1.Nodes[0].Nodes.Add(node);
            }
            #endregion

            if (this.cbxFindOtherDept.Checked)
            {
                #region 再生成别的科室的历史病人病历
                Node nodeOther = new Node(@"<b><font color=""#ED1C24"">其他科室病人</font></b>");

                tmp = recodesOtherDept.Select(p => p.DeptCode).Distinct().ToList();
                foreach (string item in tmp)
                {
                    Node node = new Node(item);   //这里是科室名称
                    List<OP_MedicalRecords> recode = recodesOtherDept.Where(p => p.DeptCode == item).ToList();
                    List<string> tmp1 = recode.Select(p => p.UpdateTime.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();  //在当前的科室中找到所有日期
                    foreach (string item1 in tmp1)
                    {
                        Node node1 = new Node(item1);  //这里是日期名称
                        List<OP_MedicalRecords> recode1 = recodesOtherDept.Where(p => p.UpdateTime.Value.ToShortDateString() == item1).ToList();
                        foreach (OP_MedicalRecords item2 in recode1)
                        {
                            //这里用存储过程返回的类里,userid不是存放的医生工号,而是医生姓名,方便显示
                            Node node2 = new Node(string.Format("[{0}][{1}]", item2.UserID, (item2.Type == 1 ? "复诊" : "初诊")) + item2.PatientName + " " + item2.TreatmentNo);
                            node2.Tag = item2.XML;
                            node1.Nodes.Add(node2);
                        }
                        node.Nodes.Add(node1);
                    }
                    nodeOther.Nodes.Add(node);
                }
                this.advTree1.Nodes[0].Nodes.Add(nodeOther);
                #endregion
            }
            this.advTree1.ExpandAll();
        }

        private void btnCurrentPatient_Click(object sender, EventArgs e)
        {
            InitRecord();
        }

        private void HistoryRecordTree_Load(object sender, EventArgs e)
        {
            this.dtEndTime.Value = DateTime.Now;
            this.dtStartTime.Value = DateTime.Now.AddDays(-7);
        }
    }


}
