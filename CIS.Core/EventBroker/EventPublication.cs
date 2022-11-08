using System;
using System.Reflection;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 发布者
    /// </summary>
    internal class EventPublication
    {
        /// <summary>
        /// 弱引用对象包装器
        /// </summary>
        private readonly WeakReference wrapper;

        /// <summary>
        /// 事件名称
        /// </summary>
        private readonly string eventName;

        /// <summary>
        /// 事件处理委托类型
        /// </summary>
        private readonly Type eventHandleType;

        /// <summary>
        /// 对象名称，用于显示
        /// </summary>
        private readonly string targetName;

        /// <summary>
        /// 事件定义，用来桥接对象的Event
        /// </summary>
        public event TopicEventHandler EventFired;

        public EventPublication(object target, string eventName)
        {
            wrapper = new WeakReference(target);
            this.eventName = eventName;
            this.targetName = target.GetType().Name;

            EventInfo info = target.GetType().GetEvent(EventName);
            eventHandleType = info.EventHandlerType;

            Delegate handler = Delegate.CreateDelegate(
               EventHandleType, this,
               this.GetType().GetMethod("OnEventFired"));
            info.AddEventHandler(target, handler);
        }

        /// <summary>
        /// 获取对象引用
        /// </summary>
        public object Target
        {
            get { return wrapper.Target; }
        }

        /// <summary>
        /// 对象名称，用于显示
        /// </summary>
        public string TargetName
        {
            get { return targetName; }
        }

        /// <summary>
        /// 判断对象是否存活
        /// </summary>
        public bool IsAlive
        {
            get { return wrapper.IsAlive; }
        }

        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName
        {
            get { return eventName; }
        }

        /// <summary>
        /// 事件处理类型
        /// </summary>
        public Type EventHandleType
        {
            get { return eventHandleType; }
        }

        public virtual void OnEventFired(object sender, EventArgs e)
        {
            var handle = EventFired;
            if (handle != null)
                handle(this, sender, e);
        }

        public override string ToString()
        {
            return string.Format("[{0} - {1}]", targetName, eventName);
        }
    }
}