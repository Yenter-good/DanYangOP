using System;
using System.Collections.Generic;
using System.Data;
using CIS.Model;
using CIS.Purview.ViewModel;
using CIS.Utility;
using CIS.Model.RationalUse;
using System.Reflection;

namespace CIS.Purview
{
    public static class Purview
    {


        /// <summary>
        /// 用户所拥有的系统
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_App> GetAppList(string userID)
        {
            List<Sys_App> appList = DBHelper.CIS.FromSql(
            " SELECT * FROM SYS_APP  WHERE STATUS=1 AND CODE " +
            " IN( SELECT APPCODE FROM SYS_MENU WHERE STATUS=1 AND ID " +
            " IN( SELECT MENUID FROM SYS_ROLE_MENU WHERE ROLECODE " +
            " IN (SELECT ROLECODE FROM SYS_USER_ROLE WHERE USERID =@UID))) "
            ).AddInParameter("@UID", DbType.String, userID).ToList<Sys_App>();

            return appList;
        }
        /// <summary>
        /// 用户所拥有的角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_Role> GetRoleList(string userID)
        {
            List<Sys_Role> roleList = DBHelper.CIS.FromSql(" SELECT * FROM SYS_ROLE WHERE CODE IN " +
                " ( SELECT ROLECODE FROM SYS_USER_ROLE WHERE USERID=@UID)").AddInParameter("@UID", DbType.String, userID).ToList<Sys_Role>();

            return roleList;
        }
        /// <summary>
        /// 用户所拥有的科室部门
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<IView_Dept> GetDeptList(string userID)
        {
            List<IView_Dept> deptList = DBHelper.CIS.FromSql(" SELECT * FROM IVIEW_DEPT WHERE CODE IN " +
                "  ( SELECT DEPARTCODE FROM SYS_USER_DEPT WHERE USERID= @UID)").AddInParameter("@UID", DbType.String, userID).ToList<IView_Dept>();

            return deptList;
        }

        /// <summary>
        /// 用户所拥有的菜单
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_Menu> GetMenuList(string userID)
        {
            List<Sys_Menu> menuList = DBHelper.CIS.FromSql(" SELECT  * FROM SYS_MENU  WHERE STATUS=1 AND ID  IN (SELECT MENUID FROM SYS_ROLE_MENU WHERE ROLECODE IN " +
                " (SELECT ROLECODE FROM SYS_USER_ROLE WHERE USERID=@UID) ) Order by No ").AddInParameter("@UID", DbType.String, userID).ToList<Sys_Menu>();

            return menuList;
        }

        /// <summary>
        /// 用户权限参数列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_User_AuthorityCode> GetUserAuthorityList(string userID)
        {
            List<Sys_User_AuthorityCode> AuthorityList = DBHelper.CIS.FromSql(" SELECT * FROM SYS_USER_AUTHORITYCODE WHERE USERID=@UID ").AddInParameter("@UID", DbType.String, userID).ToList<Sys_User_AuthorityCode>();

            return AuthorityList;
        }
        /// <summary>
        /// 用户设置参数列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_UserParameter_Value> GetParamterList(string userID)
        {
            List<Sys_UserParameter_Value> paramterList = DBHelper.CIS.FromSql(" SELECT * FROM SYS_USERPARAMETER_VALUE WHERE USERID=@UID ").AddInParameter("@UID", DbType.String, userID).ToList<Sys_UserParameter_Value>();

            return paramterList;
        }
        /// <summary>
        /// 角色所拥有的权限参数列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_Role_AuthorityCode> GetRoleAuthorityList(string userID)
        {
            List<Sys_Role_AuthorityCode> paramterList = DBHelper.CIS.FromSql(" SELECT * FROM SYS_ROLE_AUTHORITYCODE WHERE ROLECODE IN " +
                " (SELECT ROLECODE FROM SYS_USER_ROLE WHERE USERID=@UID)").AddInParameter("@UID", DbType.String, userID).ToList<Sys_Role_AuthorityCode>();

            return paramterList;
        }

        /// <summary>
        /// 系统对应可选科室
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Sys_App_Dept> GetApp_DeptList(string userID)
        {
            List<Sys_App_Dept> app_DeptList = DBHelper.CIS.FromSql(" SELECT * FROM SYS_APP_DEPT ").ToList<Sys_App_Dept>();

            return app_DeptList;
        }

        public static UserPositionSetting GetUserPositionSetting(string userID)
        {
            UserPositionSetting tmp = new UserPositionSetting();
            string str = DBHelper.CIS.From<Sys_UserParameter_Value>().Where(p => p.ParameterCode == "U009" && p.UserID == userID).Select(p => p.ParameterValue).ToScalar<string>();
            if (str != null)
            {
                tmp = SerializeHelper.BeginJsonDeserialize<UserPositionSetting>(str);
                return tmp;
            }
            else
                return null;
        }

