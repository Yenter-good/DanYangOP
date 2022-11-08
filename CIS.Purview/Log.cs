using System;
using CIS.Model;

namespace CIS.Purview
{
    public class Log
    {
        public Log(string LoginID, IView_User User)
        {
            this.LoginID = LoginID;
            this.User = User;
        }

        public string LoginID
        { get; private set; }

        public IView_User User
        { get; private set; }

        public bool BuildOperationLog(string Method, string Desription, LogExt.Behaviour Behaviour)
        {
            Sys_OperationLog OperationLog = new Sys_OperationLog();
            OperationLog.Method = Method;
            OperationLog.Desription = Desription;
            OperationLog.Behaviour = Convert.ToInt32(Behaviour);
            OperationLog.ID = Guid.NewGuid().ToString();
            OperationLog.OperID = User.ID;
            OperationLog.OperTime = DBHelper.ServerTime;
            if (DBHelper.CIS.Insert<Sys_OperationLog>(OperationLog) > 0)
                return true;
            else
                return false;
        }

        public bool BuildLoginLog(string SystemID, LogExt.LoginType LoginType)
        {
            Sys_LoginLog LoginLog = new Sys_LoginLog();
            LoginLog.ID = this.LoginID;
            LoginLog.UserID = User.ID;
            LoginLog.SystemID = SystemID;
            LoginLog.IPAddress = Utility.Machine.GetMachineIP();
            if (LoginType == LogExt.LoginType.In)
            {
                LoginLog.InTime = DBHelper.ServerTime;
                if (DBHelper.CIS.Insert<Sys_LoginLog>(LoginLog) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                LoginLog.OutTime = DBHelper.ServerTime;
                if (DBHelper.CIS.Update<Sys_LoginLog>(LoginLog, p => p.ID == this.LoginID) > 0)
                    return true;
                else
                    return false;
            }
        }

    }
}
