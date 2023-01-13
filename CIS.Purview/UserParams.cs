using CIS.Model;
using System;
using System.Collections.Concurrent;

namespace CIS.Purview
{
    /// <summary>
    /// 系统参数访问类
    /// 命名规范 系统模板前缀_参数名称
    /// </summary>
    public class UserParams
    {
        private string curUserId = null;
        private ConcurrentDictionary<string, string> paramValues = new ConcurrentDictionary<string, string>();
        /// <summary>
        /// 选择用户
        /// </summary>
        /// <param name="deptId"></param>
        public void Select(string userId)
        {
            if (curUserId != userId)
            {
                paramValues.Clear();
                curUserId = userId;
            }
        }
        /// <summary>
        /// 刷新用户参数信息
        /// </summary>
        public void Refresh()
        {
            paramValues.Clear();
        }
        /// <summary>
        /// 登录系统时默认加载的系统
        /// </summary>
        public string Sys_DefaultAppCode { get { return GetValue(curUserId, "U001", "默认系统", "登录系统时默认加载的系统", ""); } }
        /// <summary>
        /// 保存后是否直接打印出单据
        /// </summary>
        public bool OP_SaveAndPrint { get { return GetValue(curUserId, "U002", "保存并打印", "保存后是否直接打印出单据", "是").AsBoolean(); } }
        /// <summary>
        /// 关联门诊医生站处方页面是否显示中药膏方和是否可以开草药
        /// </summary>
        public bool OP_ShowHerbalMedicine { get { return GetValue(curUserId, "U003", "是否需要草药信息", "关联门诊医生站处方页面是否显示中药膏方和是否可以开草药", "是").AsBoolean(); } }
        /// <summary>
        /// 开具处方时是否可以按回车键后换行
        /// </summary>
        public bool OP_CanEnter { get { return GetValue(curUserId, "U004", "处方是否可以回车换行", "开具处方时是否可以按回车键后换行", "是").AsBoolean(); } }
        /// <summary>
        /// 处方回车换行位置
        /// </summary>
        public string OP_Enter_Position { get { return GetValue(curUserId, "U005", "处方回车换行位置", "U004为“是”时 指定换行位置有效", ""); } }
        /// <summary>
        /// 默认用法
        /// </summary>
        public string OP_DefaultUsage { get { return GetValue(curUserId, "U006", "默认处方用法", "默认用法", "po"); } }
        /// <summary>
        /// 默认间隔
        /// </summary>
        public string OP_DefaultFrequency { get { return GetValue(curUserId, "U007", "默认处方间隔", "默认间隔", "qd"); } }
        /// <summary>
        /// 默认西药处方类型
        /// </summary>
        public string OP_DefaultPrescriptionType { get { return GetValue(curUserId, "U008", "默认西药处方类型", "默认西药处方类型", "1"); } }
        /// <summary>
        /// 子模板导入是否追加
        /// </summary>
        public string OP_DefaultSubTemplateAppend { get { return GetValue(curUserId, "U010", "子模板导入是否追加", "子模板导入是否追加", "是"); } }
        /// <summary>
        /// 草药默认用法
        /// </summary>
        public string OP_DefaultHMUsage { get { return GetValue(curUserId, "U011", "草药默认用法", "草药默认用法", "煎服"); } }
        /// <summary>
        /// 是否自动校准时间
        /// </summary>
        public string OP_AutoCalibrationTime { get { return GetValue(curUserId, "U012", "是否自动校准时间", "是否自动校准时间", "否"); } }
        /// <summary>
        /// 是否开启医保控费接口
        /// </summary>
        public string OP_SwitchMedicalInsurance { get { return GetValue(curUserId, "U013", "是否开启医保控费接口", "是否开启医保控费接口", "是"); } }
        /// <summary>
        /// 选中病人自动叫号
        /// </summary>
        public string OP_SelectPatientWithCall { get { return GetValue(curUserId, "U014", "选中病人自动叫号", "选中病人自动叫号", "否"); } }
        /// <summary>
        /// 是否辅助计算一次用量
        /// </summary>
        public string OP_AssistDose { get { return GetValue(curUserId, "U015", "是否辅助计算一次用量", "是否辅助计算一次用量", "否"); } }
        /// <summary>
        /// 是否开启西药数量自动计算
        /// </summary>
        public string OP_AutoColculateWMNum { get { return GetValue(curUserId, "U016", "是否开启西药数量自动计算", "是否开启西药数量自动计算", "否"); } }
        /// <summary>
        /// 是否开启慢病报卡复诊提醒
        /// </summary>
        public string OP_SwitchChronicSecondCome { get { return GetValue(curUserId, "U017", "是否开启慢病报卡复诊提醒", "是否开启慢病报卡复诊提醒", "否"); } }
        /// <summary>
        /// 强制填写个人史
        /// </summary>
        public string OP_ForcePersonel { get { return GetValue(curUserId, "U018", "强制填写个人史", "强制填写个人史", "否"); } }
        /// <summary>
        /// 是否使用紧急病人资料视图
        /// </summary>
        public bool OP_EmergencyPatientInfo { get { return DBHelper.CIS.From<Sys_UserParameter_Value>().Select(p => p.ParameterValue).Where(p => p.ParameterCode == "U019" && p.UserID == "All").ToScalar<string>().AsBoolean(); } }
        /// <summary>
        /// 核酸检验提醒
        /// </summary>
        public bool OP_NATTips { get { return GetValue(curUserId, "U020", "核酸检验提醒", "核酸检验提醒", "否").AsBoolean(); } }
        /// <summary>
        /// 医保事前审查
        /// </summary>
        public bool OP_BeforePrescriptionAudit { get { return GetValue(curUserId, "U021", "医保事前审查", "医保事前审查", "否").AsBoolean(); } }

