using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.Model
{
    public class OP_Prescription_Detail_HistoryPrescription : OP_Prescription_Detail
    {
        public string PrescriptionType { get; set; }

        public string HerbalMedicineNum { get; set; }
    }
}
