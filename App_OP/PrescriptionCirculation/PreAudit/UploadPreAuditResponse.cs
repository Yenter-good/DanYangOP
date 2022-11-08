using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.PreAudit
{
    class UploadPreAuditResponse
    {
        /// <summary>
        /// 处方追溯码 
        /// </summary>
        public string rxTraceCode { get; set; }
        /// <summary>
        /// 医保处方编号 
        /// </summary>
        public string hiRxno { get; set; }
    }
}
