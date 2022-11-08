using System;
using System.Collections.Generic;
using CIS.Model;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace App_Sys
{
    public partial class FormAddDept : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Node ParentCode;
        public bool IsEdit;

        public FormAddDept()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormAddDept_Shown(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            List<Sys_Dept> dept = DBHelper.CIS.From<Sys_Dept>().Where(p => p.PCode == "").ToList();
            this.cbxParentDept.DataSource = dept;

            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "门诊");
            dict.Add(2, "护理");
            dict.Add(3, "临床");
            dict.Add(4, "医技");
            dict.Add(5, "急诊");
            dict.Add(6, "留观病房");
            dict.Add(7, "库房");
            dict.Add(8, "后勤");
            dict.Add(9, "行政职能");
            BindingSource Type = new BindingSource();
            Type.DataSource = dict;
            this.cbxDeptType.DataSource = Type;

            Sys_Dept dept1 = ParentCode.Tag as Sys_Dept;
            if (IsEdit)
            {
                this.textBoxX1.Enabled = false;
                this.textBoxX1.Text = dept1.Code;
                this.textBoxX2.Text = dept1.Name;
                this.cbxDeptType.SelectedValue = dept1.Type;
                this.cbxCategory.SelectedValue = dept1.Category_Code;
                this.cbxParentDept.SelectedValue = dept1.PCode;
            }
            else
                this.cbxParentDept.SelectedValue = dept1.Code;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sys_Dept dept = DBHelper.CIS.From<Sys_Dept>().Where(p => p.Code == this.textBoxX1.Text).ToFirst();
            if (!IsEdit)
            {
                if (dept != null)
                {
                    CIS.Core.AlertBox.Error("当前编码已经存在,请重新输入");
                    return;
                }
            }
            if (this.textBoxX1.Text == "")
            {
                CIS.Core.AlertBox.Error("科室编码不能为空,请重新输入");
                return;
            }

            dept = new Sys_Dept();
            dept.Code = this.textBoxX1.Text;
            dept.Name = this.textBoxX2.Text;
            dept.PCode = this.cbxParentDept.SelectedValue.ToString();
            dept.Status = 1;
            dept.Type = this.cbxDeptType.SelectedValue.AsInt(1);
            if (IsEdit)
                DBHelper.CIS.Delete<Sys_Dept>(p => p.Code == dept.Code);

            DBHelper.CIS.Insert<Sys_Dept>(dept);
            CIS.Core.AlertBox.Info("保存成功");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }
    }
}
