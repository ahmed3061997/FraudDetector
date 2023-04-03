using FraudDetector.Application.Contracts;
using FraudDetector.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FraudDetector.Application.IOC
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IFraudFlagService, FraudFlagService>();
        }
    }
}
