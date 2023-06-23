using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
