using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Neo4jClient;
using Neo4j;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace DeliveryService.Common.Neo4j
{
    public static class Extensions
    {
        public static void AddNeo4jDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Neo4jOptions>(configuration.GetSection("neo4j"));
            services.AddSingleton<IGraphClient>(c =>
            {
                var options = c.GetService<IOptions<Neo4jOptions>>();

                //Console.WriteLine("NEO4J CLIENT OPTIONS:");
                //Console.WriteLine(options.Value.ConnectionString);
                //Console.WriteLine(options.Value.UserName);
                //Console.WriteLine(options.Value.Password);

                //var client = new GraphClient(new Uri(options.Value.ConnectionString), options.Value.UserName, options.Value.Password)
                //{
                //    JsonContractResolver = new CamelCasePropertyNamesContractResolver()
                //};

                var client = new GraphClient(new Uri(options.Value.ConnectionString.ToLower()));

                client.Connect();
                return client;
            });
        }
    }
}
