using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CIS.Core.Interceptors;
using CIS.Model;
using CIS.Utility;
using DCSoft.Writer.Dom;
using Dos.ORM;

namespace CIS.Core
{
    public partial class BaseReportForm : Form
    {

        string CollectMessage = "";
        public BaseReportForm(string ReportType, string Xml)
        {
            InitializeComponent();
            ReportTypeString = ReportType;
            XMLText = Xml;
            if (ReportTypeString == "分诊操作表")
            {
                this.txWriterControl1.EventElementCheckedChanged += TxWriterControl1_EventElementCheckedChanged;
            }
        }

        private void TxWriterControl1_EventElementCheckedChanged(string elementID, string elementName, string elementValue, XTextElement element)
        {
            if (elementName == "zz")
            {
                if (elementID == "checkAll" && (element as XTextCheckBoxElement).Checked)
                {
                    List<XTextCheckBoxElement> checkBoxElements = txWriterControl1.GetSpecifyElements(typeof(XTextCheckBoxElement)).Cast<XTextCheckBoxElement>().Where(p => p.Name == "zz").ToList();
                    foreach (var item in checkBoxElements)
                    {
                        item.Checked = false;
                    }
                   (element as XTextCheckBoxElement).Checked = true;
                }
                else
                {
                    (this.txWriterControl1.GetElementById("checkAll") as XTextCheckBoxElement).Checked = false;
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ReportTypeString == "分诊操作表")
            {
                SaveTriage();
            }
            else
            {
                OP_Report report = new OP_Report();
                report.ID = Guid.NewGuid().ToString();
                report.Content = this.txWriterControl1.XMLTextUnFormatted;
                report.DeptCode = SysContext.RunSysInfo.currDept.Code;
                report.DeptName = SysContext.RunSysInfo.currDept.Name;
                report.DoctorID = SysContext.CurrUser.user.Code;
                report.DoctorName = SysContext.CurrUser.user.Name;
                report.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
                report.ReportType = ReportTypeString;
                report.UpdateTime = DateTime.Now;
                report.PatientName = SysContext.GetCurrPatient.PatientName;
                DBHelper.CIS.Delete<OP_Report>(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && p.ReportType == ReportTypeString);
                var data = DBHelper.CIS.Insert<OP_Report>(report);
                CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存报卡", SerializeHelper.BeginJsonSerializable(report), data > 0 ? "报卡保存成功！" : "报卡保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);
                AlertBox.Info("保存成功" + CollectMessage);
            }




        }

