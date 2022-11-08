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
    public partial class FormEmergencyList : BaseForm
    {
        public FormEmergencyList()
        {
            InitializeComponent();
        }

        private void FormEmergencyList_Shown(object sender, EventArgs e)
        {
            BuildData();
        }

        private void BuildData()
        {
            string sql = "";

            if (this.checkBoxX1.Checked && SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("未选择患者");
                this.checkBoxX2.Checked = true;
            }

            if (this.checkBoxX2.Checked)
                sql = $@"select * from v_wjz where readflag=1 and ksbh='{SysContext.RunSysInfo.currDept.Code}'";
            else
                sql = $@"select * from v_wjz where readflag=1 and blh='{SysContext.GetCurrPatient.OutpatientNo}'";

            var dt = DBHelper.CIS.FromSql(sql).ToDataTable();
            this.dataGridViewX1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var newRow = this.dataGridViewX1.Rows[this.dataGridViewX1.Rows.Add()];
                newRow.Cells[colCode.Index].Value = row["XMDM"].AsString("");
                newRow.Cells[colItemName.Index].Value = row["XMMC"].AsString("");
                newRow.Cells[colItemQuantity.Index].Value = row["XMVAL"].AsString("");
                newRow.Cells[colSign.Index].Value = row["XMSXJT"].AsString("");
                newRow.Cells[colDate.Index].Value = row["JYRQ"].AsString("");
                newRow.Cells[colPatientName.Index].Value = row["BRXM"].AsString("");
                newRow.Cells[colSex.Index].Value = row["BRXB"].AsString("");
                newRow.Cells[colBLH.Index].Value = row["BLH"].AsString("");
                newRow.Tag = row;
            }
        }

        private void checkBoxX2_CheckedChangedEx(object sender, DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs e)
        {
            if (e.EventSource != DevComponents.DotNetBar.eEventSource.Mouse)
            {
                return;
            }

            this.BuildData();
        }
    }
}
