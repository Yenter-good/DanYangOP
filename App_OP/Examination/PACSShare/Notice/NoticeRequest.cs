using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Notice
{
    class NoticeRequest : ViewOtherHos.ViewOtherHosRequest
    {
        /// <summary>
        /// 来源 
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 门诊/急诊/住院/体检标志 
        /// </summary>
        public string op_em_hp_ex_mark { get; set; }
        /// <summary>
        /// 项目列表 
        /// </summary>
        public List<project> project_list { get; set; }
    }

    public class project
    {
        /// <summary>
        /// 检查设备类型 该参数值可为ct、dr或mri。
        /// </summary>
        public string chk_modality { get; set; }

        /// <summary>
        /// 检查项目名称 
        /// </summary>
        public string proj_name { get; set; }

        /// <summary>
        /// 检查项目院内编码 院内检查开单系统所使用的编码，该编码可唯一表示检查项目且稳定不变(少变)，同一个检查项目不对应多个编码值。*请使用重复检查提醒收集的院内检查项目清单细项编码。
        /// </summary>
        public string hos_proj_no { get; set; }

        /// <summary>
        /// 检查部位 如果院内工作站目录中没有单独的检查部位字段，则上传检查项目字段。
        /// </summary>
        public string ckpt_name { get; set; }

        /// <summary>
        /// 检查申请名称 
        /// </summary>
        public string chk_advice { get; set; }

        /// <summary>
        /// 请求时间 
        /// </summary>
        public DateTime study_request_time { get; set; }
    }
}
