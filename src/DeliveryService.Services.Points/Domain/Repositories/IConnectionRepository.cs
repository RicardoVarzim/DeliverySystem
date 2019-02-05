using DeliveryService.Services.Points.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Domain.Repositories
{
    public interface IConnectionRepository
    {
        Task AddAsync(Connection connection);
        Task<Connection> GetAsync(string name);
        Task<Connection> GetAsync(Guid id);
        Task<IEnumerable<Connection>> BrowsePointAsync(Guid pointId);
    }
}
