using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CIS.Core.EventBroker
{
    public class EventTopic
    {
        public EventTopic()
        {
        }

        public EventTopic(string name)
            : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// 事件主题标识
        /// </summary>
        public string Name { get; set; }

        private List<EventPublication> publishers = new List<EventPublication>();

        /// <summary>
        /// 发布者列表
        /// </summary>
        internal List<EventPublication> Publishers
        {
            get { return publishers; }
            set { publishers = value; }
        }

        private List<EventSubscription> subscribers = new List<EventSubscription>();

        /// <summary>
        /// 订阅者列表
        /// </summary>
        internal List<EventSubscription> Subscribers
        {
            get { return subscribers; }
            set { subscribers = value; }
        }

        /// <summary>
        /// 增加发布者
        /// </summary>
        internal void AddPublication(EventPublication publisher)
        {
            EventContext.Instance.WriteTo("主题：{0} 添加发布者{1}", Name, publisher);
            publisher.EventFired += OnEventFired;
            publishers.Add(publisher);
        }

        /// <summary>
        /// 增加订阅者
        /// </summary>
        internal void AddSubscription(EventSubscription subscriber)
        {
            EventContext.Instance.WriteTo("主题：{0} 添加订阅者{1}", Name, subscriber);
            subscribers.Add(subscriber);
        }

        /// <summary>
        /// 移除发布者
        /// </summary>
        internal void RemovePublication(EventPublication publisher)
        {
            EventContext.Instance.WriteTo("主题：{0} 移除发布者{1}", Name, publisher);
            publishers.Remove(publisher);
        }

        /// <summary>
        /// 移除订阅者
        /// </summary>
        internal void RemoveSubscription(EventSubscription subscriber)
        {
            EventContext.Instance.WriteTo("主题：{0} 移除订阅者{1}", Name, subscriber);
            subscribers.Remove(subscriber);
        }

        internal void OnEventFired(EventPublication publication, object sender, EventArgs args)
        {
            CheckInvalidPublications();
            CheckInvalidSubscriptions();
            foreach (var subscriber in subscribers)
            {
                subscriber.HandleEvent(publication, sender, args);
            }
        }

        private void CheckInvalidPublications()
        {
            IEnumerable<EventPublication> inValids =
                (from d in publishers
                 where d.IsAlive == false
                 select d).ToList();
            foreach (var invalid in inValids)
            {
                EventContext.Instance.WriteTo("发布者 {0} 被垃圾回收", invalid.TargetName);
                RemovePublication(invalid);
            }
        }

        private void CheckInvalidSubscriptions()
        {
            IList<EventSubscription> inValids =
                (from d in subscribers
                 where d.IsAlive == false
                 select d).ToList();
            foreach (var invalid in inValids)
            {
                EventContext.Instance.WriteTo("订阅者 {0} 被垃圾回收", invalid.TargetName);
                RemoveSubscription(invalid);
            }
        }
    }

    public class EventTopicCollection : IEnumerable<EventTopic>
    {
        private Dictionary<string, EventTopic> topics
            = new Dictionary<string, EventTopic>();

        public EventTopic this[string name]
        {
            get
            {
                return topics.ContainsKey(name) ? topics[name] : null;
            }
        }

        public void Add(EventTopic topic)
        {
            EventContext.Instance.WriteTo("新增一个主题：{0}", topic.Name);
            topics.Add(topic.Name, topic);
        }

        public EventTopic Add(string name)
        {
            EventTopic topic = new EventTopic(name);
            Add(topic);
            return topic;
        }

        public IEnumerator<EventTopic> GetEnumerator()
        {
            return topics.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}