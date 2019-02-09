using DeliveryService.Common.Commands;
using DeliveryService.Common.Mongo;
using DeliveryService.Common.RabbitMq;
using DeliveryService.Services.Identity.Domain.Repositories;
using DeliveryService.Services.Identity.Domain.Services;
using DeliveryService.Services.Identity.Handlers;
using DeliveryService.Services.Identity.Repositories;
using DeliveryService.Services.Identity.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.Services.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddLogging();
            services.AddRabbitMq(Configuration);
            services.AddMongoDb(Configuration);
            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices.GetService<IDatabaseInit>().InitAsync();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
