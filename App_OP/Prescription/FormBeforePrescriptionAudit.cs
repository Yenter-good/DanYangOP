using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.Prescription
{
    public partial class FormBeforePrescriptionAudit : BaseForm
    {
        public FormBeforePrescriptionAudit()
        {
            InitializeComponent();
        }

        public void Init(BeforePrescriptionAuditResult input)
        {
            foreach (var error in input.Errors)
            {
                var newRow = this.dataGridViewX1.Rows[this.dataGridViewX1.Rows.Add()];
                newRow.Cells[colContent.Index].Value = error.Content;
                newRow.Cells[colLevel.Index].Value = error.Level;
                newRow.Cells[colLegal.Index].Value = error.Legal;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
