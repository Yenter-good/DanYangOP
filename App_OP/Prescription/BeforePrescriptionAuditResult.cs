using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Prescription
{
    public class BeforePrescriptionAuditResult
    {
        public bool Success { get; set; }
        public List<BeforePrescriptionAuditErrorInfo> Errors { get; set; }
    }

    public class BeforePrescriptionAuditErrorInfo
    {
        public string Content { get; set; }
        public int Level { get; set; }
        public string Legal { get; set; }
    }
}
