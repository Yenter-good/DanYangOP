namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 切换系统取消事件参数
    /// </summary>
    public class SystemCancelEventArgs : CancelEventArgsExt
    {
        /// <summary>
        /// 历史系统编号
        /// </summary>
        public string OldAppCode { get; private set; }

        /// <summary>
        /// 新系统编号
        /// </summary>
        public string NewAppCode { get; private set; }

        public SystemCancelEventArgs(string oldAppCode, string newAppCode)
        {
            OldAppCode = oldAppCode;
            NewAppCode = newAppCode;
        }
    }
}