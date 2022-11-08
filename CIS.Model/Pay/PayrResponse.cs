using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CIS.Model
{
    [XmlRoot("XML")]
    public class PayResponse
    {
        public XMLREC XMLREC { get; set; }
    }

    public class XMLREC
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        [XmlElement("STATUS")]
        public string STATUS { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("ERRMSG")]
        public string ERRMSG { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [XmlElement("PAYMODE")]
        public string PAYMODE { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("ORDERNO")]
        public string ORDERNO { get; set; }
        /// <summary>
        /// 订单金额(单位：分)
        /// </summary>
        [XmlElement("TOTALFEE")]
        public string TOTALFEE { get; set; }
        /// <summary>
        /// 实收金额 (单位：分)
        /// </summary>
        [XmlElement("ACTUALCHARGE")]
        public string ACTUALCHARGE { get; set; }
        /// <summary>
        /// 优惠金额 (单位：分)
        /// </summary>
        [XmlElement("DISCOUNT")]
        public string DISCOUNT { get; set; }
        /// <summary>
        /// 二维码串
        /// </summary>
        [XmlElement("QRCODE")]
        public string QRCODE { get; set; }
        /// <summary>
        /// 二维码图片url
        /// </summary>
        [XmlElement("QRCODEURL")]
        public string QRCODEURL { get; set; }
    }
}
