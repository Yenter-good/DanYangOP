using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;
using Dos.ORM;

namespace App_OP.Prescription
{
    public partial class FormAddAgent : BaseForm
    {
        public FormAddAgent()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tbxName.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                return;
            }
            if (this.tbxIDCard.Text == "")
            {
                MessageBox.Show("身份证不能为空");
                return;
            }

            var result = this.tbxIDCard.Text.ToLower().CheckIDCard();
            if (result != "")
            {
                MessageBox.Show(result);
                return;
            }

            var ageString = this.tbxIDCard.Text.Substring(6, 8);
            DateTime age;
            if (!DateTime.TryParseExact(ageString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AllowInnerWhite, out age))
            {
                MessageBox.Show("身份证号中的生日有误");
                return;
            }

            Dictionary<Field, object> modify = new Dictionary<Field, object>();
            modify[OP_Journal._.AgentAge] = (DateTime.Now.Year - age.Year).ToString() + "岁";
            modify[OP_Journal._.AgentIDCard] = this.tbxIDCard.Text;
            modify[OP_Journal._.AgentName] = this.tbxName.Text;
            modify[OP_Journal._.AgentSex] = this.cbxSex.SelectedItem.AsString();
            modify[OP_Journal._.DrugPurpose] = this.tbxPurpose.Text;

            DBHelper.CIS.Update<OP_Journal>(modify, p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormAddAgent_Shown(object sender, EventArgs e)
        {
            this.cbxSex.SelectedIndex = 0;
        }
    }
}
