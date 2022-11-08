using System;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 事件参数类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventModelArgs<T> : EventArgs
    {
        public T Data { get; set; }
    }

    /// <summary>
    /// 通用委托类型定义
    /// </summary>
    public delegate void EventModelHandler<T>(object sender, EventModelArgs<T> args);

    /// <summary>
    /// 总线事件类型
    /// </summary>
    internal delegate void TopicEventHandler(EventPublication publication, object sender, EventArgs args);
}