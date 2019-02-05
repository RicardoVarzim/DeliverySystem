using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly IMongoDatabase _database;

        public PointRepository(IMongoDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        private IMongoCollection<Point> Collection
        {
            get { return _database.GetCollection<Point>("Points"); }
        }

        public async Task AddAssync(Point node)
        {
            await Collection.InsertOneAsync(node);
        }

        public async Task<IEnumerable<Point>> BrowseAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public async Task<Point> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(p=>p.Id == id);
        }
    }
}
