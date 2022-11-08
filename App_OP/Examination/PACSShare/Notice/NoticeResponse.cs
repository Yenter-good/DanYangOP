using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Notice
{
    class NoticeResponse
    {
        /// <summary>
        /// 状态编码 成功：200失败：其他
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// 接口描述 错误描述
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// 接口数据 
        /// </summary>
        public data data { get; set; }

    }

    public class data : ViewOtherHos.data
    {
        /// <summary>
        /// 总数
        /// </summary>
        public string totalNum { get; set; }
    }
}
