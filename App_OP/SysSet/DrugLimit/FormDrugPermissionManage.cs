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

namespace App_OP
{
    public partial class FormDrugPermissionManage : BaseForm
    {
        public FormDrugPermissionManage()
        {
            InitializeComponent();
            this.dgvDetail.AutoGenerateColumns = false;

            this.tbxDept.LostFocus += TbxDept_LostFocus;
            this.tbxDoctor.LostFocus += TbxDept_LostFocus;
            this.tbxTitle.LostFocus += TbxDept_LostFocus;

            this.tbxDept.GotFocus += TbxDept_GotFocus;
            this.tbxDoctor.GotFocus += TbxDept_GotFocus;
            this.tbxTitle.GotFocus += TbxDept_GotFocus;
        }

        List<Entity> listDept;
        List<Entity> listUser;
        List<Entity> listTitle;

        public OP_Dic_DrugPermission_Ext Result = new OP_Dic_DrugPermission_Ext();

        private class Entity
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string SearchCode { get; set; }
        }

        private void InitData()
        {
            listDept = DBHelper.CIS.FromSql("select Code,Name,SearchCode from iview_dept WHERE TYPE='1'").ToList<Entity>();
            listUser = DBHelper.CIS.FromSql("select Code,Name,SearchCode from IView_User").ToList<Entity>();
            listTitle = DBHelper.CIS.FromSql("select MC AS Name,MC AS Code,pym as SearchCode from ZD_PER_ZCFL").ToList<Entity>();
        }

        private void InitUI()
        {
            if (Result.DeptCode != null && Result.DeptCode != "")
            {
                string[] dept = Result.DeptCode.Split(',');
                foreach (var item in dept)
                {
                    Entity tmp = listDept.Find(p => p.Code == item);
                    int index = dgvDept.Rows.Add();
                    dgvDept.Rows[index].Cells[0].Value = tmp.Name;
                    dgvDept.Rows[index].Cells[1].Value = tmp.Code;
                }
            }
            if (Result.DoctorCode != null && Result.DoctorCode != "")
            {
                string[] doctor = Result.DoctorCode.Split(',');
                foreach (var item in doctor)
                {
                    Entity tmp = listUser.Find(p => p.Code == item);
                    int index = dgvDoctor.Rows.Add();
                    dgvDoctor.Rows[index].Cells[0].Value = tmp.Name;
                    dgvDoctor.Rows[index].Cells[1].Value = tmp.Code;
                }
            }
            if (Result.TitleName != null && Result.TitleName != "")
            {
                string[] title = Result.TitleName.Split(',');
                foreach (var item in title)
                {
                    Entity tmp = listTitle.Find(p => p.Code == item);
                    int index = dgvTitle.Rows.Add();
                    dgvTitle.Rows[index].Cells[0].Value = tmp.Name;
                    dgvTitle.Rows[index].Cells[1].Value = tmp.Code;
                }
            }

            this.tbxPatientNumber.Text = Result.PatientNumber.AsString("");
            if (Result.PatientNumberInterval.AsString("") == "月")
                this.rbPatientMonth.Checked = true;
            else
                this.rbPatientDay.Checked = true;

            this.tbxDoctorNumber.Text = Result.DoctorNumber.AsString("");
            if (Result.DoctorNumberInterval.AsString("") == "月")
                this.rbDoctorMonth.Checked = true;
            else
                this.rbDoctorDay.Checked = true;

            if (Result.Flag == 0)
                this.rbAllow.Checked = true;
            else
                this.rbBan.Checked = true;

            if (Result.PrescriptionType == DrugLimitPrescriptionTypeEnum.Normal)
                this.cbxNormal.Checked = true;
            else if (Result.PrescriptionType == DrugLimitPrescriptionTypeEnum.Chronic)
                this.cbxChronic.Checked = true;
            else if (Result.PrescriptionType == DrugLimitPrescriptionTypeEnum.All)
                this.cbxAll.Checked = true;
        }

        private void TbxDept_GotFocus(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.TextBoxX tbx = sender as DevComponents.DotNetBar.Controls.TextBoxX;
            this.dgvDetail.Left = tbx.Location.X;
            this.dgvDetail.Top = tbx.Location.Y + tbx.Height;
        }

        private void TbxDept_LostFocus(object sender, EventArgs e)
        {
            this.dgvDetail.Hide();
        }

