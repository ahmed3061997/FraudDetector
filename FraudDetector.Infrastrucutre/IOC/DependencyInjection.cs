using FraudDetector.Application.Contracts;
using FraudDetector.Infrastrucutre.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FraudDetector.Infrastrucutre.IOC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFraudFlagService, FraudFlagService>();
        }
    }
}
