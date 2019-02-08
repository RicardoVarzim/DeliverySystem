using DeliveryService.Common.Commands;
using DeliveryService.Common.Mongo;
using DeliveryService.Common.RabbitMq;
using DeliveryService.Services.Points.Domain.Repositories;
using DeliveryService.Services.Points.Handlers;
using DeliveryService.Services.Points.Repositories;
using DeliveryService.Services.Points.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.Services.Node
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreatePoint>, CreatePointHandler>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddScoped<IPointService, PointService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
