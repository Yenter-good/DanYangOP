using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.ViewPrescription
{
    class ViewPrescriptionResponse
    {
        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 定点医疗机构编号  
        /// </summary>
        public string fixmedinsCode { get; set; }

        /// <summary>
        /// 定点医疗机构名称  
        /// </summary>
        public string fixmedinsName { get; set; }

        /// <summary>
        /// 医保处方状态编码  参考（rx_stas_cod g） 
        /// </summary>
        public string rxStasCodg { get; set; }

        /// <summary>
        /// 医保处方状态名称  
        /// </summary>
        public string rxStasName { get; set; }

        /// <summary>
        /// 医保处方使用状态编码  参考（rx_used_sta s_codg）
        /// </summary>
        public string rxUsedStasCodg { get; set; }

        /// <summary>
        /// 医保处方使用状态名称   
        /// </summary>
        public string rxUsedStasName { get; set; }

        /// <summary>
        /// 开方时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime prscTime { get; set; }

        /// <summary>
        /// 药品数量（剂数）  
        /// </summary>
        public decimal rxDrugCnt { get; set; }

        /// <summary>
        /// 处方整剂用法编号  参考药物使用- 途径代码(drug_medc_way_code) 
        /// </summary>
        public string rxUsedWayCodg { get; set; }

        /// <summary>
        /// 处方整剂用法名称   
        /// </summary>
        public string rxUsedWayName { get; set; }

        /// <summary>
        /// 处方整剂频次编号  参考使用频次（used_frqu） 
        /// </summary>
        public string rxFrquCodg { get; set; }

        /// <summary>
        /// 处方整剂频次名称   
        /// </summary>
        public string rxFrquName { get; set; }

        /// <summary>
        /// 处方整剂剂量单位   
        /// </summary>
        public string rxDosunt { get; set; }

        /// <summary>
        /// 处方整剂单次剂量数   
        /// </summary>
        public decimal rxDoscnt { get; set; }

        /// <summary>
        /// 处方整剂医嘱说明   
        /// </summary>
        public string rxDrordDscr { get; set; }

        /// <summary>
        /// 处方有效天数   
        /// </summary>
        public decimal valiDays { get; set; }

        /// <summary>
        /// 有效截止时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime valiEndTime { get; set; }

        /// <summary>
        /// 复用（多次）使用标志 0-否、1-是 
        /// </summary>
        public string reptFlag { get; set; }

        /// <summary>
        /// 最大复用次数   
        /// </summary>
        public decimal maxReptCnt { get; set; }

        /// <summary>
        /// 已复用次数   
        /// </summary>
        public decimal reptdCnt { get; set; }

        /// <summary>
        /// 使用最小间隔（天数）   
        /// </summary>
        public decimal minInrvDays { get; set; }

        /// <summary>
        /// 处方类别编号   
        /// </summary>
        public string rxTypeCode { get; set; }

        /// <summary>
        /// 处方类别名称   
        /// </summary>
        public string rxTypeName { get; set; }

        /// <summary>
        /// 长期处方标志  0 否、1-是 
        /// </summary>
        public string longRxFlag { get; set; }

        public List<rxDetlList> rxDetlList { get; set; }
        public rxOtpinfo rxOtpinfo { get; set; }
        public List<diseinfo> diseinfo { get; set; }
    }

    class rxDetlList
    {
        /// <summary>
        /// 医疗目录编码  即医保目录编码 
        /// </summary>
        public string medListCodg { get; set; }

        /// <summary>
        /// 定点医药机构目录编号  即院内药品编码 
        /// </summary>
        public string fixmedinsHilistId { get; set; }

        /// <summary>
        /// 院内制剂标志   
        /// </summary>
        public string hospPrepFlag { get; set; }

        /// <summary>
        /// 处方项目分类代码  
        /// </summary>
        public string rxItemTypeCode { get; set; }

        /// <summary>
        /// 处方项目分类名称   
        /// </summary>
        public string rxItemTypeName { get; set; }

        /// <summary>
        /// 中药类别名称   
        /// </summary>
        public string tcmdrugTypeName { get; set; }

        /// <summary>
        /// 中药类别代码   
        /// </summary>
        public string tcmdrugTypeCode { get; set; }

        /// <summary>
        /// 草药脚注   
        /// </summary>
        public string tcmherbFoote { get; set; }

        /// <summary>
        /// 药物类型代码   
        /// </summary>
        public string mednTypeCode { get; set; }

        /// <summary>
        /// 药物类型   
        /// </summary>
        public string mednTypeName { get; set; }

        /// <summary>
        /// 主要用药标志   
        /// </summary>
        public string mainMedcFlag { get; set; }

        /// <summary>
        /// 加急标志   
        /// </summary>
        public string urgtFlag { get; set; }

        /// <summary>
        /// 基本药物标志   
        /// </summary>
        public string basMednFlag { get; set; }

        /// <summary>
        /// 是否进口药品  0-否、1-是 
        /// </summary>
        public string impDrugFlag { get; set; }

        /// <summary>
        /// 药品商品名   
        /// </summary>
        public string drugProdname { get; set; }

        /// <summary>
        /// 通用名编码   
        /// </summary>
        public string gennameCodg { get; set; }

        /// <summary>
        /// 药品通用名   
        /// </summary>
        public string drugGenname { get; set; }

        /// <summary>
        /// 药品剂型   
        /// </summary>
        public string drugDosform { get; set; }

        /// <summary>
        /// 药品规格   
        /// </summary>
        public string drugSpec { get; set; }

        /// <summary>
        /// 生厂厂家   
        /// </summary>
        public string prdrName { get; set; }

        /// <summary>
        /// 药品单价   
        /// </summary>
        public decimal drugPric { get; set; }

        /// <summary>
        /// 药品总金额   
        /// </summary>
        public decimal drugSumamt { get; set; }

        /// <summary>
        /// 用药途径代码   
        /// </summary>
        public string medcWayCodg { get; set; }

        /// <summary>
        /// 用药途径描述   
        /// </summary>
        public string medcWayDscr { get; set; }

        /// <summary>
        /// 用药开始时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime medcBegntime { get; set; }

        /// <summary>
        /// 用药结束时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime medcEndtime { get; set; }

        /// <summary>
        /// 用药天数   
        /// </summary>
        public decimal medcDays { get; set; }

        /// <summary>
        /// 药品发药数量   
        /// </summary>
        public decimal drugCnt { get; set; }

        /// <summary>
        /// 药品发药单位   
        /// </summary>
        public string drugDosunt { get; set; }

        /// <summary>
        /// 单次用量   
        /// </summary>
        public decimal sinDoscnt { get; set; }

        /// <summary>
        /// 单次剂量单位   
        /// </summary>
        public string sinDosunt { get; set; }

        /// <summary>
        /// 使用频次编码   
        /// </summary>
        public string usedFrquCodg { get; set; }

        /// <summary>
        /// 使用频次名称   
        /// </summary>
        public string usedFrquName { get; set; }

        /// <summary>
        /// 用药总量   
        /// </summary>
        public string drugTotlcnt { get; set; }

        /// <summary>
        /// 用药总量单位   
        /// </summary>
        public string drugTotlcntEmp { get; set; }

        /// <summary>
        /// 医院审批标志   
        /// </summary>
        public string hospApprFlag { get; set; }

    }

    class rxOtpinfo
    {
        /// <summary>
        /// 医疗类别  参考医疗类别（med_type） 
        /// </summary>
        public string medType { get; set; }

        /// <summary>
        /// 住院/门诊号   
        /// </summary>
        public string iptOpNo { get; set; }

        /// <summary>
        /// 门诊住院标志  1-门诊，2-住院 
        /// </summary>
        public string otpIptFlag { get; set; }

        /// <summary>
        /// 患者姓名   
        /// </summary>
        public string patnName { get; set; }

        /// <summary>
        /// 年龄   
        /// </summary>
        public decimal patnAge { get; set; }

        /// <summary>
        /// 患者身高   
        /// </summary>
        public decimal patnHgt { get; set; }

        /// <summary>
        /// 患者体重   
        /// </summary>
        public decimal patnWt { get; set; }

        /// <summary>
        /// 性别   
        /// </summary>
        public string gend { get; set; }

        /// <summary>
        /// 妊娠(孕周)   
        /// </summary>
        public decimal gesoVal { get; set; }

        /// <summary>
        /// 新生儿标志  0-否、1-是
        /// </summary>
        public string nwbFlag { get; set; }

        /// <summary>
        /// 新生儿日、月龄  
        /// </summary>
        public string nwbAge { get; set; }

        /// <summary>
        /// 哺乳期标志  0-否、1-是 
        /// </summary>
        public decimal suckPrdFag { get; set; }

        /// <summary>
        /// 过敏史   
        /// </summary>
        public string algsHis { get; set; }

        /// <summary>
        /// 险种类型   
        /// </summary>
        public string insutype { get; set; }

        /// <summary>
        /// 开方科室名称   
        /// </summary>
        public string prscDeptName { get; set; }

        /// <summary>
        /// 开方医师姓名   
        /// </summary>
        public string prscDrName { get; set; }

        /// <summary>
        /// 药师姓名   
        /// </summary>
        public string pharName { get; set; }

        /// <summary>
        /// 医疗机构药师审方时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime pharChkTime { get; set; }

        /// <summary>
        /// 就诊时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime mdtrtTime { get; set; }

        /// <summary>
        /// 病种编码  按照标准编码填写： 按病种结算病种目录代码(bydise_setl_lis t_code)、 门诊慢特病病种目录代码(opsp_dise_cod) 
        /// </summary>
        public string diseCodg { get; set; }

        /// <summary>
        /// 病种名称   
        /// </summary>
        public string diseName { get; set; }

        /// <summary>
        /// 是否特殊病种   
        /// </summary>
        public string spDiseFlag { get; set; }

        /// <summary>
        /// 主诊断代码   
        /// </summary>
        public string maindiagCode { get; set; }

        /// <summary>
        /// 主诊断名称   
        /// </summary>
        public string maindiagName { get; set; }

        /// <summary>
        /// 疾病病情描述   
        /// </summary>
        public string diseCondDscr { get; set; }

        /// <summary>
        /// 是否初诊  0-否、1-是 
        /// </summary>
        public string fstdiagFlag { get; set; }

    }

    class diseinfo
    {
        /// <summary>
        /// 诊断类别   
        /// </summary>
        public string diagType { get; set; }

        /// <summary>
        /// 主诊断标志   
        /// </summary>
        public string maindiagFlag { get; set; }

        /// <summary>
        /// 诊断排序号   
        /// </summary>
        public decimal diagSrtNo { get; set; }

        /// <summary>
        /// 诊断代码   
        /// </summary>
        public string diagCode { get; set; }

        /// <summary>
        /// 诊断名称   
        /// </summary>
        public string diagName { get; set; }

        /// <summary>
        /// 诊断科室   
        /// </summary>
        public string diagDept { get; set; }

        /// <summary>
        /// 诊断医生编码   
        /// </summary>
        public string diagDrNo { get; set; }

        /// <summary>
        /// 诊断医生姓名   
        /// </summary>
        public string diagDrName { get; set; }

        /// <summary>
        /// 诊断时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime diagTime { get; set; }

        /// <summary>
        /// 中医病名代码   
        /// </summary>
        public string tcmDiseCode { get; set; }

        /// <summary>
        /// 中医病名   
        /// </summary>
        public string tcmDiseName { get; set; }

        /// <summary>
        /// 中医症候代码   
        /// </summary>
        public string tcmsympCode { get; set; }

        /// <summary>
        /// 中医症候   
        /// </summary>
        public string tcmsymp { get; set; }

    }
}
