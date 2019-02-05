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
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IMongoDatabase _database;

        public ConnectionRepository(IMongoDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        private IMongoCollection<Connection> Collection
        {
            get { return _database.GetCollection<Connection>("Connections"); }
        }

        public async Task AddAsync(Connection connection)
        {
            await Collection.InsertOneAsync(connection);
        }

        public async Task<IEnumerable<Connection>> BrowsePointAsync(Guid pointId)
        {
            return await Collection.AsQueryable().Where(c => c.Destination == pointId).ToListAsync();
        }

        public async Task<Connection> GetAsync(string observations)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(c => c.Observations == observations);
        }

        public async Task<Connection> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
