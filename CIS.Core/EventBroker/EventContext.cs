using System;

namespace CIS.Core.EventBroker
{
    /// <summary>
    /// 单例类，记录上下文日志
    /// </summary>
    public class EventContext
    {
        private static readonly EventContext instance
            = new EventContext();

        private EventContext()
        {
        }

        public static EventContext Instance { get { return instance; } }

        public event Action<string> Write;

        public void WriteTo(string message)
        {
            var handle = Write;
            if (handle != null)
                handle(message);
        }

        public void WriteTo(string message, params object[] args)
        {
            string fullMsg = string.Format(message, args);
            WriteTo(fullMsg);
        }
    }
}