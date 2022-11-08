using CIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Number
{
    class NumberHelper
    {
        public int Handler()
        {
            NumberRequest request = new NumberRequest()
            {
                app_doc_idcard = SysContext.CurrUser.user.IDCard,
                app_doc_loginid = SysContext.CurrUser.UserId,
                app_doc_name = SysContext.CurrUser.UserName,
                app_dpt_code = SysContext.RunSysInfo.currDept.Code,
                app_dpt_name = SysContext.RunSysInfo.currDept.Name,
                cardno = SysContext.GetCurrPatient.IDCard,
                cardtype = "1",
                mobile = SysContext.GetCurrPatient.ContactNumber,
                name = SysContext.GetCurrPatient.PatientName,
                organ_code = "12321181468778299Y",
                organ_empi = SysContext.GetCurrPatient.OutpatientNo,
                organ_name = "丹阳市中医院",
                permissions_code = "IIS",
                study_request_time = DateTime.Now,
                op_em_hp_ex_mark = "门诊"
            };

            var response = PACSShareHelper.Post<NumberResponse>(request, "http://20.30.1.81/openapi/api/v2/study/shorttime/list/total", "获取项目总数");
            if (response == null)
                return 0;
            else
                return response.data.total_num;
        }
    }
}
