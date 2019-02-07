using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class ConnectionCreatedRejected : IRejectedEvent
    {
        public Guid Id { get; }

        public string Reason { get; }

        public string Code { get; }

        protected ConnectionCreatedRejected() { }

        public ConnectionCreatedRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
