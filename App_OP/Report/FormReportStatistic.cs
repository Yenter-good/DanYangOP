using CIS.Core;
using CIS.Model;
using CIS.Purview;
using DCSoft.Writer.Dom;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 创建人:Yenter
/// 创建时间:2020-09-09 09:02:47
/// 功能:
/// </summary>
namespace App_OP
{
    public partial class FormReportStatistic : BaseForm
    {
        private string _selectedReportType;

        public FormReportStatistic()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            List<OP_Dic_Report> reports = DBHelper.CIS.From<OP_Dic_Report>().ToList();

            this.dtStartDateTime.Value = DateTime.Now.AddDays(-7);
            this.dtEndDateTime.Value = DateTime.Now;
            this.dtStartDateTime1.Value = DateTime.Now.AddDays(-7);
            this.dtEndDateTime1.Value = DateTime.Now;

            var parentRow = reports.Where(p => p.ParentID == "").OrderBy(p => p.No).ToList();
            foreach (var item in parentRow)
            {
                var childReports = reports.Where(p => p.ParentID == item.ID && p.CanStatistic).OrderBy(p => p.No);
                if (childReports.Count() == 0)
                    continue;

                GridRow row = new GridRow(item.ItemName);
                row.Rows.AddRange(BuildRow(reports, childReports, item.ItemName));
                this.superGridControl1.PrimaryGrid.Rows.Add(row);
            }
            this.superGridControl1.PrimaryGrid.ExpandAll();

