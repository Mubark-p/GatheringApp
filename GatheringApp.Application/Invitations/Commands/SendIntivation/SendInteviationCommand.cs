

using MediatR;

namespace GatheringApp.Application.Invitations.Commands.SendIntivation;

public sealed record SendInteviationCommand
(
    Guid memberId,
    Guid gatheringId,
    CancellationToken CancellationToken
    
    ):IRequest<Unit>;
