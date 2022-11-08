using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Token
{
    class TokenRequest
    {
        /// <summary>
        /// 应用编码 该参数由管理员提供。
        /// </summary>
        public string app_key { get; set; }

        /// <summary>
        /// 时间戳 当前时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 签名 md5(md5(app_key+timestamp)+secret) 签名字符串，注意md5两次加密，均选用32位小写字符串。secret由管理员提供。
        /// </summary>
        public string app_sign { get; set; }

    }
}
