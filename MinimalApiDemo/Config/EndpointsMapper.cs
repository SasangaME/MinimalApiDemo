using MinimalApiDemo.Features.Pet;

namespace MinimalApiDemo.Config;

public static class EndpointsMapper
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPetEndpoints();
    }
}