using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CIS.ControlLib.Win32;

namespace App_OP
{
    public static class SEMRRecord
    {
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref CopyDataStruct lParam);
        [StructLayout(LayoutKind.Sequential)]
        public struct CopyDataStruct
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        private static void StartProcess(string doctorCode, string registerTime, string treatmentNo, string patientName, string patientBirthday)
        {
            if (File.Exists(Application.StartupPath + @"\妇幼专科电子病历\SEMRSystem.exe"))
            {
                Process a = new Process();
                a.StartInfo.FileName = Application.StartupPath + @"\妇幼专科电子病历\SEMRSystem.exe";
                a.StartInfo.Arguments = BuildArg(doctorCode, registerTime, treatmentNo, patientName, patientBirthday);
                a.Start();
            }
            else
            {
                MessageBox.Show("文件不存在,无法启动", "提示");
            }
        }

        private static string BuildArg(string doctorCode, string registerTime, string treatmentNo, string patientName, string patientBirthday)
        {
            string sendStr = $@"@nebula_genre_startup¤¤{doctorCode}¤登记日期≡{registerTime}§病历类型≡新建门诊病历§外部标识号≡{treatmentNo},{treatmentNo}§姓名≡{patientName}§出生年月≡{patientBirthday}§外部查询名≡挂号处查询§外部查询子句≡(就诊号=?and门诊号=?)¤1";
            Clipboard.SetText(sendStr);
            return sendStr;
        }

        public static void CallSEMRRecord(string doctorCode, string registerTime, string treatmentNo, string patientName, string patientBirthday)
        {
            if (!File.Exists(Application.StartupPath + @"\妇幼专科电子病历\SEMRSystem.exe"))
            {
                MessageBox.Show("妇幼专科电子病历程序不存在,无法启动", "提示");
                return;
            }
            if (!SendMessage(doctorCode, registerTime, treatmentNo, patientName, patientBirthday))
            {
                StartProcess(doctorCode, registerTime, treatmentNo, patientName, patientBirthday);
                SendMessage(doctorCode, registerTime, treatmentNo, patientName, patientBirthday);
            }
        }

        private static bool SendMessage(string doctorCode, string registerTime, string treatmentNo, string patientName, string patientBirthday)
        {
            string sendStr = BuildArg(doctorCode, registerTime, treatmentNo, patientName, patientBirthday); ;

            //生成WMI查询语句
            //可以根据启动参数中判断是否是当前工号登录的进程
            string wmiQuery = string.Format("select * from Win32_Process where Name='{0}' ", "SEMRSystem.exe");
            //发送消息并激活已运行进程
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
            {
                using (ManagementObjectCollection retObjectCollection = searcher.Get())
                {
                    foreach (ManagementObject obj in retObjectCollection)
                    {
                        Process existProcess = Process.GetProcessById(int.Parse(obj.Properties["ProcessId"].Value.ToString()));
                        if (existProcess != null && !existProcess.HasExited)
                        {
                            CopyDataStruct a = new CopyDataStruct()
                            {
                                cbData = sendStr.Length * 2 + 1, //lpData长度
                                lpData = sendStr,
                                dwData = new IntPtr(Convert.ToInt32(DateTime.Now.ToString("hhmmssffff")))
                            };
                            SendMessage(existProcess.MainWindowHandle, (int)WinMsg.WM_COPYDATA, Process.GetCurrentProcess().MainWindowHandle.ToInt32(), ref a);
                            ShowWindowAsync(existProcess.MainWindowHandle, 3);
                            UnsafeNativeMethods.SetForegroundWindow(existProcess.MainWindowHandle);

                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
