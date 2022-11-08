using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace App_Sys
{
    public partial class FormAddParameter : DevComponents.DotNetBar.Office2007RibbonForm
    {
        Sys_Parameter Parameter = new Sys_Parameter();//参数配置表
        public FormAddParameter()
        {
            InitializeComponent();
            this.ControlBox = false;
            InitUI();
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitUI()
        {
            Dictionary<int, string> sta = new Dictionary<int, string>();
            sta.Add(0, "可编辑");
            sta.Add(1, "不可编辑");
            sta.Add(2, "停用");
            BindingSource Type = new BindingSource();
            Type.DataSource = sta;
            this.input_Status.DataSource = Type;
        }

        //新增false,修改true
        bool edit = false;
        /// <summary>
        /// 修改时调用
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
        /// 保存
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
                //修改
                int reUpdate = DBHelper.CIS.Update<Sys_Parameter>(Param, Sys_Parameter._.ID == Parameter.ID);
                if (reUpdate > 0)
                {
                    MsgBox.OK("已修改" + Param.ParameterName);
                    this.Close();
                }
                else MsgBox.RetryCancel("修改失败!请重试");
            }
            else
            {
                //新增
                int reInsert = DBHelper.CIS.Insert<Sys_Parameter>(Param);
                if (reInsert > 0)
                {
                    MsgBox.OK("已添加" + Param.ParameterName);
                    this.Close();
                }
                else MsgBox.RetryCancel("添加失败!请重试");
            }
        }


        /// <summary>
        /// 判断对象值
        /// </summary>
        /// <returns></returns>
        private bool Validing()
        {
            if (string.IsNullOrWhiteSpace(input_Code.Text))
            {
                input_Code.Focus();
                AlertBox.Error("编码不可以为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("名称不可以为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_ParamValue.Text))
            {
                input_Name.Focus();
                AlertBox.Error("值不可以为空");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取消并关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}