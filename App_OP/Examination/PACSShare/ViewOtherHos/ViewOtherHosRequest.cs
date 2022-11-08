using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.ViewOtherHos
{
    class ViewOtherHosRequest
    {
        /// <summary>
        /// 医疗机构编码 18位统一社会信用代码
        /// </summary>
        public string organ_code { get; set; }

        /// <summary>
        /// 医疗机构名称 
        /// </summary>
        public string organ_name { get; set; }

        /// <summary>
        /// 申请科室编码 
        /// </summary>
        public string app_dpt_code { get; set; }

        /// <summary>
        /// 申请科室名称 
        /// </summary>
        public string app_dpt_name { get; set; }

        /// <summary>
        /// 申请医生登录账号 
        /// </summary>
        public string app_doc_loginid { get; set; }

        /// <summary>
        /// 申请医生身份证号 
        /// </summary>
        public string app_doc_idcard { get; set; }

        /// <summary>
        /// 申请医生姓名 
        /// </summary>
        public string app_doc_name { get; set; }

        /// <summary>
        /// 院内患者主索引 建议采用全球唯一编码
        /// </summary>
        public string organ_empi { get; set; }

        /// <summary>
        /// 证件类型 如有多种证件，请优先上传居民身份证。参照《江苏省卫生健康云（影像平台）数据采集接口标准》附录字典表表5 RC038-国家公立医院绩效考核患者证件类别代码
        /// </summary>
        public string cardtype { get; set; }

        /// <summary>
        /// 证件号码 
        /// </summary>
        public string cardno { get; set; }

        /// <summary>
        /// 患者姓名 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 患者电话 
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 鉴权平台标识 默认传IIS
        /// </summary>
        public string permissions_code { get; set; }

        /// <summary>
        /// 请求时间 
        /// </summary>
        public DateTime study_request_time { get; set; }

    }
}
