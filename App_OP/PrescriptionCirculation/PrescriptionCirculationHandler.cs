using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App_OP.PrescriptionCirculation.PreAudit;
using CIS.Core;
using CIS.Utility;

namespace App_OP.PrescriptionCirculation
{
    class PrescriptionCirculationHandler
    {
        private Encryption _encryption = new Encryption();
        private Decryption _decryption = new Decryption();

        public T Post<T>(object request, string url, string handlerName) where T : class
        {
            var pcRequest = _encryption.GetEncryptionData(request, handlerName);

            if (pcRequest == null)
                return null;

            var json = SerializeHelper.BeginJsonSerializable(pcRequest);

            var success = HTTPHelper.HttpPost(url, json, HTTPHelper.ContentType.Json, out var pcResponse);
            LogHelper.Debug($"{handlerName} 获得响应加密报文 " + pcResponse);

            if (success)
            {
                return _decryption.GetDecryptionData<T>(pcResponse, handlerName);
            }
            else
            {
                AlertBox.Error("双通道上传失败");
                return null;
            }
        }
    }
}
