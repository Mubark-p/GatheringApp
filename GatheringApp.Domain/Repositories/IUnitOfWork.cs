 

namespace GatheringApp.Domain.Repositories;

public  interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
