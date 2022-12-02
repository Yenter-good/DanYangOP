using App_OP.PrescriptionCirculation.PreAudit;
using App_OP.PrescriptionCirculation.Upload;
using CIS.Core;
using CIS.Model;
using CIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.UploadSign
{
    class UploadPrescriptionSignHelper
    {
        private PrescriptionCirculationHandler _handler;

        public UploadPrescriptionSignHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public (UploadPrescriptionSignResponse, UploadPrescriptionRequest) Handler(UploadPreAuditResponse preauditInfo, OP_PrescriptionCirculation prescription, string PrescriptionNum)
        {
            var dt = DBHelper.CIS.FromSql($"select * from vtyb_mz_dj where jzh ='{prescription.TreatmentNo}'").ToDataTable();
            if (dt.Rows.Count == 0)
                return (null, null);

            UploadPrescriptionRequest uploadRequest = new UploadPrescriptionRequest();

            uploadRequest.rxTraceCode = preauditInfo.rxTraceCode;
            uploadRequest.hiRxno = preauditInfo.hiRxno;

            uploadRequest.mdtrtId = dt.Rows[0]["mdtrt_id"].ToString();
            uploadRequest.patnName = SysContext.GetCurrPatient.PatientName;
            uploadRequest.psnCertType = "01";
            uploadRequest.certno = SysContext.GetCurrPatient.IDCard;
            uploadRequest.fixmedinsName = "丹阳市中医院";
            uploadRequest.fixmedinsCode = "H32118100064";
            uploadRequest.drCode = SysContext.CurrUser.user.HealthCareCode;
            uploadRequest.prscDrName = SysContext.CurrUser.UserName;
            uploadRequest.pharDeptName = SysContext.RunSysInfo.currDept.Name;
            uploadRequest.pharDeptCode = SysContext.RunSysInfo.currDept.Code;
            uploadRequest.pharCode = SysContext.CurrUser.user.HealthCareCode;
            uploadRequest.pharName = SysContext.CurrUser.UserName;
            uploadRequest.pharChkTime = prescription.UpdateTime.Value;

            var uploadBase = uploadRequest as UploadPrescriptionBase;
            var base64 = Print.PrescriptionBase64(prescription.PrescriptionNo, preauditInfo.rxTraceCode, PrescriptionNum);

            UploadPrescriptionSignRequest signRequest = new UploadPrescriptionSignRequest()
            {
                fixmedinsCode = "H32118100064",
                originalValue = SerializeHelper.BeginJsonSerializable(uploadBase).ToBase64(),
                originalRxFile = base64
            };

            var url = SysContext.CurrUser.Params.OP_PrescriptionCirculation_Url;
            var response = _handler.Post<UploadPrescriptionSignResponse>(signRequest, url + "/fixmedins/fixmedins/rxFixmedinsSign", "上传签名");
            if (response != null)
                return (response, uploadRequest);
            else
                return (null, null);
        }
    }
}
