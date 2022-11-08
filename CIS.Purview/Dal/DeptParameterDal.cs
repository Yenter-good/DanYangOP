using CIS.Model;

namespace CIS.Purview
{
    public class DeptParameterDal
    {
        #region
        /// <summary>
        /// 添加科室参数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="descrption"></param>
        /// <param name="value"></param>
        public static void dbDeptParamAdd(string deptId,string code, string name, string descrption, string value)
        {
            if (!CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_DeptParameter>(s => s.Code == code))
            {
                var category = new Model.Sys_DeptParameter();
                category.Code = code;
                category.Name = name;
                category.Description = descrption;
                CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_DeptParameter>(category);
            }
            var param = new Model.Sys_DeptParameter_Value();
            param.DeptID = deptId;
            param.ParameterCode = code;
            param.ParameterValue = value;
         
            CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_DeptParameter_Value>(param);
        }


        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Get(string deptId,string code)
        {
            return DBHelper.CIS.From<Sys_DeptParameter_Value>()
                                .Select(s => s.ParameterValue)
                                .Where(s => s.ParameterCode == code && s.DeptID == deptId)
                                .ToScalar<string>();
        }
        /// <summary>
        /// 判断是否存在指定编码的参数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool Exists(string deptId, string code)
        {
            return CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_DeptParameter_Value>(s => s.DeptID == deptId && s.ParameterCode == code);
        }

        #endregion
    }
}
