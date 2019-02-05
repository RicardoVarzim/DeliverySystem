using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Common.Commands
{
    public class CreatePointConnections : ICommand
    {
        public CreatePointConnections(Guid userId, Guid id, string name, DateTime createdAt, IEnumerable<CreateConnection> connections)
        {
            foreach (var item in connections)
                item.Destination = id;

            UserId = userId;
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreatedAt = createdAt;
            Connections = connections;
        }

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CreateConnection> Connections { get; set; }
    }
}
