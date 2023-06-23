using Domain;
using Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class IoCWrapper
    {
        public static IServiceCollection AddDependencyInjectionForAllLayers(this IServiceCollection services, string dbConnectionString)
        {            
            services.AddDomainServices();
            services.AddDataServices(dbConnectionString);

            return services;
        }
    }
}
