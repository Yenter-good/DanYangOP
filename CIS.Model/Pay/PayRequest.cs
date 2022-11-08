using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CIS.Model
{
    [XmlRoot("XML")]
    public class PayRequest
    {
        /// <summary>
        /// 功能号
        /// </summary>
        public string FOUNCTIONID { get; set; }
        /// <summary>
        /// 支付方式 alipay(支付宝) weixinpay（微信）区分大小写
        /// </summary>
        public string PAYMODE { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public string FEE { get; set; }
        /// <summary>
        /// 操作员工号
        /// </summary>
        public string SPONSOR { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string HOLDERNAME { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public string ACTUALCHARGE { get; set; }
        /// <summary>
        /// 分配的KEY
        /// </summary>
        public string KEY { get; set; }
        /// <summary>
        /// 渠道商代号
        /// </summary>
        public string TERMINALSN { get; set; }
    }
}
