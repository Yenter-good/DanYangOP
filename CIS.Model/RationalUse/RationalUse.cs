using System.Xml.Serialization;

namespace CIS.Model.RationalUse
{
    [XmlRoot("base_xml")]
    public class RationalUse
    {
        public RationalUse()
        { }

        public string RootName { get; set; }

        /// <summary>
        /// HIS
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 医院编码
        /// </summary>
        public string hosp_code { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string dept_code { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string dept_name { get; set; }
        /// <summary>
        /// 医生信息
        /// </summary>
        public doct doct { get; set; }
    }

    public class doct
    {
        /// <summary>
        /// 医生代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 医生级别代码
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 医生级别名称
        /// </summary>
        public string type_name { get; set; }

    }
}
