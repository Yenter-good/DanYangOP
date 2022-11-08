using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CIS.Model;
using CIS.Purview.ViewModel;
using System.Configuration;

namespace CIS.Core
{
    /// <summary>
    /// 系统运行时注册信息
    /// </summary>
    public static class SysContext
    {
        public static CurrUser CurrUser = new CurrUser();
        public static CurrRunSysInfo RunSysInfo = new CurrRunSysInfo();
        public static Dictionary<string, object> Session = new Dictionary<string, object>();
        public static List<Clinic> Clinic = new List<Clinic>();
        public static int IsFirstRecord = 0; //是否是初诊病历
        public static HMSocket.SocketClient HMSocket = new HMSocket.SocketClient();
        public static bool HasRemindChronic = false;   //已经提醒过复诊慢性病报卡

        public static bool IsWriteJournal { get; set; }

        public static Configuration Config { get; set; }
        /// <summary>
        /// 公共事件发布者
        /// </summary>
        public static CIS.Core.EventBroker.EventPublisher Publisher = new EventBroker.EventPublisher();

        /// <summary>
        /// 公共事件总线
        /// </summary>
        public static CIS.Core.EventBroker.EventBroker EventBroker = new CIS.Core.EventBroker.EventBroker();

        static SysContext()
        {
            EventBroker.Register(Publisher);
            Session.Add("LoginID", Guid.NewGuid().ToString());
        }

        /// <summary>
        /// 本机IP地址
        /// </summary>
        public static string ClientIP
        {
            get;
            set;
        }

        /// <summary>
        /// 本机MAC地址
        /// </summary>
        public static string ClientMAC
        { get; set; }
        public static IView_HIS_Outpatients GetCurrPatient
        {
            get
            {
                if (!CIS.Core.SysContext.Session.ContainsKey(CIS.Core.SysContext.Session_CurrPatient))
                    return null;
                return CIS.Core.SysContext.Session[CIS.Core.SysContext.Session_CurrPatient] as IView_HIS_Outpatients;
            }
            private set { }
        }

        public static UserPositionSetting UserPositionSetting
        {
            get
            {
                if (!Session.ContainsKey(Session_Position))
                    return null;
                return Session[Session_Position] as UserPositionSetting;
            }
            set
            {
                Session[Session_Position] = value;
            }
        }

        /// <summary>
        /// 当前病人
        /// </summary>
        public const string Session_CurrPatient = "CurrPatient";

        public const string Session_Position = "Position";

        /// <summary>
        /// 设置登录用户
        /// </summary>
        /// <param name="user"></param>
        public static void SetLoginUser(CurrUser user)
        {
            SysContext.CurrUser = user;
            SysContext.Clinic = DBHelper.CIS.FromSql("SELECT ZQBH AS ClinicCode,ZQMC AS ClinicName,KSBH AS DeptCode FROM ZD_KS_ZQ").ToList<Clinic>();
            UserPositionSetting = Purview.Purview.GetUserPositionSetting(user.user.Code);
            List<Sys_App> temApp = SysContext.CurrUser.appList.Where<Sys_App>(x => x.Code == SysContext.CurrUser.Params.Sys_DefaultAppCode).ToList();
            if (temApp.Count > 0)
            {
                Sys_App defaultApp = temApp[0];
                if (defaultApp != null)
                {
                    SwitchSystem(defaultApp.Code);
                }
            }      
        }

        /// <summary>
        /// 切换系统
        /// </summary>
        /// <param name="AppCode"></param>
        /// <returns>是否切换成功</returns>
        public static bool SwitchSystem(string AppCode)
        {
            if (SysContext.CurrUser.appList.Count == 0 || SysContext.CurrUser.menuList.Count == 0) return false;
            List<Sys_App> temp = SysContext.CurrUser.appList.Where(x => x.Code == AppCode).ToList<Sys_App>();
            if (temp.Count < 1) return false;
            //触发系统变更时事件
            string oldAppCode = null;
            if (SysContext.RunSysInfo.currApp != null)
                oldAppCode = SysContext.RunSysInfo.currApp.Code;
            var cancelEventArgs = new EventBroker.SystemCancelEventArgs(oldAppCode, AppCode);
            Publisher.RaiseSystemChanging(cancelEventArgs);
            if (cancelEventArgs.Cancel)
                return false;
            //变更当前系统及相关参数
            SysContext.RunSysInfo.currApp = temp[0];
            SysContext.RunSysInfo.user = SysContext.CurrUser.user;
            SysContext.RunSysInfo.currAppMenuList = SysContext.CurrUser.menuList.Where(x => x.AppCode == AppCode).ToList<Sys_Menu>();

            List<Sys_App_Dept> appDept = DBHelper.CIS.From<Sys_App_Dept>().Where(x => x.AppCode == AppCode).ToList();
            SysContext.RunSysInfo.appHasDeptList = SysContext.CurrUser.deptList.Where(x => appDept.Exists(p => p.DeptCode == x.Code)).ToList();
            if (SysContext.RunSysInfo.appHasDeptList.Count > 0)
                SysContext.RunSysInfo.currDept = SysContext.RunSysInfo.appHasDeptList[0];
            //触发系统变更后事件
            Publisher.RaiseSystemChanged();
            return true;
        }

        public static Form CreateForm(Sys_Menu menu)
        {
            string formType = menu.FName;
            string appType = menu.RNO;
            Form form = null;
            if (string.IsNullOrWhiteSpace(appType))
            {
                MessageBox.Show("该模块没有注册无法使用", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (string.IsNullOrWhiteSpace(formType))
            {
                MessageBox.Show("该功能未实现或没有注册", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                string path = appType;//项目的Assembly选项名称
                string name = formType; //类的名字
                form = (Form)Assembly.Load(path).CreateInstance(name);
                Assembly assembly = Assembly.Load(path);
                var configType = assembly.GetTypes().FirstOrDefault(t => t.GetInterface("IContext") != null);
                if (configType != null)
                {
                    Type type = form.GetType();
                    PropertyInfo propertyUser = type.GetProperty("Session");
                    Session session = new Session();
                    session.user = SysContext.CurrUser.user;
                    session.dept = SysContext.RunSysInfo.currDept;
                }
            }
            catch (Exception ex)
            {
                MsgBox.OK("该功能未实现或没有注册\n异常消息：" + ex.Message);
                return null;
            }
            EventBroker.Register(form);
            return form;
        }

        public static Form CreateForm(string NameSpace, string ClassName)
        {
            Form form = null;
            try
            {
                string path = NameSpace;//项目的Assembly选项名称
                string name = ClassName; //类的名字
                form = (Form)Assembly.Load(path).CreateInstance(name);
                Assembly assembly = Assembly.Load(path);
                var configType = assembly.GetTypes().FirstOrDefault(t => t.GetInterface("IContext") != null);
                if (configType != null)
                {
                    Type type = form.GetType();
                    PropertyInfo propertyUser = type.GetProperty("Session");
                    Session session = new Session();
                    session.user = SysContext.CurrUser.user;
                    session.dept = SysContext.RunSysInfo.currDept;
                }
            }
            catch (Exception ex)
            {
                MsgBox.OK("该功能未实现或没有注册\n异常消息：" + ex.Message);
                return null;
            }
            EventBroker.Register(form);
            return form;
        }

        public static List<OP_Job> GetJobList()
        {
            List<OP_Job> job = new List<OP_Job>();
            if (job.Count == 0)
                job = DBHelper.CIS.From<OP_Job>().OrderBy(p => p.No).ToList();

            return job;
        }
    }
}