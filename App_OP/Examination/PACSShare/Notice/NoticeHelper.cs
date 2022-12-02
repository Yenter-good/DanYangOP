using CIS.Core;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Notice
{
    class NoticeHelper
    {
        public (string url, string serialNumber) Handler(List<OP_Prescription_Detail> details)
        {
            NoticeRequest request = new NoticeRequest()
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
                op_em_hp_ex_mark = "门诊",
                source = "丹阳市中医院",
            };

            request.project_list = new List<project>();
            foreach (var detail in details)
            {
                request.project_list.Add(new project()
                {
                    chk_advice = detail.ItemName,
                    chk_modality = "",
                    ckpt_name = detail.ItemName,
                    hos_proj_no = detail.ItemCode,
                    proj_name = detail.ItemName,
                    study_request_time = DateTime.Now
                });
            }

            var url = SysContext.CurrUser.Params.OP_PACSShare_Url;
            var response = PACSShareHelper.Post<NoticeResponse>(request, url + "/openapi/api/v2/mutual/project/notice", "类似检查项目");
            if (response == null)
                return (null, null);
            else
            {
                if (response.data.url == null)
                    return (null, response.data.view_record_id);
                else
                {
                    var url1 = $"{response.data.url.transport_protocol}://{response.data.url.domain}/{response.data.url.path}";
                    return (url1, response.data.view_record_id);
                }
            }
        }
    }
}