            this.cbxDept.DataSource = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1).ToDataTable();
            this.cbxDept.DisplayMember = "Name";
            this.cbxDept.ValueMember = "Code";
            this.cbxDept.FilterFields = new string[] { "SearchCode" };
        }

        private List<GridRow> BuildRow(IEnumerable<OP_Dic_Report> reportAll, IEnumerable<OP_Dic_Report> reports, string parentName)
        {
            List<GridRow> result = new List<GridRow>();
            foreach (var item in reports)
            {
                var childReports = reports.Where(p => p.ParentID == item.ID).OrderBy(p => p.No);

                GridRow row = new GridRow(item.ItemName);
                row.Cells[0].CellStyles.Default.Image = Properties.Resources.Cards_16x16;
                row.Tag = item;
                row.Rows.AddRange(BuildRow(reportAll, childReports, item.ItemName));
                result.Add(row);
            }
            return result;
        }

        private void btnInfectionSearch_Click(object sender, EventArgs e)
        {
            var selectedRows = this.superGridControl1.GetSelectedRows();
            if (selectedRows.Count == 0)
                return;

            var selectedRow = selectedRows[0] as GridRow;
            _selectedReportType = selectedRow.Cells[0].Value.AsString();

            this.advTree1.Nodes.Clear();
            if (this.checkBoxX1.Checked)
                SearchByName(_selectedReportType);
            else
                SearchByTreatmentNo(_selectedReportType);

        }

        private void checkBoxX2_CheckedChangedEx(object sender, DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs e)
        {
            if (e.NewChecked.Checked)
                this.labelX3.Text = e.NewChecked.Text + "：";
        }

        private void SearchByName(string reportName)
        {
            var sql = $@"
select brxm,jzh,ghrq,ksmc from ghbrzl where ghrq>='{this.dtStartDateTime.Value.Date}' and ghrq<='{this.dtEndDateTime.Value.Date}' and brxm ='{this.tbxSearchCode.Text}'
union all 
select brxm,jzh,ghrq,ksmc from ghbrlsk where ghrq>='{this.dtStartDateTime.Value.Date}' and ghrq<='{this.dtEndDateTime.Value.Date}' and brxm ='{this.tbxSearchCode.Text}'
";
            var dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            var deptNames = dt.Rows.Cast<DataRow>().Select(p => p["ksmc"].ToString()).Distinct().ToList<string>();

            new System.Threading.Thread(() =>
            {
                foreach (var deptName in deptNames)
                {
                    Node node = new Node(deptName);
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        this.advTree1.Nodes.Add(node);
                        node.ExpandAll();
                    });

                    var rows = dt.Select($"ksmc='{deptName}'");
                    foreach (var row in rows)
                    {
                        bool exists = false;
                        exists = DBHelper.CIS.Exists<OP_Report>(p => p.TreatmentNo == row["jzh"].ToString() && p.ReportType == reportName);
                        var existsText = exists ? $" <font color=\"#ED1C24\">有记录</font>" : " ";
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            Node childNode = new Node($"{row["brxm"].ToString()} {row["jzh"].ToString().Trim()}{existsText}");
                            childNode.Tag = row["jzh"].ToString().Trim();
                            node.Nodes.Add(childNode);
                        });
                    }
                }
            });
        }

        private void SearchByTreatmentNo(string reportName)
        {
            var model = DBHelper.CIS.From<OP_Report>().Where(p => p.TreatmentNo == this.tbxSearchCode.Text && p.UpdateTime >= this.dtStartDateTime.Value.Date && p.UpdateTime <= this.dtEndDateTime.Value.Date && p.ReportType == reportName).First();

            if (model == null)
                return;

            Node node = new Node(model.DeptName);
            Node childNode = new Node($"{model.PatientName} + {model.TreatmentNo} <font color=\"#ED1C24\">有记录</font>");
            childNode.Tag = model.TreatmentNo;
            node.Nodes.Add(childNode);

            this.advTree1.Nodes.Add(node);
        }

        private void FormReportStatistic_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            var treatmentNo = e.Node.Tag.ToString();

            var xml = DBHelper.CIS.From<OP_Report>().Where(p => p.TreatmentNo == treatmentNo && p.ReportType == _selectedReportType).Select(p => p.Content).ToScalar<string>();
            this.txWriterControl1.XMLText = "";
            if (xml != null)
                this.txWriterControl1.XMLText = xml;
        }

        private void cbxDept_TextChanged(object sender, EventArgs e)
        {
            string value = this.cbxDept.SelectedValue.ToString();
            DataTable user = DBHelper.CIS.From<IView_User>().Where(p => p.Dept_Code == value).ToDataTable();

            this.cbxDoctor.DataSource = user;
            this.cbxDoctor.DisplayMember = "Name";
            this.cbxDoctor.ValueMember = "Code";
            this.cbxDoctor.FilterFields = new string[] { "SearchCode" };
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.advTree2.Nodes.Clear();

            string value = this.cbxDoctor.SelectedValue.AsString("");
            if (value == "")
                return;

            var models = DBHelper.CIS.From<OP_Report>().Where(p => p.UpdateTime >= this.dtStartDateTime1.Value.Date && p.UpdateTime <= this.dtEndDateTime1.Value.AddDays(1).Date && p.DoctorID == value).Select(p => new { p.ReportType, p.UpdateTime, p.PatientName, p.TreatmentNo }).ToList();


            var reportTypes = models.Select(p => p.ReportType).Distinct().ToList();
            foreach (var reportType in reportTypes)
            {
                var datetimes = models.Where(p => p.ReportType == reportType).Select(p => p.UpdateTime.Value.Date).Distinct().OrderByDescending(p => p).ToList();
                Node parent = new Node(reportType + $"({models.Count(p => p.ReportType == reportType)}份)");
                foreach (var dt in datetimes)
                {
                    var model = models.Where(p => p.UpdateTime.Value.Date == dt).ToList();
                    var time = new Node(dt.ToShortDateString());
                    parent.Nodes.Add(time);
                    foreach (var item in model)
                    {
                        var child = new Node($"{item.PatientName} {item.TreatmentNo}");
                        child.Name = item.TreatmentNo;
                        child.Tag = reportType;
                        time.Nodes.Add(child);
                    }
                }
                this.advTree2.Nodes.Add(parent);
            }

            var count = AddInHospitalTree();
            this.labelX8.Text = "总计:" + (models.Count + count) + "份";
            this.advTree2.ExpandAll();

        }
        /// <summary>
        /// 新增住院登记单统计
        /// </summary>
        private int AddInHospitalTree()
        {
            string value = this.cbxDoctor.SelectedValue.AsString("");
            if (value == "")
                return 0;
            var inHosReports = DBHelper.CIS.FromSql($@"select h.*,j.ProcessTime from OP_HospitalizedReport as h
                inner join (select * from OP_Journal union all select * from OP_Journal_History) as j
                on h.TreatmentNo = j.OutpatientNo
                where j.ProcessTime <= '{this.dtEndDateTime1.Value.AddDays(1).Date}' and j.ProcessTime >= '{this.dtStartDateTime1.Value.Date}' and h.DoctorID = '{value}'").ToList<OP_HospitalizedReport>();
            Node parent = new Node($"住院登记单({inHosReports.Count()}份)");
            var datetimes = inHosReports.Select(p => p.ProcessTime.Value.Date).Distinct().OrderByDescending(p => p).ToList();
            foreach (var dt in datetimes)
            {
                var model = inHosReports.Where(p => p.ProcessTime.Value.Date == dt).ToList();
                var time = new Node(dt.ToShortDateString());
                parent.Nodes.Add(time);
                foreach (var item in model)
                {
                    var child = new Node($"{item.PatientName} {item.TreatmentNo}");
                    child.Name = item.TreatmentNo;
                    child.Tag = item;
                    time.Nodes.Add(child);
                }
            }             
            this.advTree2.Nodes.Add(parent);
            return inHosReports.Count;
        }

        private void advTree2_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag is OP_HospitalizedReport hospitalizedReport)
            {
                this.txWriterControl2.LoadDocumentFromString(SysParams.GetHospitalizedReport, "XML");
                this.txWriterControl2.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
                InitData(hospitalizedReport);
            }

            var tag = e.Node.Tag.AsString("");

            if (tag == "")
                return;

            var xml = DBHelper.CIS.From<OP_Report>().Where(p => p.TreatmentNo == e.Node.Name && p.ReportType == tag).Select(p => p.Content).ToScalar<string>();
            this.txWriterControl2.XMLText = xml;
        }

        private void InitData(OP_HospitalizedReport hospitalizedReport)
        {
            var properties = hospitalizedReport.GetType().GetProperties();
            foreach (var item in properties)
            {
                try
                {
                    XTextInputFieldElement input = this.txWriterControl2.GetElementById(item.Name) as XTextInputFieldElement;
                    if (input != null)
                        input.Text = item.GetValue(hospitalizedReport, null).AsString("");
                }
                catch
                {
                }
            }

            XTextBarcodeFieldElement bar = this.txWriterControl2.GetElementById("bar") as XTextBarcodeFieldElement;
            if (bar != null)
                bar.Text = hospitalizedReport.TreatmentNo;

            string elementName = "checkbox" + (hospitalizedReport.InHosType.AsInt() + 1).ToString();
            XTextRadioBoxElement radio = this.txWriterControl2.GetElementById(elementName) as XTextRadioBoxElement;
            if (radio != null)
                radio.Checked = true;
        }

    }
}
