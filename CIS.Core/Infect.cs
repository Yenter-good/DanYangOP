using CIS.Core;
using CIS.Core.Interceptors;
using CIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace CIS.Core
{
    public static class Infect
    {
        [DllImport("HNIMIS_INFECT.dll", EntryPoint = "YgIndex")] //"TestDll.dll"为dll名称,EntryPoint 为函数名
        static extern int YgIndex(string blh, string zycs, string ysgh, string ysxm, string ksbh, string ksmc, string mzlx, string jbbm, string jbmc, string sfzh, string phone, int Zdjc, string Cardlx);

        [DllImport("HNIMIS_INFECT.dll", EntryPoint = "YgCheck")] //"TestDll.dll"为dll名称,EntryPoint 为函数名
        static extern string YgCheck(string blh, string zycs, string ysgh, string ysxm, string ksbh, string ksmc, string mzlx, string jbbm, string jbmc, int Zdjc, string Cardlx);

        #region 院感接口
        public static string YG_Check(string OutpatientNo, string UserCode, string UserName, string DeptCode, string DeptName, string ICD, string ICDName, string CardType)
        {
            return YgCheck(OutpatientNo, "0", UserCode, UserName, DeptCode, DeptName, "0", ICD, ICDName, 1, CardType);
        }

        public static void Yg_Index(string OutpatientNo, string UserCode, string UserName, string DeptCode, string DeptName, string ICD, string ICDName, string CardType)
        {

            List<OP_Journal> j = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == OutpatientNo).ToList();
            string id = "";
            string phone = "";

            if (j.Count > 0)
            {
                id = j[0].IDCard;
                phone = j[0].PhoneNumber;
            }
            var res = YgIndex(OutpatientNo, "0", UserCode, UserName, DeptCode, DeptName, "0", ICD, ICDName, id, phone, 1, CardType);
            Interceptors.Log4Helper.WriteLog(typeof(Infect), new CIS.Core.Interceptors.LogMessage("调用Yg_Index", $"{OutpatientNo}，{UserCode}，{UserName}，{DeptCode}，{DeptName}，{ICD}，{ICDName}，{CardType}，{id}，{phone}", $"{res}"), Log4NetLevel.Warn);
        }
        #endregion

        /// <summary>
        /// 检查传染病报卡
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ICD"></param>
        public static bool CheckInfection(string Name, string ICD)
        {
            if (SysContext.RunSysInfo.currDept.InfectUp.AsString("") == "1")
            {

                string sql = string.Format("Exec YG_Check '0','{0}',0,'0','{1}','{2}'", SysContext.GetCurrPatient.OutpatientNo, ICD, Name);
                string result = DBHelper.CIS.FromSql(sql).ToScalar<string>();
                Interceptors.Log4Helper.WriteLog(typeof(Infect), new CIS.Core.Interceptors.LogMessage("检查传染病报卡", sql, result), Log4NetLevel.Warn);
                if (result.Trim() == "1")
                {
                    Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "0");
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 检查慢阻报卡
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ICD"></param>
        public static bool CheckMZ(string Name, string ICD)
        {
            OP_Journal journal = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).First();
            if (journal != null && journal.FirstOrMany == "复诊")
                return false;
            //if (SysContext.RunSysInfo.currDept.InfectUp.AsString("") == "1")
            //{
            string sql = string.Format("Exec YG_Check '0','{0}',0,'16','{1}','{2}'", SysContext.GetCurrPatient.OutpatientNo, ICD, Name);
            string result = DBHelper.CIS.FromSql(sql).ToScalar<string>();
            Interceptors.Log4Helper.WriteLog(typeof(Infect), new CIS.Core.Interceptors.LogMessage("检查慢阻报卡", sql, result), Log4NetLevel.Warn);
            if (result.Trim() == "1")
            {
                Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "16");
                return true;
            }
            //}
            return false;
        }
        private static void ShowInfection()
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("未选择患者,无法查询传染病");
                return;
            }
            Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, "", "肺结核", "0");
        }

        private static void ShowChronic()
        {
            if (SysContext.GetCurrPatient == null)
            {
                AlertBox.Info("未选择患者,无法查询慢性病");
                return;
            }
            Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, "", "糖尿病", "15");
        }

        public static bool CheckChronic(string Name, string ICD, bool ImposesShow = false)
        {
            OP_Journal journal = DBHelper.CIS.From<OP_Journal>().Where(p => p.OutpatientNo == SysContext.GetCurrPatient.OutpatientNo).First();
            if (journal == null)
                return false;

            if (journal.FirstOrMany == "初诊")
                return CheckChronicFirstCome(Name, ICD);
            else
            {
                if (SysContext.CurrUser.Params.OP_SwitchChronicSecondCome == "是")
                    return CheckChronicSecondCome(Name, ICD, ImposesShow);
            }
            return false;
        }

        public static bool CheckChronic(string Name)
        {
            List<string> chronicName = new List<string>() { "冠心病", "脑卒中", "肿瘤" };
            List<string> columnName = new List<string>() { "GXB", "GZZ", "ZL" };
            int index = chronicName.FindIndex(p => Name.Contains(p));
            if (index == -1)
                return false;

            DataTable dt = DBHelper.CIS.FromSql(string.Format("SELECT * FROM ZD_MBZL WHERE SFZH='{0}'", SysContext.GetCurrPatient.IDCard)).ToDataTable();

            if (dt.Rows.Count == 0)
                return false;

            string value = dt.Rows[0][columnName[index]].AsString("");
            if (value == "")
                return true;

            return false;
        }

        /// <summary>
        /// 病人复诊慢性病
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ICD"></param>
        public static bool CheckChronicSecondCome(string Name, string ICD, bool ImposesShow = false)
        {
            if (SysContext.RunSysInfo.currDept.Chronic.AsString("") == "1")
            {
                if (SysContext.HasRemindChronic && !ImposesShow)
                    return false;

                bool chronic = CheckChronic(Name);
                if (chronic)
                {
                    System.Windows.Forms.MessageBox.Show("该病人可能需要上报慢病");
                    SysContext.HasRemindChronic = true;
                    return false;
                }

                //List<string> chronicName = new List<string>() { "高血压", "冠心病", "脑卒中", "糖尿病", "肿瘤" };
                //List<string> columnName = new List<string>() { "GXY", "GXB", "GZZ", "TNB", "ZL" };
                //int index = chronicName.FindIndex(p => Name.Contains(p));
                //if (index == -1)
                //    return false;

                //DataTable dt = DBHelper.CIS.FromSql(string.Format("SELECT * FROM ZD_MBZL WHERE SFZH='{0}'", SysContext.GetCurrPatient.IDCard)).ToDataTable();
                ////if (dt.Rows.Count >= 1)
                ////{
                ////    AlertBox.Error("当前病人有慢性病没有填报报卡,请注意");
                ////    SysContext.HasRemindChronic = true;
                ////}
                //if (dt.Rows.Count == 0)
                //{
                //    System.Windows.Forms.MessageBox.Show("当前病人有慢性病没有填报报卡,请注意");
                //    SysContext.HasRemindChronic = true;
                //    return false;
                //}

                //string value = dt.Rows[0][columnName[index]].AsString("");
                //if (value == "")
                //{
                //    System.Windows.Forms.MessageBox.Show("当前病人有慢性病没有填报报卡,请注意");
                //    SysContext.HasRemindChronic = true;
                //}
            }
            return false;
        }

        /// <summary>
        /// 病人初诊慢性病
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ICD"></param>
        /// <returns></returns>
        public static bool CheckChronicFirstCome(string Name, string ICD)
        {
            //bool chronic = CheckChronic(Name);
            //if (chronic)
            //{
            //    Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "15");
            //    return true;
            //}

            string sql = string.Format("Exec YG_Check '0','{0}',0,'15','{1}','{2}'", SysContext.GetCurrPatient.OutpatientNo, ICD, Name);
            string result = DBHelper.CIS.FromSql(sql).ToScalar<string>();
            Interceptors.Log4Helper.WriteLog(typeof(Infect), new CIS.Core.Interceptors.LogMessage("检查病人初诊慢性病", sql, result), Log4NetLevel.Warn);
            if (result.Trim() == "1")
            {
                Yg_Index(SysContext.GetCurrPatient.OutpatientNo, SysContext.CurrUser.user.Code, SysContext.CurrUser.user.Name, SysContext.RunSysInfo.currDept.Code, SysContext.RunSysInfo.currDept.Name, ICD, Name, "15");
                return true;
            }
            return false;
        }

        public static void WriteErrorLog(string Log, string Type)
        {
            Sys_Exception_Log log = new Sys_Exception_Log();
            log.ID = Guid.NewGuid().ToString();
            log.ExceptionText = Log;
            log.UserID = SysContext.CurrUser.user.Code;
            log.UserName = SysContext.CurrUser.user.Name;
            log.DeptCode = SysContext.RunSysInfo.currDept.Code;
            log.DeptName = SysContext.RunSysInfo.currDept.Name;
            log.UpdateTime = DateTime.Now;
            log.Type = Type;
            DBHelper.CIS.Insert<Sys_Exception_Log>(log);
        }
    }
}
