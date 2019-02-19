using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public class CreateConnection : ICommand
    {
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public Guid Destination { get; set; }
        public string Observations { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
