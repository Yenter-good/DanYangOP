using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Submit
{
    class SubmitRequest : ViewOtherHos.ViewOtherHosRequest
    {
        /// <summary>
        /// 调阅流水号 记录医生一次调阅的唯一标识
        /// </summary>
        public string view_record_id { get; set; }

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
        public List<Notice.project> project_list { get; set; }

    }
}
