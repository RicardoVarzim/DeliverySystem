using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Neo4j.Driver.V1;

namespace DeliveryService.Common.Neo4j
{
    public static class Extensions
    {
        [Obsolete("use AddNeo4jDriver instead")]
        public static void AddNeo4jClient(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<Neo4jOptions>(configuration.GetSection("neo4j"));
            //services.AddSingleton<IGraphClient>(c =>
            //{
            //    var options = c.GetService<IOptions<Neo4jOptions>>();

            //    Console.WriteLine("NEO4J CLIENT OPTIONS:");
            //    Console.WriteLine(options.Value.ConnectionString);
            //    Console.WriteLine(options.Value.UserName);
            //    Console.WriteLine(options.Value.Password);

            //    var client = new GraphClient(new Uri(options.Value.ConnectionString), options.Value.UserName, options.Value.Password);
                
            //    client.Connect();
                
            //    return client;
            //});
        }

        public static void AddNeo4jDriver(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Neo4jOptions>(configuration.GetSection("neo4j"));
            services.AddSingleton<IDriver>(d =>
            {
                var options = d.GetService<IOptions<Neo4jOptions>>();

                Console.WriteLine("NEO4J Driver OPTIONS:");
                Console.WriteLine(options.Value.ConnectionString);
                Console.WriteLine(options.Value.UserName);
                Console.WriteLine(options.Value.Password);

                var driver = GraphDatabase.Driver(options.Value.ConnectionString, AuthTokens.Basic(options.Value.UserName, options.Value.Password));

                //using (var session = driver.Session())
                //{
                //    var name = "teste";
                //    session.Run("CREATE (a:Person {name: $name})", new { name });
                //}

                return driver;
            });
        }
    }
}
