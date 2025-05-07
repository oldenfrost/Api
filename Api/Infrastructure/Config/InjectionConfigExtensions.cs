using Api.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Linq;

namespace Api.Infrastructure.Config
{
    public static class InjectionConfigExtensions
    {
        public static IServiceCollection AddInjectionServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<PostgreSQLDataAccess>()
                .AddClasses(classes => classes.Where(type =>
                    type.Name.EndsWith("DataAccess") ||
                    type.Name.EndsWith("DataClient") ||
                    type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
