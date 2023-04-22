using GatheringApp.Application.Abstractions;
using GatheringApp.Domain.DomainEvents;
using GatheringApp.Domain.Premitives;
using GatheringApp.Domain.Repositories;
using MediatR;

namespace GatheringApp.Application.Invitations.Events;

public sealed class InvitationAcceptedDomainEventHandler : INotificationHandler<InvitationAcceptedDomainEvent>
{

    private readonly IEmailService emailService;
    private readonly IGatheringRepository gatheringRepository;

    public InvitationAcceptedDomainEventHandler(
        IEmailService emailService,
        IGatheringRepository gatheringRepository)
    {
        this.emailService = emailService;
        this.gatheringRepository = gatheringRepository;
    }

    public async Task Handle(InvitationAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        var gathering = await gatheringRepository.
            GetGatheringByIDAsync(notification.GatheringId,cancellationToken);

        if (gathering == null)
        {
            return; 
        }

        await emailService.
            SendInvitationAcceptedEmailAsync(gathering, cancellationToken);
    }
}
