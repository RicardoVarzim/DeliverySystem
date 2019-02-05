using DeliveryService.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Services.Activities.Domain.Models
{
    public class Activity
    {
        protected Activity() { }

        public Activity(Guid id, string name, string category, string description, Guid userId, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DeliverySystemException("empty_actitivity_name", "Activity name not found.");
            }

            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserId = userId;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
