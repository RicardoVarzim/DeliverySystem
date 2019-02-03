using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Common.Mongo
{
    public class MongoInit : IDatabaseInit
    {
        private bool _initialized;
        private readonly IDatabaseSeeder _seeder;
        private readonly IMongoDatabase _database;
        private readonly bool _seed;

        public MongoInit(IMongoDatabase database, IDatabaseSeeder seeder, IOptions<MongoOptions> options)
        {
            _seeder = seeder;
            _database = database;
            _seed = options.Value.Seed;
        }
        public async Task InitAsync()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;

            if (!_seed)
                return;

            await _seeder.SeedAsync();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("DeliveryServiceConventions", new MongoConvention(), x => true);
        }
    }

    internal class MongoConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions
        {
            get
            {
                return new List<IConvention>
                {
                    new IgnoreExtraElementsConvention(true),
                    new EnumRepresentationConvention(MongoDB.Bson.BsonType.String),
                    new CamelCaseElementNameConvention()
                };
            }
        }
    }
}
