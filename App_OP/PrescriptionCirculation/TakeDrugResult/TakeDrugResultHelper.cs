using CIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.TakeDrugResult
{
    class TakeDrugResultHelper
    {
        private PrescriptionCirculationHandler _handler;

        public TakeDrugResultHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public TakeDrugResultResponse Handler(OP_Prescription prescription)
        {
            var dt = DBHelper.CIS.FromSql($"select * from vtyb_mz_dj where jzh ='{prescription.TreatmentNo}'").ToDataTable();
            if (dt.Rows.Count == 0)
                return null;
            var request = new TakeDrugResultRequest()
            {
                certno = prescription.IDCard,
                fixmedinsCode = "H32118100064",
                hiRxno = prescription.PrescriptionCirculation_PrescriptionNo,
                mdtrtId = dt.Rows[0]["mdtrt_id"].ToString(),
                psnCertType = "01",
                psnName = prescription.PatientName,
            };

            return _handler.Post<TakeDrugResultResponse>(request, "http://10.72.3.127:20080/fixmedins/fixmedins/rxSetlInfoQuery", "取药查询");
        }
    }
}
