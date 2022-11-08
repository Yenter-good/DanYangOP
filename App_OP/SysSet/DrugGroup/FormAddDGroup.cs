using System;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    public partial class FormAddDGroup : BaseForm
    {
        public FormAddDGroup()
        {
            InitializeComponent();
        }

        public string status = "add";//״̬ �༭������
        public string parentID = "0";//���ڵ�ID
        public int type = 1;//1���� 2����
        public int drugType = 1;//1�����гɣ�ҩ 2��ҩ
        public OP_DrugGroup group = new OP_DrugGroup();


        private void FormAddDGroup_Shown(object sender, EventArgs e)
        {
            if (status == "add")
            {
                radioButton1.Checked = type == 0;
                rdo1.Checked = type == 1;
                rdo2.Checked = type == 2;
            }
            else
            {
                SetValue();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            int i = 0;
            if (status == "add")
            {
                GetValue();
                group.ID = Guid.NewGuid().ToString();
                group.DrugType = this.drugType;
                i = DBHelper.CIS.Insert<OP_DrugGroup>(group);
            }
            else
            {
                GetValue();
                i = DBHelper.CIS.Update<OP_DrugGroup>(group, OP_DrugGroup._.ID == group.ID);
            }

            if (i > 0)
                AlertBox.Info("����ɹ�");
            else
                AlertBox.Error("����ʧ��");

            if (status == "add")
            {
                tbxName.Text = "";
            }
            this.Close();
        }

        private void SetValue()
        {
            radioButton1.Checked = group.GroupType == 0;
            rdo1.Checked = group.GroupType == 1 || group.GroupType == null;
            rdo2.Checked = group.GroupType == 2;
            tbxName.Text = group.Name;
            tbxNo.Text = group.No.ToString();
        }

        private void GetValue()
        {
            group.Name = tbxName.Text.Trim();
            if (radioButton1.Checked)
            {
                group.GroupType = 0;
                group.Owner = "*";
            }
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
                group.DrugType = drugType;
            }
        }


        private bool Validing()
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                tbxName.Focus();
                AlertBox.Error("�������Ʋ�����Ϊ��");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ȡ�����ر�
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}