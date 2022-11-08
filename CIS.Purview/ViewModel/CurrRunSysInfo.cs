using System.Collections.Generic;
using CIS.Model;

namespace CIS.Purview.ViewModel
{
    public class CurrRunSysInfo
    {
        private SysParams _Params = new SysParams();
        public Sys_App currApp = new Sys_App();//当前运行的系统
        public IView_User user = new IView_User();//当前用户信息
        public IView_Dept currDept = new IView_Dept();//当前科室
        public Clinic clinic = new Clinic();//当前诊区
        public List<Sys_Menu> currAppMenuList = new List<Sys_Menu>();//运行系统的菜单
        public Sys_Menu mainPage = new Sys_Menu();//系统主页
        public List<IView_Dept> appHasDeptList = new List<IView_Dept>();//该系统可被用于的科室
        /// <summary>
        /// 获取运行系统的参数
        /// </summary>
        public SysParams Params { get { return _Params; } }
    }
}
