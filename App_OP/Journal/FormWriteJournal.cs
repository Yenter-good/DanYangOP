using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using Dos.ORM;
using CIS.Utility;

namespace App_OP
{
    public partial class FormWriteJournal : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private OP_Journal _currentJournal { get; set; }

        public FormWriteJournal()
        {
            InitializeComponent();
        }

        string[] NationStr = new string[] { "汉族", "蒙古族", "满族", "朝鲜族", "赫哲族", "达斡尔族", "鄂温克族", "鄂伦春族", "回族", "东乡族", "土族", "撒拉族", "保安族", "裕固族", "维吾尔族", "哈萨克族", "柯尔克孜族", "锡伯族", "塔吉克族", "乌孜别克族", "俄罗斯族", "塔塔尔族", "藏族", "门巴族", "珞巴族", "羌族", "彝族", "白族", "哈尼族", "傣族", "傈僳族", "佤族", "拉祜族", "纳西族", "景颇族", "布朗族", "阿昌族", "普米族", "怒族", "德昂族", "独龙族", "基诺族", "苗族", "布依族", "侗族", "水族", "仡佬族", "壮族", "瑶族", "仫佬族", "毛南族", "京族", "土家族", "黎族", "畲族", "高山族" };
        string[] NationalityStr = new string[] { "中国", "蒙古", "朝鲜", "韩国", "日本", "菲律宾", "越南", "老挝", "柬埔寨", "缅甸", "泰国", "马来西亚", "文莱", "新加坡", "印度尼西亚", "东帝汶", "尼泊尔", "不丹", "孟加拉国", "印度", "巴基斯坦", "斯里兰卡", "马尔代夫", "哈萨克斯坦", "吉尔吉斯斯坦", "塔吉克斯坦", "乌兹别克斯坦", "土库曼斯坦", "阿富汗", "伊拉克", "伊朗", "叙利亚", "约旦", "黎巴嫩", "以色列", "巴勒斯坦", "沙特阿拉伯", "巴林", "卡塔尔", "科威特", "阿拉伯联合酋长国（阿联酋）", "阿曼", "也门", "格鲁吉亚", "亚美尼亚", "阿塞拜疆", "土耳其", "塞浦路斯" };
        List<OP_Job> job = SysContext.GetJobList();
        public IView_HIS_Outpatients currPatient { get; set; }
        public bool ForceShown { get; set; } = true;

