namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 科室变更取消事件参数
    /// </summary>
    public class DepartmentCancelEventArgs : CancelEventArgsExt
    {
        /// <summary>
        /// 历史科室编号
        /// </summary>
        public string OldDeptId { get; private set; }

        /// <summary>
        /// 新科室编号
        /// </summary>
        public string NewDeptId { get; private set; }

        public DepartmentCancelEventArgs(string oldDeptId, string newDeptId)
        {
            OldDeptId = oldDeptId;
            NewDeptId = newDeptId;
        }
    }
}