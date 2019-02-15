using DeliveryService.Services.Points.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Domain.Repositories
{
    public interface IGraphRepository
    {
        Task<List<Path>> PathAsync(MyPoint origin, MyPoint destiny);
        Task AddPointAsync(MyPoint node);
        Task AddConnectionAsync(Guid pointId, Connection connection);
    }
}
