using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.Examination.PACSShare.Number
{
    class NumberRequest:ViewOtherHos.ViewOtherHosRequest
    {
        /// <summary>
        /// 门诊/急诊/住院/体检标志 默认传门诊
        /// </summary>
        public string op_em_hp_ex_mark { get; set; }
    }
}
