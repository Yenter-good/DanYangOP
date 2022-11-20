using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Token
{
    class TokenHelper
    {
        public bool Handler()
        {
            string secret = "ead6213132957a487d6eb6180ebe0cc5";

            TokenRequest request = new TokenRequest();
            request.app_key = "1575311312265756673";
            request.timestamp = getTime10().ToString();
            request.app_sign = ((request.app_key + request.timestamp).ToMD5() + secret).ToMD5();

            var response = PACSShareHelper.Post<TokenResponse>(request, "http://20.30.1.81/openapi/api/v2/auth/token", "获取Token");
            if (response != null)
            {
                PACSShareHelper.Token = response.data.token;
                return true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("获取Token报错");
                return false;
            }
        }

        //获取10位时间戳
        private long getTime10()
        {
            //ToUniversalTime()转换为标准时区的时间,去掉的话直接就用北京时间
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            //得到精确到秒的时间戳（长度10位）
            long time = (long)ts.TotalSeconds;
            return time;
        }
    }
}
