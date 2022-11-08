using Open_Newtonsoft_Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.UploadSign
{
    class UploadPrescriptionSignResponse
    {
        /// <summary>
        /// 处方文件  医保电子签名后处方文件originalRxFile的 base64 值 
        /// </summary>
        public string rxFile { get; set; }

        /// <summary>
        /// 签名/章摘要值  医保电子签名后处方信息originalValue 的签名结果值 
        /// </summary>
        public string signDigest { get; set; }

        /// <summary>
        /// 签名机构证书 SN   
        /// </summary>
        public string signCertSn { get; set; }

        /// <summary>
        /// 签名机构证书 DN   
        /// </summary>
        public string signCertDn { get; set; }

    }
}
