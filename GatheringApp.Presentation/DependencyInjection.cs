using Microsoft.Extensions.DependencyInjection;

namespace GatheringApp.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection addPresentation(this IServiceCollection services)
    {
        var semply = typeof(DependencyInjection).Assembly;
        



        return services;
    }
}
