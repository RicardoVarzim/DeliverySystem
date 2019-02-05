using DeliveryService.Services.Points.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Services
{
    public interface IPointService
    {
        Task AddPointAsync(Guid id, string name, Guid userId, DateTime createdAt);
        Task AddPointAsync(Guid id, string name, Guid userId, DateTime createAt, IEnumerable<Connection> connections);
        Task AddConnectionAsync(Guid id, decimal cost, Guid destination, string observations);
    }
}
