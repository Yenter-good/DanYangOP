using System;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 全局事件发布者
    /// </summary>
    public class EventPublisher
    {
        /// <summary>
        /// 刷新患者信息
        /// </summary>
        [EventPublication("RefreshPatient")]
        public event EventHandler<PatientEventArgs> RefreshPatient;

        /// <summary>
        /// 系统变更时发生事件
        /// </summary>
        [EventPublication("SystemChanging")]
        public event EventHandler<SystemCancelEventArgs> SystemChanging;

        /// <summary>
        /// 系统变更后发生事件
        /// </summary>
        [EventPublication("SystemChanged")]
        public event EventHandler SystemChanged;

        /// <summary>
        /// 科室变更时发生事件
        /// </summary>
        [EventPublication("DepartmentChanging")]
        public event EventHandler<DepartmentCancelEventArgs> DepartmentChanging;

        /// <summary>
        /// 科室变更后发生事件
        /// </summary>
        [EventPublication("DepartmentChanged")]
        public event EventHandler DepartmentChanged;

        /// <summary>
        /// 触发病人信息刷新事件
        /// </summary>
        /// <param name="e"></param>
        public void RaiseRefreshPatient(PatientEventArgs e)
        {
            if (RefreshPatient != null)
                RefreshPatient(null, e);
        }

        /// <summary>
        /// 触发切换系统时触发事件
        /// </summary>
        /// <param name="e"></param>
        public void RaiseSystemChanging(SystemCancelEventArgs e)
        {
            if (SystemChanging != null)
                SystemChanging(null, e);
        }

        /// <summary>
        /// 触发切换系统后事件
        /// </summary>
        /// <param name="e"></param>
        public void RaiseSystemChanged()
        {
            if (SystemChanged != null)
                SystemChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// 触发科室变更时触发事件
        /// </summary>
        /// <param name="e"></param>
        public void RaiseDepartmentChanging(DepartmentCancelEventArgs e)
        {
            if (DepartmentChanging != null)
                DepartmentChanging(null, e);
        }

        /// <summary>
        /// 触发科室变更后事件
        /// </summary>
        /// <param name="e"></param>
        public void RaiseDepartmentChanged()
        {
            if (DepartmentChanged != null)
                DepartmentChanged(null, EventArgs.Empty);
        }
    }
}