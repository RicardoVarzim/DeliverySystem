using System;

namespace DeliveryService.Services.Points.Domain.Models
{
    public class Connection
    {
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public Guid Destination { get; set; }
        public string Observations { get; set; }

        protected Connection()
        {
        }

        public Connection(Guid id, decimal cost, Guid destination, string observations)
        {
            Id = id;
            Cost = cost;
            Destination = destination;
            Observations = observations ?? throw new ArgumentNullException(nameof(observations));
        }
    }
}
