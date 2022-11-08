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
    public partial class FormSpecialItemReport : BaseForm
    {
        public FormSpecialItemReport()
        {
            InitializeComponent();
        }


        private void InitUI()
        {
            List<OP_SpecialMaterialReport> Report = DBHelper.CIS.From<OP_SpecialMaterialReport>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();

            if (Report.Count != 0)
            {
                OP_SpecialMaterialReport tmp1 = Report[0];
                this.txWriterControl1.XMLText = tmp1.Content;
                return;
            }
            try
            {
                XTextInputFieldElement input = this.txWriterControl1.GetElementById("PatientName") as XTextInputFieldElement;
                input.Text = SysContext.GetCurrPatient.PatientName;
                input = this.txWriterControl1.GetElementById("PatientSex") as XTextInputFieldElement;
                input.Text = SysContext.GetCurrPatient.Sex;
                input = this.txWriterControl1.GetElementById("PatientAge") as XTextInputFieldElement;
                input.Text = SysContext.GetCurrPatient.Age;
                input = this.txWriterControl1.GetElementById("PatientName") as XTextInputFieldElement;
                input.Text = SysContext.GetCurrPatient.PatientName;
                input = this.txWriterControl1.GetElementById("TreatmentNo") as XTextInputFieldElement;
                input.Text = SysContext.GetCurrPatient.OutpatientNo;
                input = this.txWriterControl1.GetElementById("DeptName") as XTextInputFieldElement;
                input.Text = SysContext.RunSysInfo.currDept.Name;
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OP_SpecialMaterialReport report = new OP_SpecialMaterialReport();
            report.ID = Guid.NewGuid().ToString();
            report.Content = this.txWriterControl1.XMLTextUnFormatted;
            report.DoctorCode = SysContext.CurrUser.user.Code;
            report.DeptCode = SysContext.RunSysInfo.currDept.Code;
            report.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            report.UpdateTime = DateTime.Now;

            DBHelper.CIS.Delete<OP_SpecialMaterialReport>(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo);
            DBHelper.CIS.Insert(report);
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
                AlertBox.Error("未选择病人,无法填写特殊材料审批");
                this.Close();
                return;
            }

            this.txWriterControl1.LoadDocumentFromString(SysParams.GetSpecialItem, "XML");
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
            InitUI();
        }
    }
}
