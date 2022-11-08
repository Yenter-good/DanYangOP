using System.Collections.Generic;
using CIS.Model;

namespace CIS.Purview.ViewModel
{
    public class CurrUser
    {
        private UserParams _Params = new UserParams();
        private UserAuthoritis _Authority = new UserAuthoritis();

        public IView_User user = new IView_User();//用户的主体信息
        public List<Sys_App> appList = new List<Sys_App>();//用户所拥有的系统
        public List<Sys_Role> roleList = new List<Sys_Role>();//用户所拥有的角色
        public List<IView_Dept> deptList = new List<IView_Dept>();//用户所拥有的科室部门
        public List<Sys_Menu> menuList = new List<Sys_Menu>();//用户所拥有的菜单
        public List<Sys_App_Dept> app_DeptList = new List<Sys_App_Dept>();//系统对应可选科室
        /// <summary>
        /// 获取用户编号
        /// </summary>
        public string UserId { get { return user.ID; } }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        public string UserName { get { return user.Name; } }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        public string JobTitleCode { get { return user.JobTitleCode; } }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        public string JobTitleName { get { return user.JobTitleName; } }
        /// <summary>
        /// 获取用户参数
        /// </summary>
        public UserParams Params { get { _Params.Select(user.ID); return _Params; } }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        public UserAuthoritis Authoritis { get { _Authority.Select(user.ID); return _Authority; } }
    }
}
