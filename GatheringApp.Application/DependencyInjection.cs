

using Microsoft.Extensions.DependencyInjection;
 
 
using MediatR;
 
namespace GatheringApp.Application;

public  static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var semply= typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration => 
        configuration.RegisterServicesFromAssembly
        (semply));
        
        
        return services;
    }
}
