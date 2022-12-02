using CIS.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare
{
    public class PACSShareHelper
    {
        private static Dictionary<string, string> _tokenHeader;
        private static string _token;
        private static bool _log;

        public void Init()
        {
            var log = ConfigurationManager.AppSettings["pacs_share_log"];
            if (log == "true")
                _log = true;
            else
                _log = false;
        }

        public static string Token
        {
            get => _token;
            set
            {
                _token = value;
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

                if (_log)
                    LogHelper.Debug($"{handlerName} 响应报文 " + response, "PACSShare");

                if (success)
                    return SerializeHelper.BeginJsonDeserialize<T>(response);
                else
                    return default;
            }
            catch (Exception ex)
            {
                if (_log)
                    LogHelper.Debug($"{handlerName} 响应报文报错 " + ex.Message, "PACSShare");
            }

            return default;
        }
    }
}
