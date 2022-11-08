using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_Sys
{
    public partial class FormAddParameter : DevComponents.DotNetBar.Office2007RibbonForm
    {
        Sys_Parameter Parameter = new Sys_Parameter();//�������ñ�
        public FormAddParameter()
        {
            InitializeComponent();
            this.ControlBox = false;
            InitUI();
        }

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        private void InitUI()
        {
            Dictionary<int, string> sta = new Dictionary<int, string>();
            sta.Add(0, "�ɱ༭");
            sta.Add(1, "���ɱ༭");
            sta.Add(2, "ͣ��");
            BindingSource Type = new BindingSource();
            Type.DataSource = sta;
            this.input_Status.DataSource = Type;
        }

        //����false,�޸�true
        bool edit = false;
        /// <summary>
        /// �޸�ʱ����
        /// </summary>
        /// <param name="Param"></param>
        public FormAddParameter(Sys_Parameter Param)
        {
            InitializeComponent();
            this.ControlBox = false;
            Parameter = Param;
            InitUI();
            edit = true;
            input_Code.Enabled = false;
            input_Code.Text = Param.ParameterCode;
            input_Name.Enabled = false;
            input_Name.Text = Param.ParameterName;
            input_ParamValue.Text = Param.ParameterValue;
            input_Description.Text = Param.Description;
            input_Status.SelectedValue = Param.Status;
        }
        
        /// <summary>
        /// ����
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            Sys_Parameter Param = new Sys_Parameter();
            Param.ParameterCode = input_Code.Text.Trim();
            Param.ParameterName = input_Name.Text.Trim();
            Param.ParameterValue = this.input_ParamValue.Text.Trim();
            Param.Description = input_Description.Text.Trim();
            Param.Status = Convert.ToInt32(input_Status.SelectedValue.ToString());
            if (edit == true)
            {
                //�޸�
                int reUpdate = DBHelper.CIS.Update<Sys_Parameter>(Param, Sys_Parameter._.ID == Parameter.ID);
                if (reUpdate > 0)
                {
                    MsgBox.OK("���޸�" + Param.ParameterName);
                    this.Close();
                }
                else MsgBox.RetryCancel("�޸�ʧ��!������");
            }
            else
            {
                //����
                int reInsert = DBHelper.CIS.Insert<Sys_Parameter>(Param);
                if (reInsert > 0)
                {
                    MsgBox.OK("�����" + Param.ParameterName);
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
                AlertBox.Error("���벻����Ϊ��");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("���Ʋ�����Ϊ��");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_ParamValue.Text))
            {
                input_Name.Focus();
                AlertBox.Error("ֵ������Ϊ��");
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