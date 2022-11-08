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
using CIS.Utility;
using Dos.ORM;

namespace App_OP
{
    public partial class FormLogInOutReport : BaseForm
    {
        private List<IView_User> _users;
        private List<IView_Dept> _depts;

        public FormLogInOutReport()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            this.dtStartDate.Value = DateTime.Now;
            this.dtEndDate.Value = DateTime.Now;
        }

        private void InitData()
        {
            _depts = DBHelper.CIS.From<IView_Dept>().Where(p => p.Type == 1).ToList();

            _depts.Insert(0, new IView_Dept() { Name = "全院", Code = "*" });

            this.cbxDept.DisplayMember = nameof(IView_Dept.Name);
            this.cbxDept.ValueMember = nameof(IView_Dept.Code);
            this.cbxDept.DataSource = _depts;
            this.cbxDoctor.SelectedItem = null;

            _users = DBHelper.CIS.From<IView_User>().ToList();
        }

        private void FormLogInOutReport_Shown(object sender, EventArgs e)
        {
            InitUI();
            InitData();
        }

        private void cbxDept_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxDept.SelectedItem == null)
                return;

            var dept = this.cbxDept.SelectedItem as IView_Dept;

            List<Sys_User_Dept> users;

            if (dept.Code != "*")
                users = DBHelper.CIS.From<Sys_User_Dept>().Where(p => p.DepartCode == dept.Code).ToList();
            else
                users = DBHelper.CIS.From<Sys_User_Dept>().ToList();

            List<IView_User> matchUsers = new List<IView_User>();
            foreach (var user in users)
            {
                var tmp = _users.Find(p => p.Code.Trim() == user.UserID.Trim());
                if (tmp == null)
                    continue;
                matchUsers.Add(tmp);
            }

            this.cbxDoctor.DisplayMember = nameof(IView_User.Name);
            this.cbxDoctor.ValueMember = nameof(IView_User.Code);
            this.cbxDoctor.DataSource = matchUsers;
            this.cbxDoctor.SelectedItem = null;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cbxDoctor.SelectedItem == null)
                SearchDept();
            else
                SearchUser();
        }

        private void SearchDept()
        {
            var selectedItem = this.cbxDept.SelectedItem;
            if (selectedItem == null)
                return;

            var selectedDept = selectedItem as IView_Dept;

            var users = _users.Where(p => p.Dept_Code == selectedDept.Code);

            List<OP_Log_InOut> logs;

            if (selectedDept.Code != "*")
                logs = DBHelper.CIS.From<OP_Log_InOut>().Where(p => p.UserCode.In(users.Select(d => d.Code).ToList()) && p.OperationDate >= this.dtStartDate.Value.Date && p.OperationDate <= this.dtEndDate.Value.Date.End()).OrderBy(p => new { p.OperationDate, p.OperationTime }).ToList();
            else
                logs = DBHelper.CIS.From<OP_Log_InOut>().Where(p => p.OperationDate >= this.dtStartDate.Value.Date && p.OperationDate <= this.dtEndDate.Value.Date.End()).OrderBy(p => new { p.UserCode, p.OperationDate, p.OperationTime }).ToList();

            BuildRows(logs);
        }
        private void SearchUser()
        {
            var selectedItem = this.cbxDoctor.SelectedItem;
            if (selectedItem == null)
                return;

            var selectedUser = selectedItem as IView_User;

            var logs = DBHelper.CIS.From<OP_Log_InOut>().Where(p => p.UserCode == selectedUser.Code && p.OperationDate >= this.dtStartDate.Value.Date && p.OperationDate <= this.dtEndDate.Value.Date.End()).OrderBy(p => new { p.OperationDate, p.OperationTime }).ToList();

            BuildRows(logs);
        }
        private void BuildRows(List<OP_Log_InOut> logs)
        {
            this.dgvLogInOut.PrimaryGrid.Rows.Clear();

            var dates = logs.OrderBy(p => p.OperationDate).Select(p => p.OperationDate).Distinct();

            foreach (var date in dates)
            {
                var logByDate = logs.Where(p => p.OperationDate == date).ToList();
                var userCodes = logByDate.Select(p => p.UserCode).Distinct();

                foreach (var userCode in userCodes)
                {
                    var user = _users.Find(p => p.Code == userCode);
                    if (user == null)
                        return;

                    var log = logs.Where(p => p.OperationDate == date && p.UserCode == userCode).ToList();
                    if (log == null || log.Count == 0)
                        return;
                    var newRow = this.dgvLogInOut.PrimaryGrid.NewRow();
                    newRow.Cells[colDoctorName.ColumnIndex].Value = user.Name;
                    newRow.Cells[colOperationDate.ColumnIndex].Value = date.ToShortDateString();

                    var login = log.Find(p => p.OperationType == 0);
                    var logout = log.Find(p => p.OperationType == 1);
                    var loginTime = login == null ? "" : login.OperationTime.ToLongTimeString();
                    var logoutTime = logout == null ? "" : logout.OperationTime.ToLongTimeString();

                    newRow.Cells[colLogInOutTime.ColumnIndex].Value = loginTime + "～" + logoutTime;

                    this.dgvLogInOut.PrimaryGrid.Rows.Add(newRow);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExcelHelper.ExportXLS(this.dgvLogInOut, this.saveFileDialog1.FileName);
        }
    }
}
