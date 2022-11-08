using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CIS.Core.Interceptors
{
    public class LogMessage
    {
        /// <summary>
        /// 三个参数(名称，入参，出参)
        /// </summary>
        public LogMessage(string ActionClick, string Parameters,string DataResult)
        {
            this.ActionClick = ActionClick;
            this.Parameters = Parameters;
            this.DataResult = DataResult;
            this.DoctorCode = CIS.Core.SysContext.CurrUser.UserId.ToString();
            this.IP = CIS.Core.SysContext.ClientIP.ToString();
        }

        //protected string GetIP() //获取本地IP
        //{
        //    IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
        //    IPAddress ipAddr = ipHost.AddressList[0];
        //    return ipAddr.ToString();
        //}
        /// <summary>
        /// 全部参数构造
        /// </summary>
        public LogMessage(string ActionClick, string Parameters, string DoctorCode, string IP, string DataResult)
        {
            this.ActionClick = ActionClick;
            this.Parameters = Parameters;
            this.DoctorCode = DoctorCode;
            this.IP = IP;
            this.DataResult = DataResult;
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string ActionClick
        {
            get;
            set;
        }

        /// <summary>
        /// 入参
        /// </summary>
        public string Parameters
        {
            get;
            set;
        }
        /// <summary>
        /// 类
        /// </summary>
        public string logger
        {
            get;
            set;
        }
        /// <summary>
        /// 医生工号
        /// </summary>
        public string DoctorCode
        {
            get;
            set;
        }

        /// <summary>
        /// 电脑IP
        /// </summary>
        public string IP
        {
            get;
            set;
        }

        /// <summary>
        /// 出参
        /// </summary>
        public string DataResult
        {
            get;
            set;
        }
    }
}
