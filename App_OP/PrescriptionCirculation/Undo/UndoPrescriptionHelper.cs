using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Undo
{
    public class UndoPrescriptionHelper
    {
        private PrescriptionCirculationHandler _handler;

        public UndoPrescriptionHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public UndoPrescriptionResponse Handler(OP_PrescriptionCirculation prescription, string reason)
        {
            UndoPrescriptionRequest request = new UndoPrescriptionRequest();
            request.hiRxno = prescription.PrescriptionCirculationNo;
            request.fixmedinsCode = "H32118100064";
            request.drCode = SysContext.CurrUser.user.HealthCareCode;
            request.undoDrName = SysContext.CurrUser.UserName;
            request.undoDrCertType = "01";
            request.undoDrCertno = SysContext.CurrUser.user.IDCard;
            request.undoRea = reason;
            request.undoTime = DateTime.Now;

            var url = SysContext.CurrUser.Params.OP_PrescriptionCirculation_Url;
            var response = _handler.Post<UndoPrescriptionResponse>(request, url + SysContext.CurrUser.Params.OP_PrescriptionCirculation_Uri.Undo, "处方撤销");
            if (response != null)
                return response;
            else
                return null;
        }
    }
}
