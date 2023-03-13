using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.Purview.ParameterEntities
{
    public class PrescriptionCirculationUriEntity
    {
        public string AuditResult { get; set; }
        public string Inventory { get; set; }
        public string PreAudit { get; set; }
        public string TakeDrugResult { get; set; }
        public string Undo { get; set; }
        public string Upload { get; set; }
        public string UploadSign { get; set; }
        public string ViewPrescription { get; set; }
    }
}
