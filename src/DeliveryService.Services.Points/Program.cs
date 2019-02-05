using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Common.Commands;
using DeliveryService.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DeliveryService.Services.Node
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                    .UseRabbitMq()
                    .SubscribeToCommand<CreatePoint>()
                    .Build()
                    .Run();
        }
    }
}