        public static List<Sys_Parameter> GetSysParameter(string userID)
        {
            List<Sys_Parameter> paramList = DBHelper.CIS.From<Sys_Parameter>().ToList();

            return paramList;
        }

        /// <summary>
        /// 通过用户代码获取当前登录用户的所有信息
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static CurrUser GetCurrUserForUserCode(string userCode)
        {
            CurrUser u = new CurrUser();
            u.user = DBHelper.CIS.From<IView_User>().Where(p => p.Code == userCode && p.Status == 1).ToFirst();
            u.roleList = GetRoleList(u.user.ID);
            u.appList = GetAppList(u.user.ID);
            u.deptList = GetDeptList(u.user.ID);
            u.menuList = GetMenuList(u.user.ID);
            u.app_DeptList = GetApp_DeptList(u.user.ID);

            return u;
        }

        public static List<IView_User> GetUserList()
        {
            List<IView_User> userList = DBHelper.CIS.FromSql(" SELECT * FROM IVIEW_USER").ToList<IView_User>();

            return userList;
        }

        /// <summary>
        /// 获取所有科室
        /// </summary>
        /// <returns></returns>
        public static List<IView_Dept> GetDeptList()
        {
            List<IView_Dept> deptList = DBHelper.CIS.FromSql(" SELECT * FROM IVIEW_DEPT").ToList<IView_Dept>();

            return deptList;
        }

        public static string GetRationalUsePublicArgs(IView_User Doctor, IView_Dept Dept, string HospitalCode)
        {
            RationalUse use = new RationalUse();
            doct doct = new doct();
            doct.name = Doctor.Name;
            doct.code = Doctor.Code;
            doct.type = Doctor.JobTitle.AsString(",").Split(',')[0];
            doct.type_name = Doctor.JobTitle.AsString(",").Split(',')[1];
            use.doct = doct;

            use.hosp_code = HospitalCode;
            use.dept_name = Dept.Name;
            use.dept_code = Dept.Code;

            return SerializeHelper.BeginXMLSerializable(use);
        }

        public static string GetRationalUseAnalysisArgs(List<OP_Prescription_Detail> detail, IView_HIS_Outpatients patient, IView_User Doctor, IView_Dept Dept)
        {
            RationalUseAnalysis tips = new RationalUseAnalysis();
            tips = SetDefultValue<RationalUseAnalysis>(tips);
            medicine_data data = new medicine_data();
            List<CIS.Model.RationalUse.medicine> p = new List<CIS.Model.RationalUse.medicine>();
            tips.his_time = DateTime.Now.ToString();
            tips.hosp_flag = "op";
            tips.treat_type = "100";
            tips.treat_code = patient.OutpatientNo;
            tips.patient.name = patient.PatientName;
            tips.patient.sex = patient.Sex;
            tips.patient.card_type = "9";
            tips.patient.card_code = patient.CardNo.AsString("") != "" ? patient.CardNo : patient.OutpatientNo;
            tips.patient.diagnose_data.diagnose.type = "2";
            tips.prescription_data.prescription.id = detail[0].PrescriptionNo;
            tips.prescription_data.prescription.is_current = "1";
            tips.prescription_data.prescription.pres_time = DateTime.Now.ToString();
            tips.prescription_data.prescription.doct_code = Doctor.Code;
            tips.prescription_data.prescription.dept_code = Dept.Code;
            tips.prescription_data.prescription.dept_name = Dept.Name;
            foreach (OP_Prescription_Detail item in detail)
            {
                CIS.Model.RationalUse.medicine medic = SetDefultValue<CIS.Model.RationalUse.medicine>(new CIS.Model.RationalUse.medicine());
                medic.name = item.ItemName;
                medic.his_code = item.ItemCode;
                medic.spec = item.Specification;
                medic.group = item.No.ToString();
                medic.dose_unit = item.DosageUnit;
                medic.freq = item.Frequency;
                medic.administer = item.Usage;
                medic.days = item.Days.ToString();
                p.Add(medic);
            }
            data.medicine = p;
            tips.prescription_data.prescription.medicine_data.medicine = p;
            return SerializeHelper.BeginXMLSerializable(tips);

        }

        private static T SetDefultValue<T>(T model) where T : class
        {
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (PropertyInfo item in info)
            {
                if (item.PropertyType != typeof(string))
                {
                    if (item.PropertyType.Namespace != "System.Collections.Generic")
                    {
                        Type t = item.PropertyType;
                        object obj = Assembly.Load(t.Namespace).CreateInstance(t.FullName);

                        item.SetValue(model, SetDefultValue<object>(obj), null);
                    }
                }
                else
                {
                    item.SetValue(model, "", null);
                }
            }
            return model;
        }
    }
}

