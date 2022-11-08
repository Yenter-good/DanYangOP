using System;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_OP.SysSet.ExaminationGruop
{
    public partial class FormAddGroup : BaseForm
    {
        public FormAddGroup()
        {
            InitializeComponent();
        }

        public string status = "add";//状态 编辑或新增
        public string type = "jy";//添加类型
        public string parentID = "0";//父节点ID
        public IView_Inside_ExamineGroup group = new IView_Inside_ExamineGroup();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            int i = 0;
            if (status == "add")
            {
                GetValue();
                group.ID = Guid.NewGuid().ToString();
                i = DBHelper.CIS.Insert<IView_Inside_ExamineGroup>(group);
            }
            else
            {
                GetValue();
                i = DBHelper.CIS.Update<IView_Inside_ExamineGroup>(group, IView_Inside_ExamineGroup._.ID == group.ID);
            }

            if (i > 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error("保存失败");
            this.Close();
        }

        private void SetValue()
        {

            rdo1.Checked = group.GroupLevel == 0 || group.GroupLevel == null;
            rdo2.Checked = group.GroupLevel == 1;
            rdo3.Checked = group.GroupLevel == 2;
            tbxName.Text = group.Name;
            tbxNo.Text = group.No.ToString();
        }

        private void GetValue()
        {
            group.Name = tbxName.Text.Trim();
            if (rdo1.Checked) group.GroupLevel = 0;
            if (rdo3.Checked) group.GroupLevel = 1;
            if (rdo2.Checked) group.GroupLevel = 2;
            group.No = Convert.ToInt32(tbxNo.Value);
            if (status == "add")
            {
                group.GroupType = type;
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
            SetValue();
        }
    }
}
