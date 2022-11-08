using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Purview;
using CIS.Core;
using CIS.Model;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace App_OP
{
    public partial class FormInfectionReport : FormCancelUnenabled
    {
        public FormInfectionReport()
        {
            InitializeComponent();
        }

        public OP_Journal journal;
        public List<OP_PatientDiagnosis> diagnosis;

        private void FormInfectionReport_Shown(object sender, EventArgs e)
        {
            InitData();
            Application.DoEvents();
            this.txWriterControl1.RefreshDocument();
        }

        private void InitData()
        {
            string patientID = SysContext.GetCurrPatient.PatientID;
            string xml = DBHelper.CIS.From<OP_InfectionReport>().Where(p => p.PatientID == patientID).Select(p => p.XMLDocument).ToScalar<string>();
            if (xml == null)
            {
                this.txWriterControl1.XMLText = SysParams.GetInfectionReport;
                SetData();
            }
            else
                this.txWriterControl1.XMLText = xml;
        }

        private void SetData()
        {
            PropertyInfo[] property = journal.GetType().GetProperties();
            foreach (OP_PatientDiagnosis item in diagnosis)
            {
                XTextCheckBoxElement input = this.txWriterControl1.GetElementById(item.Code) as XTextCheckBoxElement;
                if (input != null)
                    input.Checked = true;
            }
            foreach (PropertyInfo item in property)
            {
                XTextElementList input = this.txWriterControl1.GetElementsById(item.Name);
                if (input.Count > 0)
                {
                    if (input.Count > 1)
                    {
                        XTextElement element = input.Find(p => (p as XTextCheckBoxElement).Caption == item.GetValue(journal, null).ToString() || (p as XTextCheckBoxElement).Caption == item.GetValue(journal, null).ToString() + "、");
                        if (element != null)
                            (element as XTextCheckBoxElement).Checked = true;
                    }
                    else
                        if (input[0] is XTextInputFieldElement)
                            (input[0] as XTextInputFieldElement).Text = item.GetValue(journal, null).ToString();
                        else
                            (input[0] as XTextCheckBoxElement).Checked = true;
                }
            }

            XTextInputFieldElement input1 = this.txWriterControl1.GetElementById("CardID") as XTextInputFieldElement;
            input1.Text = DateTime.Now.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OP_InfectionReport report = new OP_InfectionReport();
            report.ID = Guid.NewGuid().ToString();
            report.XMLDocument = this.txWriterControl1.XMLTextUnFormatted;
            report.DeptCode = SysContext.RunSysInfo.currDept.Code;
            report.DeptName = SysContext.RunSysInfo.currDept.Name;
            report.DoctorCode = SysContext.CurrUser.user.Code;
            report.DoctorName = SysContext.CurrUser.user.Name;
            report.PatientID = SysContext.GetCurrPatient.PatientID;
            report.PatientName = SysContext.GetCurrPatient.PatientName;
            report.UpdateTime = DateTime.Now;
            DBHelper.CIS.Delete<OP_InfectionReport>(p => p.PatientID == report.PatientID);
            DBHelper.CIS.Insert<OP_InfectionReport>(report);
            AlertBox.Info("保存成功");
            this.Close();
        }
    }
}
