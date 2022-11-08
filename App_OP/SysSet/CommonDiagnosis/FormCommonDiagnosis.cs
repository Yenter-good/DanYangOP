using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP.SysSet.CommonDiagnosis
{
    public partial class FormCommonDiagnosis : BaseForm
    {
        public FormCommonDiagnosis()
        {
            InitializeComponent();
        }

        List<IView_HIS_ICD> icdList = new List<IView_HIS_ICD>();
        List<OP_Dic_CommonICD> commonIcdList = new List<OP_Dic_CommonICD>();

        private void FormCommonDiagnosis_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SysContext.RunSysInfo.user.ID) || string.IsNullOrWhiteSpace(SysContext.RunSysInfo.currDept.Code))
            {
                MsgBox.OK("系统未加载到当前科室或当前操作员请联系管理员！");
                return;
            }
            InitData();
            InitUI();
        }
        private void InitData()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1.Columns.Add("a");
            dt1.Columns.Add("b");
            dt1.Columns.Add("c");
            dt1.Columns.Add("d");

            dt2.Columns.Add("a");
            dt2.Columns.Add("b");   //这里我创建了两个表一个有列abcd,一个有列ab,但是我没有添加数据

            foreach (DataRow item in dt1.Rows)  //循环第一张表的行
            {
                DataRow row = dt2.NewRow(); //第二张表实例化一个行
                foreach (DataColumn item1 in dt1.Columns)   //循环第一张表的列
                {
                    if (dt2.Columns.Contains(item1.ColumnName))     //如果在第二张表里找不到某一列就进入下一个循环
                        continue;
                    row[item1.ColumnName] = item[item1];    //将第一个表的对应行某列的值赋值给row的对应位置
                }
                dt2.Rows.Add(row);  //将行插入表二
            }


            icdList = DBHelper.CIS.From<IView_HIS_ICD>().ToList();
        }

        private void InitUI()
        {
            gridICD.PrimaryGrid.AutoGenerateColumns = false;
            gridCommon.PrimaryGrid.AutoGenerateColumns = false;
            RefrshCommonList();

            Application.DoEvents();
        }
        private void RefrshCommonList()
        {
            commonIcdList = DBHelper.CIS.From<OP_Dic_CommonICD>().Where(x => x.DeptCode == SysContext.RunSysInfo.currDept.Code).ToList();
            gridCommon.PrimaryGrid.DataSource = commonIcdList;

            Application.DoEvents();
            gridCommon.PrimaryGrid.ClearSelectedCells();

            foreach (GridRow item in this.gridCommon.PrimaryGrid.Rows)
            {
                if (item.Cells["Type"].Value.AsString("") == "ICD")
                    item.Cells[0].Value = "西医诊断";
                else if (item.Cells["Type"].Value.AsString("") == "HMDiagnosis")
                    item.Cells[0].Value = "中医诊断";
                else
                    item.Cells[0].Value = "中医证候";
            }
        }
        //点击添加到常用诊断按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddICDItem();
        }
        //右键菜单
        private void btnAdd_R_Click(object sender, EventArgs e)
        {
            AddICDItem();
        }
        //双击行
        private void gridICD_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            AddICDItem();
        }
        private void AddICDItem()
        {
            SelectedElementCollection rows = gridICD.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            int errorNumber = 0;
            int saveNumber = 0;
            foreach (GridRow row in rows)
            {
                string name = row["DiaName"].Value.ToString();
                string code = row["Code"].Value.ToString();
                if (commonIcdList.Where(x => x.Name == name).ToList().Count > 0)
                {
                    AlertBox.Info("诊断" + name + "已存在");
                    errorNumber++;
                    continue;
                }
                OP_Dic_CommonICD item = new OP_Dic_CommonICD();
                item.ID = Guid.NewGuid().ToString();
                item.Code = code;
                item.Name = name;
                item.SearchCode = name.GetSpell();
                item.DeptCode = SysContext.RunSysInfo.currDept.Code;
                item.Updater = SysContext.RunSysInfo.user.ID;
                item.Type = row[2].Value.ToString();
                item.UpdateTime = DateTime.Now;
                int i = DBHelper.CIS.Insert<OP_Dic_CommonICD>(item);
                if (i < 1)
                    errorNumber++;
                else
                    saveNumber++;
            }

            if (saveNumber != 0)
                AlertBox.Info("保存成功");

            RefrshCommonList();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = tbxSearch.Text.Trim();
            if (text.Length == 0)
                gridICD.PrimaryGrid.DataSource = null;
            else
                gridICD.PrimaryGrid.DataSource = icdList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) || x.Name.Contains(text)).ToList();

            Application.DoEvents();
            foreach (GridRow item in this.gridICD.PrimaryGrid.Rows)
            {
                if (item.Cells["Type"].Value.ToString() == "ICD")
                    item.Cells["TypeName"].Value = "西医诊断";
                else if (item.Cells["Type"].Value.ToString() == "HMDiagnosis")
                    item.Cells["TypeName"].Value = "中医诊断";
                else
                    item.Cells["TypeName"].Value = "中医证候";
            }
            gridICD.PrimaryGrid.ClearSelectedCells();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = tbxCode.Text.Trim();
            string name = tbxName.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                AlertBox.Error("请输入诊断编码，默认为 A00.999");
                return;
            }
            if (commonIcdList.Where(x => x.Name.Trim() == name.Trim()).ToList().Count > 0)
            {
                AlertBox.Error("已经添加过了");
                return;
            }
            OP_Dic_CommonICD item = new OP_Dic_CommonICD();
            item.ID = Guid.NewGuid().ToString();
            item.Code = code;
            item.Name = name;
            item.SearchCode = name.GetSpell();
            item.DeptCode = SysContext.RunSysInfo.currDept.Code;
            item.Updater = SysContext.RunSysInfo.user.ID;
            int i = DBHelper.CIS.Insert<OP_Dic_CommonICD>(item);
            if (i > 0)
                AlertBox.Info("保存成功");
            else
                AlertBox.Error("保存失败");

            RefrshCommonList();
        }

        private void btnDel_R_Click(object sender, EventArgs e)
        {
            DelItem();
        }

        private void DelItem()
        {
            SelectedElementCollection rows = gridCommon.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一个项目");
                return;
            }
            int errorNumber = 0;
            foreach (GridRow row in rows)
            {
                string ID = row["gridCommon_ID"].Value.AsString("");
                int i = DBHelper.CIS.Delete<OP_Dic_CommonICD>(OP_Dic_CommonICD._.ID == ID);

                if (i < 1)
                    errorNumber++;
            }

            if (errorNumber == 0)
                AlertBox.Info("删除成功");
            else
                AlertBox.Error(errorNumber + "条记录删除失败");
            RefrshCommonList();
        }

        private void gridCommon_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            DelItem();
        }



    }
}
