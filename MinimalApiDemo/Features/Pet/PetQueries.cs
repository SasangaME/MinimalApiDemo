using MediatR;

namespace MinimalApiDemo.Features.Pet;

public record GetPetsQuery : IRequest<IEnumerable<Pet>>;

public record GetPetByIdQuery(string Id) : IRequest<Pet>;
