using MinimalApiDemo.Database;
using MongoDB.Driver;

namespace MinimalApiDemo.Features.Pet;

public interface IPetReadRepository
{
    Task<IEnumerable<Pet>> FindAll(CancellationToken cancellationToken);
    Task<Pet?> FindById(string id, CancellationToken cancellationToken); 
}

public class PetReadRepository(DbContext dbContext) : IPetReadRepository
{
    public async Task<IEnumerable<Pet>> FindAll(CancellationToken cancellationToken)
    {
        return await dbContext.Pets.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Pet?> FindById(string id, CancellationToken cancellationToken)
    {
        return await dbContext.Pets.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}