using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIS.Utility;

namespace App_OP.PrescriptionCirculation
{
    class Decryption
    {
        public T GetDecryptionData<T>(string response, string handlerName) where T : class
        {
            var success = HTTPHelper.HttpPost("http://192.168.1.218:8095/Getsmjm", response, HTTPHelper.ContentType.Json, out var result);
            LogHelper.Debug($"{handlerName} 获得响应解密报文 " + result);
            if (success)
            {
                var data = SerializeHelper.BeginJsonDeserialize<DecryptionResponse>(result);

                if (data.code != 0)
                    return null;

                return SerializeHelper.BeginJsonDeserialize<T>(data.data);
            }
            else
                return null;
        }
    }

    class DecryptionResponse
    {
        public int code { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
}
