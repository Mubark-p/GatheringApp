

using GatheringApp.Domain.Enums;
using MediatR;

namespace GatheringApp.Application.Gatherings.Commands.CreateGathering;

public sealed record CreateGatheringCommand

    (
    Guid MemberId,
    GatheringType Type,
    DateTime SchedualAt,
    string Name,
    string? Location,
    int? MaximumNmerOfAttendee,
    int? InvitationValidBeforInHours

    
    
    ):IRequest<Unit>;
