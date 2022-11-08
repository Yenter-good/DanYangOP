using CIS.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation
{
    class Encryption
    {
        public PrescriptionCirculationRequest GetEncryptionData(object obj, string handlerName)
        {
            var request = new request()
            {
                data = obj
            };

            var json = SerializeHelper.BeginJsonSerializable(request);
            LogHelper.Debug($"{handlerName} 提交待加密报文 " + json);
            var success = HTTPHelper.HttpPost("http://192.168.1.218:8095/Getsmdy", json, HTTPHelper.ContentType.Json, out var result);
            if (success)
            {
                LogHelper.Debug($"{handlerName} 获得加密报文 " + result);

                var response = SerializeHelper.BeginJsonDeserialize<EncryptionResponse>(result);
                if (response.code != 0)
                    return null;

                return response.data;
            }
            return null;
        }
    }

    class request
    {
        public object data { get; set; }
    }

    class EncryptionResponse
    {
        public int code { get; set; }
        public PrescriptionCirculationRequest data { get; set; }
        public string message { get; set; }
    }

}
