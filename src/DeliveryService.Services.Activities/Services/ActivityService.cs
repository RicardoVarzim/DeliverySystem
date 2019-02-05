using DeliveryService.Common.Exceptions;
using DeliveryService.Services.Activities.Domain.Models;
using DeliveryService.Services.Activities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {

        private readonly IActivityRepository _activityRepository;
        private readonly ICatetoryRepository _catetoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICatetoryRepository catetoryRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _catetoryRepository = catetoryRepository ?? throw new ArgumentNullException(nameof(catetoryRepository));
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _catetoryRepository.GetAsync(category);
            if(activityCategory == null)
            {
                throw new DeliverySystemException("category_not_found", category + " was not found.");
            }
            var activity = new Activity(id,name,category,description,userId,createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}
