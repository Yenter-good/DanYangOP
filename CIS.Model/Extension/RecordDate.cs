namespace CIS.Model
{
    public class RecordDate
    {
        /// <summary>
        /// 主诉
        /// </summary>
        public string ChiefComplaints
        {
            get;
            set;
        }
        /// <summary>
        /// 现病史
        /// </summary>
        public string PresentIllness
        {
            get;
            set;
        }
        /// <summary>
        /// 既往史
        /// </summary>
        public string Past
        {
            get;
            set;
        }
        /// <summary>
        /// 个人史
        /// </summary>
        public string Personal
        {
            get;
            set;
        }
        /// <summary>
        /// 婚育史
        /// </summary>
        public string Marrital
        {
            get;
            set;
        }
        /// <summary>
        /// 吸烟史
        /// </summary>
        public string Smoke
        {
            get;
            set;
        }
        /// <summary>
        /// 过敏史
        /// </summary>
        public string Allergen
        {
            get;
            set;
        }
        /// <summary>
        /// 家族史
        /// </summary>
        public string Family
        {
            get;
            set;
        }
        /// <summary>
        /// 体格检查
        /// </summary>
        public string PhysicalExamination
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string DealWith
        {
            get;
            set;
        }

        public string ExaminationResult
        {
            get;
            set;
        }

        /// <summary>
        /// 专科检查
        /// </summary>
        public string Speciality
        { get; set; }

        /// <summary>
        /// 药敏史
        /// </summary>
        public string DrugAllergy
        { get; set; }

        /// <summary>
        /// 中医辩证
        /// </summary>
        public string HerbDialectic
        { get; set; }
    }
}
