using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Events
{
    public class PointCreated : IEvent
    {
        public PointCreated(Guid id, string name, Guid userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
    }
}
