using CIS.Core;
using CIS.Model;
using CIS.Utility;
using System;
using System.Data;
using System.Windows.Forms;

namespace App_OP
{
    public partial class FormRecordProportion : BaseForm
    {
        public FormRecordProportion()
        {
            InitializeComponent();
        }

        private void FormRecordProportion_Shown(object sender, EventArgs e)
        {
            this.dtStartTime.Value = DateTime.Now;
            this.dtEndTime.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string StartTime = this.dtStartTime.Value.ToShortDateString() + " 00:00:00";
            string EndTime = this.dtEndTime.Value.ToShortDateString() + " 23:59:59";
            string sql = string.Format(Properties.Resources.丹阳门诊病历书写率统计, StartTime, EndTime);
            DataTable dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            this.superGridControl1.PrimaryGrid.DataSource = dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excle文件|*.xls";
            dialog.FileName = "门诊病历书写比例";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelHelper.ExportXLS(this.superGridControl1.PrimaryGrid.DataSource as DataTable, dialog.FileName);
                    AlertBox.Info("导出成功" + Environment.NewLine + dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败" + Environment.NewLine + ex.Message);
                }
            }
        }
    }
}
