using System;
using System.Collections.Generic;
using System.Drawing;
using CIS.Model;
using CIS.Utility;
using System.Linq;
using System.Text;

namespace App_OP
{
    public static class QRImage
    {
        public static Bitmap GetPayImage(PayRequest request)
        {
            string xml = SerializeHelper.BeginXMLSerializable(request);

            Pay.Pay pay = new Pay.Pay();
            string xmlResult = pay.PayInterface(xml);
            PayResponse response = SerializeHelper.BeginXMLDeserialize<PayResponse>(xmlResult);

            if (response.XMLREC.STATUS != "FAIL")
            {
                string url = response.XMLREC.QRCODEURL;
                return HTTPHelper.HttpGet(url);
            }
            return null;
        }
    }
}
