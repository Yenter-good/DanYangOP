using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using Dos.ORM;

namespace App_OP.PatientInfo
{
    public partial class FormSearchPatient : BaseForm
    {
        public FormSearchPatient()
        {
            InitializeComponent();
        }


        List<IView_Dept> dept = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1 && p.Code != SysContext.RunSysInfo.currDept.Code).ToList();
        public string type = "changeDept";

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //TODO
            if (type == "changeDept")
            {
                IView_Dept select = this.listBox1.SelectedItem as IView_Dept;


                IView_HIS_Outpatients patient = DBHelper.CIS.From<IView_HIS_Outpatients>().Where(x => x.CardNo == tbxSearch.Text.Trim() || x.OutpatientNo == tbxSearch.Text.Trim() && x.DeptCode == SysContext.RunSysInfo.currDept.Code).ToFirst();
                if (patient == null)
                {
                    AlertBox.Error("没有该号码的患者请确认输入的号码是否正确！");
                    return;
                }
                if (patient.DoctorNo != "" && patient.DoctorNo != SysContext.CurrUser.user.Code)
                {
                    MsgBox.OK("当前患者已经被别人接诊，无法更换科室");
                    return;
                }
                if (MsgBox.OKCancel("是否为 " + patient.PatientName.Trim() + " 更换科室") == DialogResult.OK)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("JZH", patient.OutpatientNo);
                    dic.Add("KSBH", select.Code);
                    dic.Add("KSMC", select.Name);
                    dic.Add("SKSBH", SysContext.RunSysInfo.currDept.Code);
                    dic.Add("YSGH", SysContext.CurrUser.user.Code);
                    int i = DosORMExtension.ExecuteProcNonQuery(DBHelper.CIS, "Proc_OP_ChangeDept", dic);
                    if (i > 0)
                    {
                        {
                            AlertBox.Info("更换科室成功");

                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                        AlertBox.Error("更换科室失败，请确认输入信息是否正确");
                }


            }
            //TODO
            if (type == "registered")
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("s", "s");
                List<Sys_App> applist = DosORMExtension.ExecuteProcList<Sys_App>(DBHelper.CIS, "Proc_HIS_FreeRegistered", dic);

            }
        }

        private void FormSearchPatient_Shown(object sender, EventArgs e)
        {
            this.listBox1.DataSource = dept;
            if (SysContext.GetCurrPatient != null)
                this.tbxSearch.Text = SysContext.GetCurrPatient.OutpatientNo;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            List<IView_Dept> tmp = dept.Where(p => p.SearchCode.Contains(this.textBoxX1.Text.ToUpper()) || p.Name.Contains(this.textBoxX1.Text)).ToList();
            this.listBox1.DataSource = tmp;
        }
    }
}
