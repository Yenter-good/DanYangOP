using System;
using System.Collections.Generic;
using CIS.Model;

namespace CIS.Purview
{
    /// <summary>
    /// App访问类
    /// </summary>
    public class SysAppDal
    {
        /// <summary>
        /// 获取所有系统信息
        /// </summary>
        /// <returns></returns>
        public static List<Sys_App> GetAllApps()
        {
            return DBHelper.CIS.From<Sys_App>().OrderBy(a=>a.No).ToList();
        }
        /// <summary>
        /// 获取有效的系统信息
        /// </summary>
        /// <returns></returns>
        public static List<Sys_App> GetValidApps()
        {
            return DBHelper.CIS.From<Sys_App>().Where(a => a.Status == 1).OrderBy(a => a.No).ToList();
        }
        /// <summary>
        /// 判断指定系统是否包含菜单
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static bool HasMenus(string appCode)
        {
            return DBHelper.CIS.Exists<Sys_Menu>(m => m.AppCode == appCode);
        }
        /// <summary>
        /// 获取指定系统下的全部菜单列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static List<Sys_Menu> GetAllMenus(string appCode)
        {
            return DBHelper.CIS.From<Sys_Menu>().Where(m => m.AppCode == appCode).OrderBy(m => m.No).ToList();
 
        }
        /// <summary>
        /// 获取指定系统下有效的菜单列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static List<Sys_Menu> GetValidMenus(string appCode)
        {
            return CIS.Model.DBHelper.CIS.From<CIS.Model.Sys_Menu>()
                        .Where(m => m.Status == 1 && m.AppCode == appCode)
                        .OrderBy(m => m.No)
                        .ToList(); ;

        }
        /// <summary>
        /// 获取系统用于的科室列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static List<IView_Dept> GetDepts(string appCode)
        {
           return  DBHelper.CIS.From<Sys_App_Dept>()
                                .Select(IView_Dept._.All)
                                .InnerJoin<Sys_App>((a, b) => a.AppCode == b.Code)
                                .InnerJoin<IView_Dept>((a, b) => a.DeptCode == b.Code)
                                .Where(a => a.AppCode == appCode)
                                .ToList<IView_Dept>();
        }
        /// <summary>
        /// 保存科室列表
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="deptCodes"></param>
        /// <returns></returns>
        public static bool SaveDepts(string appCode, List<string> deptCodes)
        {
            List<Sys_App_Dept> models = new List<Sys_App_Dept>();
            foreach (var item in deptCodes)
            {
                models.Add(new Sys_App_Dept {  AppCode=appCode, DeptCode=item});
            }
            using (var tran = DBHelper.CIS.BeginTransaction())
            {
                try
                {
                    DBHelper.CIS.Delete<Sys_App_Dept>(s => s.AppCode == appCode);
                    if(models.Count>0)
                        DBHelper.CIS.Insert<Sys_App_Dept>(models);
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    Dos.Common.LogHelper.Error(ex.Message, "SQL");
                }
            } 
            
            return true;
        }

        /// <summary>
        /// 设置主页
        /// </summary>
        /// <param name="appCode"></param>
        /// <param name="dll"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static bool SetHomePage(string appCode, string dll, string className)
        {
            string homePage ="";
            if(!dll.IsNullOrEmpty() && !className.IsNullOrEmpty())
                homePage=string.Join("|",dll,className);
            return DBHelper.CIS.Update<Sys_App>(Sys_App._.HomePage, homePage, a => a.Code == appCode) > 0;
        }
        /// <summary>
        /// 获取主页设置 
        /// item1为dll item2为classname
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static Tuple<string,string> GetHomePage(string appCode)
        {
            string homepage = DBHelper.CIS.From<Sys_App>().Select(a => a.HomePage).Where(a=>a.Code==appCode).ToScalar().AsNotNullString();
            string[] s = homepage.Split('|');
            if (s != null && s.Length == 2)
            {
               return Tuple.Create<string, string>(s[0], s[1]);
            }
            return Tuple.Create<string, string>("","");
        }
    }
}
