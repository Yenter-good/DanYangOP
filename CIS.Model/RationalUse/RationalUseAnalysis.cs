using System.Collections.Generic;
using System.Xml.Serialization;

namespace CIS.Model.RationalUse
{
    [XmlRoot("details_xml")]
    public class RationalUseAnalysis
    {
        [XmlAttribute("number")]
        public string is_upload { get; set; }

        /// <summary>
        /// HIS系统时间（YYYY-MM-DD HH:mm:SS）
        /// </summary>
        public string his_time { get; set; }

        /// <summary>
        /// 门诊住院标识 op/ip
        /// </summary>
        public string hosp_flag { get; set; }

        /// <summary>
        /// 就诊类型
        /// </summary>
        public string treat_type { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        public string treat_code { get; set; }

        /// <summary>
        /// 床位号
        /// </summary>
        public string bed_no { get; set; }

        /// <summary>
        /// 病区号
        /// </summary>
        public string area_code { get; set; }

        public patient patient { get; set; }

        public prescription_data prescription_data { get; set; }
    }

    public class patient
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 是否婴幼儿
        /// </summary>
        public string is_infant { get; set; }

        /// <summary>
        /// 出生日期(YYYY-MM-DD)
        /// </summary>
        public string birth { get; set; }

        /// <summary>
        /// 性别（男/女/未知）
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// 体重（单位：千克）
        /// </summary>
        public string weight { get; set; }

        /// <summary>
        /// 身高（单位：厘米）
        /// </summary>
        public string height { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string card_type { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string card_code { get; set; }

        /// <summary>
        /// 时间单位（天、周、月）
        /// </summary>
        public string pregnant_unit { get; set; }

        /// <summary>
        /// 怀孕时间
        /// </summary>
        public string pregnant { get; set; }

        public allergic_data allergic_data { get; set; }

        public diagnose_data diagnose_data { get; set; }

        public lis_data lis_data { get; set; }
    }

    public class allergic_data
    {
        public allergic allergic { get; set; }
    }

    public class allergic
    {
        /// <summary>
        /// 过敏类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 过敏源名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 过敏源代码
        /// </summary>
        public string code { get; set; }
    }

    public class diagnose_data
    {
        public diagnose diagnose { get; set; }
    }

    public class diagnose
    {
        /// <summary>
        /// 诊断类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 诊断代码
        /// </summary>
        public string code { get; set; }
    }

    public class lis_data
    {
        public form form { get; set; }
    }

    public class form
    {
        /// <summary>
        /// 检验、检查单号
        /// </summary>
        public string no { get; set; }

        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string project_name { get; set; }

        /// <summary>
        /// 检验、检查标记 0-检验, 1-检查
        /// </summary>
        public string lis_flag { get; set; }

        /// <summary>
        /// 检验、检查结果出具时间
        /// </summary>
        public string result_date { get; set; }

        /// <summary>
        /// 检验样本编码
        /// </summary>
        public string sample_code { get; set; }

        /// <summary>
        /// 检验样本名称
        /// </summary>
        public string sample_name { get; set; }

        /// <summary>
        /// 微生物送检标识 0-否, 1-是
        /// </summary>
        public string mac_flag { get; set; }

        public item item { get; set; }

    }

    public class item
    {
        /// <summary>
        /// 检验、检查编码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 检验、检查名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 检验、检查结果
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 结果值的单位
        /// </summary>
        public string uom { get; set; }

        /// <summary>
        /// 结果参考范围上限
        /// </summary>
        public string upper { get; set; }

        /// <summary>
        /// 结果参考范围下限
        /// </summary>
        public string lower { get; set; }
    }

    public class prescription_data
    {
        public prescription prescription { get; set; }
    }

    public class prescription
    {
        /// <summary>
        /// 处方号
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 处方理由
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// 是否紧急处方(0:否1:是)
        /// </summary>
        public string is_urgent { get; set; }

        /// <summary>
        /// 是否新开处方(0:否1:是)
        /// </summary>
        public string is_new { get; set; }

        /// <summary>
        /// 是否当前处方（0/1）
        /// </summary>
        public string is_current { get; set; }

        /// <summary>
        /// 开嘱医生代码
        /// </summary>
        public string doct_code { get; set; }

        /// <summary>
        /// 开嘱科室代码
        /// </summary>
        public string dept_code { get; set; }

        /// <summary>
        /// 开嘱科室姓名
        /// </summary>
        public string dept_name { get; set; }

        /// <summary>
        /// 长期医嘱L/临时医嘱T
        /// </summary>
        public string pres_type { get; set; }

        /// <summary>
        /// 处方时间（YYYY-MM-DD HH:mm:SS）
        /// </summary>
        public string pres_time { get; set; }

        public medicine_data medicine_data { get; set; }
    }

    public class medicine_data
    {
        [XmlElement("medicine")]
        public List<medicine> medicine { get; set; }
    }

    public class medicine
    {
        /// <summary>
        /// 商品名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 医院药品代码
        /// </summary>
        public string his_code { get; set; }

        /// <summary>
        /// 医保代码
        /// </summary>
        public string insur_code { get; set; }

        /// <summary>
        /// 配液单号
        /// </summary>
        public string pyd_code { get; set; }

        /// <summary>
        /// 配液单组号
        /// </summary>
        public string link_group { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string spec { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        public string group { get; set; }

        /// <summary>
        /// 用药理由
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// 单次量单位
        /// </summary>
        public string dose_unit { get; set; }

        /// <summary>
        /// 单次量
        /// </summary>
        public string dose { get; set; }

        /// <summary>
        /// 频次代码
        /// </summary>
        public string freq { get; set; }

        /// <summary>
        /// 给药途径代码
        /// </summary>
        public string administer { get; set; }

        /// <summary>
        /// （住院）用药开始时间	(YYYY-MM-DD HH:mm:SS)
        /// </summary>
        public string begin_time { get; set; }

        /// <summary>
        /// 住院）用药结束时间(YYYY-MM-DD HH:mm:SS)
        /// </summary>
        public string end_time { get; set; }

        /// <summary>
        /// 服药天数（门诊）
        /// </summary>
        public string days { get; set; }

        /// <summary>
        /// （住院）是否预防用药（1是，0否）        
        /// </summary>
        public string preventiveflag { get; set; }

        /// <summary>
        /// （住院）手术单号
        /// </summary>
        public string otno { get; set; }

        /// <summary>
        /// 签名医师工号
        /// </summary>
        public string signer_code { get; set; }

        /// <summary>
        /// 授权时间
        /// </summary>
        public string accredit_date { get; set; }

        /// <summary>
        /// 允许用药时间（小时）
        /// </summary>
        public string accredit_hours { get; set; }

        /// <summary>
        /// 允许用药次数
        /// </summary>
        public string accredit_times { get; set; }

    }
}
