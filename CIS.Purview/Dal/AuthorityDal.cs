using System;

namespace CIS.Purview
{
    class AuthorityDal
    {
        /// <summary>
        /// 判断是否存在指定编码的权限
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool Exists(string code)
        {
            return CIS.Model.DBHelper.CIS.Exists<CIS.Model.Sys_AuthorityCode>(a => a.Code == code);
        }
        /// <summary>
        /// 添加权限字典项目
        /// </summary>
        /// <param name="code">权限编码</param>
        /// <param name="name">权限名称</param>
        /// <param name="category">权限分类</param>
        public static void Add(string code, string name, string category)
        {
            CIS.Model.Sys_AuthorityCode model = new Model.Sys_AuthorityCode();
            model.Code = code;
            model.Name = name;
            model.Category = category;
            model.SearchCode = name.GetSpell();
            CIS.Model.DBHelper.CIS.Insert<CIS.Model.Sys_AuthorityCode>(model);
        }
    }
}
