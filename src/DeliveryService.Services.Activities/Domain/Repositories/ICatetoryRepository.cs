using DeliveryService.Services.Activities.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Domain.Repositories
{
    public interface ICatetoryRepository
    {
        Task<Category> GetAsync(Guid id);
        Task<Category> GetAsync(string name);
        Task AddAsync(Category category);
    }
}
