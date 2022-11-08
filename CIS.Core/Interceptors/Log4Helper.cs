using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Core.Interceptors
{
    public class Log4Helper
    {
        /// <summary>
        /// 调用Log4net写日志，日志等级为 ：信息（Info）
        /// </summary>
        /// <param name="logContent">日志内容</param>
        //public static void WriteLog(Type type, LogMessage logContent, Log4NetLevel log4Level)
        //{
        //    //log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", ConfigFileExtension = "config", Watch = true);

        //    WriteLog(type,logContent, Log4NetLevel.Info);
        //}
        /// <summary>
        /// 调用Log4net写日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="log4Level">记录日志等级，枚举</param>
        public static void WriteLog(Type type, LogMessage logContent, Log4NetLevel log4Level)
        {
            ILog log = LogManager.GetLogger("ReflectionLayout");
            logContent.logger = type.FullName.ToString();

            switch (log4Level)
            {
                case Log4NetLevel.Warn:
                    log.Warn(logContent);
                    break;
                case Log4NetLevel.Debug:
                    log.Debug(logContent);
                    break;
                case Log4NetLevel.Info:
                    log.Info(logContent);
                    break;
                case Log4NetLevel.Fatal:
                    log.Fatal(logContent);
                    break;
                case Log4NetLevel.Error:
                    log.Error(logContent);
                    break;
            }
        }

    }


    /// <summary>
    /// log4net 日志等级类型枚举
    /// </summary>
    public enum Log4NetLevel
    {
        [Description("警告信息")]
        Warn = 1,
        [Description("调试信息")]
        Debug = 2,
        [Description("一般信息")]
        Info = 3,
        [Description("严重错误")]
        Fatal = 4,
        [Description("错误日志")]
        Error = 5
    }
}
