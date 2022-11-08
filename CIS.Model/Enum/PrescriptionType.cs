using CIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CIS.Model
{
    public enum PrescriptionType
    {
        /// <summary>
        /// 普通处方
        /// </summary>
        [EnumDescription("普通处方")]
        Normal = 1,
        /// <summary>
        /// 检验处方
        /// </summary>
        [EnumDescription("检验处方")]
        LIS = 11,
        /// <summary>
        /// 检查处方
        /// </summary>
        [EnumDescription("检查处方")]
        RIS = 12,
        /// <summary>
        /// 草药处方
        /// </summary>
        [EnumDescription("草药处方")]
        Herbal = 2,
        /// <summary>
        /// 草药处方
        /// </summary>
        [EnumDescription("草药处方")]
        HerbalChronic = 13,
        /// <summary>
        /// 慢性病处方
        /// </summary>
        [EnumDescription("慢性病处方")]
        Chronic = 3,
        /// <summary>
        /// 毒麻处方
        /// </summary>
        [EnumDescription("毒麻处方")]
        Poisonous = 4,
        /// <summary>
        /// 急诊处方
        /// </summary>
        [EnumDescription("急诊处方")]
        Emergency = 5,
        /// <summary>
        /// 儿童处方
        /// </summary>
        [EnumDescription("儿童处方")]
        Children = 6,
        /// <summary>
        /// 精麻一处方
        /// </summary>
        [EnumDescription("精麻一处方")]
        JingmaYi = 7,
        /// <summary>
        /// 精麻二处方
        /// </summary>
        [EnumDescription("精麻二处方")]
        JingmaEr = 8,
        /// <summary>
        /// 治疗处方
        /// </summary>
        [EnumDescription("治疗处方")]
        Treatment = 9,
    }
}
