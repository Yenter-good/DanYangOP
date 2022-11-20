using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation.TakeDrugResult
{
    public partial class FormTakeDrugResultPreview : BaseForm
    {
        public FormTakeDrugResultPreview()
        {
            InitializeComponent();
        }

        internal void Init(TakeDrugResultResponse response)
        {
            this.dgvPrescription.Rows.Clear();
            foreach (var prescription in response.seltdelts)
            {
                var newRow = this.dgvPrescription.Rows[this.dgvPrescription.Rows.Add()];
                newRow.Cells[colName.Index].Value = prescription.drugProdname;
                newRow.Cells[colSpec.Index].Value = prescription.drugSpec;
                newRow.Cells[colCount.Index].Value = prescription.cnt;
                newRow.Cells[colAprvNo.Index].Value = prescription.aprvno;
                newRow.Cells[colBchNo.Index].Value = prescription.bchno;
                newRow.Cells[colManuNum.Index].Value = prescription.manuLotnum;
                newRow.Cells[colPrdrName.Index].Value = prescription.prdrName;
            }
        }
    }
}
