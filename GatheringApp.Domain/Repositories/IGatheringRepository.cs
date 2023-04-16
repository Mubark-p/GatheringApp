
using GatheringApp.Domain.Entities;

namespace GatheringApp.Domain.Repositories;

public  interface IGatheringRepository
{
    Task<Gathering?> GetGatheringByIDAsync(Guid id, CancellationToken cancellationToken);
    void Add(Gathering gathering);
}
