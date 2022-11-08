using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    public partial class FormInfectionCheck : BaseForm
    {
        public FormInfectionCheck()
        {
            InitializeComponent();
        }
        List<OP_InfectionReport> list = new List<OP_InfectionReport>();
        int index = 0;
        private void InitData()
        {
            try
            {
                list = DBHelper.CIS.From<OP_InfectionReport>().Where(p => p.UpdateTime > this.dateTimeInput1.Value && p.UpdateTime < this.dateTimeInput2.Value).OrderBy(p => p.UpdateTime).ToList();
            }
            catch
            {
            }
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            InitData();
            if (list.Count == 0)
                return;
            index = 0;
            this.txWriterControl1.XMLText = list[index].XMLDocument.ToString();
        }

        private void RefreshLabel(OP_InfectionReport report)
        {
            this.labelX1.Text = "科室：" + report.DeptName;
            this.labelX2.Text = "医生姓名：" + report.DoctorName;
            this.labelX3.Text = "病人姓名：" + report.PatientName;
            this.labelX4.Text = "日期：" + report.UpdateTime.Value.ToShortDateString();

            this.labelX2.Left = this.labelX1.Left + this.labelX1.Width + 20;
            this.labelX3.Left = this.labelX2.Left + this.labelX2.Width + 20;
            this.labelX4.Left = this.labelX3.Left + this.labelX3.Width + 20;
        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            if (index >= list.Count - 1)
                return;
            this.txWriterControl1.XMLText = list[++index].XMLDocument.ToString();
        }

        private void panelEx4_Click(object sender, EventArgs e)
        {
            if (index <= 0)
                return;
            this.txWriterControl1.XMLText = list[--index].XMLDocument.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
                return;
            OP_InfectionReport report = list[index];
            report.XMLDocument = this.txWriterControl1.XMLTextUnFormatted;
            DBHelper.CIS.Update<OP_InfectionReport>(report);
            CIS.Core.AlertBox.Info("保存成功");
        }

        private void FormInfectionCheck_Shown(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = DateTime.Now.AddMonths(-1);
            this.dateTimeInput2.Value = DateTime.Now;
        }
    }
}
