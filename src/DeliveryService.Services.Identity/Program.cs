using DeliveryService.Common.Commands;
using DeliveryService.Common.Services;

namespace DeliveryService.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                 .UseRabbitMq()
                 .SubscribeToCommand<CreateUser>()
                 .Build()
                 .Run();
        }
    }
}
