using MinimalApiDemo.Common.Enums;

namespace MinimalApiDemo.Features.Pet;

public static class PetEndpoints
{
    public static void MapPetEndpoints(this WebApplication app)
    {
        var petGroup = app.MapGroup("/api/pets")
            .WithTags("Pets");
        
        petGroup.MapGet("/api/pets", () => Results.Ok(GetPets()));

        petGroup.MapGet("/api/pets/{id:int}", (int id) =>
        {
            var pet = GetPetById(id);
            return pet is not null ? Results.Ok(pet) : Results.NotFound();
        });

        petGroup.MapPost("/api/pets", (PetDto pet) =>
        {
            var newPet = CreatePet(pet);
            return Results.Created($"/api/pets/{newPet.Id}", newPet);
        });
    }

    private static IEnumerable<PetDto> GetPets()
    {
        return new List<PetDto>
        {
            new PetDto { Id = 1, Name = "Pippa", Gender = Gender.Female },
            new PetDto { Id = 2, Name = "Ollie", Gender = Gender.Male }
        };
    }

    private static PetDto? GetPetById(int id)
    {
        return GetPets().FirstOrDefault(p => p.Id == id);
    }

    private static PetDto CreatePet(PetDto pet)
    {
        pet.Id = GetPets().Max(p => p.Id) + 1;
        return pet;
    }
}