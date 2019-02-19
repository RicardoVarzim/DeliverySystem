using DeliveryService.Api.Handlers;
using DeliveryService.Common.Auth;
using DeliveryService.Common.Events;
using DeliveryService.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace DeliveryService.Api
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
            services.AddMvc();
            services.AddLogging();
            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
            services.AddScoped<IEventHandler<PointCreated>, PointCreatedHandler>();
            services.AddScoped<IEventHandler<ConnectionCreated>, ConnectionCreatedHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0",
                    new Info
                    {
                        Title = "Delivery Service",
                        Version = "v0",
                        Description = "REST API to administrate and help a delivery service.",
                        Contact = new Contact
                        {
                            Name = "Ricardo Varzim",
                            Url = "https://github.com/RicardoVarzim"
                        }
                    });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var appName = Assembly.GetEntryAssembly().GetName().Name;
                string pathXmlDoc =
                    Path.Combine(basePath, $"{appName}.xml");

                c.IncludeXmlComments(pathXmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Delivery Service");
            //});
        }
    }
}
