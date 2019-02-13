using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Repositories
{
    public class GraphRepository : IGraphRepository
    {
        private readonly IGraphClient client;

        public GraphRepository(IGraphClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task AddConnectionAsync(Guid pointId, Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task AddPointAsync(Point node)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Point>> PathAsync(Point origin, Point destiny)
        {
            throw new NotImplementedException();
        }
    }
}
