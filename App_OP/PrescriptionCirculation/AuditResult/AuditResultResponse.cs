using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.AuditResult
{
    class AuditResultResponse
    {
        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 医保药师姓名   
        /// </summary>
        public string pharName { get; set; }

        /// <summary>
        /// 医保药师代码   
        /// </summary>
        public string pharCode { get; set; }

        /// <summary>
        /// 处方审核状态代码   
        /// </summary>
        public string rxChkStasCodg { get; set; }

        /// <summary>
        /// 处方审核意见   
        /// </summary>
        public string rxChkOpnn { get; set; }

        /// <summary>
        /// 处方审核时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime rxChkTime { get; set; }

    }
}
