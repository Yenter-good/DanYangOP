using System.Windows.Forms;
using CIS.Core;
using CIS.Model;
using System.Data;

namespace CIS
{
    public partial class FormEditPwd : Form
    {
        public FormEditPwd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (txtPwd.Text.Trim() != txtPwdOk.Text.Trim())
            {
                AlertBox.Error("密码两次输入不一致");
                return;
            }
            DataTable dt = DBHelper.CIS.FromProc("Proc_OP_ChangePwd")
                .AddInParameter("oldPwd", DbType.String, txtOldPwd.Text.Trim())
                .AddInParameter("newPwd", DbType.String, txtPwd.Text.Trim())
                .AddInParameter("gh", DbType.String, SysContext.CurrUser.user.Code)
                .ToDataTable();

            DataRow row = dt.Rows[0];
            string Result = row["Result"].ToString();
            string MSG = row["MSG"].ToString();

            if (Result == "0")
            {
                AlertBox.Error(MSG);
            }
            else
            {
                AlertBox.Info(MSG);
                this.Close();
            }

        }
    }
}