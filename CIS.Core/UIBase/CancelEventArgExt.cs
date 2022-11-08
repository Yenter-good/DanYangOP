using System.ComponentModel;

namespace CIS.Core
{
    /// <summary>
    /// 为可取消的事件提供数据
    /// </summary>
    public class CancelEventArgsExt:CancelEventArgs
    {
        /// <summary>
        /// 取消原因
        /// </summary>
        public string CancelReason { get; set; }
    }
}
