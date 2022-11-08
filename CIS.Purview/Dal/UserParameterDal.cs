using System.Collections.Generic;
using System.Linq;
using CIS.Model;

namespace CIS.Purview
{
    public class UserParameterDal
    {
        #region
        /// <summary>
        /// 添加用户参数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="descrption"></param>
        /// <param name="value"></param>
        public static void Add(string userId, string code, string name, string descrption, string value)
        {
            if (!CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_UserParameter>(s => s.Code == code))
            {
                var category = new Model.Sys_UserParameter();
                category.Code = code;
                category.Name = name;
                category.Description = descrption;

                CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_UserParameter>(category);
            }
            var param = new Model.Sys_UserParameter_Value();
            param.UserID = userId;
            param.ParameterCode = code;
            param.ParameterValue = value;
            CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_UserParameter_Value>(param);
        }


        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Get(string userId, string code)
        {
            return DBHelper.CIS.From<Sys_UserParameter_Value>()
                                 .Select(s => s.ParameterValue)
                                 .Where(s => s.ParameterCode == code && (s.UserID == userId || s.UserID == "All"))
                                 .ToScalar<string>();
        }
        /// <summary>
        /// 判断是否存在指定编码的参数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool Exists(string userId, string code)
        {
            return CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_UserParameter_Value>(s => (s.UserID == userId || s.UserID == "All") && s.ParameterCode == code);
        }
        /// <summary>
        /// 获取用户参数列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDict(string userId)
        {
            List<Sys_UserParameter_Value> list = CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_UserParameter_Value>()
                 .Select(s => new { s.ParameterCode, s.ParameterValue })
                 .Where(s => s.UserID == userId || s.UserID == "All")
                 .ToList();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (Sys_UserParameter_Value item in list)
            {
                if (!dict.Keys.Contains(item.ParameterCode))
                    dict.Add(item.ParameterCode, item.ParameterValue);
            }
            return dict;
        }

        #endregion
    }
}