        public OP_Journal CurrentJournal { get; private set; }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitUI()
        {
            foreach (var item in NationStr)
                this.cbxNation.Items.Add(item);

            foreach (var item in NationalityStr)
                this.cbxNationality.Items.Add(item);

            foreach (OP_Job item in job)
                this.cbxJob.Items.Add(item.JobName);

            if (currPatient.IDCard != null && currPatient.IDCard != "" && currPatient.IDCard.Length == 18)
            {
                string year = currPatient.IDCard.Substring(6, 4);
                string month = currPatient.IDCard.Substring(10, 2);
                string day = currPatient.IDCard.Substring(12, 2);
                this.dtBirthday.Value = string.Format("{0}-{1}-{2}", year, month, day).AsDateTime(DateTime.Now);
            }
            else
                this.dtBirthday.Value = DateTime.Now.AddYears(-Extensions.GetAge(currPatient.Age ?? ("")));
            this.dtDA.Value = DateTime.Now;

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

        /// <summary>
        /// 使用门诊日志进行界面赋值
        /// </summary>
        /// <param name="journal"></param>
        private void SetValue()
        {
            if (_currentJournal == null)
                _currentJournal = DBHelper.CIS.From<OP_Journal>().UnionAll(DBHelper.CIS.From<OP_Journal_History>()).Where(p => p.OutpatientNo == currPatient.OutpatientNo).First();

            string phoneNumber = "";

            if (_currentJournal.IsAutoSave == 0)
            {
                var phoneNumbers = DBHelper.CIS.From<OP_Journal>().UnionAll(DBHelper.CIS.From<OP_Journal_History>()).Where(p => p.IDCard == _currentJournal.IDCard).Select(p => p.PhoneNumber).ToList<string>();
                phoneNumber = phoneNumbers.Count == 0 ? "" : phoneNumbers.OrderByDescending(p => p.AsString("").Length).First();
            }
            else
                phoneNumber = _currentJournal.PhoneNumber;

            //第一段
            this.txtPatientName.Text = _currentJournal.PatientName;
            this.txtPatientAge.Text = _currentJournal.Age;
            this.cbxSex.SelectedItem = _currentJournal.Sex.Trim();
            this.dtBirthday.ValueObject = _currentJournal.Birthday.AsDateTime(DateTime.Now);
            this.intStature.Text = _currentJournal.Stature;
            this.cbxMarry.SelectedItem = this.cbxMarry.SelectedItem.AsString();
            this.cbxBlood.SelectedItem = this.cbxBlood.SelectedItem.AsString();
            this.intWeight.Text = _currentJournal.Wight;
            this.cbxNation.SelectedItem = this.cbxNation.SelectedItem.AsString();
            this.cbxNationality.SelectedItem = this.cbxNationality.SelectedItem.AsString();
            this.txtOrigin.Text = _currentJournal.Origin;
            this.txtIDCard.Text = _currentJournal.IDCard;
            this.cbxKnowlage.SelectedItem = this.cbxKnowlage.SelectedItem.AsString();
            this.txtBirthPlace.Text = _currentJournal.BirthPlace;

            //第二段
            this.txtAddress.Text = _currentJournal.Address;
            this.txtEmail.Text = _currentJournal.Email;
            this.txtPhoneNumber.Text = phoneNumber;
            this.txtContactsName.Text = _currentJournal.ContactsName;

            //第三段
            this.cbxJob.SelectedItem = this.cbxJob.SelectedItem.AsString();
            this.txtJobAddress.Text = _currentJournal.JobAddress;
            this.txtJobPhone.Text = _currentJournal.JobPhone;

            //第四段
            this.txtRemark.Text = _currentJournal.Remark;
            this.rbFirstVisit.Checked = _currentJournal.FirstOrMany == "初诊";
            this.rbSecondVisit.Checked = _currentJournal.FirstOrMany != "初诊";
            this.dtDA.Value = _currentJournal.DA.AsDateTime(DateTime.Now);
            this.txtBloodPressure1.Text = _currentJournal.BloodPressure1;
            this.txtBloodPressure2.Text = _currentJournal.BloodPressure2;
        }

        private OP_Journal GetEntity()
        {
            OP_Journal entity = _currentJournal;

            //第一段
            entity.PatientName = this.txtPatientName.Text;
            entity.Age = this.txtPatientAge.Text;
            entity.Sex = this.cbxSex.SelectedItem.AsString();
            entity.Birthday = this.dtBirthday.Value.AsString("");
            entity.Stature = this.intStature.Text;
            entity.Marry = this.cbxMarry.SelectedItem.AsString();
            entity.Blood = this.cbxBlood.SelectedItem.AsString();
            entity.Wight = this.intWeight.Text;
            entity.Nation = this.cbxNation.SelectedItem.AsString();
            entity.Nationality = this.cbxNationality.SelectedItem.AsString();
            entity.Origin = this.txtOrigin.Text;
            entity.IDCard = this.txtIDCard.Text;
            entity.Knowlage = this.cbxKnowlage.SelectedItem.AsString();
            entity.BirthPlace = this.txtBirthPlace.Text;

            //第二段
            entity.Address = this.txtAddress.Text;
            entity.Email = this.txtEmail.Text;
            entity.PhoneNumber = this.txtPhoneNumber.Text;
            entity.ContactsName = this.txtContactsName.Text;

            //第三段
            entity.Job = this.cbxJob.SelectedItem.AsString();
            entity.JobAddress = this.txtJobAddress.Text;
            entity.JobPhone = this.txtJobPhone.Text;

            //第四段
            entity.Remark = this.txtRemark.Text;
            entity.FirstOrMany = this.rbFirstVisit.Checked ? "初诊" : "复诊";
            entity.DA = this.dtDA.Value.ToString();
            entity.BloodPressure1 = this.txtBloodPressure1.Text;
            entity.BloodPressure2 = this.txtBloodPressure2.Text;

            return entity;
        }

        private void FormWriteJournal_Shown(object sender, EventArgs e)
        {
            if (currPatient == null)
                currPatient = SysContext.GetCurrPatient;

            InitUI();
            SetValue();
            this.txtBloodPressure1.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!CheckValidity())
                return;

            var entity = this.GetEntity();
            var entityHistory = entity.BeginJsonSerializable().BeginJsonDeserialize<OP_Journal_History>();

            entity.IsAutoSave = 1;
            entity.AttachAll();

            CurrentJournal = entity;

            Dictionary<Field, object> modify = new Dictionary<Field, object>();
            modify[OP_Journal._.DoctorName] = SysContext.CurrUser.user.Name;
            modify[OP_Journal._.DoctorNo] = SysContext.CurrUser.user.Code;
            DBHelper.CIS.Update<OP_Journal>(modify, p => p.OutpatientNo == currPatient.OutpatientNo && p.IsAutoSave == 0);

            DBHelper.CIS.Update<OP_Journal>(entity, p => p.OutpatientNo == currPatient.OutpatientNo);
            DBHelper.CIS.Update<OP_Journal_History>(entityHistory, p => p.OutpatientNo == currPatient.OutpatientNo);

            DBHelper.CIS.FromSql($"UPDATE GHBRZL SET SFZH='{entity.IDCard}' WHERE JZH = '{currPatient.OutpatientNo}'").ExecuteNonQuery();

            currPatient.IDCard = entity.IDCard;

            MsgBox.OK("保存成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            if (currPatient.Age.GetAge() > 35 && (this.txtBloodPressure1.Text == "" || this.txtBloodPressure2.Text == ""))
            {
                AlertBox.Info("超过三十五岁必须要填写血压");
                this.txtBloodPressure1.Focus();
                return false;
            }
            if (this.txtPhoneNumber.Text.Trim() == "")
            {
                AlertBox.Info("联系电话为必填项");
                this.txtPhoneNumber.Focus();
                return false;
            }

            if (this.txtBloodPressure1.Text.AsInt(0) < 80 && this.txtBloodPressure1.Text.AsInt(0) > 200)
            {
                AlertBox.Info("高压范围为80~200");
                this.txtBloodPressure1.Focus();
                return false;
            }
            if (this.txtBloodPressure2.Text.AsInt(0) < 50 && this.txtBloodPressure2.Text.AsInt(0) > 120)
            {
                AlertBox.Info("低压范围为50~120");
                this.txtBloodPressure2.Focus();
                return false;
            }
            return true;
        }
        private void BloodPressure1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == this.txtBloodPressure2)
                    this.txtPhoneNumber.Focus();
                else if (sender == this.txtBloodPressure1)
                    this.txtBloodPressure2.Focus();
                else
                    this.btnSend.Focus();
            }
        }
    }
}
