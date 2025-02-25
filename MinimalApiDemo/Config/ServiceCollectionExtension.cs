using System.Reflection;
using MinimalApiDemo.Database;
using MinimalApiDemo.Features.Pet;

namespace MinimalApiDemo.Config;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<DbContext>()
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddRepositories() ;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IPetReadRepository, PetReadRepository>()
            .AddScoped<IPetWriteRepository, PetWriteRepository>();
    }
}