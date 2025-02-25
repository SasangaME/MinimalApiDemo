using MediatR;

namespace MinimalApiDemo.Features.Pet;

public class CreatePetCommand : Pet, IRequest<string>;

public class UpdatePetCommand : Pet, IRequest<Unit>;

public class DeletePetCommand : IRequest<Unit>
{
    public string Id { get; set; }
}