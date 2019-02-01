using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
