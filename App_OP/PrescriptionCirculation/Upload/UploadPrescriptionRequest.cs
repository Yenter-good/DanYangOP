using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Upload
{
    class UploadPrescriptionRequest : UploadPrescriptionBase
    {
        /// <summary>
        /// 处方原件  医保电子签名后的处方文件base64 字符(PDF或 OFD 格式) 
        /// </summary>
        public string rxFile { get; set; }

        /// <summary>
        /// 处方信息签名值  医保电子签名后处方信息的签名结果 
        /// </summary>
        public string signDigest { get; set; }

    }
}
