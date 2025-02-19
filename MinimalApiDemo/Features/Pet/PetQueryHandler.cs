using MediatR;
using MinimalApiDemo.Common.Enums;

namespace MinimalApiDemo.Features.Pet;

public class GetPetsHandler : IRequestHandler<GetPetsQuery, IEnumerable<PetDto>>
{
    public Task<IEnumerable<PetDto>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(PetsQueryHelper.GetPets());
    }
}

public class GetPetByIdHandler : IRequestHandler<GetPetByIdQuery, PetDto>
{
    public Task<PetDto> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = PetsQueryHelper.GetPets().FirstOrDefault(p => p.Id == request.Id);
        if (pet is null)
        {
            Results.NotFound($"pet is not found for id: {request.Id}");
        }

        return Task.FromResult(pet);
    }
}

public static class PetsQueryHelper
{
    public static IEnumerable<PetDto> GetPets()
    {
        return new List<PetDto>
        {
            new PetDto { Id = 1, Name = "Fluffy", Gender = Gender.Male },
            new PetDto { Id = 2, Name = "Whiskers", Gender = Gender.Female },
            new PetDto { Id = 3, Name = "Bubbles", Gender = Gender.Female }
        };
    }
}