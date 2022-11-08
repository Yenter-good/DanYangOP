using System;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_OP.SysSet.DearWithGroup
{
    public partial class FormAddGroup : BaseForm
    {
        public FormAddGroup()
        {
            InitializeComponent();
        }

        public string status = "add";//状态 编辑或新增
        public string parentID = "0";//父节点ID
        public int type = 1;//1科室 2个人
        public OP_DearWithGroup group = new OP_DearWithGroup();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            int i = 0;
            if (status == "add")
            {
                GetValue();
                group.ID = Guid.NewGuid().ToString();
                i = DBHelper.CIS.Insert<OP_DearWithGroup>(group);
            }
            else
            {
                GetValue();
                i = DBHelper.CIS.Update<OP_DearWithGroup>(group, OP_DearWithGroup._.ID == group.ID);
            }

            if (i > 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error("保存失败");
            this.Close();

        }

        private void SetValue()
        {
            rdo1.Checked = group.GroupType == 1 || group.GroupType == null;
            rdo2.Checked = group.GroupType == 2;
            tbxName.Text = group.Name;
            tbxNo.Text = group.No.ToString();
        }

        private void GetValue()
        {
            group.Name = tbxName.Text.Trim();
            if (rdo1.Checked)
            {
                group.GroupType = 1;
                group.Owner = SysContext.RunSysInfo.currDept.Code;
            }
            if (rdo2.Checked)
            {
                group.GroupType = 2;
                group.Owner = SysContext.RunSysInfo.user.ID;

            }
            group.No = Convert.ToInt32(tbxNo.Value);
            if (status == "add")
            {
                group.ParentID = parentID;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool Validing()
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                tbxName.Focus();
                AlertBox.Error("分类名称不可以为空");
                return false;
            }
            return true;
        }

        private void FormAddGroup_Shown(object sender, EventArgs e)
        {
            if (status == "add")
            {
                rdo1.Checked = type == 1;
                rdo2.Checked = type == 2;
            }
            else
            {
                SetValue();
            }
        }
    }
}
