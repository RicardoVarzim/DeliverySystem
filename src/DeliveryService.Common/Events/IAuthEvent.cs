using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public interface IAuthEvent : IEvent
    {
        Guid UserId { get; }
    }
}
