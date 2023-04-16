

using GatheringApp.Domain.Entities;

namespace GatheringApp.Domain.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetByIDAsync(Guid id,CancellationToken cancellationToken);
    void Add(Member member);
}
