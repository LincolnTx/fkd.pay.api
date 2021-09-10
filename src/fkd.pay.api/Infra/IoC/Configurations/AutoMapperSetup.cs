using System;
using fkd.pay.api.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace fkd.pay.api.Infra.IoC.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}