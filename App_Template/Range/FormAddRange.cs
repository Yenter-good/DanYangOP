using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dos.ORM;
using CIS.Model;
using CIS.Core;
using System.Linq;

namespace App_Template
{
    public partial class FormAddRange : DevComponents.DotNetBar.Office2007RibbonForm
    {
        List<TP_RangeType> RTypeList = new List<TP_RangeType>();//值域类型表
        List<TP_RangeType> HasRTypeList = new List<TP_RangeType>();//值域类型表
        public TP_RangeType RType = new TP_RangeType();
        public FormAddRange()
        {
            InitializeComponent();
            RTypeList = DBHelper.CIS.From<TP_RangeType>().ToList();
            this.ControlBox = false;
        }

        //新增false,修改true
        bool edit = false;
        /// <summary>
        /// 修改时调用
        /// </summary>
        /// <param name="Range"></param>
        public FormAddRange(TP_Range Range)
        {
            InitializeComponent();
            RTypeList = DBHelper.CIS.From<TP_RangeType>().ToList();
            this.ControlBox = false;
            edit = true;
            input_Code.Enabled = false;
            input_Code.Text = Range.Code;
            input_Name.Enabled = false;
            input_Name.Text = Range.Name;
            input_RTypeCode.Enabled = false;
            HasRTypeList = RTypeList.Where(x => x.Code == Range.RangeTypeCode).ToList();
            if (HasRTypeList.Count == 1)
            {
                RType = HasRTypeList[0];
                this.input_RTypeCode.Text = RType.Name;
            }
            input_No.Value = Convert.ToInt32(Range.No);
            input_Search.Text = Range.SearchCode;
            FormAddTPRange_MouseClick(null, null);
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Validing()) return;
            TP_Range Range = new TP_Range();
            Range.Code = input_Code.Text.Trim();
            Range.Name = input_Name.Text.Trim();
            Range.RangeTypeCode = RType.Code; 
            Range.No = input_No.Value;
            if (input_Search.Text.Trim() != "") Range.SearchCode = input_Search.Text.Trim();
            else Range.SearchCode = Range.Name.ToUpper().GetSpell();
            if (edit == true)
            {
                //修改
                Dictionary<Field, object> dicRange = new Dictionary<Field, object>();
                dicRange.Add(TP_Range._.Name, Range.Name);
                dicRange.Add(TP_Range._.No, Range.No);
                dicRange.Add(TP_Range._.SearchCode, Range.SearchCode);
                int reUpdate = DBHelper.CIS.Update<TP_Range>(dicRange, TP_Range._.Code == Range.Code);
                if (reUpdate > 0)
                {
                    MsgBox.OK("已修改" + Range.Name);
                    this.Close();
                }
                else MsgBox.RetryCancel("修改失败!请重试");
            }
            else
            {
                //新增
                int reInsert = DBHelper.CIS.Insert<TP_Range>(Range);
                if (reInsert > 0)
                {
                    MsgBox.OK("已添加" + Range.Name);
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
            this.gridDropDown.Left = this.input_RTypeCode.Left;
            this.gridDropDown.Top = this.input_RTypeCode.Bottom;
            this.gridDropDown.Show();
            HasRTypeList = RTypeList.Where(x => x.Name.Contains(this.input_RTypeCode.Text)).ToList();
            this.gridDropDown.DataSource = HasRTypeList;
            if (HasRTypeList.Count == 1) RType = HasRTypeList[0];
        }

        private void gridDropDown_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //选择一行并且在显示的那一列按的键是回车键
            if (this.gridDropDown.SelectedRows.Count > 0)
            {
                object[] obj;
                obj = new object[] { this.gridDropDown.CurrentRow.Cells["Code"].Value.ToString(), 
                                     this.gridDropDown.CurrentRow.Cells["Name"].Value.ToString() };
                RType.Code = obj[0].ToString();
                RType.Name = obj[1].ToString();
                this.input_RTypeCode.Text = obj[1].ToString();
                Application.DoEvents();
                this.Focus();
                //关闭提示窗口
                this.gridDropDown.Hide();
            }
        }

        private void FormAddTPRange_MouseClick(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
            this.gridDropDown.Hide();
        }

    }
}