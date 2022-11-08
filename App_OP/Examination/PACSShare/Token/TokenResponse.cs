using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Token
{
    class TokenResponse
    {
        /// <summary>
        /// 状态编码 状态编码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 接口描述 接口描述
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 接口数据 接口数据
        /// </summary>
        public data data { get; set; }

    }

    class data
    {
        /// <summary>
        /// 失效时间 到期时间戳
        /// </summary>
        public string expire_in { get; set; }

        /// <summary>
        /// 接口token 资源接口将token放在header中，X-Ttoken：xadfaadsf。
        /// </summary>
        public string token { get; set; }

    }
}
