using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Number
{
    class NumberResponse
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
        /// 总数 
        /// </summary>
        public int total_num { get; set; }
    }
}
