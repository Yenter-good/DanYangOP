using System.Collections.Generic;

namespace CIS.Purview
{
    public class UserDal
    {
        /// <summary>
        /// 获取用户的权限集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<string> GetAuthorityCodes(string userId)
        {
            return  CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_User_AuthorityCode>()
                                 .Select(u => u.AuthorityCode)
                                 .Where(u => u.UserID == userId)
                                 .Union(
                    CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_Role_AuthorityCode>()
                                 .InnerJoin<CIS.Model.Sys_Role>(CIS.Model.Sys_Role_AuthorityCode._.RoleCode == CIS.Model.Sys_Role._.Code)
                                 .InnerJoin<CIS.Model.Sys_User_Role>(CIS.Model.Sys_Role._.Code == CIS.Model.Sys_User_Role._.RoleCode)
                                 .Select(CIS.Model.Sys_Role_AuthorityCode._.AuthorityCode)
                                 .Distinct()
                                 .Where(CIS.Model.Sys_User_Role._.UserID == userId)
                                  ).ToList<string>();

        }
        /// <summary>
        /// 获取指定用户的人员类型
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static CIS.Model.PersonType GetPersonType(string userId)
        {
            string pType =  CIS.Model.DBHelper.CIS.From<CIS.Model.IView_User>().Where(p => p.ID == userId).Select(p => p.Type).ToScalar<string>();
            return CIS.Model.IView_User.ToPersonType(pType);
        }
    }
}
