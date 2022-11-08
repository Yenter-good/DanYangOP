using App_OP.PrescriptionCirculation.UploadSign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Upload
{
    class UploadPrescriptionHelper
    {
        private PrescriptionCirculationHandler _handler;

        public UploadPrescriptionHelper()
        {
            _handler = new PrescriptionCirculationHandler();
        }

        public UploadPrescriptionResponse Handler(UploadPrescriptionSignResponse signResponse, UploadPrescriptionRequest request)
        {
            request.rxFile = signResponse.rxFile;
            request.signDigest = signResponse.signDigest;

            return _handler.Post<UploadPrescriptionResponse>(request, "http://10.72.3.127:20080/fixmedins/fixmedins/rxFileUpld", "处方上传");
        }
    }
}
