using System;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 订阅者
    /// </summary>
    public class EventSubscription
    {
        /// <summary>
        /// 弱引用对象包装器
        /// </summary>
        private readonly WeakReference wrapper;

        /// <summary>
        /// 方法名
        /// </summary>
        private readonly string methodName;

        /// <summary>
        /// 对象名称，仅作显示
        /// </summary>
        private readonly string targetName;

        public EventSubscription(object target, string methodName)
        {
            this.wrapper = new WeakReference(target);
            this.methodName = methodName;
            targetName = target.GetType().Name;
        }

        /// <summary>
        /// 对象是否存活
        /// </summary>
        public bool IsAlive
        {
            get { return wrapper.IsAlive; }
        }

        /// <summary>
        /// 订阅者对象方法名
        /// </summary>
        public string MethodName { get { return methodName; } }

        /// <summary>
        /// 订阅者对象，通过弱引用包装访问
        /// </summary>
        public object Target { get { return wrapper.Target; } }

        /// <summary>
        /// 订阅者对象显式名
        /// </summary>
        public string TargetName { get { return targetName; } }

        internal virtual void HandleEvent(EventPublication publication, object sender, EventArgs args)
        {
            Delegate handler = Delegate.CreateDelegate(
                publication.EventHandleType, Target, methodName);

            handler.DynamicInvoke(sender, args);
        }

        public override string ToString()
        {
            return string.Format("[{0} - {1}]", targetName, methodName);
        }
    }
}