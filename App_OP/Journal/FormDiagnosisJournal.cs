using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CIS.Model;
using CIS.Core;
using CIS.Utility;

namespace App_OP
{
    public partial class FormDiagnosisJournal : BaseForm
    {
        public FormDiagnosisJournal()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            this.dtStartTime.Value = DateTime.Now.AddMonths(-1);
            this.dtEndTime.Value = DateTime.Now;
        }

        private void InitData()
        {
            string deptCode = SysContext.RunSysInfo.currDept.Code;
            var result = DBHelper.CIS.FromSql(string.Format("SELECT Name,COUNT(NAME)AS Num FROM (SELECT NAME FROM OP_PatientDiagnosis WHERE DeptCode='{0}' AND UpdateTime>='{1}' AND UpdateTime<='{2}' UNION ALL SELECT NAME FROM OP_PatientDiagnosis_History WHERE DeptCode='{0}' AND UpdateTime>='{1}' AND UpdateTime<='{2}') DIAGNOSIS GROUP BY NAME ORDER BY NUM DESC", deptCode, this.dtStartTime.Value.ToShortDateString() + " 00:00:00", this.dtEndTime.Value.ToShortDateString() + " 23:59:59")).ToDataTable();
            this.dgvJournal.PrimaryGrid.DataSource = result;
        }

        private void FormDiagnosisJournal_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExcelHelper.ExportXLS(this.dgvJournal, this.saveFileDialog1.FileName);
        }
    }
}
