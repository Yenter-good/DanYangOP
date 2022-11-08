using System;
using CIS.Model;
using CIS.Core;

namespace App_OP
{
    public partial class FormLISAdditional : FormCancelUnenabled
    {
        public FormLISAdditional()
        {
            InitializeComponent();
        }

        public string PrescriptionNo
        { get; set; }

        private void FormLISAdditional_Shown(object sender, EventArgs e)
        {
            this.comboBox1.Text = "0";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IView_HIS_DealWithItem Deal = DBHelper.CIS.From<IView_HIS_DealWithItem>().Where(p => p.Code == "414311").First();
            int num = GetNum(this.comboBox1.Text);
            if (num == 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            OP_Prescription_Detail detail = new OP_Prescription_Detail();
            detail.ID = Guid.NewGuid().ToString();
            detail.TreatmentNo = SysContext.GetCurrPatient.OutpatientNo;
            detail.PatientID = SysContext.GetCurrPatient.PatientID;
            detail.PrescriptionNo = PrescriptionNo;
            detail.ItemType = "9";
            detail.No = 99;
            detail.IsAdditional = 1;
            detail.ItemCode = "414311";
            detail.ItemName = Deal.Name;
            detail.PackingUnit = Deal.PackingUnit;
            detail.UpdateTime = DateTime.Now;
            detail.Specification = Deal.Specification;
            detail.Price = Deal.Price;
            detail.Number = num;
            detail.Total = Deal.Price * detail.Number;
            DBHelper.CIS.Insert<OP_Prescription_Detail>(detail);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private int GetNum(string num)
        {
            int num1 = 0;
            int.TryParse(num, out num1);
            return num1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    
    }
}
