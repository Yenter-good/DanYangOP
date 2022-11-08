using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CIS.Interface
{
    public static class Interface
    {
        [DllImport("HNIMIS_INFECT.dll", EntryPoint = "YgIndex")] //"TestDll.dll"为dll名称,EntryPoint 为函数名
        static extern int YgIndex(string blh, string zycs, string ysgh, string ysxm, string ksbh, string ksmc, string mzlx, string jbbm, string jbmc, int Zdjc, string Cardlx);

        [DllImport("HNIMIS_INFECT.dll", EntryPoint = "YgCheck")] //"TestDll.dll"为dll名称,EntryPoint 为函数名
        static extern int YgCheck(string blh, string zycs, string ysgh, string ysxm, string ksbh, string ksmc, string mzlx, string jbbm, string jbmc, int Zdjc, string Cardlx);

        public static void YG_Check(string OutpatientNo, string UserCode, string UserName, string DeptCode, string DeptName, string ICD, string ICDName, string CardType)
        {
            YgCheck(OutpatientNo, "0", UserCode, UserName, DeptCode, DeptName, "0", ICD, ICDName, 1, CardType);
        }

        public static void Yg_Index(string OutpatientNo, string UserCode, string UserName, string DeptCode, string DeptName, string ICD, string ICDName, string CardType)
        {
            YgIndex(OutpatientNo, "0", UserCode, UserName, DeptCode, DeptName, "0", ICD, ICDName, 1, CardType);
        }
    }
}
