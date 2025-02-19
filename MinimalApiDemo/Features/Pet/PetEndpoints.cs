using MediatR;

namespace MinimalApiDemo.Features.Pet;

public static class PetEndpoints
{
    public static void MapPetEndpoints(this WebApplication app)
    {
        var petGroup = app.MapGroup("/api/pets")
            .WithTags("Pets");

        petGroup.MapGet("/", async (IMediator mediator) =>
        {
            var pets = await mediator.Send(new GetPetsQuery());
            return Results.Ok(pets);
        });

        petGroup.MapGet("/{id:int}", async (IMediator mediator, int id) =>
        {
            var pet = await mediator.Send(new GetPetByIdQuery(id));
            return Results.Ok(pet);
        });

        petGroup.MapPost("/", async (IMediator mediator, CreatePetCommand petCommand) =>
        {
            petCommand.Id = await mediator.Send(petCommand);
            return Results.Created($"/pets/{petCommand.Id}", petCommand);
        });
    }
}