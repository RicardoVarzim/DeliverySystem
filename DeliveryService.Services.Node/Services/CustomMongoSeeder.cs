using DeliveryService.Common.Mongo;
using DeliveryService.Services.Points.Domain.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DeliveryService.Services.Points.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IPointRepository _pointRepository;

        public CustomMongoSeeder(IMongoDatabase database, IPointRepository pointRepository) : base(database)
        {
            _pointRepository = pointRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            //TODO:
            await Task.CompletedTask;
        }
    }
}
