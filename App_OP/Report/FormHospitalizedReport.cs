using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Purview;
using CIS.Core;
using CIS.Model;
using DCSoft.Writer.Dom;
using System.Reflection;
using DCSoft.Writer.Data;

namespace App_OP
{
    public partial class FormHospitalizedReport : BaseForm
    {
        public FormHospitalizedReport()
        {
            InitializeComponent();
        }

        List<IView_Dept> dept = new List<IView_Dept>();
        List<IView_HIS_ICD> ICD = new List<IView_HIS_ICD>();
        public OP_HospitalizedReport Report;

        public string Diagnosis
        { get; set; }

        private void FormHospitalizedReport_Shown(object sender, EventArgs e)
        {
            if (Report != null)
            {
                this.txWriterControl1.XMLText = Report.Content;
                return;
            }

            dept = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 3).ToList();
            ICD = DBHelper.CIS.From<IView_HIS_ICD>().ToList();
            IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
            if (patient == null)
            {
                AlertBox.Error("未选择病人,无法填写住院报告单");
                this.Close();
                return;
            }

            this.txWriterControl1.LoadDocumentFromString(SysParams.GetHospitalizedReport, "XML");
            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;

            var input = this.txWriterControl1.GetElementById("InHosDept") as XTextInputFieldElement;
            input.FieldSettings = new InputFieldSettings();
            input.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            input.FieldSettings.ListSource = new ListSourceInfo();
            input.FieldSettings.ListSource.Items = new ListItemCollection();
            foreach (var item in dept)
                input.FieldSettings.ListSource.Items.Add(new ListItem() { SpellCode = item.SearchCode, Text = item.Name });

            InitUI();
        }

        private void InitUI()
        {
            IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            OP_Journal journal = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).First();

            List<OP_HospitalizedReport> Report = DBHelper.CIS.From<OP_HospitalizedReport>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo).ToList();
            if (Report.Count != 0)
            {
                //OP_HospitalizedReport tmp1 = Report[0];
                //this.txWriterControl1.XMLText = tmp1.Content;
                InitData(Report[0]);
                return;
            }

            XTextInputFieldElement input = this.txWriterControl1.GetElementById("HMDiagnosis") as XTextInputFieldElement;
            input.Text = string.Join(",", diagnosis.Where(p => p.IsHMDiagnosis == 1).Select(p => p.Name).ToArray<string>());
            input = this.txWriterControl1.GetElementById("WMDiagnosis") as XTextInputFieldElement;
            input.Text = string.Join(",", diagnosis.Where(p => p.IsHMDiagnosis != 1).Select(p => p.Name).ToArray<string>());
            input = this.txWriterControl1.GetElementById("DoctorID") as XTextInputFieldElement;
            input.Text = SysContext.CurrUser.user.Code;
            input = this.txWriterControl1.GetElementById("DoctorName") as XTextInputFieldElement;
            input.Text = SysContext.CurrUser.user.Name;
            input = this.txWriterControl1.GetElementById("ContantPhoneNumber") as XTextInputFieldElement;
            input.Text = journal == null ? "" : journal.ContactsPhone;
            input = this.txWriterControl1.GetElementById("ContantName") as XTextInputFieldElement;
            input.Text = journal == null ? "" : journal.ContactsName;
            input = this.txWriterControl1.GetElementById("PatientName") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.PatientName;
            input = this.txWriterControl1.GetElementById("PatientSex") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.Sex;
            input = this.txWriterControl1.GetElementById("PatientAge") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.Age;
            input = this.txWriterControl1.GetElementById("PatientAddress") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.Address;
            input = this.txWriterControl1.GetElementById("PatientPhoneNumber") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.ContactNumber;
            input = this.txWriterControl1.GetElementById("TreatmentNo") as XTextInputFieldElement;
            input.Text = SysContext.GetCurrPatient.OutpatientNo;

            XTextBarcodeFieldElement bar = this.txWriterControl1.GetElementById("bar") as XTextBarcodeFieldElement;
            if (bar != null)
                bar.Text = SysContext.GetCurrPatient.OutpatientNo;

        }

        private void InitData(OP_HospitalizedReport hospitalizedReport)
        {
            var properties = hospitalizedReport.GetType().GetProperties();
            foreach (var item in properties)
            {
                try
                {
                    XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Name) as XTextInputFieldElement;
                    if (input != null)
                        input.Text = item.GetValue(hospitalizedReport, null).AsString("");
                }
                catch
                {
                }
            }

            XTextBarcodeFieldElement bar = this.txWriterControl1.GetElementById("bar") as XTextBarcodeFieldElement;
            if (bar != null)
                bar.Text = hospitalizedReport.TreatmentNo;

            string elementName = "checkbox" + (hospitalizedReport.InHosType.AsInt() + 1).ToString();
            XTextRadioBoxElement radio = this.txWriterControl1.GetElementById(elementName) as XTextRadioBoxElement;
            if (radio != null)
                radio.Checked = true;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (SaveRecord())
                this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FileCleanPrint, false, null);
        }

        private void txWriterControl1_EventContentChanged(object eventSender, DCSoft.Writer.ContentChangedEventArgs args)
        {
            if (args.Element.ID == "DeptName")
            {
                List<IView_Dept> tmp = dept.Where(p => p.Name == args.Element.Text).ToList();
                if (tmp.Count > 0)
                    this.txWriterControl1.GetElementById("Region").Text = tmp[0].RegionName;
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }

        private bool SaveRecord()
        {
            OP_HospitalizedReport report = new OP_HospitalizedReport();
            report.ID = Guid.NewGuid().ToString();
            report.DeptCode = SysContext.RunSysInfo.currDept.Code;
            var properties = report.GetType().GetProperties();
            foreach (var item in properties)
            {
                try
                {
                    XTextInputFieldElement input = this.txWriterControl1.GetElementById(item.Name) as XTextInputFieldElement;
                    if (input != null)
                    {
                        if (item.Name == nameof(OP_HospitalizedReport.InHosDept) || item.Name == nameof(OP_HospitalizedReport.InHosNurseArea))
                        {
                            if (input.Text == null || input.Text == "")
                            {
                                AlertBox.Info("住院科室和住院病区为必填项");
                                return false;
                            }
                        }
                        item.SetValue(report, input.Text, null);
                    }
                }
                catch
                {
                }
            }
            report.InHosType = "0";
            var elements = this.txWriterControl1.GetSpecifyElements(typeof(XTextRadioBoxElement));
            foreach (XTextRadioBoxElement item in elements)
            {
                if (item.Checked)
                {
                    if (item.Text.Contains("门诊"))
                        report.InHosType = "0";
                    else if (item.Text.Contains("急诊"))
                        report.InHosType = "1";
                    else if (item.Text.Contains("其他医疗机构转入"))
                        report.InHosType = "2";
                    else if (item.Text.Contains("其他"))
                        report.InHosType = "3";
                }
            }

            DBHelper.CIS.Delete<OP_HospitalizedReport>(p => p.TreatmentNo == (Report != null ? Report.TreatmentNo : SysContext.GetCurrPatient.OutpatientNo));
            DBHelper.CIS.Insert<OP_HospitalizedReport>(report);
            AlertBox.Info("保存成功");
            return true;
        }
    }
}
