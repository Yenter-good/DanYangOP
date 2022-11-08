using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Undo
{
    public class UndoPrescriptionRequest
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
        /// 撤销医师的医保医师代码   
        /// </summary>
        public string drCode { get; set; }

        /// <summary>
        /// 撤销医师姓名   
        /// </summary>
        public string undoDrName { get; set; }

        /// <summary>
        /// 撤销医师证件类型  参 照 人 员 证 件(psn_cert_type) 
        /// </summary>
        public string undoDrCertType { get; set; }

        /// <summary>
        /// 撤销医师证件号码   
        /// </summary>
        public string undoDrCertno { get; set; }

        /// <summary>
        /// 撤销原因描述   
        /// </summary>
        public string undoRea { get; set; }

        /// <summary>
        /// 撤销时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime undoTime { get; set; }

    }
}
