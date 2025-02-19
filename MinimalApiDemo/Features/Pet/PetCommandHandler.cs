using MediatR;

namespace MinimalApiDemo.Features.Pet;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, int>
{
    public async Task<int> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        // Save the pet to the database
        return 1;
    }
}

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        // Update the pet in the database
        return Unit.Value;
    }
}


public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, Unit>
{
    public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        // Delete the pet from the database
        return Unit.Value;
    }
}