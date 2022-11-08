using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using System.Linq;

namespace App_Sys
{
    public partial class FormAddDicDetails : DevComponents.DotNetBar.Office2007RibbonForm
    {
        List<Sys_Dic> dicList = new List<Sys_Dic>();//字典表
        List<Sys_Dic> HasDicList = new List<Sys_Dic>();//字典表
        public Sys_Dic dic = new Sys_Dic();
        public FormAddDicDetails()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.input_DicCode.Text = dic.Name;
            InitUI();
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitUI()
        {
            dicList = DBHelper.CIS.From<Sys_Dic>().ToList();
            //this.input_DicCode1.DataSource = dicList;
            //this.input_DicCode1.ValueMember = "Code";
            //this.input_DicCode1.DisplayMember = "Name";
        }

        //新增false,修改true
        bool edit = false;
        /// <summary>
        /// 修改时调用
        /// </summary>
        /// <param name="DicD"></param>
        public FormAddDicDetails(Sys_Dic_Details DicD)
        {
            InitializeComponent();
            this.ControlBox = false;
            InitUI();
            edit = true;
            input_Code.Enabled = false;
            input_Code.Text = DicD.Code;
            input_Name.Enabled = false;
            input_Name.Text = DicD.Value;
            input_Description.Text = DicD.Description;
            if (edit == true) input_DicCode.Enabled = true;
            HasDicList = dicList.Where(x => x.Code == DicD.DicCode).ToList();
            if (HasDicList.Count == 1)
            {
                dic = HasDicList[0];
                this.input_DicCode.Text = dic.Name;
            }
            input_No.Value = Convert.ToInt32(DicD.No);
            input_Search.Text = DicD.SearchCode;
            FormAddDicDetails_MouseClick(null, null);
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            Sys_Dic_Details DicD = new Sys_Dic_Details();
            DicD.Code = input_Code.Text.Trim();
            DicD.Value = input_Name.Text.Trim();
            DicD.Description = input_Description.Text.Trim();
            DicD.DicCode = dic.Code; 
            DicD.No = input_No.Value;
            if (input_Search.Text.Trim() != "") DicD.SearchCode = input_Search.Text.Trim();
            else DicD.SearchCode = DicD.Value.ToUpper().GetSpell();
            if (edit == true)
            {
                //修改
                int reUpdate = DBHelper.CIS.Update<Sys_Dic_Details>(DicD, Sys_Dic_Details._.Code == DicD.Code);
                if (reUpdate > 0)
                {
                    MsgBox.OK("已修改" + DicD.Value);
                    this.Close();
                }
                else MsgBox.RetryCancel("修改失败!请重试");
            }
            else
            {
                //新增
                int reInsert = DBHelper.CIS.Insert<Sys_Dic_Details>(DicD);
                if (reInsert > 0)
                {
                    MsgBox.OK("已添加" + DicD.Value);
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
            return true;
        }

        /// <summary>
        /// 取消并关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input_DicCode_TextChanged(object sender, EventArgs e)
        {
            this.gridDropDown.Left = this.input_DicCode.Left;
            this.gridDropDown.Top = this.input_DicCode.Bottom;
            this.gridDropDown.Show();
            HasDicList = dicList.Where(x => x.SearchCode.Contains(this.input_DicCode.Text.ToUpper()) || x.Name.Contains(this.input_DicCode.Text)).ToList();
            this.gridDropDown.DataSource = HasDicList;
            if (HasDicList.Count == 1) dic = HasDicList[0];
        }

        private void gridDropDown_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //选择一行并且在显示的那一列按的键是回车键
            if (this.gridDropDown.SelectedRows.Count > 0)
            {
                object[] obj;
                obj = new object[] { this.gridDropDown.CurrentRow.Cells["Code"].Value.ToString(), 
                                     this.gridDropDown.CurrentRow.Cells["Name"].Value.ToString() };
                dic.Code = obj[0].ToString();
                dic.Name = obj[1].ToString();
                this.input_DicCode.Text = obj[1].ToString();
                Application.DoEvents();
                this.Focus();
                //关闭提示窗口
                this.gridDropDown.Hide();
            }
        }

        private void FormAddDicDetails_MouseClick(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
            this.gridDropDown.Hide();
        }

    }
}