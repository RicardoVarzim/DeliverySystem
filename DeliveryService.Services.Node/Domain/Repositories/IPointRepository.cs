using DeliveryService.Services.Points.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Domain.Repositories
{
    public interface IPointRepository
    {
        Task<Point> GetAsync(Guid id);
        Task<IEnumerable<Point>> BrowseAsync();
        Task AddAssync(Point node);
    }
}
