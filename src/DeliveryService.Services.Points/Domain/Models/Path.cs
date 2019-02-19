using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Domain.Models
{
    public class Path
    {
        public Guid PointId { get; set; }
        public decimal Cost { get; set; }
    }
}
