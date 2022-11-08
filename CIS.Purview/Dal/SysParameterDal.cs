using System;
using CIS.Model;
using Dos.ORM;

namespace CIS.Purview
{
    public class SysParameterDal
    {
        #region
        public static void Add(string code, string name, string descrption, string value)
        {
            CIS.Model.Sys_Parameter param = new Model.Sys_Parameter();
            param.ParameterCode = code;
            param.ParameterName = name;
            param.ParameterValue = value;
            param.RNO = "Global";
            param.SearchCode = name.GetSpell();
            param.Status = 1;
            CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_Parameter>(param);
        }
        /// <summary>
        /// 参数配置Delete
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static int Delete(string Code)
        {
            DbTrans trans = DBHelper.CIS.BeginTransaction();
            try
            {
                trans.Delete<Sys_Parameter>(Sys_Parameter._.ParameterCode == Code);

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                return 1;
            }
            finally
            {
                trans.Close();
            }
            return 0;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Get(string code)
        {
           return DBHelper.CIS.From<Sys_Parameter>()
                                .Select(s => s.ParameterValue)
                                .Where(s => s.ParameterCode == code)
                                .ToScalar<string>();
        }
        /// <summary>
        /// 更新参数值
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public static void Update(string code, string value)
        {
            DBHelper.CIS.Update<Sys_Parameter>(Sys_Parameter._.ParameterValue, value, Sys_Parameter._.ParameterCode == code);
        }
        /// <summary>
        /// 判断是否存在指定编码的参数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool Exists(string code)
        {
            return CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_Parameter>(s => s.ParameterCode == code);
        }

        #endregion
    }
}
