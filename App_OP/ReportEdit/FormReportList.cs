using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIS.Model;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP
{
    public partial class FormReportList : BaseForm
    {
        public FormReportList()
        {
            InitializeComponent();
        }
        List<OP_Dic_Report> Report;

        private void FormReportEdit_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init(bool fromNew = true)
        {
            this.superGridControl1.PrimaryGrid.Rows.Clear();
            if (fromNew)
                Report = DBHelper.CIS.From<OP_Dic_Report>().Select(p => new { p.ID, p.ParentID, p.ItemName, p.Type, p.Assembly, p.NameSpace, p.MethodName, p.No, p.Status }).OrderBy(p => p.No).ToList();
            var parentRow = Report.Where(p => p.ParentID == "").ToList();
            foreach (var item in parentRow)
            {
                GridRow row = new GridRow(BuildCell(item, ""));
                row.Tag = item;
                row.Rows.AddRange(BuildRow(Report.Where(p => p.ParentID == item.ID).OrderBy(p => p.No), item.ItemName));
                this.superGridControl1.PrimaryGrid.Rows.Add(row);
            }
            this.superGridControl1.PrimaryGrid.ExpandAll();
            Application.DoEvents();
        }

        private List<GridRow> BuildRow(IEnumerable<OP_Dic_Report> reports, string parentName)
        {
            List<GridRow> result = new List<GridRow>();
            foreach (var item in reports)
            {
                GridRow row = new GridRow(BuildCell(item, parentName));
                row.Cells[0].CellStyles.Default.Image = Properties.Resources.Cards_16x16;
                row.Tag = item;
                row.Rows.AddRange(BuildRow(Report.Where(p => p.ParentID == item.ID).OrderBy(p => p.No), item.ItemName));
                result.Add(row);
            }
            return result;
        }

        /// <summary>
        /// 通过模块实体和分类名称获取树节点实体
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public object[] BuildCell(OP_Dic_Report report, string category)
        {
            return new object[] {
                            report.ItemName                  // 模块名称
                            ,category                       // 上级名称
                            ,report.Assembly                  // 程序集
                            ,report.NameSpace                // 命名空间
                            ,report.MethodName            //方法名
                            ,report.No                   // 排序
                            ,report.Type                //显示方式
                            ,report.Status==0            //是否启用
                            ,report.ID
             };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            if (e.RowArea == RowArea.InCellExpand)
                return;
            this.EditMenu(this.superGridControl1.PrimaryGrid.GetSelectedRows()[0] as GridRow);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="gr"></param>
        private void EditMenu(GridRow gr)
        {
            if (gr == null) return;
            var model = (gr.Tag as OP_Dic_Report);
            if (model == null) return;
            FormReportEdit form = new FormReportEdit(model);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var obj = BuildCell(form.Result, gr.Cells[1].Value.ToString());
                for (int i = 0; i < gr.Cells.Count; i++)
                    gr.Cells[i].Value = obj[i];
                OP_Dic_Report result = form.Result;
                result.Attach();
                Report.RemoveAll(p => p.ID == model.ID);
                Report.Add(result);
                DBHelper.CIS.Update<OP_Dic_Report>(result, p => p.ID == model.ID);
                Init(false);
            }

        }
        private void AddMenu(GridRow gr)
        {
            if (gr == null) return;
            var model = (gr.Tag as OP_Dic_Report);
            if (model == null) return;
            OP_Dic_Report report = new OP_Dic_Report() { ParentID = model.ID };
            FormReportEdit form = new FormReportEdit(report);
            if (form.ShowDialog() == DialogResult.OK)
            {
                OP_Dic_Report result = form.Result;
                result.ID = Guid.NewGuid().ToString();
                if (result == null)
                    return;
                Report.Add(result);
                DBHelper.CIS.FromSql(string.Format("INSERT INTO OP_DIC_REPORT SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", result.ID, result.ParentID, result.ItemName, result.Type, result.Assembly, result.NameSpace, result.MethodName, result.No, "", result.Status, 0)).ExecuteNonQuery();
                Init(false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var rows = this.superGridControl1.GetSelectedRows();
            if (rows.Count == 0)
                return;
            GridRow row = rows[0] as GridRow;
            string ID = row.Cells["gridID"].Value.ToString();
            FormDesignReport form = new FormDesignReport();
            form.XMLID = ID;
            form.ShowDialog();
        }

        private void superGridControl1_RowClick(object sender, GridRowClickEventArgs e)
        {
            if ((e.GridRow as GridRow).Cells["gridOpenStyle"].Value.AsString("") == "文档")
                this.btnEdit.Enabled = true;
            else
                this.btnEdit.Enabled = false;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var rows = this.superGridControl1.GetSelectedRows();
            if (rows.Count == 0)
                return;
            GridRow row = rows[0] as GridRow;
            AddMenu(row);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rows = this.superGridControl1.GetSelectedRows();
            if (rows.Count == 0)
                return;
            GridRow row = rows[0] as GridRow;
            if (row.Rows.Count > 0)
                return;
            OP_Dic_Report report = row.Tag as OP_Dic_Report;
            DBHelper.CIS.Delete<OP_Dic_Report>(p => p.ID == report.ID);
            Report.RemoveAll(p => p.ID == report.ID);
            Init(false);

        }
    }
}
