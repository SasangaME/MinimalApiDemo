using MinimalApiDemo.Database;
using MongoDB.Driver;

namespace MinimalApiDemo.Features.Pet;

public interface IPetWriteRepository
{
    Task<string> Create(Pet pet, CancellationToken cancellationToken);
    Task Update(string id, Pet pet, CancellationToken cancellationToken);
    Task Delete(string id, CancellationToken cancellationToken);
}

public class PetWriteRepository(DbContext dbContext) : IPetWriteRepository
{
    public async Task<string> Create(Pet pet, CancellationToken cancellationToken)
    {
        await dbContext.Pets.InsertOneAsync(pet, cancellationToken: cancellationToken);
        return pet.Id;
    }

    public async Task Update(string id, Pet pet, CancellationToken cancellationToken)
    {
        await dbContext.Pets.ReplaceOneAsync(p => p.Id == id, pet, cancellationToken: cancellationToken);
    }

    public async Task Delete(string id, CancellationToken cancellationToken)
    {
        await dbContext.Pets.DeleteOneAsync(p => p.Id == id, cancellationToken: cancellationToken);
    }
}