using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Utility;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;
using System.Threading;
using System.Linq;
using static App_OP.FormJournal;

namespace App_OP
{
    public partial class FormAllJournal : BaseForm
    {
        private List<OP_Journal_Ext> _allJournal;
        BindingSource bs = new BindingSource();

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
            this.dgvJournal.AutoGenerateColumns = false;
            this.dgvJournal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void FormAllJournal_Shown(object sender, EventArgs e)
        {
            InitData();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string deptCode = this.comboBoxEx1.SelectedValue.ToString();

            string sql = "";

            if (deptCode == "*")
            {
                sql = $@"
select * from (
select * from op_journal where ProcessTime>='{this.StartTime.Value.Start()}' and ProcessTime<='{this.EndTime.Value.End()}'
union all
select * from op_journal_history where ProcessTime>='{this.StartTime.Value.Start()}' and ProcessTime<='{this.EndTime.Value.End()}') a order by ProcessTime desc
";
            }
            else
            {
                sql = $@"
select * from (
select * from op_journal where ProcessTime>='{this.StartTime.Value.Start()}' and ProcessTime<='{this.EndTime.Value.End()}' and deptcode='{deptCode}'
union all
select * from op_journal_history where ProcessTime>='{this.StartTime.Value.Start()}' and ProcessTime<='{this.EndTime.Value.End()}' and deptcode='{deptCode}') a order by ProcessTime desc
";
            }

            _allJournal = DBHelper.CIS.FromSql(sql).ToList<OP_Journal_Ext>();

            _allJournal.ForEach(p =>
            {
                if (!p.BloodPressure1.IsNullOrWhiteSpace())
                    p.BloodPressure = p.BloodPressure1 + "~" + p.BloodPressure2 + "mmHg";
                p.Birthday = string.Format("{0:yyyy年MM月dd日}", p.Birthday.AsDateTime());
                p.DA = string.Format("{0:yyyy年MM月dd日}", p.DA.AsDateTime());
            });
            this.labelX1.Text = "总接诊人数：" + _allJournal.Count + "人";
            this.progressBar1.Show();
            this.label1.Text = "正在加载\r\n请稍后";
            this.progressBar1.Maximum = _allJournal.Count;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Value = 0;
            this.panel1.Show();

            new Thread(SearchDiagnosis).Start();
        }

        private void SearchDiagnosis()
        {
            var treatmentNos = _allJournal.Select(p => p.OutpatientNo).Distinct().ToList();
            int skip = 0;
            while (true)
            {
                if (skip >= treatmentNos.Count)
                    break;
                var tmp = treatmentNos.Skip(skip).Take(500);
                skip += 500;

                var treatmentNo = string.Join("','", tmp);
                var sql = $@"
select * from (SELECT name,treatmentno,type,[index] from op_patientdiagnosis union all select name,treatmentno,type,[index] from op_patientdiagnosis_history) a where treatmentno in ('{treatmentNo}')
";
                var diagnosis = DBHelper.CIS.FromSql(sql).ToList<PatientDiagnosis>();

                foreach (var journal in _allJournal.Where(p => tmp.Contains(p.OutpatientNo)))
                {
                    var diag = diagnosis.Where(p => p.TreatmentNo == journal.OutpatientNo);
                    var wm = diag.Where(p => p.Type == 0).OrderBy(p => p.Index);
                    List<string> format = new List<string>();
                    int index = 1;
                    if (wm.Count() > 0)
                    {
                        format.Add("西医诊断");
                        foreach (var item in wm)
                            format.Add($"    {index++}.{item.Name}");
                    }
                    var hm = diag.Where(p => p.Type != 0).OrderBy(p => p.Type).ThenBy(p => p.Index);
                    if (hm.Count() > 0)
                    {
                        format.Add($"中医诊断");
                        index = 1;
                        foreach (var item in hm)
                            format.Add($"    {index++}.{item.Name}");
                    }
                    journal.Name = string.Join(Environment.NewLine, format);
                }

                try
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        if (this.progressBar1.Value + 500 > this.progressBar1.Maximum)
                            this.progressBar1.Value = this.progressBar1.Maximum;
                        else
                            this.progressBar1.Value += 500;
                    });
                }
                catch
                {
                    return;
                }


            }
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (this.IsDisposed || this.Disposing)
                        return;
                    this.label1.Text = "正在构建界面\r\n请稍后";
                    this.progressBar1.Hide();
                    Application.DoEvents();
                    bs = new BindingSource();
                    bs.DataSource = _allJournal;

                    this.dgvJournal.DataSource = bs;
                    Application.DoEvents();
                    this.panel1.Hide();
                });
            }
            catch
            {
                return;
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExcelHelper.ExportXLS(this.dgvJournal, this.saveFileDialog1.FileName);
        }

        private void dgvJournal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string treatmentno = this.dgvJournal.Rows[e.RowIndex].Cells[colTreatmentNo.Index].Value.ToString();
            FormWriteJournal form = new FormWriteJournal();
            List<IView_HIS_Outpatients> list = DBHelper.CIS.From<IView_HIS_Outpatients_All>().Where(p => p.OutpatientNo == treatmentno).ToList<IView_HIS_Outpatients>();
            if (list.Count == 0)
                return;

            form.currPatient = list[0];
            if (form.ShowDialog() == DialogResult.OK)

            {
                var currJournal = _allJournal.FirstOrDefault(p => p.OutpatientNo == treatmentno);
                if (currJournal != null)
                {
                    var journal = form.CurrentJournal;
                    currJournal.PatientName = journal.PatientName;
                    currJournal.Age = journal.Age;
                    currJournal.Sex = journal.Sex;
                    currJournal.Birthday = journal.Birthday;
                    currJournal.Stature = journal.Stature;
                    currJournal.Marry = journal.Marry;
                    currJournal.Blood = journal.Blood;
                    currJournal.Wight = journal.Wight;
                    currJournal.Nation = journal.Nation;
                    currJournal.Nationality = journal.Nationality;
                    currJournal.Origin = journal.Origin;
                    currJournal.IDCard = journal.IDCard;
                    currJournal.Knowlage = journal.Knowlage;
                    currJournal.BirthPlace = journal.BirthPlace;
                    currJournal.Address = journal.Address;
                    currJournal.Email = journal.Email;
                    currJournal.PhoneNumber = journal.PhoneNumber;
                    currJournal.ContactsName = journal.ContactsName;
                    currJournal.Job = journal.Job;
                    currJournal.JobAddress = journal.JobAddress;
                    currJournal.JobPhone = journal.JobPhone;
                    currJournal.Remark = journal.Remark;
                    currJournal.FirstOrMany = journal.FirstOrMany;
                    currJournal.DA = journal.DA;
                    currJournal.BloodPressure1 = journal.BloodPressure1;
                    currJournal.BloodPressure2 = journal.BloodPressure2;
                    if (!currJournal.BloodPressure1.IsNullOrWhiteSpace())
                        currJournal.BloodPressure = currJournal.BloodPressure1 + "~" + currJournal.BloodPressure2 + "mmHg";
                    else
                        currJournal.BloodPressure = "";
                    currJournal.Birthday = string.Format("{0:yyyy年MM月dd日}", currJournal.Birthday.AsDateTime());
                    currJournal.DA = string.Format("{0:yyyy年MM月dd日}", currJournal.DA.AsDateTime());

                    bs.ResetBindings(false);
                    this.dgvJournal.Invalidate();
                }
            }
        }
    }


}
