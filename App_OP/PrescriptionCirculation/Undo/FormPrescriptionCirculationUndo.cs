using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation.Undo
{
    public partial class FormPrescriptionCirculationUndo : BaseForm
    {
        public FormPrescriptionCirculationUndo()
        {
            InitializeComponent();
        }

        public string Reason { get => this.tbxReason.Text; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxReason.Text))
            {
                MessageBox.Show("撤销原因不能为空");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
