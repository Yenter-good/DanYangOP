using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.ViewOtherHos
{
    class ViewOtherHosResponse
    {
        /// <summary>
        /// 状态编码 成功：200失败：其他
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 接口描述 错误描述
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 接口数据 
        /// </summary>
        public data data { get; set; }
    }

    public class data
    {
        /// <summary>
        /// 调阅流水号 记录医生一次调阅的唯一标识
        /// </summary>
        public string view_record_id { get; set; }

        /// <summary>
        /// 跳转url 医学影像数据跨院共享系统的跳转url，地址中携带调阅流水号
        /// </summary>
        public url url { get; set; }
    }

    public class url
    {
        /// <summary>
        /// 协议 
        /// </summary>
        public string transport_protocol { get; set; }

        /// <summary>
        /// 域名和端口 
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        /// 路径 
        /// </summary>
        public string path { get; set; }
    }
}
