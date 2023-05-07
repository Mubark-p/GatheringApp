using Microsoft.Extensions.DependencyInjection;
 

namespace GatheringApp.InfraStructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrucure(this IServiceCollection services)
        {
            var semply = typeof(DependencyInjection).Assembly;
            services
         .Scan(
         selector => selector
             .FromAssemblies(
                semply
                  )
             .AddClasses(false)
             .AsImplementedInterfaces()
             .WithScopedLifetime());


            return services;
        }
    }
}
