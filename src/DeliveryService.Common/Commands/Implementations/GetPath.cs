using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public class GetPath : ICommand
    {
        public Guid originId { get; set; }
        public Guid destinationId { get; set; }
    }
}