        /// <summary>
        /// 云影像平台
        /// </summary>
        public bool OP_PACSShare { get { return GetValue(curUserId, "U022", "云影像平台", "云影像平台", "否").AsBoolean(); } }

        /// <summary>
        /// 处方双通道地址
        /// </summary>
        public string OP_PrescriptionCirculation_Url { get { return GetValue(curUserId, "U998", "处方双通道地址", "处方双通道地址", "http://10.72.3.127:20080").AsString(); } }
        /// <summary>
        /// 云影像平台地址
        /// </summary>
        public string OP_PACSShare_Url { get { return GetValue(curUserId, "U999", "云影像平台地址", "云影像平台地址", "http://20.30.1.81").AsString(); } }

        public string OP_HealthRecords_Url { get { return GetValue("All", "U997", "健康档案地址", "健康档案地址", "http://20.17.10.172:9990").AsString(); } }
        public string OP_HealthRecords_Encryption_Url { get { return GetValue("All", "U996", "健康档案获取加密偏移地址", "健康档案获取加密偏移地址", "http://20.17.10.172:9990/ehr/getEncryptParam").AsString(); } }
        public string OP_HealthRecords_Account { get { return GetValue("All", "U995", "健康档案账号", "健康档案账号", "DYSZYY").AsString(); } }
        public string OP_HealthRecords_Password { get { return GetValue("All", "U994", "健康档案密码", "健康档案密码", "dheueEW#2s!@%").AsString(); } }
        public string OP_HealthRecords_AESKey { get { return GetValue("All", "U993", "健康档案加密key", "健康档案加密key", "ivGtmsFC5lVdm2Kj").AsString(); } }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code">参数编码</param>
        /// <param name="name">参数名称</param>
        /// <param name="descrption">描述文本</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private string GetValue(string userId, string code, string name, string descrption, string defaultValue)
        {
            if (userId == null) return defaultValue;
            string value = defaultValue;
            if (paramValues.ContainsKey(code))
            {
                paramValues.TryGetValue(code, out value);
                return value;
            }
            else
            {
                if (UserParameterDal.Exists(userId, code))
                {
                    value = UserParameterDal.Get(userId, code);
                }
                else
                {
                    //UserParameterDal.Add(userId, code, name, descrption, value);
                }
                paramValues.TryAdd(code, value);
                return value;
            }
        }


    }
}
