using System;
using CIS.Model;
using CIS.Core;
using CIS.Utility;


namespace App_Sys
{
    public partial class FormAddRole : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormAddRole()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            Sys_Role role = ControlHelper.GetValue<Sys_Role>(this);
            try
            {
                DBHelper.CIS.Delete<Sys_Role>(Sys_Role._.Code == role.Code);
                DBHelper.CIS.Insert<Sys_Role>(role);
                AlertBox.Info("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                AlertBox.Error(ex.Message);
            }
            
        }

        private bool Validing()
        {
            if (string.IsNullOrWhiteSpace(input_Code.Text))
            {
                input_Code.Focus();
                AlertBox.Error("角色代码不可以为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("角色名称不可以为空");
                return false;
            } 

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
