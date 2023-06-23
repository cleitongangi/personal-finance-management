using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class MigrationManager
    {
        public static IServiceProvider ApplyMigration(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<PersonalFinanceDbContext>();
            appContext.Database.Migrate();

            return serviceProvider;
        }
    }
}
