using DeliveryService.Services.Points.Domain.Models;
using DeliveryService.Services.Points.Domain.Repositories;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Repositories
{
    public class GraphRepository : IGraphRepository
    {
        private readonly IDriver driver;

        public GraphRepository(IDriver driver)
        {
            this.driver = driver;
        }

        public Task AddConnectionAsync(Guid pointId, Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task AddPointAsync(MyPoint node)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MyPoint>> PathAsync(MyPoint origin, MyPoint destiny)
        {
            throw new NotImplementedException();
        }
    }
}
