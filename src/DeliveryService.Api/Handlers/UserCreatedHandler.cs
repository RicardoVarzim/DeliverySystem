using System;
using System.Threading.Tasks;
using DeliveryService.Common.Events;

namespace DeliveryService.Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public async Task HandleAsync(UserCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User created: {@event.Name}");
        }
    }
}