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
                            MATCH (a:Point),(b:Point)
                            WHERE a.id = 'A' AND b.id = 'B'
                            CREATE (a)-[r:cost]->(b)
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
                    return session.RunAsync("CREATE (a:Point { id: '" + node.Id + "' }) ");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Path>> PathAsync(MyPoint origin, MyPoint destiny)
        {
            try
            {
                using(var session = _driver.Session())
                {
                    var result = session.RunAsync(@"
                        MATCH (start:Point{id:'" + origin.Id + "'}), (end:Point{id:'" + destiny.Id + @"'})
                        CALL algo.shortestPath.stream(start, end, 'cost')
                        YIELD nodeId, cost
                        MATCH(other: Point) WHERE id(other) = nodeId
                        RETURN other.id AS id, cost
                    ");

                    return result.Result.ToListAsync(x => new Path() {
                        PointId = x.Values["id"].As<Guid>(),
                        Cost = x.Values["cost"].As<decimal>()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
