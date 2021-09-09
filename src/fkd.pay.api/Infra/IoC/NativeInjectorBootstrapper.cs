using fkd.pay.api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using fkd.pay.api.Data.Repositories.PaymentCardRepository;

namespace fkd.pay.api.Infra.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterData(services);
        }

        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
        }
    }
}