        private void SaveTriage()
        {
            List<XTextRadioBoxElement> radioboxList = txWriterControl1.GetSpecifyElements(typeof(XTextRadioBoxElement)).Cast<XTextRadioBoxElement>().ToList();
            List<XTextCheckBoxElement> checkBoxElements = txWriterControl1.GetSpecifyElements(typeof(XTextCheckBoxElement)).Cast<XTextCheckBoxElement>().ToList();
            Dictionary<string, string> needCheckList = new Dictionary<string, string> { { "lxb", "流行病史" }, { "jcs", "接触史" }, { "gfx", "高风险人员" }, { "zz", "症状" }, { "ymjz", "疫苗接种" }, { "承诺", "承诺" } };
            List<StringItem> inputValues = new List<StringItem>();
            foreach (var itemName in needCheckList)
            {
                if (itemName.Key == "zz")
                {
                    var checkList = checkBoxElements.Where(p => p.Name == itemName.Key && p.Checked).ToList();
                    if (checkList.Count == 0)
                    {
                        MsgBox.OK(itemName.Value + "必填");
                        return;
                    }
                    else
                    {
                        var val = checkList.Select(p => p.Text).ToList();
                        var str = string.Join(",", val);
                        inputValues.Add(new StringItem(itemName.Key, str, itemName.Value));
                    }
                }
                else
                {
                    var lxbList = radioboxList.Where(p => p.Name == itemName.Key && p.Checked).ToList();
                    if (lxbList.Count == 0)
                    {
                        MsgBox.OK(itemName.Value + "必填");
                        return;
                    }
                    else
                    {
                        inputValues.Add(new StringItem(itemName.Key, lxbList[0].Text, itemName.Value));
                    }
                }

            }
            OP_Report report = new OP_Report();
            report.ID = Guid.NewGuid().ToString();
            report.Content = this.txWriterControl1.XMLTextUnFormatted;
            report.DeptCode = SysContext.RunSysInfo.currDept.Code;
            report.DeptName = SysContext.RunSysInfo.currDept.Name;
            report.DoctorID = SysContext.CurrUser.user.Code;
            report.DoctorName = SysContext.CurrUser.user.Name;
            report.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            report.ReportType = ReportTypeString;
            report.UpdateTime = DateTime.Now;
            report.PatientName = SysContext.GetCurrPatient.PatientName;
            DBHelper.CIS.Delete<OP_Report>(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && p.ReportType == ReportTypeString);
            var data = DBHelper.CIS.Insert<OP_Report>(report);

            AlertBox.Info("保存成功" + CollectMessage);
            CIS.Core.Interceptors.Log4Helper.WriteLog(this.GetType(), new CIS.Core.Interceptors.LogMessage("保存报卡", SerializeHelper.BeginJsonSerializable(report), data > 0 ? "报卡保存成功！" : "报卡保存失败！"), data > 0 ? Log4NetLevel.Info : Log4NetLevel.Error);

            List<OP_ReportValue> oP_ReportValues = new List<OP_ReportValue>();
            inputValues.Add(new StringItem("IDCard", this.txWriterControl1.GetElementById("IDCard").Text, "身份证号"));
            inputValues.Add(new StringItem("PhoneNumber", this.txWriterControl1.GetElementById("PhoneNumber").Text, "手机号码"));
            inputValues.Add(new StringItem("tep", this.txWriterControl1.GetElementById("tep").Text, "体温"));
            foreach (var item in inputValues)
            {
                OP_ReportValue reportValue = new OP_ReportValue();
                reportValue.Id = CreateUUID();
                reportValue.ReportID = report.ID;
                reportValue.ReportName = ReportTypeString;
                reportValue.PatientName = SysContext.GetCurrPatient.PatientName;
                reportValue.TreamentNo = SysContext.GetCurrPatient.OutpatientNo;
                reportValue.DoctorCode = SysContext.CurrUser.UserId;
                reportValue.CreateDateTime = report.UpdateTime;
                reportValue.LastModifyDatetime = report.UpdateTime;
                reportValue.LastModifyUserCode = SysContext.CurrUser.UserId;
                reportValue.CreateUserCode = SysContext.CurrUser.UserId;
                reportValue.FileldID = item.Key;
                reportValue.FileldValue = item.Value;
                reportValue.FieldName = item.Code;
                reportValue.Staus = 1;
                reportValue.DeptCode = SysContext.RunSysInfo.currDept.Code;
                oP_ReportValues.Add(reportValue);
            }

            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                try
                {
                    //foreach (var item in medicalRecords_Appends)
                    //{
                    //    item.Id = _idService.CreateUUID();
                    //    item.SetCreationValues();
                    //    WhereClip whereClip = new WhereClip();
                    //    whereClip =  whereClip.And(OP_MedicalRecords_Append._.HosId == App.Current.RuntimeSystemInfo.HospitalInfo.Id && OP_MedicalRecords_Append._.NodeId == item.NodeId);
                    //    if (item.IdCardNo.IsNullOrWhiteSpace())
                    //    {
                    //        whereClip = whereClip.And(OP_MedicalRecords_Append._.CardNo == item.CardNo);
                    //    }
                    //    else
                    //    {
                    //        whereClip = whereClip.And(OP_MedicalRecords_Append._.IdCardNo == item.IdCardNo);
                    //    }

                    //   var delvalues = AuditionHelper.GetDeletionValues<OP_MedicalRecords_Append>();
                    //    tran.Update<OP_MedicalRecords_Append>(delvalues, whereClip);
                    //}

                    Dictionary<Dos.ORM.Field, object> updateValue = new Dictionary<Dos.ORM.Field, object>();
                    updateValue[OP_ReportValue._.Staus] = (int)2;
                    updateValue[OP_ReportValue._.LastModifyDatetime] = report.UpdateTime;
                    updateValue[OP_ReportValue._.LastModifyUserCode] = SysContext.CurrUser.UserId;
                    updateValue[OP_ReportValue._.DeleteDatetime] = report.UpdateTime;
                    updateValue[OP_ReportValue._.DeleteUserCode] = SysContext.CurrUser.UserId;
                    tran.Update<OP_ReportValue>(updateValue, p => p.ReportName == ReportTypeString && p.TreamentNo == SysContext.GetCurrPatient.OutpatientNo);
                    tran.Insert(oP_ReportValues);

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }





        }

