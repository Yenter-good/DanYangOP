using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.AuditResult
{
    class AuditResultHelper
    {
        private PrescriptionCirculationHandler _handler;

        public AuditResultHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public AuditResultResponse Handler(OP_PrescriptionCirculation prescription)
        {
            var dt = DBHelper.CIS.FromSql($"select * from vtyb_mz_dj where jzh ='{prescription.TreatmentNo}'").ToDataTable();
            if (dt.Rows.Count == 0)
                return null;
            var request = new AuditResultRequest()
            {
                certno = prescription.IDCard,
                fixmedinsCode = "H32118100064",
                hiRxno = prescription.PrescriptionCirculationNo,
                mdtrtId = dt.Rows[0]["mdtrt_id"].ToString(),
                psnCertType = "01",
                psnName = prescription.PatientName,
            };

            var url = SysContext.CurrUser.Params.OP_PrescriptionCirculation_Url;
            return _handler.Post<AuditResultResponse>(request, url + SysContext.CurrUser.Params.OP_PrescriptionCirculation_Uri.AuditResult, "审核结果查询");
        }
    }
}
