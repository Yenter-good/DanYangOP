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
using DevComponents.DotNetBar;

namespace App_OP
{
    public partial class FormReportManage1 : BaseForm
    {
        public FormReportManage1(FormMain _formMain)
        {
            InitializeComponent();
            formMain = _formMain;
        }

        private void FormReportManage_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private static FormMain formMain;

        //private class Tree
        //{
        //    public string ParentName { get; set; }
        //    public string Name { get; set; }
        //    public string NameSpace { get; set; }
        //    public string Type { get; set; }
        //    public string TabName { get; set; }
        //    public string Method { get; set; }
        //}

        //List<Tree> list = new List<Tree>();
        public void InitTabs()
        {
            var list = this.superTabControl1.Tabs.Cast<SuperTabItem>().Where(p => p.CloseButtonVisible).ToList();

            foreach (SuperTabItem tabItem in list)
                this.superTabControl1.Tabs.Remove(tabItem);
        }

        private void InitUI()
        {
            List<OP_Dic_Report> reports = DBHelper.CIS.From<OP_Dic_Report>().Where(p => p.Status == 0).ToList();

            this.dtInfectionStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtInfectionEndTime.Value = DateTime.Now;
            this.dtChronicStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtChronicEndTime.Value = DateTime.Now;
            this.dtHospitalizedStartTime.Value = DateTime.Now.AddDays(-1);
            this.dtHospitalizedEndTime.Value = DateTime.Now;

            var parentRow = reports.Where(p => p.ParentID == "").OrderBy(p => p.No).ToList();
            foreach (var item in parentRow)
            {
                GridRow row = new GridRow(item.ItemName);
                row.Rows.AddRange(BuildRow(reports, reports.Where(p => p.ParentID == item.ID).OrderBy(p => p.No), item.ItemName));
                this.superGridControl1.PrimaryGrid.Rows.Add(row);
            }
            this.superGridControl1.PrimaryGrid.ExpandAll();


        }

        private List<GridRow> BuildRow(IEnumerable<OP_Dic_Report> reportAll, IEnumerable<OP_Dic_Report> reports, string parentName)
        {
            List<GridRow> result = new List<GridRow>();
            foreach (var item in reports)
            {
                GridRow row = new GridRow(item.ItemName);
                row.Cells[0].CellStyles.Default.Image = Properties.Resources.Cards_16x16;
                row.Tag = item;
                row.Rows.AddRange(BuildRow(reportAll, reportAll.Where(p => p.ParentID == item.ID).OrderBy(p => p.No), item.ItemName));
                result.Add(row);
            }
            return result;
        }

        private Form CreateForm(string NameSpace, string ClassName)
        {
            Form form = null;
            try
            {
                string path = NameSpace;//项目的Assembly选项名称
                string name = ClassName; //类的名字
                form = (Form)Assembly.Load(path).CreateInstance(name);
                Assembly assembly = Assembly.Load(path);
            }
            catch (Exception ex)
            {
                MsgBox.OK("该功能未实现或没有注册\n异常消息：" + ex.Message);
                return null;
            }
            return form;
        }
        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            if (e.GridRow.Rows.Count == 0)
            {
                OP_Dic_Report tag = e.GridRow.Tag as OP_Dic_Report;
                Form form = null;
                if (tag.Type == "窗体")
                {
                    if (tag.Assembly.AsString("") == "" || tag.NameSpace.AsString("") == "")
                        return;
                    form = CreateForm(tag.Assembly, tag.NameSpace);
                    form.Show();

                }
                else if (tag.Type == "方法")
                {
                    Type t = Assembly.Load(tag.Assembly).GetType(tag.NameSpace);//  typeof(FormReportManage);
                    object obj = t.RunFunction(tag.MethodName, new object[] { });
                    if (obj is string)
                        AlertBox.Info("该功能未定义,调用失败");
                }
                else if (tag.Type == "对话框")
                {
                    form = CreateForm(tag.Assembly, tag.NameSpace);
                    form.ShowDialog();
                    formMain.HandleRefreshPatient(new PatientEventArgs() { Mode = PatientEventArgs.UpdateMode.Diagnosis });
                }
                else if (tag.Type == "文档")
                {
                    form = new BaseReportForm(tag.ItemName, tag.XML);
                    form.TopLevel = false;
                    form.Dock = DockStyle.Fill;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Visible = true;

                    var index = this.superTabControl1.Tabs.IndexOf(tag.ItemName);
                    if (index == -1)
                    {
                        var tabItem = this.superTabControl1.CreateTab(tag.ItemName);
                        tabItem.CloseButtonVisible = true;
                        tabItem.AttachedControl.Controls.Add(form);
                        tabItem.Name = tag.ItemName;
                        this.superTabControl1.Tabs.Add(tabItem);
                        this.superTabControl1.SelectedTab = tabItem;
                    }
                    else
                        this.superTabControl1.SelectedTabIndex = index;
                }

                //if (tag.TabName != "")
                //    this.superTabControl1.SelectedTabIndex = this.superTabControl1.Tabs.IndexOf(tag.TabName);
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
            DateTime startDateTime, endDateTime;
            if (sender == this.btnInfectionSearch)
            {
                startDateTime = this.dtInfectionStartTime.Value.Date;
                endDateTime = this.dtInfectionEndTime.Value.Date.AddDays(1).AddSeconds(-1);
                this.advTree1.Nodes.Clear();
            }

            else
            {
                startDateTime = this.dtChronicStartTime.Value.Date;
                endDateTime = this.dtChronicStartTime.Value.Date.AddDays(1).AddSeconds(-1);
                this.advTree2.Nodes.Clear();
            }

            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.UpdateTime >= startDateTime && p.UpdateTime <= endDateTime && p.DeptCode == SysContext.RunSysInfo.currDept.Code && p.Updater == SysContext.CurrUser.user.Name).ToList();

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
    }
}

