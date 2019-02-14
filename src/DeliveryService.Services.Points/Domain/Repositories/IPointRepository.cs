using DeliveryService.Services.Points.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Domain.Repositories
{
    public interface IPointRepository
    {
        Task<MyPoint> GetAsync(Guid id);
        Task<IEnumerable<MyPoint>> BrowseAsync();
        Task AddAssync(MyPoint node);
    }
}
