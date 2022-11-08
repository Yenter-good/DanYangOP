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

        //新增false,修改true
        bool edit = false;
        /// <summary>
        /// 修改时调用
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
            if (dic.Style == 0) input_Style.Text = "不可编辑";
            else if (dic.Style == 1) input_Style.Text = "可编辑";
            input_Search.Text = dic.SearchCode;
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            Sys_Dic Dic = new Sys_Dic();
            Dic.Code = input_Code.Text.Trim();
            Dic.Name = input_Name.Text.Trim();
            Dic.Description = input_Description.Text.Trim();
            if (input_Style.Text.Trim() == "不可编辑") Dic.Style = 0;
            else if (input_Style.Text.Trim() == "可编辑") Dic.Style = 1;
            else Dic.Style = String.IsNullOrEmpty(input_Style.Text.Trim()) ? 0 : 1;//空值则为0
            if (input_Search.Text.Trim() != "") Dic.SearchCode = input_Search.Text.Trim();
            else Dic.SearchCode = Dic.Name.ToUpper().GetSpell();
            if (edit == true)
            {
                //修改
                int reUpdate = DBHelper.CIS.Update<Sys_Dic>(Dic, Sys_Dic._.Code == Dic.Code);
                if (reUpdate > 0)
                {
                    MsgBox.OK("已修改类别" + Dic.Name);
                    this.Close();
                }
                else MsgBox.RetryCancel("修改失败!请重试");
            }
            else
            {
                //新增
                int reInsert = DBHelper.CIS.Insert<Sys_Dic>(Dic);
                if (reInsert > 0)
                {
                    MsgBox.OK("已添加类别" + Dic.Name);
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
                AlertBox.Error("类别编码不可以为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("类别名称不可以为空");
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