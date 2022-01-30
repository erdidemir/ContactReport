using Contact.Api.EventBusConsumer;
using Contact.Application;
using Contact.Infrastructure;
using EventBus.Messages.Commons;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Api
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
            services.AddApplicationServices();
            services.AddInfrastructureService(Configuration);

            // MassTransit - RabbitMQ Configuration
            services.AddMassTransit(config => {
                
                config.AddConsumer<RaporUpdateConsumer>();

                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                    cfg.UseHealthCheck(ctx);

                   
                    cfg.ReceiveEndpoint(EventBusConstants.RaporUpdateQueue, c => {
                        c.ConfigureConsumer<RaporUpdateConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();

            // General Configuration
            services.AddScoped<RaporUpdateConsumer>();
            services.AddAutoMapper(typeof(Startup));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
