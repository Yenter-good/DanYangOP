namespace CIS.Model
{
    partial class Sys_Dept
    {
        /// <summary>
        /// 获取科室分类
        /// </summary>
        public DeptType? DeptType
        {
            get
            {
                return (DeptType?)this.Type;
            }
        }
        /// <summary>
        /// 获取科室分类名称
        /// </summary>
        /// <returns></returns>
        public string GetDeptTypeName()
        {
            if (!this.DeptType.HasValue) return "";
            switch (this.DeptType.Value)
            {
                case CIS.Model.DeptType.Outpatient:
                    return "门诊";
                case CIS.Model.DeptType.Nurse:
                    return "护理";
                case CIS.Model.DeptType.Clinic:
                    return "临床";
                case CIS.Model.DeptType.MedicalLaboratory:
                    return "医技";
                case CIS.Model.DeptType.Emergency:
                    return "急诊";
                case CIS.Model.DeptType.ObservationWard:
                    return "留观病房";
                case CIS.Model.DeptType.StorageRoom:
                    return "库房";
                case CIS.Model.DeptType.Logistics:
                    return "后勤";
                case CIS.Model.DeptType.Administration:
                    return "行政";
                default:
                    return "";
            }
        }
    }
}
