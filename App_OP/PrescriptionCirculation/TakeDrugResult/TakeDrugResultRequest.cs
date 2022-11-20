using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.TakeDrugResult
{
    class TakeDrugResultRequest
    {
        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 定点医疗机构编号   
        /// </summary>
        public string fixmedinsCode { get; set; }

        /// <summary>
        /// 医保就诊 ID  医保门诊挂号时返回 
        /// </summary>
        public string mdtrtId { get; set; }

        /// <summary>
        /// 人员名称   
        /// </summary>
        public string psnName { get; set; }

        /// <summary>
        /// 人员证件类型   
        /// </summary>
        public string psnCertType { get; set; }

        /// <summary>
        /// 证件号码   
        /// </summary>
        public string certno { get; set; }

    }
}
