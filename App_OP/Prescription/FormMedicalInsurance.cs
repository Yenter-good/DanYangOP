using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Utility;

namespace App_OP
{
    public partial class FormMedicalInsurance : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormMedicalInsurance()
        {
            InitializeComponent();
        }

        public MedicalInsuranceDrugResult result;
        private MedicalInsuranceReasonSend send = new MedicalInsuranceReasonSend();
        int index = 0;

        private void FormMedicalInsurance_Shown(object sender, EventArgs e)
        {
            send.code = "100";
            send.feedBackMsg = "此值为对本次所有违规结果的反馈内容";
            ShowInfo();
            this.Height = this.btnSend.Top + this.btnSend.Height + 20;
            this.tbxExplain.Focus();
        }

        private void ShowInfo()
        {
            this.lbCount.Text = string.Format("当前您有{0}条医保控费提醒需要解决{1}当前第{2}条", result.messages.Count, Environment.NewLine, index + 1);
            this.lbCount.Left = this.Width / 2 - this.lbCount.Width / 2;

            this.lbContent.Text = result.messages[index].content + Environment.NewLine + result.messages[index].comments;
        }

        private void Send()
        {
            messages msg = new messages();
            msg.uuid = result.messages[index].uuid;
            msg.ruleId = result.messages[index].ruleId;
            msg.triggerLevel = result.messages[index].triggerLevel;
            msg.involvedCost = result.messages[index].involvedCost;
            msg.comments = result.messages[index].content;
            msg.feedBackMsg = this.tbxExplain.Text;
            if (msg.encounterResults == null)
                msg.encounterResults = new List<encounterResults>();
            msg.encounterResults.Add(new encounterResults() { encounterId = SysContext.GetCurrPatient.OutpatientNo, orderIds = new List<string>() });
            if (send.messages == null)
                send.messages = new List<messages>();
            send.messages.Add(msg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.tbxExplain.Text == "")
            {
                AlertBox.Info("反馈信息不能为空");
                return; ;
            }
            Send();
            if (index < result.messages.Count - 1)
            {
                index++;
                ShowInfo();
                this.tbxExplain.Text = "";
            }
            else
            {
                string json = send.BeginJsonSerializable();
                json = GetPatientMedicalInsuranceBasicJson(json);
                string reason = CIS.Utility.HTTPHelper.HttpPost("http://192.168.1.228:8080/MMAP/RuleFeedBack.do", json);

                MedicalInsuranceReasonResult ReasonResult = CIS.Utility.SerializeHelper.BeginJsonDeserialize<MedicalInsuranceReasonResult>(reason);
                if (ReasonResult != null && ReasonResult.code == "202")
                {
                    AlertBox.Info("反馈信息已经提交成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    AlertBox.Info(string.Format("反馈信息提交失败,原因为{0}{1}", Environment.NewLine, ReasonResult == null ? "提交超时" : ReasonResult.msg));
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                    this.Close();
                }
            }
        }

        private string GetPatientMedicalInsuranceBasicJson(string json)
        {
            List<string> list = new List<string>();
            list.Add("hospitalID=321181010003");
            list.Add("clientIP=" + SysContext.ClientIP);
            list.Add("clientMac=" + SysContext.ClientMAC);
            list.Add("companyCode=80-A5-89-CA-AE-B7");
            list.Add("feedBack=" + json);
            return string.Join("&", list.ToArray());
        }

        private void tbxExplain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend_Click(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}
