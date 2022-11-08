using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using System.Reflection;
using CIS.Core.EventBroker;
using CIS.Model;
using DevComponents.AdvTree;

namespace App_OP
{
    public partial class FormReportManage : BaseForm
    {
        public FormReportManage(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }

        private void FormReportManage_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private static FormMain formMain;

        private class Tree
        {
            public string ParentName { get; set; }
            public string Name { get; set; }
            public string NameSpace { get; set; }
            public string Type { get; set; }
            public string TabName { get; set; }
        }

        List<Tree> list = new List<Tree>();

        private void InitUI()
        {
            list.Add(new Tree() { Name = "病人资料", ParentName = "资料", NameSpace = "App_OP.FormWriteJournal", Type = "Form", TabName = "" });
            list.Add(new Tree() { Name = "住院登记单", ParentName = "资料", NameSpace = "App_OP.FormHospitalizedReport", Type = "Form", TabName = "tabHospitalized" });
            list.Add(new Tree() { Name = "疾病诊断证明书", ParentName = "资料", NameSpace = "App_OP.FormDiagnosisReport", Type = "Form", TabName = "" });
            list.Add(new Tree() { Name = "医用特殊耗材使用审批表", ParentName = "资料", NameSpace = "App_OP.FormSpecialItemReport", Type = "Form", TabName = "" });
            list.Add(new Tree() { Name = "医用特殊耗材使用审批表", ParentName = "资料", NameSpace = "App_OP.FormSpecialItemReport", Type = "Form", TabName = "" });
            list.Add(new Tree() { Name = "传染病报告卡", ParentName = "填报", NameSpace = "ShowInfection", Type = "Method", TabName = "tabInfection" });
            list.Add(new Tree() { Name = "慢性病报告卡", ParentName = "填报", NameSpace = "ShowChronic", Type = "Method", TabName = "tabChronic" });
            list.Add(new Tree() { Name = "慢阻病报告卡", ParentName = "填报", NameSpace = "ShowChronic", Type = "Method", TabName = "tabChronic" });

            this.dtInfectionStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtInfectionEndTime.Value = DateTime.Now;
            this.dtChronicStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtChronicEndTime.Value = DateTime.Now;
            this.dtHospitalizedStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtHospitalizedEndTime.Value = DateTime.Now;

            List<string> tmp = list.Select(p => p.ParentName).Distinct().ToList();

            foreach (string item in tmp)
            {
                GridRow row = new GridRow(item);
                row.CellStyles.Default.Font = new Font(this.Font, FontStyle.Bold);
                List<Tree> treeTmp = list.Where(p => p.ParentName == item).ToList();
                foreach (Tree item1 in treeTmp)
                {
                    GridRow row1 = new GridRow(item1.Name);
                    row1.Tag = item1;
                    row1.Cells[0].CellStyles.Default.Image = Properties.Resources.Cards_32x32;
                    row.Rows.Add(row1);
                }
                this.superGridControl1.PrimaryGrid.Rows.Add(row);
            }
            this.superGridControl1.PrimaryGrid.ExpandAll();
        }

        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            if (e.GridRow.Rows.Count == 0)
            {
                Tree tag = e.GridRow.Tag as Tree;
                if (tag.Type == "Form")
                {
                    Form form = SysContext.CreateForm("App_OP", tag.NameSpace);
                    form.ShowDialog();
                }
                else if (tag.Type == "Method")
                {
                    Type t = Assembly.Load("App_OP").GetType("App_OP.FormReportManage");//  typeof(FormReportManage);
                    object obj = t.RunFunction(tag.NameSpace, new object[] { });
                    if (obj is string)
                        AlertBox.Info("该功能未定义,调用失败");
                    //MethodInfo mt = t.GetMethod(tag.NameSpace, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    //if (mt != null)
                    //    mt.Invoke(this, new object[] { });
                    //else
                    //    AlertBox.Info("该功能未定义,调用失败");
                }

                if (tag.TabName != "")
                    this.superTabControl1.SelectedTabIndex = this.superTabControl1.Tabs.IndexOf(tag.TabName);
            }
        }