        private void FormDrugPermissionManage_Shown(object sender, EventArgs e)
        {
            InitData();
            InitUI();
        }

        private void tbxDept_TextChanged(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.TextBoxX tbx = sender as DevComponents.DotNetBar.Controls.TextBoxX;

            if (tbx.Text == "")
            {
                this.dgvDetail.Hide();
                return;
            }

            List<Entity> list = (tbx == this.tbxDept ? listDept : tbx == this.tbxDoctor ? listUser : listTitle).Where(p => p.SearchCode.Contains(tbx.Text.ToUpper())).ToList();
            this.dgvDetail.DataSource = list;
            this.dgvDetail.Show();
        }

        private void tbxDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DevComponents.DotNetBar.Controls.TextBoxX tbx = sender as DevComponents.DotNetBar.Controls.TextBoxX;
                DataGridViewSelectedRowCollection rows = this.dgvDetail.SelectedRows;
                if (rows.Count == 0)
                    return;
                DataGridViewRow row = rows[0];

                string code = row.Cells["col_Code"].Value.ToString();
                string name = row.Cells["col_Name"].Value.ToString();

                DataGridView dgv = tbx == this.tbxDept ? dgvDept : tbx == this.tbxDoctor ? dgvDoctor : dgvTitle;

                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = name;
                dgv.Rows[index].Cells[1].Value = code;

                tbx.Text = "";
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                CIS.ControlLib.Win32.UnsafeNativeMethods.SendMessage(this.dgvDetail.Handle, (int)CIS.ControlLib.Win32.WinMsg.WM_KEYDOWN, e.KeyValue, 0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result.DeptCode = string.Join(",", this.dgvDept.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());
            Result.DoctorCode = string.Join(",", this.dgvDoctor.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());
            Result.TitleName = string.Join(",", this.dgvTitle.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());

            Result.Flag = this.rbAllow.Checked ? 0 : 1;
            Result.PatientNumber = this.tbxPatientNumber.Text.AsInt();
            Result.PatientNumberInterval = this.rbPatientMonth.Checked ? "月" : "日";
            Result.DoctorNumber = this.tbxDoctorNumber.Text.AsInt();
            Result.DoctorNumberInterval = this.rbDoctorMonth.Checked ? "月" : "日";
            Result.PrescriptionType = this.cbxChronic.Checked ? DrugLimitPrescriptionTypeEnum.Chronic : this.cbxNormal.Checked ? DrugLimitPrescriptionTypeEnum.Normal : DrugLimitPrescriptionTypeEnum.All;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormDrugPermissionManage_MouseClick(object sender, MouseEventArgs e)
        {
            this.dgvDetail.Hide();
            this.btnOK.Focus();
        }

        private void dgvDept_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewSelectedRowCollection rows = this.dgvDept.SelectedRows;
                if (rows.Count == 0)
                    return;

                this.dgvDept.Rows.Remove(rows[0]);
                string deptCode = string.Join(",", this.dgvDept.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());
                Result.DeptCode = deptCode;

                DBHelper.CIS.FromSql($"UPDATE OP_Dic_DrugPermission SET DeptCode='{deptCode}' WHERE ID='{Result.ID}'").ToScalar();
            }
        }

        private void dgvDoctor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewSelectedRowCollection rows = this.dgvDoctor.SelectedRows;
                if (rows.Count == 0)
                    return;

                this.dgvDoctor.Rows.Remove(rows[0]);
                string doctorCode = string.Join(",", this.dgvDoctor.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());
                Result.DoctorCode = doctorCode;

                DBHelper.CIS.FromSql($"UPDATE OP_Dic_DrugPermission SET DoctorCode='{doctorCode}' WHERE ID='{Result.ID}'").ToScalar();
            }
        }

        private void dgvTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewSelectedRowCollection rows = this.dgvTitle.SelectedRows;
                if (rows.Count == 0)
                    return;

                this.dgvTitle.Rows.Remove(rows[0]);
                string titleName = string.Join(",", this.dgvTitle.Rows.Cast<DataGridViewRow>().Select(p => p.Cells[1].Value).ToArray());
                Result.TitleName = titleName;

                DBHelper.CIS.FromSql($"UPDATE OP_Dic_DrugPermission SET DoctorCode='{titleName}' WHERE ID='{Result.ID}'").ToScalar();
            }
        }
    }
}
