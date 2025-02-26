using MediatR;

namespace MinimalApiDemo.Features.Pet;

public class GetPetsHandler(IPetReadRepository petReadRepository) : IRequestHandler<GetPetsQuery, IEnumerable<Pet>>
{
    public async Task<IEnumerable<Pet>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
    {
        var pets = await petReadRepository.FindAll(cancellationToken);
        return pets;
    }
}

public class GetPetByIdHandler(IPetReadRepository petReadRepository) : IRequestHandler<GetPetByIdQuery, Pet>
{
    public async Task<Pet> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = await petReadRepository.FindById(request.Id, cancellationToken);
        if (pet is null)
        {
            Results.NotFound($"pet is not found for id: {request.Id}");
        }

        return pet;
    }
}
