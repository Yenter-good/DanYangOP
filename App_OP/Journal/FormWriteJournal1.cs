using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    public partial class FormWriteJournal1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormWriteJournal1()
        {
            InitializeComponent();
        }

        string[] NationStr = new string[] { "汉族", "蒙古族", "满族", "朝鲜族", "赫哲族", "达斡尔族", "鄂温克族", "鄂伦春族", "回族", "东乡族", "土族", "撒拉族", "保安族", "裕固族", "维吾尔族", "哈萨克族", "柯尔克孜族", "锡伯族", "塔吉克族", "乌孜别克族", "俄罗斯族", "塔塔尔族", "藏族", "门巴族", "珞巴族", "羌族", "彝族", "白族", "哈尼族", "傣族", "傈僳族", "佤族", "拉祜族", "纳西族", "景颇族", "布朗族", "阿昌族", "普米族", "怒族", "德昂族", "独龙族", "基诺族", "苗族", "布依族", "侗族", "水族", "仡佬族", "壮族", "瑶族", "仫佬族", "毛南族", "京族", "土家族", "黎族", "畲族", "高山族" };
        string[] NationalityStr = new string[] { "中国", "蒙古", "朝鲜", "韩国", "日本", "菲律宾", "越南", "老挝", "柬埔寨", "缅甸", "泰国", "马来西亚", "文莱", "新加坡", "印度尼西亚", "东帝汶", "尼泊尔", "不丹", "孟加拉国", "印度", "巴基斯坦", "斯里兰卡", "马尔代夫", "哈萨克斯坦", "吉尔吉斯斯坦", "塔吉克斯坦", "乌兹别克斯坦", "土库曼斯坦", "阿富汗", "伊拉克", "伊朗", "叙利亚", "约旦", "黎巴嫩", "以色列", "巴勒斯坦", "沙特阿拉伯", "巴林", "卡塔尔", "科威特", "阿拉伯联合酋长国（阿联酋）", "阿曼", "也门", "格鲁吉亚", "亚美尼亚", "阿塞拜疆", "土耳其", "塞浦路斯" };
        List<OP_Job> job = SysContext.GetJobList();
        public bool IsNoCancle = false;
        public bool ImposeShow = false;
        public IView_HIS_Outpatients currPatient { get; set; }
        OP_Journal currJournal = new OP_Journal();

        #region 初始化
        private void InitUI()
        {
            foreach (var item in NationStr)
                this.Nation.Items.Add(item);

            foreach (var item in NationalityStr)
                this.Nationality.Items.Add(item);

            foreach (OP_Job item in job)
                this.Job.Items.Add(item.JobName);
            if (currPatient.IDCard != null && currPatient.IDCard != "" && currPatient.IDCard.Length == 18)
            {

                string year = currPatient.IDCard.Substring(6, 4);
                string month = currPatient.IDCard.Substring(10, 2);
                string day = currPatient.IDCard.Substring(12, 2);
                this.Birthday.Value = string.Format("{0}-{1}-{2}", year, month, day).AsDateTime(DateTime.Now);
            }
            else
                this.Birthday.Value = DateTime.Now.AddYears(-Extensions.GetAge(currPatient.Age ?? ("")));
            this.DA.Value = DateTime.Now;

            foreach (var item in this.groupBox1.Controls)
                if (item is ComboBox)
                    (item as ComboBox).SelectedIndex = 0;
            foreach (var item in this.groupBox3.Controls)
                if (item is ComboBox)
                    (item as ComboBox).SelectedIndex = 0;
            foreach (var item in this.groupBox4.Controls)
                if (item is ComboBox)
                    (item as ComboBox).SelectedIndex = 0;
        }

        private void InitData()
        {
            if (!ImposeShow) //如果不是强制显示
            {
                bool HasInfo = false;
                List<OP_Journal> jj = new List<OP_Journal>(); ;
                List<OP_Journal> j = DBHelper.CIS.From<OP_Journal>().UnionAll(DBHelper.CIS.From<OP_Journal_History>()).Where(p => p.OutpatientNo == currPatient.OutpatientNo).ToList();  //先确定这个就诊号有没有填写过日志
                if (j.Count == 0)
                {
                    if (currPatient.IDCard != null && currPatient.IDCard != "") //如果当前这个人没有日志,那么查找是否有他的身份证的历史信息
                    {
                        jj = DBHelper.CIS.From<OP_Journal>().UnionAll(DBHelper.CIS.From<OP_Journal_History>()).Where(p => p.IDCard == currPatient.IDCard).ToList();
                        if (jj.Count > 0)
                            HasInfo = true;
                    }
                }
                else
                {
                    SysContext.IsWriteJournal = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                SetData(currPatient);

                if (HasInfo)
                {
                    var phoneNumbers = jj.Where(p => p.PhoneNumber != null).Select(p => p.PhoneNumber).ToList<string>();
                    var phoneNumber = phoneNumbers.Count == 0 ? "" : phoneNumbers.OrderByDescending(p => p.Length).ToList()[0];
                    this.PhoneNumber.Text = phoneNumber;
                }
            }
            else
            {
                List<OP_Journal> j = DBHelper.CIS.From<OP_Journal>().UnionAll(DBHelper.CIS.From<OP_Journal_History>()).Where(p => p.OutpatientNo == currPatient.OutpatientNo).ToList();  //先确定这个就诊号有没有填写过日志
                currJournal = j[0];
                SetData(j[0]);
                if (currJournal.FirstOrMany == "初诊")
                    this.radioButton1.Checked = true;
                else
                    this.radioButton2.Checked = true;
            }

            this.Opacity = 1;
        }

        private void SetData(object obj)
        {
            foreach (Control item in this.groupBox1.Controls)
                if (obj is IView_HIS_Outpatients)
                {
                    if (item.Tag != null && item.Tag.AsString("") != "")
                        InitData(item, obj as IView_HIS_Outpatients);
                }
                else
                    InitData(item, obj as OP_Journal);

            foreach (Control item in this.groupBox2.Controls)
                if (obj is IView_HIS_Outpatients)
                {
                    if (item.Tag != null && item.Tag.AsString("") != "")
                        InitData(item, obj as IView_HIS_Outpatients);
                }
                else
                    InitData(item, obj as OP_Journal);

            foreach (Control item in this.groupBox3.Controls)
                if (obj is IView_HIS_Outpatients)
                {
                    if (item.Tag != null && item.Tag.AsString("") != "")
                        InitData(item, obj as IView_HIS_Outpatients);
                }
                else
                    InitData(item, obj as OP_Journal);

            foreach (Control item in this.groupBox4.Controls)
                if (obj is IView_HIS_Outpatients)
                {
                    if (item.Tag != null && item.Tag.AsString("") != "")
                        InitData(item, obj as IView_HIS_Outpatients);
                }
                else
                    InitData(item, obj as OP_Journal);
        }

        private static void InitData(Control item, IView_HIS_Outpatients patient)
        {
            if (item is ComboBox)
                (item as ComboBox).SelectedIndex = (item as ComboBox).Items.IndexOf(patient.GetType().GetProperty(item.Tag.ToString()).GetValue(patient, null).ToString().Trim());
            else if (item is TextBox)
                (item as TextBox).Text = (patient.GetType().GetProperty(item.Tag.ToString()).GetValue(patient, null) ?? "").ToString();
            else if (item is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                (item as DevComponents.Editors.DateTimeAdv.DateTimeInput).Value = patient.GetType().GetProperty(item.Tag.ToString()).GetValue(patient, null).AsDateTime(DateTime.Now);
            else if (item is DateTimePicker)
                (item as DateTimePicker).Value = patient.GetType().GetProperty(item.Tag.ToString()).GetValue(patient, null).AsDateTime(DateTime.Now);
        }

        private static void InitData(Control item, OP_Journal patient)
        {
            if (item is ComboBox)
                (item as ComboBox).SelectedIndex = (item as ComboBox).Items.IndexOf((patient.GetType().GetProperty(item.Name.ToString()).GetValue(patient, null) ?? "").ToString().Trim());
            else if (item is TextBox)
                (item as TextBox).Text = (patient.GetType().GetProperty(item.Name.ToString()).GetValue(patient, null) ?? "").ToString();
            else if (item is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                (item as DevComponents.Editors.DateTimeAdv.DateTimeInput).Value = patient.GetType().GetProperty(item.Name.ToString()).GetValue(patient, null).AsDateTime(DateTime.Now);
            else if (item is DateTimePicker)
                (item as DateTimePicker).Value = patient.GetType().GetProperty(item.Name.ToString()).GetValue(patient, null).AsDateTime(DateTime.Now);
        }
        #endregion

        #region 设置数据
        private OP_Journal SetData()
        {
            OP_Journal result = new OP_Journal();
            foreach (Control item in this.groupBox1.Controls)
                result = SetData(result, item);

            foreach (Control item in this.groupBox2.Controls)
                result = SetData(result, item);

            foreach (Control item in this.groupBox3.Controls)
                result = SetData(result, item);

            foreach (Control item in this.groupBox4.Controls)
                result = SetData(result, item);

            return result;
        }

        private OP_Journal SetData(OP_Journal obj, Control control)
        {
            if (control is ComboBox)
                obj.GetType().GetProperty(control.Name).SetValue(obj, ((control as ComboBox).SelectedItem ?? "").ToString(), null);
            else if (control is TextBox)
                obj.GetType().GetProperty(control.Name).SetValue(obj, (control as TextBox).Text.ToString(), null);
            else if (control is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                obj.GetType().GetProperty(control.Name).SetValue(obj, (control as DevComponents.Editors.DateTimeAdv.DateTimeInput).Value.ToString(), null);
            else if (control is DateTimePicker)
                obj.GetType().GetProperty(control.Name).SetValue(obj, (control as DateTimePicker).Value.ToString(), null);
            return obj;
        }
        #endregion

        private void FormWriteJournal_Shown(object sender, EventArgs e)
        {
            if (currPatient == null && SysContext.GetCurrPatient != null)
            {
                currPatient = SysContext.GetCurrPatient;
                ImposeShow = true;
            }

            if (currPatient == null)
            {
                AlertBox.Error("未选择病人,无法填写病人信息");
                this.Close();
                return;
            }
            InitUI();
            InitData();
            this.BloodPressure1.Focus();
            if (IsNoCancle)
            {
                this.btnCancle.Enabled = false;
                this.ControlBox = false;
            }

            this.Height = this.btnSend.Top + this.btnSend.Height + 20;
        }

        #region 检验有效性
        /// <summary>
        /// 检查页面有效性
        /// </summary>
        /// <returns></returns>
        private bool CheckValidity()
        {
            //if (this.Address.Text == "" || this.PhoneNumber.Text == "" || this.Job.SelectedItem == null)
            //{
            //    MessageBox.Show("地址、手机号和职业为必填项");
            //    return false;
            //}
            if (currPatient.Age.GetAge() > 35 && (this.BloodPressure1.Text == "" || this.BloodPressure2.Text == ""))
            {
                AlertBox.Info("超过三十五岁必须要填写血压");
                this.BloodPressure1.Focus();
                return false;
            }
            if (this.PhoneNumber.Text == "")
            {
                AlertBox.Info("联系电话为必填项");
                this.PhoneNumber.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 窗口事件
        private void BloodPressure1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == this.BloodPressure2)
                    this.PhoneNumber.Focus();
                else if (sender == this.BloodPressure1)
                    this.BloodPressure2.Focus();
                else
                    this.btnSend.Focus();
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!CheckValidity())
                return;
            List<OP_PatientDiagnosis> diagnosis = DBHelper.CIS.From<OP_PatientDiagnosis>().Where(p => p.TreatmentNo == currPatient.OutpatientNo).ToList();

            List<OP_PatientDiagnosis> MainDiagnosis = diagnosis.Where(p => p.IsMain == 1).ToList();

            OP_Journal journal = SetData();
            journal.ID = Guid.NewGuid().ToString();
            journal.DeptCode = SysContext.RunSysInfo.currDept.Code;
            journal.DeptName = SysContext.RunSysInfo.currDept.Name;
            journal.DoctorName = SysContext.CurrUser.user.Name;
            journal.DoctorNo = SysContext.CurrUser.user.Code;
            journal.PatientDiagnosis = MainDiagnosis.Count == 0 ? "" : MainDiagnosis[0].Name;
            journal.CardNo = currPatient.CardNo;
            journal.OutpatientNo = currPatient.OutpatientNo;
            journal.PatientID = currPatient.PatientID;
            journal.FirstOrMany = this.radioButton1.Checked ? "初诊" : "复诊";
            journal.UpdateDate = DateTime.Now;
            journal.ProcessTime = currJournal.ProcessTime == null ? DateTime.Now : currJournal.ProcessTime;
            journal.DA = this.DA.Value.ToString();
            journal.IsAutoSave = 1;
            //if (this.checkBox1.Checked)
            //{
            //    FormInfectionReport form = new FormInfectionReport();
            //    form.journals = journals;
            //    form.diagnosis = diagnosis;
            //    form.ShowDialog();
            //}
            if (ImposeShow)
            {
                DBHelper.CIS.Delete<OP_Journal>(p => p.OutpatientNo == currPatient.OutpatientNo);
                DBHelper.CIS.Delete<OP_Journal_History>(p => p.OutpatientNo == currPatient.OutpatientNo);
            }
            DBHelper.CIS.Insert<OP_Journal>(journal);

            currPatient.IDCard = this.IDCard.Text;
            DBHelper.CIS.FromSql($"UPDATE GHBRZL SET SFZH='{this.IDCard.Text}' WHERE JZH='{currPatient.OutpatientNo}'").ExecuteNonQuery();

            MessageBox.Show("保存成功");
            SysContext.IsWriteJournal = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

    }
}
