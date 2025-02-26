using MediatR;

namespace MinimalApiDemo.Features.Pet;

public class CreatePetCommandHandler(IPetWriteRepository petWriteRepository) : IRequestHandler<CreatePetCommand, string>
{
    public async Task<string> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var petId = await petWriteRepository.Create(request, cancellationToken);
        return petId;
    }
}

public class UpdatePetCommandHandler(IPetWriteRepository petWriteRepository, IMediator mediator) : IRequestHandler<UpdatePetCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var existingPet = await mediator.Send(new GetPetByIdQuery(request.Id), cancellationToken);
        if(existingPet is null)
        {
            Results.NotFound($"Pet not found for id: {request.Id}");
        }

        existingPet.Name = request.Name;
        existingPet.Breed = request.Breed;
        existingPet.Color = request.Color;
        existingPet.Weight = request.Weight;
        existingPet.BirthDate = request.BirthDate;
        await petWriteRepository.Update(request.Id, existingPet, cancellationToken);
        return Unit.Value;
    }
}


public class DeletePetCommandHandler(IPetWriteRepository petWriteRepository) : IRequestHandler<DeletePetCommand, Unit>
{
    public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        await petWriteRepository.Delete(request.Id , cancellationToken);
        return Unit.Value;
    }
}