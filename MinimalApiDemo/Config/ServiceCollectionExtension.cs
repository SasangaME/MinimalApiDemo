using System.Reflection;
using MinimalApiDemo.Database;

namespace MinimalApiDemo.Config;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<DbContext>()
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}