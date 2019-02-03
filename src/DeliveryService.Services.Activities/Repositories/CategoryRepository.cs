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
    public class CategoryRepository : ICatetoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Category category)
        {
            await Collection.InsertOneAsync(category);
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Category> GetAsync(string name)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        private IMongoCollection<Category> Collection
        {
            get { return _database.GetCollection<Category>("Categories"); }
        }
    }
}
