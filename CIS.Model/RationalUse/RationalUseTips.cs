using System.Xml.Serialization;

namespace CIS.Model.RationalUseTips
{
    [XmlRoot("details_xml")]
    public class RationalUseTips
    {
        /// <summary>
        /// 门诊住院标识
        /// </summary>
        public string hosp_flag { get; set; }

        public medicine medicine { get; set; }
    }

    public class medicine
    {
        /// <summary>
        /// 药品代码
        /// </summary>
        public string his_code { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string his_name { get; set; }
    }
}
