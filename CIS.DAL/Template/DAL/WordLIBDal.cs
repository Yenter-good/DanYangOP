using System.Collections.Generic;
using CIS.Model;
using Dos.ORM;
using System.Linq;

namespace CIS.DAL.Template
{
    /// <summary>
    /// 辅助词库
    /// </summary>
    public class WordLIBDal
    {
        #region 查询方法

        /// <summary>
        /// 获取指定用户的词语库
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public static List<TP_WordLIB> GetPerson(string UserID)
        {
            return DBHelper.CIS.From<TP_WordLIB>().ToList();

        }
        /// <summary>
        /// 获取指定用户在相应科室下能看见的他人的词库
        /// </summary>
        /// <param name="DeptCode">科室编号</param>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public static Dictionary<IView_User, List<TP_WordLIB>> GetOther(string DeptCode, string UserID)
        {
            //获取用户类型
            PersonType personType = CIS.Purview.UserDal.GetPersonType(UserID);
            //获取科室下的同类型用户
            List<IView_User> _Others = DBHelper.CIS.From<IView_User>()
                .Where(p => p.Dept_Code == DeptCode && p.Status == 1 && p.ID != UserID && p.Type == ((int)personType).ToString())
                .Select(p => new { p.ID, p.Name }).ToList<IView_User>();
            if (_Others.Count == 0)
                return null;
            var _Words = DBHelper.CIS.From<TP_WordLIB>().Where(p => p.UserID.In(_Others.Select(o => o.ID).ToArray()) && (p.DTLimit == "*" || p.DTLimit.Contains(DeptCode)) && p.Status == 1).ToList();
            return _Words.GroupBy(w => w.UserID).ToDictionary(k => _Others.Find(o => o.ID == k.Key), v => v.ToList());
        }
        /// <summary>
        /// 根据科室编号获得科室词库
        /// </summary>
        /// <param name="DeptCode">科室编号</param>
        /// <returns></returns>
        public static List<TP_WordLIB> GetDept(string DeptCode)
        {
            return DBHelper.CIS.From<TP_WordLIB>().Where(p => p.DTLimit.Contains(DeptCode) && p.UserID == "*" && p.Status == 1).ToList();
        }
        /// <summary>
        /// 获取全院通用的词库
        /// </summary>
        /// <returns></returns>
        public static List<TP_WordLIB> GetAllDept()
        {
            return DBHelper.CIS.From<TP_WordLIB>().Where(p => p.DTLimit == "*" && p.UserID == "*" && p.Status == 1).ToList();
        }
        #endregion



    }
}
