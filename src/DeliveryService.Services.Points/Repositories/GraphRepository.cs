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
        private readonly IDriver _driver;

        public GraphRepository(IDriver driver)
        {
            _driver = driver;
        }

        public Task AddConnectionAsync(Guid pointId, Connection connection)
        {
            try
            {
                using (var session = _driver.Session())
                {
                    return session.RunAsync(@"
                            MATCH (a:Point),(b:Person)
                            WHERE a.id = 'A' AND b.name = 'B'
                            CREATE (a)-[r:RELTYPE]->(b)
                            RETURN type(r)                    
                        ");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task AddPointAsync(MyPoint node)
        {
            try
            {
                using (var session = _driver.Session())
                {
                    return session.RunAsync("CREATE (a:Point) { id: '"+ node.Id + "' }");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<MyPoint>> PathAsync(MyPoint origin, MyPoint destiny)
        {
            throw new NotImplementedException();
        }
    }
}
