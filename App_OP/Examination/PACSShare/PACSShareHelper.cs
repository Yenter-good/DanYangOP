using CIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare
{
    public class PACSShareHelper
    {
        private static Dictionary<string, string> _tokenHeader;
        private static string _token;

        public static string Token
        {
            get => _token;
            set
            {
                _tokenHeader = new Dictionary<string, string>();
                _tokenHeader["X-Token"] = value;
            }
        }

        public static T Post<T>(object obj, string url, string handlerName)
        {
            var json = SerializeHelper.BeginJsonSerializable(obj);
            LogHelper.Debug($"{handlerName} 请求报文 " + json, "PACSShare");

            bool success;
            string response;

            try
            {
                if (string.IsNullOrWhiteSpace(Token))
                    success = HTTPHelper.HttpPost(url, json, HTTPHelper.ContentType.Json, out response);
                else
                    success = HTTPHelper.HttpPost(url, json, _tokenHeader, HTTPHelper.ContentType.Json, out response);

                LogHelper.Debug($"{handlerName} 响应报文 " + json, "PACSShare");

                if (success)
                    return SerializeHelper.BeginJsonDeserialize<T>(response);
                else
                    return default;
            }
            catch (Exception ex)
            {
                LogHelper.Debug($"{handlerName} 响应报文报错 " + ex.Message, "PACSShare");
            }

            return default;
        }
    }
}
