using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Purview;
using CIS.Core;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace App_Sys
{
    public partial class FormSetSysParameter : Form
    {
        List<Sys_Parameter> ParamList = new List<Sys_Parameter>();//参数配置表
        List<Sys_Parameter> HasParamList = new List<Sys_Parameter>();//参数配置表
        public FormSetSysParameter()
        {
            InitializeComponent();
            InitUI();
            InitData();
        }

        /// <summary>
        /// 初始化数据绑定
        /// </summary>
        private void InitData()
        {
            ParamList = DBHelper.CIS.From<Sys_Parameter>().ToList(); 
            HasParam();
            Application.DoEvents();
            this.gridSysParameter.PrimaryGrid.SetSelectedRows(0, 1, true);
        }
        
        /// <summary>
        /// 设置状态颜色显示
        /// </summary>
        private void StatusColor()
        {
            if (this.gridSysParameter.PrimaryGrid.Rows.Count > 0)
                for (int i = 0; i < HasParamList.Count; i++)
                {
                    GridRow rows = this.gridSysParameter.PrimaryGrid.Rows[i] as GridRow;
                    Sys_Parameter temp = rows.DataItem as Sys_Parameter;
                    object cell = this.gridSysParameter.PrimaryGrid.GridPanel.GetCell(i, 4).Value;
                    if (temp.Status == 1)
                        this.gridSysParameter.PrimaryGrid.GridPanel.GetCell(i, 4).CellStyles.Default.Background.Color1 = Color.Red;
                    else if (temp.Status == 2)
                        this.gridSysParameter.PrimaryGrid.GridPanel.GetCell(i, 4).CellStyles.Default.Background.Color1 = Color.Gray;
                }
        }

        /// <summary>
        /// 编辑0可编辑，1不可编辑，2停用
        /// </summary>
        private void HasParam()
        {
            HasParamList.Clear();
            if (cbStop.Checked == true)
            {
                if (cbNoAllow.Checked == true)
                {
                    //数据筛选
                    HasParamList = ParamList.Where(x => x.Status == 0).ToList();
                    gridSysParameter.PrimaryGrid.DataSource = HasParamList;
                }
                else
                {
                    //数据筛选
                    HasParamList = ParamList.Where(x => x.Status != 2).ToList();
                    gridSysParameter.PrimaryGrid.DataSource = HasParamList;
                }
            }
            else
            {
                if (cbNoAllow.Checked == true)
                {
                    //数据筛选
                    HasParamList = ParamList.Where(x => x.Status != 1).ToList();
                    gridSysParameter.PrimaryGrid.DataSource = HasParamList;
                }
                else
                {
                    HasParamList = DBHelper.CIS.From<Sys_Parameter>().ToList();
                    gridSysParameter.PrimaryGrid.DataSource = HasParamList;
                }
            }

        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        private void cbStop_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            HasParam();
            Application.DoEvents();
            this.gridSysParameter.PrimaryGrid.SetSelectedRows(0, 1, true);
            StatusColor();
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        private void cbNoAllow_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            HasParam();
            Application.DoEvents();
            this.gridSysParameter.PrimaryGrid.SetSelectedRows(0, 1, true);
            StatusColor();
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
            var pCode = this.gridSysParameter.PrimaryGrid.Columns["colEditStatus"];
            pCode.EditorType = typeof(MyComboBox);
            pCode.EditorParams = new object[] { sta.ToList() };

        }

        /// <summary>
        /// 刷新表
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitData();
            Application.DoEvents();
            this.gridSysParameter.PrimaryGrid.SetSelectedRows(0, 1, true);
            StatusColor();
        }

        /// <summary>
        /// 添加
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddParameter FormAddParameter = new FormAddParameter();
            FormAddParameter.ShowDialog();
            btnRefresh_Click(null, null);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridSysParameter.PrimaryGrid.DataSource != null && gridSysParameter.PrimaryGrid.Rows.Count > 0)
            {
                if (gridSysParameter.PrimaryGrid.GetSelectedRows().Count < 1) { AlertBox.Info("请先选中行！"); return; }

                GridRow row = this.gridSysParameter.GetSelectedRows()[0] as GridRow;
                Sys_Parameter temp = row.DataItem as Sys_Parameter;    //实例化编辑行  
                if (temp.Status == 0)
                {
                    FormAddParameter FormAddParameter = new FormAddParameter(temp);
                    FormAddParameter.ShowDialog();
                    btnRefresh_Click(null, null);
                }
                else if (temp.Status == 2)
                {
                    FormAddParameter FormAddParameter = new FormAddParameter(temp);
                    FormAddParameter.input_Description.Enabled = false;
                    FormAddParameter.input_Name.Enabled = false;
                    FormAddParameter.input_Code.Enabled = false;
                    FormAddParameter.input_ParamValue.Enabled = false;
                    FormAddParameter.ShowDialog();
                    btnRefresh_Click(null, null);
                }
                else AlertBox.Info("该状态下不允许编辑！");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridSysParameter.PrimaryGrid.DataSource != null && gridSysParameter.PrimaryGrid.Rows.Count > 0)
            {
                if (gridSysParameter.PrimaryGrid.GetSelectedRows().Count <= 0) { AlertBox.Info("请先选中行！"); return; }

                GridRow row = this.gridSysParameter.GetSelectedRows()[0] as GridRow;
                Sys_Parameter temp = row.DataItem as Sys_Parameter;    //实例化编辑行  
                if (temp.Status == 0)
                {
                    string deleteCode = temp.ParameterCode;
                    try
                    {
                        if (MsgBox.YesNo("确定要删除么？") == DialogResult.Yes)
                        {
                            int deleteCount = SysParameterDal.Delete(deleteCode);
                            if (deleteCount == 0)
                            {
                                AlertBox.Info("保存成功！");
                                InitData();
                            }
                            else AlertBox.Info("保存失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.OK(ex.Message);
                    }
                }
                else AlertBox.Info("该状态下不允许编辑！");
            }
        }

        private void gridSysParameter_RowClick(object sender, GridRowClickEventArgs e)
        {
            GridRow row = null;
            if (this.gridSysParameter.PrimaryGrid.GetSelectedRows().Count > 0)
                row = this.gridSysParameter.PrimaryGrid.GetSelectedRows()[0] as GridRow;
        }

        public class MyComboBox : GridComboBoxExEditControl
        {
            public MyComboBox(object Source)
            {
                this.DisplayMember = "Value";
                this.ValueMember = "Key";
                this.DataSource = Source;
            }

        }

        private void gridSysParameter_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }
        
    }
}
