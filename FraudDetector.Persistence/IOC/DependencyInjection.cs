using FraudDetector.Domain.Repositories;
using FraudDetector.Domain.Repositories.Base;
using FraudDetector.Persistence.Context;
using FraudDetector.Persistence.Repositories;
using FraudDetector.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FraudDetector.Persistence.IOC
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFraudFlagRepository, FraudFlagRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }
}
