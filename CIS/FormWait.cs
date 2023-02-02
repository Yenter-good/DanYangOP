//				_ooOoo_                   
//			   o8888888o                  
//			  88\" . \"88                  
//			   (| -_- |)                  
//			   O\\  =  /O                  
//			____/`---'\\____               
//		  .'  \\|     |//  `.             
//		/  \\\\|||  :  |||//  \\            
//	    /  _||||| -:- |||||-  \\           
//	   |   | \\\\\\  -  /// |   |           
//	   | \\_|  ''\\---/''  |   |           
//	   \\  .-\\__  `-`  ___/-. /           
//	  ___`. .'  /--.--\\  `. . __          
//   .\"\" '<  `.___\\_<|>_/___.'  >'\"\".       
//| | :  `- \\`.;`\\ _ /`;.`/ - ` : | |     
//\\  \\ `-.   \\_ __\\ /__ _/   .-` /  /     
//======`-.____`-.___\\_____/___.-`____.-'======
//                   `=---='                   
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//佛祖保佑                永无BUG
//佛曰：
//写字楼里写字间，写字间里程序员；
//程序人员写程序，又拿程序换酒钱。
//酒醒只在网上坐，酒醉还来网下眠；
//酒醉酒醒日复日，网上网下年复年。
//但愿老死电脑间，不愿鞠躬老板前；
//奔驰宝马贵者趣，公交自行程序员。
//别人笑我减疯癫，我笑自己命太贱；
//不见满街漂亮妹，哪个归得程序员？


using CIS.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CIS
{


    public partial class FormWait : DevComponents.DotNetBar.Office2007RibbonForm
    {

        public FormWait()
        {
            InitializeComponent();
        }

        bool Flag = false;
        string SwitchReadyModule = System.Configuration.ConfigurationManager.AppSettings["ReadyModule"];
        string SwitchReadyQueueManagementSystem = System.Configuration.ConfigurationManager.AppSettings["ReadyQueueManagementSystem"];
        private void FormWait_Load(object sender, EventArgs e)
        {
            this.labelX1.Parent = this.pictureBox1;
        }

        private void FormWait_Shown(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Application.StartupPath + @"\Log"))
            {
                string oldPath = Application.StartupPath + @"\Log";
                Directory.Delete(oldPath, true);
            }
            if (System.IO.Directory.Exists(Application.StartupPath + @"\妇幼专科电子病历\mandalat_log"))
            {
                string oldPath = Application.StartupPath + @"\妇幼专科电子病历\mandalat_log";
                Directory.Delete(oldPath, true);
            }
            UpdateSystem();
            SetInfo();
            if (SwitchReadyQueueManagementSystem == "true")
                InitQueueManagementSystem();
            if (SwitchReadyModule == "true")
                ReadyModule();
            else
            {
                this.Close();
            }


        }

        private void InitQueueManagementSystem()
        {
            this.labelX1.Text += "正在初始化叫号系统" + Environment.NewLine;
            if (SysContext.HMSocket.CreateDataBase() == 0)
            {
                MessageBox.Show("叫号系统连接异常,请注意");
            }
        }

        private void UpdateSystem()
        {
            this.labelX1.Text += "正在启动更新程序" + Environment.NewLine;
            try
            {
                //Process proc = Process.Start(System.IO.Directory.GetParent(Application.StartupPath) + @"\客户端.exe", "门诊医生站" + "%" + Process.GetCurrentProcess().ProcessName);
                //while (!proc.HasExited)
                //{
                //    Application.DoEvents();
                //}
                string path = AppDomain.CurrentDomain.BaseDirectory + "MAutoUpdate.exe";
                //同时启动自动更新程序
                if (File.Exists(path))
                {
                    var processName = Process.GetCurrentProcess().ProcessName;
                    ProcessStartInfo processStartInfo = new ProcessStartInfo()
                    {
                        FileName = "MAutoUpdate.exe",
                        Arguments = $"{processName} 0"
                    };
                    Process proc = Process.Start(processStartInfo);
                    if (proc != null)
                    {
                        proc.WaitForExit();
                    }
                }
            }
            catch
            {
            }
        }

        private void ReadyModule()
        {
            int num = 0;
            string str = this.labelX1.Text;
            new System.Threading.Thread(() =>
            {
                int index = 0;
                while (!Flag)
                {
                    string tmp = str + "正在初始化系统模块".PadRight("正在初始化系统模块".Length + index++, '.');
                    if (index > 6)
                        index = 0;
                    BeginInvoke((MethodInvoker)delegate
                    {
                        this.labelX1.Text = tmp;
                    });
                    System.Threading.Thread.Sleep(500);
                }
            }).Start();

            var a = new Action(LoadData);
            a.BeginInvoke(ad, a);
        }

        private void SetInfo()
        {
            this.labelX1.Text += "正在获取必要信息" + Environment.NewLine;
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    CIS.Core.SysContext.ClientIP = ip.ToString();
            }
            string mac = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
            }
            catch
            {
                mac = "unknow";
            }
            CIS.Core.SysContext.ClientMAC = mac;
        }
        public void ad(IAsyncResult ar)
        {
            var action = ar.AsyncState as Action;
            action.EndInvoke(ar);
            this.Invoke((MethodInvoker)delegate
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            });
        }
        public void LoadData()
        {
            CIS.DCWriter.Common.WriterAppStartup.Start();
            Flag = true;
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

    }

}
