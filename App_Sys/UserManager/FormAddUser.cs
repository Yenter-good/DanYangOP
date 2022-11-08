using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;

namespace App_Sys
{
    public partial class FormAddUser : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public string UserID;
        public string Dept_Code;
        IView_User User = new IView_User();
        Sys_User_Subsidiary User_Sub = new Sys_User_Subsidiary();

        public FormAddUser()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormAddUser_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitUI()
        {
            List<Sys_Dic_Details> Details = DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "JobTitle").ToList();
            this.input_JobTitle.DataSource = Details;
            List<Sys_Dic_Details> Type = DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "UserType").ToList();
            this.input_Type.DataSource = Type;
            List<Sys_Dic_Details> Qualification = DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "Qualification").ToList();
            this.input_EducationaBackground.DataSource = Qualification;
            List<Sys_Dic_Details> Sex = DBHelper.CIS.From<Sys_Dic_Details>().Where(p => p.DicCode == "Sex").ToList();
            this.input_Sex.DataSource = Sex;
            List<IView_Dept> Dept = CIS.Purview.Purview.GetDeptList();
            this.input_Dept_Code.DataSource = Dept;

            this.input_Birthday.Value = DateTime.Now;
            this.input_Dept_Code.SelectedValue = Dept_Code ?? Dept[0].Code;

            if (this.btnAddOrUpdate.Text == "保存")
            {
                //CIS.Utility.ControlHelper.SetValue<Sys_User>(this, CIS.Purview.Purview.GetUserList(UserID.AsInt(0)), true);
                //CIS.Utility.ControlHelper.SetValue<Sys_User_Subsidiary>(this.groupBox2, DBHelper.CIS.From<Sys_User_Subsidiary>().Where(p => p.ID == UserID.AsInt(0)).First(), false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (this.btnAddOrUpdate.Text == "保存")
                UpdateUser();
            else
                AddUser();
        }

        private void UpdateUser()
        {
            IView_User user = CIS.Utility.ControlHelper.GetValue<IView_User>(this.groupBox1);
            Sys_User_Subsidiary user_sub = CIS.Utility.ControlHelper.GetValue<Sys_User_Subsidiary>(this.groupBox2);
            Sys_User tmp = DBHelper.CIS.From<Sys_User>().Where(p => p.Code == user.Code && p.ID != UserID).ToFirst();
            user_sub.Code = user.Code;
            user_sub.Name = user.Name;
            user.Dept_Code = user_sub.Dept_Code;
            user.Status = 1;
            user.Sex = user_sub.Sex;
            if (tmp != null && tmp.Status == 1)
            {
                MessageBox.Show("当前编码已经存在并处于正在使用状态,请重新输入");
                return;
            }
            DBHelper.CIS.Delete<Sys_User>(p => p.ID == UserID);
            DBHelper.CIS.Delete<Sys_User_Subsidiary>(p => p.ID == UserID);
            DBHelper.CIS.Insert<IView_User>(user);
            DBHelper.CIS.Insert<Sys_User_Subsidiary>(user_sub);
            CIS.Core.AlertBox.Info("保存成功");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AddUser()
        {
            IView_User user = CIS.Utility.ControlHelper.GetValue<IView_User>(this.groupBox1);
            Sys_User_Subsidiary user_sub = CIS.Utility.ControlHelper.GetValue<Sys_User_Subsidiary>(this.groupBox2);
            user_sub.Code = user.Code;
            user_sub.Name = user.Name;
            user.Dept_Code = user_sub.Dept_Code;
            user.Status = 1;
            user.Sex = user_sub.Sex;
            if (user.Code != "")
            {
                IView_User tmp = DBHelper.CIS.From<IView_User>().Where(p => p.Code == user.Code).ToFirst();
                if (tmp != null && tmp.Status == 1)
                {
                    MessageBox.Show("当前编码已经存在并处于正在使用状态,请重新输入");
                    return;
                }
                DBHelper.CIS.Insert<IView_User>(user);
                DBHelper.CIS.Insert<Sys_User_Subsidiary>(user_sub);
                CIS.Core.AlertBox.Info("保存成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("用户编码不能为空,请重新输入");
        }
    }
}
