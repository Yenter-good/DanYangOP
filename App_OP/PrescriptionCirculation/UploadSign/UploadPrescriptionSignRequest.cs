using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.UploadSign
{
    class UploadPrescriptionSignRequest
    {
        /// <summary>
        /// 定点机构代码  定点机构唯一标识，用于识别机构对应的医保数字证书，CertId 和其保持一致 
        /// </summary>
        public string fixmedinsCode { get; set; }

        /// <summary>
        /// 原始待签名处方信息  JSONString 序列化（对第3.3.3.4.1 中 1-20 字段进行JSONString）后的 base64 字符值（注:采用CMS/PKCS#7 Detach 方式进行sm2WithSm3 签名，GB/T 35275-2017） 
        /// </summary>
        public string originalValue { get; set; }

        /// <summary>
        /// 原始待签名处方文件  文件 base64 的字符值（注:采用CMS/PKCS#7 Detach 方式进行sm2WithSm3 签名，GB/T 35275-2017） 
        /// </summary>
        public string originalRxFile { get; set; }

    }
}
