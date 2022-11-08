using CIS.Core;
using CIS.Model;
using DevComponents.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.Report
{
    public partial class FormBedState : BaseForm
    {
        private DataTable _dt;

        public FormBedState()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            this.dgvBed.AutoGenerateColumns = false;

            _dt = DBHelper.CIS.FromSql($@"select * from V_ZY_BC").ToDataTable();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (DataRow row1 in _dt.Rows)
            {
                var name= row1["DeptName"].ToString();
                var code= row1["DeptCode"].ToString();

                if (name.IsNullOrWhiteSpace() || code.IsNullOrWhiteSpace())
                {
                    continue;
                }
                if (dict.ContainsKey(code))
                {
                    continue;
                }
                dict[code] = name;
            }

            var dv = _dt.DefaultView;
            var depts = dv.ToTable(true, "DeptName", "DeptCode");
            foreach (var row in dict)
            {
                var comboitem = new ComboItem();
                comboitem.Text = row.Value;
                comboitem.Tag = row.Key;
                this.cbxDeptName.Items.Add(comboitem);
            }
        }

        private void FormBedState_Shown(object sender, EventArgs e)
        {
            this.InitUI();
        }

        private void cbxDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.cbxDeptName.SelectedItem as ComboItem;
            var deptCode = item.Tag.ToString();

            this.dgvBed.DataSource = _dt.Select($"DeptCode='{deptCode}'").CopyToDataTable();

            Application.DoEvents();
            int none = 0, has = 0;
            foreach (DataGridViewRow row in this.dgvBed.Rows)
            {
                if (row.Cells[colBedState.Index].Value.ToString() == "空床")
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    none++;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    has++;
                }
            }

            this.labelX1.Text = "总床位数：" + this.dgvBed.Rows.Count;
            this.labelX2.Text = "空闲床位数：" + none;
            this.labelX3.Text = "占用床位数：" + has;

            this.dgvBed.Focus();
        }
    }
}
