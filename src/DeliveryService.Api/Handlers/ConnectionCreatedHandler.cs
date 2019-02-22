using DeliveryService.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Api.Handlers
{
    public class ConnectionCreatedHandler : IEventHandler<ConnectionCreated>
    {
        public async Task HandleAsync(ConnectionCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Connection created: {@event.Observations}");
        }
    }
}
