using System;
using CIS.Model;
using CIS.Core;

namespace App_Sys
{
    public partial class FormAddDic : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormAddDic()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        //����false,�޸�true
        bool edit = false;
        /// <summary>
        /// �޸�ʱ����
        /// </summary>
        /// <param name="dic"></param>
        public FormAddDic(Sys_Dic dic)
        {
            InitializeComponent();
            this.ControlBox = false;
            edit = true;
            input_Code.Enabled = false;
            input_Code.Text = dic.Code;
            input_Name.Enabled = false;
            input_Name.Text = dic.Name;
            input_Description.Text = dic.Description;
            if (dic.Style == 0) input_Style.Text = "���ɱ༭";
            else if (dic.Style == 1) input_Style.Text = "�ɱ༭";
            input_Search.Text = dic.SearchCode;
        }
        
        /// <summary>
        /// ����
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            Sys_Dic Dic = new Sys_Dic();
            Dic.Code = input_Code.Text.Trim();
            Dic.Name = input_Name.Text.Trim();
            Dic.Description = input_Description.Text.Trim();
            if (input_Style.Text.Trim() == "���ɱ༭") Dic.Style = 0;
            else if (input_Style.Text.Trim() == "�ɱ༭") Dic.Style = 1;
            else Dic.Style = String.IsNullOrEmpty(input_Style.Text.Trim()) ? 0 : 1;//��ֵ��Ϊ0
            if (input_Search.Text.Trim() != "") Dic.SearchCode = input_Search.Text.Trim();
            else Dic.SearchCode = Dic.Name.ToUpper().GetSpell();
            if (edit == true)
            {
                //�޸�
                int reUpdate = DBHelper.CIS.Update<Sys_Dic>(Dic, Sys_Dic._.Code == Dic.Code);
                if (reUpdate > 0)
                {
                    MsgBox.OK("���޸����" + Dic.Name);
                    this.Close();
                }
                else MsgBox.RetryCancel("�޸�ʧ��!������");
            }
            else
            {
                //����
                int reInsert = DBHelper.CIS.Insert<Sys_Dic>(Dic);
                if (reInsert > 0)
                {
                    MsgBox.OK("��������" + Dic.Name);
                    this.Close();
                }
                else MsgBox.RetryCancel("���ʧ��!������");
            }
        }


        /// <summary>
        /// �ж϶���ֵ
        /// </summary>
        /// <returns></returns>
        private bool Validing()
        {
            if (string.IsNullOrWhiteSpace(input_Code.Text))
            {
                input_Code.Focus();
                AlertBox.Error("�����벻����Ϊ��");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("������Ʋ�����Ϊ��");
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