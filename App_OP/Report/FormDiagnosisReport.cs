using CIS.Core;
using CIS.Model;
using CIS.Purview;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP
{
    public partial class FormDiagnosisReport : BaseForm
    {
        public FormDiagnosisReport()
        {
            InitializeComponent();
        }

        List<IView_HIS_ICD> ICD = new List<IView_HIS_ICD>();

        private void InitUI()
        {
            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            List<OP_DiagnosisReport> Report = DBHelper.CIS.From<OP_DiagnosisReport>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            List<OP_Journal> journal = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            if (Report.Count != 0)
            {
                OP_DiagnosisReport tmp1 = Report[0];
                this.txWriterControl1.XMLText = tmp1.Content;
                return;
            }

            Dictionary<string, string> dictInput = new Dictionary<string, string>();
            dictInput.Add("PatientName", SysContext.GetCurrPatient.PatientName.Trim());
            dictInput.Add("PatientSex", SysContext.GetCurrPatient.Sex.Trim());
            dictInput.Add("PatientDiagnosis", string.Join(",", diagnosis.Select(p => p.Name).ToArray()).Trim());
            dictInput.Add("DeptName", SysContext.RunSysInfo.currDept.Name.Trim());
            dictInput.Add("DoctorName", SysContext.CurrUser.user.Name.Trim());
            dictInput.Add("Date", string.Format("{0:yyyy年MM月dd日}", DateTime.Now));
            dictInput.Add("PhoneNumber", journal.Count == 0 ? "" : journal[0].PhoneNumber);
            dictInput.Add("Age", SysContext.GetCurrPatient.Age.Trim());
            dictInput.Add("TreatmentNo", SysContext.GetCurrPatient.OutpatientNo.Trim());

            XTextInputFieldElement input;
            foreach (var item in dictInput)
            {
                input = this.txWriterControl1.GetElementById(item.Key) as XTextInputFieldElement;
                if (input != null)
                    input.Text = item.Value;
            }

            //XTextInputFieldElement input = this.txWriterControl1.GetElementById("PatientName") as XTextInputFieldElement;
            //input.Text = SysContext.GetCurrPatient.PatientName;
            //input = this.txWriterControl1.GetElementById("PatientSex") as XTextInputFieldElement;
            //input.Text = SysContext.GetCurrPatient.Sex;
            //input = this.txWriterControl1.GetElementById("PatientDiagnosis") as XTextInputFieldElement;
            //input.Text = string.Join(",", diagnosis.Select(p => p.Name).ToArray());
            //input = this.txWriterControl1.GetElementById("DeptName") as XTextInputFieldElement;
            //input.Text = SysContext.RunSysInfo.currDept.Name;
            //input = this.txWriterControl1.GetElementById("DoctorName") as XTextInputFieldElement;
            //input.Text = SysContext.CurrUser.user.Name;
            //input = this.txWriterControl1.GetElementById("Date") as XTextInputFieldElement;
            //input.Text = string.Format("{0:yyyy年MM月dd日}", DateTime.Now);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OP_DiagnosisReport report = new OP_DiagnosisReport();
            report.ID = Guid.NewGuid().ToString();
            report.Content = this.txWriterControl1.XMLTextUnFormatted;
            report.DoctorID = SysContext.CurrUser.user.Code;
            report.DoctorName = SysContext.CurrUser.user.Name;
            report.DeptCode = SysContext.RunSysInfo.currDept.Code;
            report.DeptName = SysContext.RunSysInfo.currDept.Name;
            report.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            DBHelper.CIS.Delete<OP_DiagnosisReport>(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo);
            DBHelper.CIS.Insert<OP_DiagnosisReport>(report);
            AlertBox.Info("保存成功");
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FileCleanPrint, false, null);
        }

        private void FormDiagnosisReport_Shown(object sender, EventArgs e)
        {
            IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
            if (patient == null)
            {
                AlertBox.Error("未选择病人,无法填写诊断报告单");
                this.Close();
                return;
            }

            this.txWriterControl1.LoadDocumentFromString(SysParams.GetDiagnosisReport, "XML");
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            InitUI();
        }
    }
}
