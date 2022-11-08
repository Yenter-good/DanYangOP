using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.DotNetBar.SuperGrid;
using CIS.Core;

namespace App_Sys.ICD
{
    public partial class FormICD : Form
    {
        public FormICD()
        {
            InitializeComponent();
        }

        private List<Sys_Dic_ICD> ICDList = new List<Sys_Dic_ICD>();
        private String editType = "Edit";
        private Sys_Dic_ICD CurrICD = new Sys_Dic_ICD();
        private void FormICD_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }
        private void InitData()
        {
            ICDList = DBHelper.CIS.From<Sys_Dic_ICD>().ToList();
        }

        private void InitUI()
        {
            pnlDetail.Enabled = false;

            gridICD.PrimaryGrid.DataSource = ICDList;
            gridICD.PrimaryGrid.AutoGenerateColumns = false;

            Application.DoEvents();//处理消息队列 清除界面堵塞
            gridICD.PrimaryGrid.ClearSelectedCells();//默认不选择行

        }

        private void ClearForm()
        {
            txtCode.Text = "";
            txtInsideCode.Text = "";
            txtDiseasesLevel.Text = "";
            txtName.Text = "";
            txtSearchCode.Text = "";
            txtDays.Text = "";
            txtCost.Text = "";

            CurrICD = new Sys_Dic_ICD();
        }


        private void SetValue(Sys_Dic_ICD icd)
        {
            txtCode.Text = icd.Code;
            txtInsideCode.Text = icd.InsideCode;
            txtDiseasesLevel.Text = icd.DiseasesLevel.ToString();
            txtName.Text = icd.Name;
            txtSearchCode.Text = icd.SearchCode;
            txtDays.Text = icd.Days.ToString();
            txtCost.Text = icd.Cost.ToString();
        }

        private Sys_Dic_ICD GetValue()
        {
            Sys_Dic_ICD icd = new Sys_Dic_ICD();
            icd.Code = txtCode.Text;
            icd.InsideCode = txtInsideCode.Text;
            icd.DiseasesLevel = Convert.ToInt32(txtDiseasesLevel.Text);
            icd.Name = txtName.Text;
            icd.SearchCode = txtSearchCode.Text;
            icd.Days=Convert.ToInt32(txtDays.Text);
            icd.Cost=Convert.ToDecimal(txtCost.Text);
            return icd;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = gridICD.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("新增诊断必须要有对应ICD，所以请选中一条符合临床诊断的ICD记录，新增时将自动对应到该ICD编码");
                return;
            }


            pnlDetail.Enabled = true;
            txtCode.Enabled = true;
            editType = "Add";
            ClearForm();
            GridRow row = rows[0] as GridRow;
            Sys_Dic_ICD ICD = row.DataItem as Sys_Dic_ICD;
            txtCode.Text = ICD.Code;
            txtCode.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlDetail.Enabled = true;
            txtCode.Enabled = false;
            editType = "Edit";
        }

        private void gridICD_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            pnlDetail.Enabled = true;
            txtCode.Enabled = false;
            editType = "Edit";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = gridICD.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一行");
                return;
            }
            Sys_Dic_ICD icd = GetValue();
            int i = 0;

            if (editType == "Edit")
                i = DBHelper.CIS.Update<Sys_Dic_ICD>(icd, Sys_Dic_ICD._.Code == icd.Code && Sys_Dic_ICD._.InsideCode == CurrICD.InsideCode);
            else
                i = DBHelper.CIS.Insert(icd);

            if (i > 0)
            {
                ICDList.Remove(CurrICD);
                ICDList.Insert(0, icd);
                gridICD.PrimaryGrid.DataSource = ICDList;
                Application.DoEvents();//处理消息队列 清除界面堵塞
                gridICD.PrimaryGrid.ClearSelectedCells();//默认不选择行
                AlertBox.Info("保存成功!");
            }
            else
                AlertBox.Error("保存失败!");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim();
            if (text.Trim().Length < 1)
                gridICD.PrimaryGrid.DataSource = ICDList;
            List<Sys_Dic_ICD> subList = ICDList.Where(x => x.SearchCode.AsNotNullString().ToUpper().Contains(text.ToUpper()) || x.Name.AsNotNullString().ToUpper().Contains(text.ToUpper())).ToList();
            gridICD.PrimaryGrid.DataSource = subList;
        }
        private void gridICD_RowClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowClickEventArgs e)
        {
            SelectedElementCollection rows = gridICD.GetSelectedRows();
            if (rows.Count == 0)
            {
                AlertBox.Error("请选中一行");
                return;
            }
            GridRow row = rows[0] as GridRow;
            Sys_Dic_ICD icd = row.DataItem as Sys_Dic_ICD;
            CurrICD = icd;
            SetValue(icd);
        }

    }
}
