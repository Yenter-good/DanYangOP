using System;

namespace CIS.Core.EventBroker
{
    [Flags]
    public enum EventScope
    {
        Local = 0x0001,
        Remote = 0x0002,
        Both = Local | Remote
    }
}