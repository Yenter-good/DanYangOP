using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Utility;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP
{
    public partial class FormAllJournal : BaseForm
    {
        public FormAllJournal()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            List<IView_Dept> dept = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1).ToList();
            dept.Insert(0, new IView_Dept() { Name = "全部", Code = "*" });
            this.comboBoxEx1.DisplayMember = "Name";
            this.comboBoxEx1.ValueMember = "Code";
            this.comboBoxEx1.DataSource = dept;

            this.StartTime.Value = DateTime.Now.AddDays(-1);
            this.EndTime.Value = DateTime.Now;
            this.dgvJournal.PrimaryGrid.AutoGenerateColumns = false;
        }

        private void FormAllJournal_Shown(object sender, EventArgs e)
        {
            InitData();

        }

        private List<TreeNode> a(TreeNodeCollection b)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode item in b)
            {
                if (item.Checked)
                    result.Add(item);
                if (item.Nodes.Count > 0)
                    result.AddRange(a(item.Nodes));
            }
            return result;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            string deptCode = this.comboBoxEx1.SelectedValue.ToString();
            List<OP_Journal_Ext> list = new List<OP_Journal_Ext>();

            string sql = "";

            if (deptCode == "*")
            {
                sql = $@"
select * from (
select
stuff(
(select
char(10) +
(case when pd.ISMAIN = 1 then (case when pd.IsHMDiagnosis = 0 then '西医诊断：' else '中医诊断：' end) else '' end)
+ (case when pd.ISMAIN = 1 then '' else '          ' end)
+ cast(row_number()over(PARTITION by pd.treatmentno, pd.IsHMDiagnosis  order by pd.IsMain desc, pd.[index]) as varchar(50))
+ '、' + pd.[name]
from(select TreatmentNo, IsHMDiagnosis, IsMain,[Index],[Name] from OP_PatientDiagnosis union all select TreatmentNo, IsHMDiagnosis, IsMain,[Index],[Name] from OP_PatientDiagnosis_History) pd
where pd.TreatmentNo = a.OutpatientNo
for xml path(''))
,1,1,'') as Name,
a.*
from(SELECT * FROM OP_Journal WHERE ProcessTime >= '{this.StartTime.Value.ToShortDateString() + " 00:00:00"}' and ProcessTime <= '{this.EndTime.Value.ToShortDateString() + " 23:59:59"}' UNION ALL SELECT * FROM OP_Journal_History WHERE ProcessTime >= '{this.StartTime.Value.ToShortDateString() + " 00:00:00"}' and ProcessTime <= '{this.EndTime.Value.ToShortDateString() + " 23:59:59"}') a WHERE 1=1 ) a";
            }
            else
            {
                sql = $@"
select * from (
select
stuff(
(select
char(10) +
(case when pd.ISMAIN = 1 then (case when pd.IsHMDiagnosis = 0 then '西医诊断：' else '中医诊断：' end) else '' end)
+ (case when pd.ISMAIN = 1 then '' else '          ' end)
+ cast(row_number()over(PARTITION by pd.treatmentno, pd.IsHMDiagnosis  order by pd.IsMain desc, pd.[index]) as varchar(50))
+ '、' + pd.[name]
from(select TreatmentNo, IsHMDiagnosis, IsMain,[Index],[Name] from OP_PatientDiagnosis union all select TreatmentNo, IsHMDiagnosis, IsMain,[Index],[Name] from OP_PatientDiagnosis_History) pd
where pd.TreatmentNo = a.OutpatientNo
for xml path(''))
,1,1,'') as Name,
a.*
from(SELECT * FROM OP_Journal WHERE ProcessTime >= '{this.StartTime.Value.ToShortDateString() + " 00:00:00"}' and ProcessTime <= '{this.EndTime.Value.ToShortDateString() + " 23:59:59"}' UNION ALL SELECT * FROM OP_Journal_History WHERE ProcessTime >= '{this.StartTime.Value.ToShortDateString() + " 00:00:00"}' and ProcessTime <= '{this.EndTime.Value.ToShortDateString() + " 23:59:59"}') a
where a.DeptCode = '{deptCode}' ) a";
            }

            sql += " order by a.ProcessTime desc";

            list = DBHelper.CIS.FromSql(sql).ToList<OP_Journal_Ext>();

            this.labelX1.Text = "总接诊人数：" + list.Count + "人";
            this.dgvJournal.PrimaryGrid.DataSource = list;
            this.dgvJournal.PrimaryGrid.ClearSelectedCells();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExcelHelper.ExportXLS(this.dgvJournal, this.saveFileDialog1.FileName);
        }

        private void dgvJournal_RowDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs e)
        {
            string treatmentno = (e.GridRow as GridRow).Cells["col_OutpatientNo"].Value.ToString();
            FormWriteJournal form = new FormWriteJournal();
            List<IView_HIS_Outpatients> list = DBHelper.CIS.From<IView_HIS_Outpatients>().Where(p => p.OutpatientNo == treatmentno).ToList();
            if (list.Count == 0)
            {
                list = DBHelper.CIS.From<IView_HIS_Outpatients_All>().Where(p => p.OutpatientNo == treatmentno).ToList<IView_HIS_Outpatients>();
                if (list.Count == 0)
                    return;
            }
            form.currPatient = list[0];
            form.ShowDialog();
            btnQuery_Click(null, null);
        }
    }


}
