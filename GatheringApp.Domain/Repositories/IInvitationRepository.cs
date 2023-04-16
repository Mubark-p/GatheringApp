

using GatheringApp.Domain.Entities;

namespace GatheringApp.Domain.Repositories;

public  interface IInvitationRepository
{
    //Task<Invitation> GetInvitationByIDAsync(Guid id, CancellationToken cancellationToken);

    void Add(Invitation invitation);
}
