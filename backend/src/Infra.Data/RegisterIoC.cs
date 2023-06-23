using Domain.Interfaces.Data;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Infra.Data
{
    public static class RegisterIoC
    {
        public static readonly LoggerFactory MyLoggerFactory = new(new[] { new DebugLoggerProvider() });

        public static IServiceCollection AddDataServices(this IServiceCollection services, string dbCnnString)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PersonalFinanceDbContext>();

            services.AddDbContext<PersonalFinanceDbContext>(options =>
            {
                options
                    .UseNpgsql(dbCnnString)
                    .UseSnakeCaseNamingConvention()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .UseLoggerFactory(MyLoggerFactory);
            });

            return services;
        }
    }
}
