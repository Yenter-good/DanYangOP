using PFU.AHProvincial;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using CIS.Model;
using CIS.Core;

namespace CIS
{
    internal static class Program
    {
        public readonly static string AppName = "丹阳中医院门诊医生站";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //var exeConfigMap = new System.Configuration.ExeConfigurationFileMap();
            //exeConfigMap.ExeConfigFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CIS.config");
            //SysContext.Config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(exeConfigMap, System.Configuration.ConfigurationUserLevel.None);
            //防止重复运行
            //if (AvertRepeatRun()) return;

            //定义系统配置文件路径
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CIS.config"));
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            using (FormWait waitForm = new FormWait())
            {
                waitForm.ShowDialog();
                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormMain());
                }
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            string str = GetExceptionMsg(e.ExceptionObject as Exception, "");
            MessageBox.Show(str);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, "");
            MessageBox.Show(str);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************" + Environment.NewLine);
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString() + Environment.NewLine);
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name + Environment.NewLine);
                sb.AppendLine("【异常信息】：" + ex.Message + Environment.NewLine);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace + Environment.NewLine);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr + Environment.NewLine);
            }
            sb.AppendLine("***************************************************************");

            Sys_Exception_Log log = new Sys_Exception_Log();
            log.ID = Guid.NewGuid().ToString();
            log.ExceptionText = sb.ToString();
            log.UserID = SysContext.CurrUser.user.Code;
            log.UserName = SysContext.CurrUser.user.Name;
            log.DeptCode = SysContext.RunSysInfo.currDept.Code;
            log.DeptName = SysContext.RunSysInfo.currDept.Name;
            log.UpdateTime = DateTime.Now;
            DBHelper.CIS.Insert<Sys_Exception_Log>(log);

            return sb.ToString();

        }

        static bool AvertRepeatRun()
        {
            int processCount = 0;
            Process[] pa = Process.GetProcesses();//获取当前进程数组。 
            string curProcessName = Process.GetCurrentProcess().ProcessName;
            foreach (Process PTest in pa)
            {
                if (PTest.ProcessName == curProcessName)
                {
                    processCount += 1;
                }
            }
            if (processCount > 1)
            {
                //已运行则 显示运行的窗体
                UnsafeNativeMethods.Singling(AppName);
                return true;

            }

            return false;
        }
    }
}