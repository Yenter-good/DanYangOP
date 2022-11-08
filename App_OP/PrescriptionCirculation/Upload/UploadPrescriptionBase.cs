using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Upload
{
    class UploadPrescriptionBase
    {
        /// <summary>
        /// 处方追溯码  有效时间和处方有效时间保持一致，上传时每张处方只能使用一次 
        /// </summary>
        public string rxTraceCode { get; set; }

        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 医保就诊 ID  参保病人信息字段（注：医保门诊挂号时返回） 
        /// </summary>
        public string mdtrtId { get; set; }

        /// <summary>
        /// 患者姓名   
        /// </summary>
        public string patnName { get; set; }

        /// <summary>
        /// 人员证件类型   
        /// </summary>
        public string psnCertType { get; set; }

        /// <summary>
        /// 证件号码   
        /// </summary>
        public string certno { get; set; }

        /// <summary>
        /// 定点医疗机构名称   
        /// </summary>
        public string fixmedinsName { get; set; }

        /// <summary>
        /// 定点医疗机构编号   
        /// </summary>
        public string fixmedinsCode { get; set; }

        /// <summary>
        /// 开方医保医师代码  国家医保医师代码
        /// </summary>
        public string drCode { get; set; }

        /// <summary>
        /// 开方医师姓名   
        /// </summary>
        public string prscDrName { get; set; }

        /// <summary>
        /// 审方药师科室名称   
        /// </summary>
        public string pharDeptName { get; set; }

        /// <summary>
        /// 审方药师科室编号   
        /// </summary>
        public string pharDeptCode { get; set; }

        /// <summary>
        /// 审方药师职称编码  参照审方药师职称编码（phar_pro_tech_duty） 
        /// </summary>
        public string pharProfttlCodg { get; set; }

        /// <summary>
        /// 审方药师职称名称   
        /// </summary>
        public string pharProfttlName { get; set; }

        /// <summary>
        /// 审方医保药师代码 国家医保药师代码 
        /// </summary>
        public string pharCode { get; set; }

        /// <summary>
        /// 审方药师证件类型  参照人员证件类型(psn_cert_type) 
        /// </summary>
        public string pharCertType { get; set; }

        /// <summary>
        /// 审方药师证件号码   
        /// </summary>
        public string pharCertno { get; set; }

        /// <summary>
        /// 审方药师姓名  Y 
        /// </summary>
        public string pharName { get; set; }

        /// <summary>
        /// 审方药师执业资格证号   
        /// </summary>
        public string pharPracCertNo { get; set; }

        /// <summary>
        /// 医疗机构药师审方时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime pharChkTime { get; set; }
    }
}
