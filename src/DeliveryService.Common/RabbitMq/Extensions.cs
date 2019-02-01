﻿using DeliveryService.Common.Commands;
using DeliveryService.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using System.Reflection;
using System.Threading.Tasks;

namespace DeliveryService.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));
        }

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));
        }

        private static string GetQueueName<T>()
        {
            return $"{Assembly.GetEntryAssembly().GetName()}/{ typeof(T).Name}";
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions { ClientConfiguration = options });
            services.AddSingleton<IBusClient>(client);

        }
    }
}
