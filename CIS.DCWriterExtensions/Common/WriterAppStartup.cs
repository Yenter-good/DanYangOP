using DCSoft.Writer;
using System;
using System.Linq;
using System.ServiceProcess;

namespace CIS.DCWriter.Common
{
    public class WriterAppStartup
    {
        /// <summary>
        /// 只需调用一次
        /// </summary>
        public static void Start()
        {
            //注册编辑器激活码
            //WriterAppHost.Register("02324EA500000000000027000000E6B7B1E59CB3E4B99DE6988EE78FA0E4BFA1E681AFE7A791E68A80E69C89E99990E585ACE58FB88AAF15000000E4B99DE6988EE78FA0454D52E7BC96E8BE91E599A80400", false);
            //注册扩展命令
            WriterAppHost.Default.CommandContainer.Modules.AddModule(new CIS.DCWriter.Commands.WriterCommandModuleExtension());
            //预加载编辑器处理
            try
            {
                WriterAppHost.PreloadSystem();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("RPC"))
                {
                    //尝试启动RPC服务
                    try
                    {
                        var services = ServiceController.GetServices().ToList();
                        if (services.Exists(s => s.ServiceName.ToUpper() == "RPCSS"))
                        {
                            var rpcService = services.Find(s => s.ServiceName.ToUpper() == "RPCSS");
                            if (rpcService.Status == ServiceControllerStatus.Paused)
                                rpcService.Continue();
                            else
                                if (rpcService.Status == ServiceControllerStatus.Stopped)
                                    rpcService.Start();
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
