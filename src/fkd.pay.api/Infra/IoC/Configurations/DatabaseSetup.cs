using System;
using fkd.pay.api.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace fkd.pay.api.Infra.IoC.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
        }
    }
}