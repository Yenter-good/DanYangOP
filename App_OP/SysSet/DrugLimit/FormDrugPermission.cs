using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP
{
    public partial class FormDrugPermission : BaseForm
    {
        public FormDrugPermission()
        {
            InitializeComponent();
        }
        List<OP_Dic_DrugPermission_Ext> listPermission;
        DataTable dtDrug;

        private void InitData()
        {
            listPermission = DBHelper.CIS.FromSql(@"
SELECT DISTINCT A.*,B.NAME AS DoctorName,C.DrugName,D.Name AS DeptName,C.Specification AS DrugSpecification,A.PrescriptionType FROM OP_Dic_DrugPermission A 
LEFT JOIN IVIEW_USER B ON A.DOCTORCODE = B.CODE
LEFT JOIN IVIEW_HIS_DRUGINFO C ON C.DrugID = A.DRUGID
LEFT JOIN IVIEW_DEPT D ON A.DEPTCODE = D.CODE").ToList<OP_Dic_DrugPermission_Ext>();
            this.dgvDrug.PrimaryGrid.DataSource = listPermission;
        }

        private void InitDrug()
        {
            dtDrug = DBHelper.CIS.FromSql("SELECT *,NickName + '   ' + Specification AS DrugNameFormat FROM IVIEW_HIS_DRUGINFO").ToDataTable();
            this.cbxDrug.DisplayMember = "DrugNameFormat";
            this.cbxDrug.ValueMember = "DrugID";
            this.cbxDrug.FilterFields = new string[] { "SearchCode" };

            this.cbxDrug.DataSource = dtDrug;
        }

        private void FormDrugPermission_Shown(object sender, EventArgs e)
        {
            InitData();
            InitDrug();
        }

        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            if (listPermission.Count(p => p.DrugID == this.cbxDrug.SelectedValue.AsString(null)) > 0)
            {
                AlertBox.Info("该药品已经存在列表中");
                return;
            }

            OP_Dic_DrugPermission drug = new OP_Dic_DrugPermission();
            DataRow[] rows = dtDrug.Select($"DrugID='{this.cbxDrug.SelectedValue.AsString(null)}'");

            drug.ID = Guid.NewGuid().ToString();
            drug.UpdateTime = DateTime.Now;
            drug.DrugID = this.cbxDrug.SelectedValue.AsString(null);

            DBHelper.CIS.Insert<OP_Dic_DrugPermission>(drug);

            listPermission.Add(new OP_Dic_DrugPermission_Ext()
            {
                DrugName = rows[0]["DrugName"].AsString(),
                DrugSpecification = rows[0]["Specification"].AsString(),
                DrugID = drug.DrugID,
                ID = drug.ID
            });
            this.dgvDrug.PrimaryGrid.DataSource = null;
            this.dgvDrug.PrimaryGrid.DataSource = listPermission;

            AlertBox.Info("保存成功");

        }

        private void dgvDrug_RowDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs e)
        {
            string id = (e.GridRow as GridRow).Cells["gridDrugCode"].Value.AsString("");
            FormDrugPermissionManage form = new FormDrugPermissionManage();
            OP_Dic_DrugPermission_Ext tmp = listPermission.Find(p => p.DrugID == id);
            form.Result = tmp;
            if (form.ShowDialog() == DialogResult.OK)
            {
                //OP_Dic_DrugPermission result = form.Result;
                //result.ID = Guid.NewGuid().ToString();
                //result.UpdateTime = DateTime.Now;
                //result.DrugID = id;
                tmp.AttachAll();
                DBHelper.CIS.Delete<OP_Dic_DrugPermission>(p => p.DrugID == id);
                DBHelper.CIS.Insert<OP_Dic_DrugPermission>(tmp);

                //OP_Dic_DrugPermission_Ext tmp = listPermission.Find(p => p.DrugID == id);
                //tmp.DeptCode = result.DeptCode;
                //tmp.DoctorCode = result.DoctorCode;
                //tmp.TitleName = result.TitleName;
                //tmp.Number = result.Number;
                //tmp.NumberInterval = result.NumberInterval;
                //tmp.NumberTarget = result.NumberTarget;
                //tmp.Flag = result.Flag;

                AlertBox.Info("保存成功");
            }
        }

        private void btnDeleteDrug_Click(object sender, EventArgs e)
        {
            SelectedElementCollection rows = this.dgvDrug.PrimaryGrid.GetSelectedRows();
            if (rows.Count > 0)
            {
                GridRow row = rows[0] as GridRow;
                string id = row.Cells["gridDrugCode"].Value.AsString("");
                DBHelper.CIS.Delete<OP_Dic_DrugPermission>(p => p.DrugID == id);
                this.dgvDrug.PrimaryGrid.Rows.Remove(row);
                AlertBox.Info("删除成功");
            }
        }
    }
}
