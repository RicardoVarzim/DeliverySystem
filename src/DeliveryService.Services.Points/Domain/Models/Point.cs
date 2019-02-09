using System;
using System.Collections.Generic;
using DeliveryService.Common.Exceptions;

namespace DeliveryService.Services.Points.Domain.Models
{
    public class Point
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Connection> Connections { get; private set; }

        protected Point() { }

        public Point(Guid id, string name, Guid userId, DateTime createdAt, List<Connection> connections)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DeliveryServiceException("empty_point_name", "Point cannot be empty.");
            }

            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
            Connections = connections;
        }
    }
}
