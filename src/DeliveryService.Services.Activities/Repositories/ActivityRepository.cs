using DeliveryService.Services.Activities.Domain.Models;
using DeliveryService.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Activity category)
        {
             await Collection.InsertOneAsync(category);
        }

        public async Task<IEnumerable<Activity>> BrowseAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public async Task<Activity> GetAsync(string name)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        private IMongoCollection<Activity> Collection
        {
            get { return _database.GetCollection<Activity>("Activities"); }
        }
    }
}
