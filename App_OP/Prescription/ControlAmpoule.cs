using System;
using System.Windows.Forms;

namespace App_OP.Prescription
{
    public partial class ControlAmpoule : UserControl
    {
        public ControlAmpoule()
        {
            InitializeComponent();
        }

        public event EventHandler Complate;

        public DataGridViewCell targetCell { get; set; }

        public float minDose { get; set; }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float? f = this.textBoxX1.Text.AsFloat();
                if (f == null || f <= 0)
                    return;
                targetCell.Value = minDose * f;
                this.textBoxX1.Text = "";
                targetCell.DataGridView.BeginEdit(true);
                Complate?.Invoke(this, null);
                //this.Hide();
            }
            else if (e.KeyCode == Keys.Up)
            {
                targetCell.DataGridView.CurrentCell = targetCell;
                targetCell.DataGridView.BeginEdit(true);
            }
        }

        public void BeginEdit()
        {
            this.textBoxX1.Focus();
            this.textBoxX1.SelectAll();
        }
    }
}