        private static void ShowInfection()
        {
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ShowInfection });
        }
        private static void ShowChronic()
        {
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ShowChronic });
        }
        private static void ShowMZ()
        {
            formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.ShowMZ });
        }
        private void btnInfectionSearch_Click(object sender, EventArgs e)
        {
            if (sender == this.btnInfectionSearch)
                this.advTree1.Nodes.Clear();
            else
                this.advTree2.Nodes.Clear();
            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.UpdateTime >= (this.dtInfectionStartTime.Value.ToShortDateString() + " 00:00:00").AsDateTime() && p.UpdateTime <= (this.dtInfectionEndTime.Value.ToShortDateString() + " 23:59:59").AsDateTime() && p.DeptCode == SysContext.RunSysInfo.currDept.Code && p.Updater == SysContext.CurrUser.user.Name).ToList();

            List<string> time = diagnosis.Select(p => p.UpdateTime.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();

            string sql = "";
            if (sender == this.btnInfectionSearch)
                sql = "Exec YG_Check '0','{0}',0,'0','{1}','{2}'";
            else
                sql = "Exec YG_Check '0','{0}',0,'15','{1}','{2}'";

            foreach (string item in time)
            {
                List<OP_PatientDiagnosis> tmp = diagnosis.Where(p => p.UpdateTime.Value.ToShortDateString() == item).ToList();
                Node node = new Node(item);
                List<string> treatmentno = new List<string>();
                foreach (OP_PatientDiagnosis item1 in tmp)
                {
                    if (treatmentno.Contains(item1.TreatmentNo))
                        continue;
                    string sql1 = string.Format(sql, item1.TreatmentNo, item1.Code, item1.Name);
                    string result = DBHelper.CIS.FromSql(sql1).ToScalar<string>();
                    Node node1;
                    if (result == "1")
                    {
                        node1 = new Node(item1.PatientName + @"     <b><font color=""#000000""></font><font color=""#ED1C24"">需要申报</font></b>");
                        node1.Tag = item1;
                    }
                    else
                        node1 = new Node(item1.PatientName);

                    node1.Name = item1.TreatmentNo;
                    node.Nodes.Add(node1);
                }
                if (sender == this.btnInfectionSearch)
                    this.advTree1.Nodes.Add(node);
                else
                    this.advTree2.Nodes.Add(node);

            }
            if (sender == this.btnInfectionSearch)
                this.advTree1.ExpandAll();
            else
                this.advTree2.ExpandAll();
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                OP_PatientDiagnosis diagnosis = e.Node.Tag as OP_PatientDiagnosis;
                string str = "";
                if (sender == this.advTree1)
                    str = "0";
                else
                    str = "15";
                Infect.Yg_Index(diagnosis.TreatmentNo, diagnosis.DoctorCode, diagnosis.Updater, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, diagnosis.Code, diagnosis.Name, str);
            }
        }

        private void btnSearchHospitalized_Click(object sender, EventArgs e)
        {
            this.advTree3.Nodes.Clear();
            string sql = string.Format("SELECT B.ID AS HasReport,A.* FROM DBO.OP_JOURNAL A LEFT JOIN DBO.OP_HOSPITALIZEDREPORT B ON A.OUTPATIENTNO=B.TREATMENTNO WHERE A.DOCTORNO='{0}' AND UpdateDate>='{1}' AND UpdateDate<='{2}' UNION ALL SELECT B.ID AS HasReport,A.* FROM DBO.OP_JOURNAL_HISTORY A LEFT JOIN DBO.OP_HOSPITALIZEDREPORT B ON A.OUTPATIENTNO=B.TREATMENTNO WHERE A.DOCTORNO='{0}' AND UpdateDate>='{1}' AND UpdateDate<='{2}'", SysContext.CurrUser.user.Code, this.dtHospitalizedStartTime.Value.ToShortDateString() + " 00:00:00", this.dtHospitalizedEndTime.Value.ToShortDateString() + " 23:59:59");
            List<HospitalizedReportExt> hospital = DBHelper.CIS.FromSql(sql).ToList<HospitalizedReportExt>();
            this.lbHospitalCount.Text = hospital.Where(p => p.HasReport != null).Count().ToString() + "张住院单";

            List<string> time = hospital.Select(p => p.UpdateDate.Value.ToShortDateString()).Distinct().OrderByDescending(p => p).ToList();

            foreach (string item in time)
            {
                List<HospitalizedReportExt> patient = hospital.Where(p => p.UpdateDate.Value.ToShortDateString() == item).ToList();
                patient = patient.OrderByDescending(p => p.HasReport).ToList();
                Node node = new Node(item);
                foreach (HospitalizedReportExt item1 in patient)
                {
                    Node node1 = new Node(item1.PatientName + (item1.HasReport != null ? string.Format(@"     <b><font color=""#ED1C24"">{0}</font></b>", "有住院单") : ""));
                    node1.Tag = item1;
                    node.Nodes.Add(node1);
                }
                this.advTree3.Nodes.Add(node);
            }
            this.advTree3.ExpandAll();
        }

        private void advTree3_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag == null) return;

            HospitalizedReportExt report = e.Node.Tag as HospitalizedReportExt;
            if (report.HasReport == null) return;
            OP_HospitalizedReport hospitolized = DBHelper.CIS.From<OP_HospitalizedReport>().Where(p => p.ID == report.HasReport).First();
            FormHospitalizedReport form = new FormHospitalizedReport();
            form.Report = hospitolized;
            form.ShowDialog();
        }

    }
}
