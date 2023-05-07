using Microsoft.Extensions.DependencyInjection;

namespace GatheringApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection addPersistence(this IServiceCollection services)
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