        public long CreateUUID()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0);
        }
        class StringItem
        {
            public string Key { get; set; }

            public string Value { get; set; }
            public string Code { get; set; }

            public StringItem(string key, string value, string code)
            {
                this.Key = key;
                this.Value = value;
                this.Code = code;
            }

        }

        public string ReportTypeString { get; set; }

        public Dictionary<string, string> dictInput { get; set; } = new Dictionary<string, string>();

        public string XMLText { get { return this.txWriterControl1.XMLTextUnFormatted; } set { this.txWriterControl1.XMLText = value; } }

        private void BaseReportForm_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            IView_HIS_Outpatients patient = SysContext.GetCurrPatient;
            if (patient == null)
            {
                AlertBox.Error("未选择病人,无法填写" + ReportTypeString);
                this.Close();
                return;
            }

            OP_Report Report = DBHelper.CIS.From<OP_Report>().Where(p => p.TreatmentNo == SysContext.GetCurrPatient.OutpatientNo && p.ReportType == ReportTypeString).First();
            if (Report != null)
            {
                this.txWriterControl1.XMLText = Report.Content;
                return;
            }

            DataTable obj = DBHelper.CIS.FromProc("Proc_OP_ReportDataSource").AddInParameter("TreatmentNo", DbType.String, SysContext.GetCurrPatient.OutpatientNo).ToDataTable();

            Dictionary<string, string> dict = new Dictionary<string, string>() {
                { "DoctorName", SysContext.CurrUser.user.Name }
                , { "DoctorCode", SysContext.CurrUser.user.Code}
                , { "Datetime",DateTime.Now.ToString()}
                , { "DeptName", SysContext.RunSysInfo.currDept.Name }
                , { "DeptCode",SysContext.RunSysInfo.currDept.Code } };

            List<string> text = DBHelper.CIS.From<OP_Dic_ReportDataSource>().Select(p => p.ElementCode).OrderBy(p => p.Index).ToList<string>();

            foreach (var item in text)
            {
                var inputs = this.txWriterControl1.GetElementsById(item);
                if (inputs == null || inputs.Count == 0)
                    continue;
                if (obj.Rows.Count >= 1 && obj.Columns.Contains(item))
                {
                    foreach (XTextInputFieldElement input in inputs)
                    {
                        input.Text = obj.Rows[0][item].AsString("");
                        input.EditorRefreshView();
                    }

                }
                else
                {
                    if (dict.ContainsKey(item))
                    {
                        foreach (XTextInputFieldElement input in inputs)
                        {
                            input.Text = dict[item];
                            input.EditorRefreshView();
                        }
                    }
                }
            }

            this.txWriterControl1.FormView = DCSoft.Writer.Controls.FormViewMode.Strict;
        }

        private void btnPrintAndSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FileCleanPrint, false, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.txWriterControl1.ExecuteCommand(DCSoft.Writer.StandardCommandNames.FileCleanPrint, false, null);
        }
    }
}
