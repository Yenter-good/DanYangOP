using System;
using CIS.Model;
using CIS.Core;

namespace App_Template
{
    public partial class FormAddRangeType : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormAddRangeType()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        //新增false,修改true
        bool edit = false;
        /// <summary>
        /// 修改时调用
        /// </summary>
        /// <param name="RType"></param>
        public FormAddRangeType(TP_RangeType RType)
        {
            InitializeComponent();
            this.ControlBox = false;
            edit = true;
            input_Code.Enabled = false;
            input_Code.Text = RType.Code;
            input_Name.Enabled = false;
            input_Name.Text = RType.Name;
            input_Description.Text = RType.Description;
            if (RType.Status == 0) input_Status.Text = "未使用";
            else if (RType.Status == 1) input_Status.Text = "使用";
            input_Search.Text = RType.SearchCode;
            input_No.Value = Convert.ToInt32(RType.No);
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            TP_RangeType RType = new TP_RangeType();
            RType.Code = input_Code.Text.Trim();
            RType.Name = input_Name.Text.Trim();
            RType.Description = input_Description.Text.Trim();
            RType.No = input_No.Value;
            if (input_Status.Text.Trim() == "未使用") RType.Status = 0;
            else if (input_Status.Text.Trim() == "使用") RType.Status = 1;
            else RType.Status = String.IsNullOrEmpty(input_Status.Text.Trim()) ? 0 : 1;//空值则为0
            if (input_Search.Text.Trim() != "") RType.SearchCode = input_Search.Text.Trim();
            else RType.SearchCode = RType.Name.ToUpper().GetSpell();
            RType.Updater = "9999";//SysContext.CurrUser.user.Code;
            RType.UpdateDate = System.DateTime.Now;
            if (edit == true)
            {
                //修改
                int reUpdate = DBHelper.CIS.Update<TP_RangeType>(RType, TP_RangeType._.Code == RType.Code);
                if (reUpdate > 0)
                {
                    MsgBox.OK("已修改类型" + RType.Name);
                    this.Close();
                }
                else MsgBox.RetryCancel("修改失败!请重试");
            }
            else
            {
                //新增
                int reInsert = DBHelper.CIS.Insert<TP_RangeType>(RType);
                if (reInsert > 0)
                {
                    MsgBox.OK("已添加类型" + RType.Name);
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
                AlertBox.Error("类型编码不可以为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(input_Name.Text))
            {
                input_Name.Focus();
                AlertBox.Error("类型名称不可以为空");
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