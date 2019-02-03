using DeliveryService.Services.Activities.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(string name);
        Task<IEnumerable<Activity>> BrowseAsync();
        Task AddAsync(Activity activity);
    }
}
