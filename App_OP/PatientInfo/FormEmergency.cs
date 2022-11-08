using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PatientInfo
{
    public partial class FormEmergency : BaseForm
    {
        public FormEmergency()
        {
            InitializeComponent();
            this.dataGridViewX1.AutoGenerateColumns = false;
        }

        public void Init(DataTable dt)
        {
            this.dataGridViewX1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var newRow = this.dataGridViewX1.Rows[this.dataGridViewX1.Rows.Add()];
                newRow.Cells[colCode.Index].Value = row["XMDM"].AsString("");
                newRow.Cells[colItemName.Index].Value = row["XMMC"].AsString("");
                newRow.Cells[colItemQuantity.Index].Value = row["XMVAL"].AsString("");
                newRow.Cells[colSign.Index].Value = row["XMSXJT"].AsString("");
                newRow.Cells[colDate.Index].Value = row["JYRQ"].AsString("");
                newRow.Cells[colRead.Index].Value = "已读";
                newRow.Tag = row;
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.colRead.Index)
            {
                var row = this.dataGridViewX1.Rows[e.RowIndex].Tag as DataRow;
                var xmno = row["XMNO"].AsString("");
                var blh = row["BLH"].AsString("");
                var jydh = row["JYDH"].AsString("");

                var sql = $@"delete from op_wjz_read where xmno='{xmno}' and blh='{blh}' and jydh='{jydh}';
insert into op_wjz_read select '{blh}','{xmno}','{jydh}',1";

                DBHelper.CIS.FromSql(sql).ExecuteNonQuery();
                this.dataGridViewX1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
