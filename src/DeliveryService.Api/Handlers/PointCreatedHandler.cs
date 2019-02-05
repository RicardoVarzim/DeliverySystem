using DeliveryService.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Api.Handlers
{
    public class PointCreatedHandler : IEventHandler<PointCreated>
    {
        public async Task HandleAsync(PointCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
