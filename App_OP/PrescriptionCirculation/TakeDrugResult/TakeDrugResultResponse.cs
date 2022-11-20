using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_OP.PrescriptionCirculation.TakeDrugResult
{
    class TakeDrugResultResponse
    {
        /// <summary>
        /// 医保处方编号   
        /// </summary>
        public string hiRxno { get; set; }

        /// <summary>
        /// 医保结算时间  yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public string setlTime { get; set; }

        public List<seltdelts> seltdelts { get; set; }
    }

    class seltdelts
    {
        /// <summary>
        /// 医药机构药品编号   
        /// </summary>
        public string medinsListCodg { get; set; }

        /// <summary>
        /// 通用名   
        /// </summary>
        public string drugGenname { get; set; }

        /// <summary>
        /// 药品商品名   
        /// </summary>
        public string drugProdname { get; set; }

        /// <summary>
        /// 药品剂型   
        /// </summary>
        public string drugDosform { get; set; }

        /// <summary>
        /// 药品规格   
        /// </summary>
        public decimal drugSpec { get; set; }

        /// <summary>
        /// 数量   
        /// </summary>
        public decimal cnt { get; set; }

        /// <summary>
        /// 批准文号   
        /// </summary>
        public string aprvno { get; set; }

        /// <summary>
        /// 批次号   
        /// </summary>
        public string bchno { get; set; }

        /// <summary>
        /// 生产批号   
        /// </summary>
        public string manuLotnum { get; set; }

        /// <summary>
        /// 生厂厂家   
        /// </summary>
        public string prdrName { get; set; }
    }
}
