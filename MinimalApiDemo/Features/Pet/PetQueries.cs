using MediatR;

namespace MinimalApiDemo.Features.Pet;

public record GetPetsQuery : IRequest<IEnumerable<PetDto>>;

public record GetPetByIdQuery(int Id) : IRequest<PetDto>;
