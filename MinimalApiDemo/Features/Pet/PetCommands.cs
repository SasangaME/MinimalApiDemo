using MediatR;

namespace MinimalApiDemo.Features.Pet;

public class CreatePetCommand : PetDto, IRequest<int>;

public class UpdatePetCommand : PetDto, IRequest<Unit>;

public class DeletePetCommand : PetDto, IRequest<Unit>;