using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Submit
{
    class SubmitResponse
    {
        /// <summary>
        /// 状态编码 成功：200失败：其他
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 接口描述 错误描述
        /// </summary>
        public string message { get; set; }

    }
}
