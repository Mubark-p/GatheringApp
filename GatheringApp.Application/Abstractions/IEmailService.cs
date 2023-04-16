using GatheringApp.Domain.Entities;

namespace GatheringApp.Application.Abstractions;

public interface IEmailService
{
    Task SendInvitationSentEmailAsync(Member member, Gathering gathering, CancellationToken cancellationToken = default);

    Task SendInvitationAcceptedEmailAsync(Gathering gathering, CancellationToken cancellationToken = default);
}
