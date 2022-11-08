using CIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.ViewOtherHos
{
    class ViewOtherHosHelper
    {
        public string Handler(string idcard, string mobile, string name, string outpatientNo)
        {
            ViewOtherHosRequest request = new ViewOtherHosRequest()
            {
                app_doc_idcard = SysContext.CurrUser.user.IDCard,
                app_doc_loginid = SysContext.CurrUser.UserId,
                app_doc_name = SysContext.CurrUser.UserName,
                app_dpt_code = SysContext.RunSysInfo.currDept.Code,
                app_dpt_name = SysContext.RunSysInfo.currDept.Name,
                cardno = idcard,
                cardtype = "1",
                mobile = mobile,
                name = name,
                organ_code = "12321181468778299Y",
                organ_empi = outpatientNo,
                organ_name = "丹阳市中医院",
                permissions_code = "IIS",
                study_request_time = DateTime.Now
            };

            var response = PACSShareHelper.Post<ViewOtherHosResponse>(request, "http://20.30.1.81/openapi/api/v2/study/create/url", "跨院调阅影像");
            if (response == null)
                return null;
            else
            {
                var url = $"{response.data.url.transport_protocol}://{response.data.url.domain}/{response.data.url.path}";
                return url;
            }

        }
    }
}
