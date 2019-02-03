using DeliveryService.Common.Mongo;
using DeliveryService.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICatetoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase database, ICatetoryRepository categoryRepository) : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work","sport","hooby"
            };

            await Task.WhenAll(categories.Select(x => _categoryRepository.AddAsync(new Domain.Models.Category(Guid.NewGuid(),x))));
        }
    }
}
