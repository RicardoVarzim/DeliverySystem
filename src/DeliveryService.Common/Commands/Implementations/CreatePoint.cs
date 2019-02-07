using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public class CreatePoint : ICommand
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
