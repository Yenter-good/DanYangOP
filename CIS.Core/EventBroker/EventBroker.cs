using System.Reflection;

namespace CIS.Core.EventBroker
{
    public class EventBroker
    {
        private readonly EventTopicCollection topics
            = new EventTopicCollection();

        /// <summary>
        /// 事件主题集合列表
        /// </summary>
        public EventTopicCollection Topics
        {
            get { return topics; }
        }

        /// <summary>
        /// 事件场景
        /// </summary>
        public virtual EventScope EventScope { get { return EventScope.Local; } }

        /// <summary>
        /// 将对象注入到事件总线上
        /// </summary>
        public void Register(object target)
        {
            BindingFlags bingdings = BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic;
            RegisterPublication(target, bingdings);
            RegisterSubscription(target, bingdings);
        }

        /// <summary>
        /// 注册发布者
        /// </summary>
        private void RegisterPublication(object target, BindingFlags bindings)
        {
            if (target == null) return;
            foreach (var info in target.GetType().GetEvents(bindings))
            {
                foreach (EventPublicationAttribute attr in
                    info.GetCustomAttributes(typeof(EventPublicationAttribute), false))
                {
                    var publisher = new EventPublication(target, info.Name);
                    var topicName = attr.Topic;
                    EventTopic topic = Topics[topicName] ?? Topics.Add(topicName);
                    topic.AddPublication(publisher);
                }
            }
        }

        /// <summary>
        /// 注册订阅者
        /// </summary>
        /// <param name="target"></param>
        /// <param name="bindings"></param>
        private void RegisterSubscription(object target, BindingFlags bindings)
        {
            foreach (var info in target.GetType().GetMethods(bindings))
            {
                foreach (EventSubscriptionAttribute attr in
                    info.GetCustomAttributes(typeof(EventSubscriptionAttribute), true))
                {
                    var subscriber = new EventSubscription(target, info.Name);
                    var topicName = attr.Topic;
                    EventTopic topic = Topics[topicName] ?? Topics.Add(topicName);
                    topic.AddSubscription(subscriber);
                }
            }
        }
    }
}