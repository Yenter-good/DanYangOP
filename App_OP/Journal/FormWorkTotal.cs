using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using CIS.Utility;
using DevComponents.DotNetBar.SuperGrid;

namespace App_OP
{
    public partial class FormWorkTotal : BaseForm
    {
        public FormWorkTotal()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dgvJournal.PrimaryGrid.DataSource = null;
            this.dgvJournal.PrimaryGrid.Columns.Clear();
            if (this.checkBox1.Checked)
            {
                if (MessageBox.Show("你选择了包括其他科室选项,查询过程可能需要等待较长时间,是否继续查询", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<IView_User> user = DBHelper.CIS.From<IView_User>().Where(p => p.Dept_Code == SysContext.RunSysInfo.currDept.Code).ToList();
                    foreach (var item in user)
                    {
                        this.labelX1.Text = "正在查询:" + item.Name;
                        Application.DoEvents();
                        DataTable dt1 = DBHelper.CIS.FromSql(string.Format("EXEC MZYS_YBB '{0}','{1}','{2}','{3}','{4}'", this.StartTime.Value.ToShortDateString() + " 00:00:00", this.EndTime.Value.ToShortDateString() + " 23:59:59", "Y", item.Code, this.radioButton1.Checked ? 1 : 2)).ToDataTable();
                        if (dt.Rows.Count == 0)
                            dt = dt1.Clone();
                        if (dt1.Rows.Count == 0)
                            continue;
                        dt.Rows.Add(dt1.Rows[0].ItemArray);
                    }
                }
            }
            else
                dt = DBHelper.CIS.FromSql(string.Format("EXEC MZYS_YBB '{0}','{1}','{2}','{3}','{4}'", this.StartTime.Value.ToShortDateString() + " 00:00:00", this.EndTime.Value.ToShortDateString() + " 23:59:59", this.radioButton3.Checked ? "Y" : "K", this.radioButton3.Checked ? SysContext.CurrUser.user.Code : SysContext.RunSysInfo.currDept.Code, this.radioButton1.Checked ? 1 : 2)).ToDataTable();

            this.dgvJournal.PrimaryGrid.DataSource = dt;
            DataRow row = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                float sum = 0;
                foreach (DataRow item in dt.Rows)
                {
                    if (dt.Columns[i].DataType == typeof(decimal) || dt.Columns[i].DataType == typeof(int))
                        sum += item[i].AsFloat(0);
                }
                row[i] = sum;
            }
            row[0] = "合计:";
            dt.Rows.Add(row);
            Application.DoEvents();
            (this.dgvJournal.PrimaryGrid.Rows[this.dgvJournal.PrimaryGrid.Rows.Count - 1] as GridRow).CellStyles.Default.TextColor = System.Drawing.Color.Green;

        }

        private void FormWorkTotal_Shown(object sender, EventArgs e)
        {
            this.StartTime.Value = DateTime.Now.AddDays(-7);
            this.EndTime.Value = DateTime.Now;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExcelHelper.ExportXLS(dt, this.saveFileDialog1.FileName);
            AlertBox.Info("导出成功,路径：" + this.saveFileDialog1.FileName);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked)
                this.checkBox1.Enabled = true;
            else
                this.checkBox1.Enabled = false;
        }
    }
}
