using Contact.Application.Contracts.Persistence.Repositories.Commons;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Infrastructure.Contracts.Persistence;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Commons;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Contracts;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Rapors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            #region Contracts

            services.AddScoped<IKisiRepository, KisiRepository>();
            services.AddScoped<IBilgiTipRepository, BilgiTipRepository>();
            services.AddScoped<IKisiIletisimRepository, KisiIletisimRepository>();

            #endregion

            #region Rapors

            services.AddScoped<IRaporRepository, RaporRepository>();

            #endregion

            return services;
        }
    }
}
