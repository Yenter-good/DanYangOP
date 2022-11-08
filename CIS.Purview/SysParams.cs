using System;
using System.Collections.Concurrent;

namespace CIS.Purview
{
    /// <summary>
    /// 系统参数访问类
    /// 命名规范 系统模板前缀_参数名称
    /// </summary>
    public class SysParams
    {
        private static ConcurrentDictionary<string, string> paramValues = new ConcurrentDictionary<string, string>();
        /// <summary>
        /// 客户名称
        /// </summary>
        public string Sys_CustomerName { get { return GetValue("SYS900001", "客户名称", "客户名称", "XX市人民医院"); } }

        public static string GetTemplateHeaderAndFooter = Properties.Resources.门诊病历页眉页脚;
        public static string GetInfectionReport = Properties.Resources.传染病报卡;
        public static string GetHospitalizedReport = Properties.Resources.住院报告单;
        public static string GetDiagnosisReport = Properties.Resources.诊断说明书;
        public static string GetSpecialItem = Properties.Resources.特殊耗材使用审批;

        #region OP 门诊医生站参数

        /// <summary>
        /// 检验单是否按标本类型拆分
        /// </summary>
        public bool OP_SplitLISOrder { get { return GetValue("OP900002", "检验单是否拆分", "检验单是否按标本类型拆分", "是").AsBoolean(); } }
        /// <summary>
        /// 检查单是否按执行科室拆分
        /// </summary>
        public bool OP_SplitRISOrder { get { return GetValue("OP900003", "检查单是否拆分", "检查单是否按执行科室拆分", "是").AsBoolean(); } }
        /// <summary>
        /// 是否启用回单号
        /// </summary>
        public bool OP_FreeRegistered { get { return GetValue("OP900004", "是否启用回单号", "门诊医生站是否可以直接挂回单号（免费号）", "否").AsBoolean(); } }
        /// <summary>
        /// 是否开启心电调阅
        /// </summary>
        public bool OP_EcgRead { get { return GetValue("OP900005", "是否开启心电调阅", "是否开启心电调阅", "否").AsBoolean(); } }
        /// <summary>
        /// 心电调阅地址
        /// </summary>
        public string OP_EcgReadUrl { get { return GetValue("OP900006", "心电调阅地址", "心电调阅地址", "否").ToString(); } }

        #endregion

        #region EMR 电子病历参数

        /// <summary>
        /// 是否开放体温单功能
        /// </summary>
        public bool EMR_Temperture { get { return GetValue("EMR900004", "是否开放体温单功能", "是否开放体温单功能", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否开放内置麻醉功能
        /// </summary>
        public bool EMR_BuiltInAMIS { get { return GetValue("EMR900005", "是否开放内置麻醉功能", "是否开放内置麻醉功能", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否开放内置医技功能
        /// </summary>
        public bool EMR_BuiltInRIS { get { return GetValue("EMR900006", "是否开放内置医技功能", "是否开放内置医技功能", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否开放内置医嘱功能
        /// </summary>
        public bool EMR_BuiltInOrder { get { return GetValue("EMR900007", "是否开放内置下嘱功能", "是否开放内置下嘱功能", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否对接医嘱结果
        /// </summary>
        public bool EMR_JionOrderResult { get { return GetValue("EMR900008", "是否对接医嘱结果", "是否对接医嘱结果", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否对接LIS结果
        /// </summary>
        public bool EMR_JionLISResult { get { return GetValue("EMR900009", "是否对接LIS结果", "是否对接LIS结果", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否对接RIS结果
        /// </summary>
        public bool EMR_JionRISResult { get { return GetValue("EMR900010", "是否对接RIS结果", "是否对接RIS结果", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否对接PACS结果
        /// </summary>
        public bool EMR_JionPACSResult { get { return GetValue("EMR900011", "是否对接PACS结果", "是否对接PACS结果", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 是否允许跨病历复制
        /// </summary>
        public bool EMR_CrossCopy { get { return GetValue("EMR900012", "是否开放体温单功能", "是否开放体温单功能", Boolean.TrueString).AsBoolean(); } }
        /// <summary>
        /// 不同科室是强制分页
        /// </summary>
        public bool EMR_DiffDeptPage { get { return GetValue("EMR900013", "不同科室是强制分页", "不同科室是强制分页", Boolean.TrueString).AsBoolean(); } }

        #endregion

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code">参数编码</param>
        /// <param name="name">参数名称</param>
        /// <param name="descrption">描述文本</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private string GetValue(string code, string name, string descrption, string defaultValue)
        {
            string value = defaultValue;
            if (paramValues.ContainsKey(code))
            {
                paramValues.TryGetValue(code, out value);
                return value;
            }
            else
            {
                if (SysParameterDal.Exists(code))
                {
                    value = SysParameterDal.Get(code);
                }
                else
                {
                    SysParameterDal.Add(code, name, descrption, value);
                }
                paramValues.TryAdd(code, value);
                return value;
            }
        }
    }
}
