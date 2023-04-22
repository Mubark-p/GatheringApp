using GatheringApp.Domain.Premitives;

namespace GatheringApp.Domain.DomainEvents;

public sealed  record InvitationAcceptedDomainEvent
    (
    Guid InvitationId,  Guid GatheringId
    ):IDomainEvent
 
