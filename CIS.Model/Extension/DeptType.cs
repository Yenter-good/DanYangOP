namespace CIS.Model
{
    /// <summary>
    /// 科室分类
    /// </summary>
    public enum DeptType
    {
        /// <summary>
        /// 门诊
        /// </summary>
        Outpatient = 1
            ,
        /// <summary>
        /// 护理
        /// </summary>
        Nurse = 2
            ,
        /// <summary>
        /// 临床
        /// </summary>
        Clinic = 3
            ,
        /// <summary>
        /// 医技
        /// </summary>
        MedicalLaboratory=4
            ,
        /// <summary>
        /// 急诊
        /// </summary>
        Emergency = 5
            ,
        /// <summary>
        /// 留观病房
        /// </summary>
        ObservationWard = 6
            ,
        /// <summary>
        /// 库房
        /// </summary>
        StorageRoom = 7
            ,
        /// <summary>
        /// 后勤
        /// </summary>
        Logistics = 8
            , 
        /// <summary>
        /// 行政
        /// </summary>
        Administration = 9
    }
}
