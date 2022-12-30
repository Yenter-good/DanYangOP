using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.Inventory
{
    class InventoryRequest
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
        /// 开方医保医师代码 国家医保医师代码
        /// </summary>
        public string drCode { get; set; }

        /// <summary>
        /// 开方医师名称 
        /// </summary>
        public string prscDrName { get; set; }

        /// <summary>
        /// 审方医保药师代码 国家医保药师代码
        /// </summary>
        public string pharCode { get; set; }

        /// <summary>
        /// 审方药师姓名 
        /// </summary>
        public string pharName { get; set; }

        public List<DrugList> drugList { get; set; }
    }

    public class DrugList
    {
        /// <summary>
        /// 医疗目录编码  即医保药品编码 
        /// </summary>
        public string medListCodg { get; set; }

        /// <summary>
        /// 药品发药数量  按院内“发药单位转换系数“换算 
        /// </summary>
        public int? drugCnt { get; set; }

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

    }
}
