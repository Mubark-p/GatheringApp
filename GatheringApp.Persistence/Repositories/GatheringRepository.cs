using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Repositories;

namespace GatheringApp.Persistence.Repositories;
public sealed class GatheringRepository : IGatheringRepository
{
    public void Add(Gathering gathering)
    {
        throw new NotImplementedException();
    }

    public Task<Gathering?> GetGatheringByIDAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
