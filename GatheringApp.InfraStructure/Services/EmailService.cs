using GatheringApp.Application.Abstractions;
using GatheringApp.Domain.Entities;

namespace GatheringApp.InfraStructure.Services;

public sealed class EmailService : IEmailService
{
    public Task SendInvitationAcceptedEmailAsync(Gathering gathering, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task SendInvitationSentEmailAsync(Member member, Gathering gathering, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
        
    }
}
