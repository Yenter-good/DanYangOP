using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.PreAudit
{
    class UploadPreAuditRequest
    {
        /// <summary>
        /// 就诊凭证类型  01-电子凭证令牌、02-身份证号、03-社会保障卡号 
        /// </summary>
        public string mdtrtCertType { get; set; }

        /// <summary>
        /// 就诊凭证编号  就诊凭证类型为“01”时填写电子凭证令牌，为“02” 时填写身份证号，为“03” 时填写社会保障卡卡号（注：就诊凭证类型“03”时必填） 
        /// </summary>
        public string mdtrtCertNo { get; set; }

        /// <summary>
        /// 卡识别码  就诊凭证类型为“03”时必填 
        /// </summary>
        public string cardSn { get; set; }

        /// <summary>
        /// 电子凭证令牌  线下场景（医院就诊）使 用，就诊凭证类型：01  
        /// </summary>
        public string ecToken { get; set; }

        /// <summary>
        /// 电子凭证线上身份核验流水号  线上场景互联网医院问诊时使用，就诊凭证类型：02
        /// </summary>
        public string authNo { get; set; }

        /// <summary>
        /// 业务类型代码  01-定点医疗机构就诊，02-互联网医院问诊 
        /// </summary>
        public string bizTypeCode { get; set; }

        /// <summary>
        /// 参保地编号  异地参保人必传 
        /// </summary>
        public string insuPlcNo { get; set; }

        /// <summary>
        /// 定点医疗机构处方编号   
        /// </summary>
        public string hospRxno { get; set; }

        /// <summary>
        /// 续方的原处方编号  
        /// </summary>
        public string initRxno { get; set; }

        /// <summary>
        /// 处方类别代码  参考处方类别代码（rx_type_code） 
        /// </summary>
        public string rxTypeCode { get; set; }

        /// <summary>
        /// 开方时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime prscTime { get; set; }

        /// <summary>
        /// 药品类目数（剂数）  非中药时为处方药品类目数量，中药时为药品总剂数 
        /// </summary>
        public decimal rxDrugCnt { get; set; }

        /// <summary>
        /// 处方整剂用法编号  （注：中药汤剂处方使用字段），参考药物使用-途径代码    (drug_medc_way_code) 
        /// </summary>
        public string rxUsedWayCodg { get; set; }

        /// <summary>
        /// 处方整剂用法名称  （注：中药汤剂处方使用字段） 
        /// </summary>
        public string rxUsedWayName { get; set; }

        /// <summary>
        /// 处方整剂频次编号  （注：中药汤剂处方使用字段），参考使用频次（used_frqu） 
        /// </summary>
        public string rxFrquCodg { get; set; }

        /// <summary>
        /// 处方整剂频次名称  （注：中药汤剂处方使用字段）， 
        /// </summary>
        public string rxFrquName { get; set; }

        /// <summary>
        /// 处方整剂剂量单位  （注：中药汤剂处方使用字段）， 
        /// </summary>
        public string rxDosunt { get; set; }

        /// <summary>
        /// 处方整剂单次剂量数  （注：中药汤剂处方使用字段），
        /// </summary>
        public decimal rxDoscnt { get; set; }

        /// <summary>
        /// 处方整剂医嘱说明  （注：中药汤剂处方使用字段） 
        /// </summary>
        public string rxDrordDscr { get; set; }

        /// <summary>
        /// 处方有效天数   
        /// </summary>
        public decimal valiDays { get; set; }

        /// <summary>
        /// 有效截止时间  开方时间+处方有效天数=有效截止时间 
        /// </summary>
        public DateTime valiEndTime { get; set; }

        /// <summary>
        /// 复用（多次）使用标志  0-否、1-是 
        /// </summary>
        public string reptFlag { get; set; }

        /// <summary>
        /// 最大使用次数   
        /// </summary>
        public decimal maxReptCnt { get; set; }

        /// <summary>
        /// 已使用次数   
        /// </summary>
        public decimal reptdCnt { get; set; }

        /// <summary>
        /// 使用最小间隔（天数）   
        /// </summary>
        public decimal minInrvDays { get; set; }

        /// <summary>
        /// 续方标志  0 否、1-是 默认否 
        /// </summary>
        public string rxCotnFlag { get; set; }

        /// <summary>
        /// 长期处方标志  0-否、1-是，默认为否 
        /// </summary>
        public string longRxFlag { get; set; }

        /// <summary>
        /// 处方明细信息
        /// </summary>
        public List<rxdrugdetail> rxdrugdetail { get; set; }

        /// <summary>
        /// 就诊信息
        /// </summary>
        public mdtrtinfo mdtrtinfo { get; set; }

        /// <summary>
        /// 诊断信息
        /// </summary>
        public List<diseinfo> diseinfo { get; set; }

    }

    /// <summary>
    /// 处方明细信息
    /// </summary>
    public class rxdrugdetail
    {
        /// <summary>
        /// 医疗目录编码  即医保药品编码 
        /// </summary>
        public string medListCodg { get; set; }

        /// <summary>
        /// 定点医药机构目录编号  即院内药品编码 
        /// </summary>
        public string fixmedinsHilistId { get; set; }

        /// <summary>
        /// 医疗机构制剂标志  0-否、1-是，默认否 
        /// </summary>
        public string hospPrepFlag { get; set; }

        /// <summary>
        /// 处方项目分类代码  参考处方项目分类代码（rx_item_type_code） 
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
        /// 中药类别代码  参考处方项目分类代码（tcmdrug_type_name），中药处方必填 
        /// </summary>
        public string tcmdrugTypeCode { get; set; }

        /// <summary>
        /// 草药脚注   
        /// </summary>
        public string tcmherbFoote { get; set; }

        /// <summary>
        /// 药物类型代码  参考药物类型代码（medn_type_co de），（注：可按院内内部的药品类型分类）
        /// </summary>
        public string mednTypeCode { get; set; }

        /// <summary>
        /// 药物类型   
        /// </summary>
        public string mednTypeName { get; set; }

        /// <summary>
        /// 主要用药标志  0-否、1-是 
        /// </summary>
        public string mainMedcFlag { get; set; }

        /// <summary>
        /// 加急标志  0-否、1-是 
        /// </summary>
        public string urgtFlag { get; set; }

        /// <summary>
        /// 基本药物标志  0-否、1-是 
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
        /// 用药途径代码  参考药物使用- 途径代码(drug_medc_way_code) （注： 可使用院内内部代码） 
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
        /// 药品单价  按发药单位计价 
        /// </summary>
        public decimal drugPric { get; set; }

        /// <summary>
        /// 药品总金额  药品发药数量×药品单价 
        /// </summary>
        public decimal drugSumamt { get; set; }

        /// <summary>
        /// 药品发药数量  按院内“发药单位转换系数“换算 
        /// </summary>
        public decimal drugCnt { get; set; }

        /// <summary>
        /// 药品发药单位 （即发药单位， 如“片“或”盒“）  处方流转和取药时的药品医保结算单位；处方项目分类代码（rx_item_type_code）值为11、12 时必填（注：拆零时发药单位可为如 “片”，不拆零时发药单位等于库存包装单位，如“盒“，可统一使用国家医保药品目录的“最小制剂单位”或“最小包装单位”）
        /// </summary>
        public string drugDosunt { get; set; }

        /// <summary>
        /// 单次用量  处方项目分类代码（rx_item_type_code）值为11、12 时必填 
        /// </summary>
        public decimal sinDoscnt { get; set; }

        /// <summary>
        /// 单次剂量单位 （即开方单位或剂量单位，如“mg“）  处方项目分类代码（rx_item_type_code）值为11、12 时必填 
        /// </summary>
        public string sinDosunt { get; set; }

        /// <summary>
        /// 使用频次编码  参考使用频次（used_frqu） 处方项目分类代码（rx_item_type_code）值为11、12 时必填（注：可使用院内内部代码） 
        /// </summary>
        public string usedFrquCodg { get; set; }

        /// <summary>
        /// 使用频次名称  处方项目分类代码（rx_item_type_code）值为11、12 时必填 
        /// </summary>
        public string usedFrquName { get; set; }

        /// <summary>
        /// 用药总量  处方项目分类代码（rx_item_type_code）值为11、12 时必填；（注：按院内“库存（包装） 单位转换系数“换算数量） 
        /// </summary>
        public decimal drugTotlcnt { get; set; }

        /// <summary>
        /// 用药总量单位 （即库存包装单位，如“盒”）  处方项目分类代码（rx_item_type_code）值为11、12 时必填，（注：可统一使用国家医保药品目录的“最小包装单位”）
        /// </summary>
        public string drugTotlcntEmp { get; set; }

        /// <summary>
        /// 医院审批标志  参照字典：（hosp_appr_fl ag） 医院审批标志， 配合目录的限制使用标志使用： a). 当目录限制使用标志为“是”时:  1) 医院审批标志为“0”或“2”时，明细 按照自费处理； 2)   医院审批标志为“1”时，明细按纳入报销处理。  b). 当目录限制使用标志为“否”时:  1) 医院审批标志为“0”或“1”时，明细按照实际情况处理； 2) 医院审批标志为“2”时，明细按照自费处理。 
        /// </summary>
        public string hospApprFlag { get; set; }

    }

    /// <summary>
    /// 就诊信息
    /// </summary>
    public class mdtrtinfo
    {
        /// <summary>
        /// 定点医疗机构名称   
        /// </summary>
        public string fixmedinsName { get; set; }

        /// <summary>
        /// 定点医疗机构编号  
        /// </summary>
        public string fixmedinsCode { get; set; }

        /// <summary>
        /// 医保就诊 ID  参保病人信息字段（注：医保门诊挂号时返回） 
        /// </summary>
        public string mdtrtId { get; set; }

        /// <summary>
        /// 医疗类别  参考医疗类别（med_type） 
        /// </summary>
        public string medType { get; set; }

        /// <summary>
        /// 住院/门诊号   
        /// </summary>
        public string iptOtpNo { get; set; }

        /// <summary>
        /// 门诊住院标识  1-门诊、2-住院，值为空时默认为 1 门诊。 
        /// </summary>
        public string otpIptFlag { get; set; }

        /// <summary>
        /// 医保人员编号   
        /// </summary>
        public string psnNo { get; set; }

        /// <summary>
        /// 患者姓名   
        /// </summary>
        public string patnName { get; set; }

        /// <summary>
        /// 人员证件类型  参照人员证件类型 (psn_cert_type) 
        /// </summary>
        public string psnCertType { get; set; }

        /// <summary>
        /// 证件号码   
        /// </summary>
        public string certno { get; set; }

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
        /// 性别  参考性别（gend） 
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
        public decimal suckPrdFlag { get; set; }

        /// <summary>
        /// 过敏史   
        /// </summary>
        public string algsHis { get; set; }

        /// <summary>
        /// 开方科室名称   
        /// </summary>
        public string prscDeptName { get; set; }

        /// <summary>
        /// 开方科室编号   
        /// </summary>
        public string prscDeptCode { get; set; }

        /// <summary>
        /// 开方医保医师代码  国家医保医师代码 
        /// </summary>
        public string drCode { get; set; }

        /// <summary>
        /// 开方医师姓名   
        /// </summary>
        public string prscDrName { get; set; }

        /// <summary>
        /// 开方医师证件类型  参照人员证件类型 (psn_cert_type) 
        /// </summary>
        public string prscDrCertType { get; set; }

        /// <summary>
        /// 开方医师证件号码   
        /// </summary>
        public string prscDrCertno { get; set; }

        /// <summary>
        /// 医生职称编码  参照开单医生职称(drord_dr_proftt l) 
        /// </summary>
        public string drProfttlCodg { get; set; }

        /// <summary>
        /// 医生职称名称   
        /// </summary>
        public string drProfttlName { get; set; }

        /// <summary>
        /// 医生科室编码   
        /// </summary>
        public string drDeptCode { get; set; }

        /// <summary>
        /// 医生科室名称   
        /// </summary>
        public string drDeptName { get; set; }

        /// <summary>
        /// 就诊时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public DateTime mdtrtTime { get; set; }

        /// <summary>
        /// 病种编码  按照标准编码填写： 按病种结算病种目录代码(bydise_setl_lis t_code)、 门诊慢特病病种目录代码(opsp_dise_cod)；医疗类别（medType）为门诊慢特病时必传 
        /// </summary>
        public string diseCodg { get; set; }

        /// <summary>
        /// 病种名称   
        /// </summary>
        public string diseName { get; set; }

        /// <summary>
        /// 特殊病种标志  0-否、1-是 
        /// </summary>
        public string spDiseFlag { get; set; }

        /// <summary>
        /// 主诊断代码  使用国家医保诊断代码 
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
        /// 医保费用结算类型  参考医保费用结算类型（hi_feesetl_type） 
        /// </summary>
        public string hiFeesetlType { get; set; }

        /// <summary>
        /// 医保费用类别名称   
        /// </summary>
        public string hiFeesetlName { get; set; }

        /// <summary>
        /// 挂号费   
        /// </summary>
        public decimal rgstFee { get; set; }

        /// <summary>
        /// 医疗费总额  注：本次需要结算的医疗费用总额， 不包括处方药品费用 
        /// </summary>
        public decimal medfeeSumamt { get; set; }

        /// <summary>
        /// 是否初诊  0-否、1-是 
        /// </summary>
        public string fstdiagFlag { get; set; }

    }

    /// <summary>
    /// 诊断信息
    /// </summary>
    public class diseinfo
    {
        /// <summary>
        /// 诊断类别  参考诊断类别 （diag_type） 
        /// </summary>
        public string diagType { get; set; }

        /// <summary>
        /// 主诊断标志  0-否、1-是 
        /// </summary>
        public string maindiagFlag { get; set; }

        /// <summary>
        /// 诊断排序号   
        /// </summary>
        public int diagSrtNo { get; set; }

        /// <summary>
        /// 诊断代码  使用国家医保诊断代码 
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
        /// 诊断医生编码  国家医保医师代码 
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
