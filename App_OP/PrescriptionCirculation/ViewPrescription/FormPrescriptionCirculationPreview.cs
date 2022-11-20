using CIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_OP.PrescriptionCirculation.ViewPrescription
{
    public partial class FormPrescriptionCirculationPreview : BaseForm
    {
        public FormPrescriptionCirculationPreview()
        {
            InitializeComponent();
        }

        internal void Init(ViewPrescriptionResponse response)
        {
            this.dgvPrescription.Rows.Clear();
            foreach (var prescription in response.rxDetlList)
            {
                var newRow = this.dgvPrescription.Rows[this.dgvPrescription.Rows.Add()];
                newRow.Cells[colName.Index].Value = prescription.drugProdname;
                newRow.Cells[colSpec.Index].Value = prescription.drugSpec;
                newRow.Cells[colUsage.Index].Value = prescription.medcWayDscr;
                newRow.Cells[colFrq.Index].Value = prescription.usedFrquName;
                newRow.Cells[colCount.Index].Value = prescription.drugTotlcnt;
                newRow.Cells[colPackageUnit.Index].Value = prescription.drugTotlcntEmp;
                newRow.Cells[colDay.Index].Value = prescription.medcDays;
            }
        }
    }
}
