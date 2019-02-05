using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class ConnectionCreated : IEvent
    {
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public Guid Destination { get; set; }
        public string Observations { get; set; }

        public ConnectionCreated(Guid id, decimal cost, Guid destination, string observations)
        {
            Id = id;
            Cost = cost;
            Destination = destination;
            Observations = observations ?? throw new ArgumentNullException(nameof(observations));
        }
    }
}
