using System;
using Microsoft.Extensions.DependencyInjection;

namespace fkd.pay.api.Infra.IoC.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}