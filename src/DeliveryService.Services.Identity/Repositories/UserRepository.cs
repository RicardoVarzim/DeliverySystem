using DeliveryService.Services.Identity.Domain.Models;
using DeliveryService.Services.Identity.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _datebase;

        public UserRepository(IMongoDatabase datebase)
        {
            _datebase = datebase ?? throw new ArgumentNullException(nameof(datebase));
        }

        private IMongoCollection<User> Collection
        {
            get { return _datebase.GetCollection<User>("Users"); }
        }

        public async Task AddAsync(User user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetAsync(string name)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(p => p.Email == name);
        }
    }
}
