using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using App_OP.PrescriptionCirculation.PreAudit;
using CIS.Core;
using CIS.Model;
using CIS.Utility;

namespace App_OP.PrescriptionCirculation
{
    class PrescriptionCirculationHandler
    {
        private Encryption _encryption = new Encryption();
        private Decryption _decryption = new Decryption();

        public static event EventHandler<PatientDiagnosisEventArgs> PatientDiagnosis;
        public static event EventHandler NewPatientHandler;

        private static bool _log;

        public static void Init()
        {
            var log = ConfigurationManager.AppSettings["prescription_circulation_log"];
            if (log == "true")
                _log = true;
            else
                _log = false;
        }

        public static List<OP_PatientDiagnosis> GetPatientDiagnoses()
        {
            var args = new PatientDiagnosisEventArgs();
            PatientDiagnosis.Invoke(null, args);
            return args.Diagnosis;
        }

        public static void NewPatient()
        {
            NewPatientHandler?.Invoke(null, EventArgs.Empty);
        }

        public static List<IView_PrescriptionCirculation_DrugInfo> DrugInfos { get; set; }

        public T Post<T>(object request, string url, string handlerName) where T : class
        {
            var pcRequest = _encryption.GetEncryptionData(request, handlerName, _log);

            if (pcRequest == null)
                return null;

            var json = SerializeHelper.BeginJsonSerializable(pcRequest);

            var success = HTTPHelper.HttpPost(url, json, HTTPHelper.ContentType.Json, out var pcResponse);
            if (_log)
                LogHelper.Debug($"{handlerName} 获得响应加密报文 " + pcResponse);

            var result = SerializeHelper.BeginJsonDeserialize<PrescriptionCirculationResponse>(pcResponse);
            if (result.code != 0)
            {
                AlertBox.Error(result.message);
                return null;
            }

            if (success)
            {
                return _decryption.GetDecryptionData<T>(pcResponse, handlerName, _log);
            }
            else
            {
                AlertBox.Error("双通道上传失败");
                return null;
            }
        }
    }

    class PatientDiagnosisEventArgs : EventArgs
    {
        public List<OP_PatientDiagnosis> Diagnosis { get; set; }
    }
}
