

using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Enums;
using GatheringApp.Domain.Repositories;
using MediatR;

namespace GatheringApp.Application.Invitations.Commands.SendIntivation;


public sealed class SendIntivationCommandHandler : IRequestHandler<SendInteviationCommand, Unit>
{

    private readonly IMemberRepository _memberRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUnitOfWork unitOfWork;

    public SendIntivationCommandHandler(
        IMemberRepository memberRepository,
        IGatheringRepository gatheringRepository,
        IInvitationRepository invitationRepository, 
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _gatheringRepository = gatheringRepository;
        _invitationRepository = invitationRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SendInteviationCommand request, CancellationToken cancellationToken)
    {
        var member =await _memberRepository
            .GetByIDAsync(request.memberId, cancellationToken);

        var gathring = await _gatheringRepository
            .GetGatheringByIDAsync(request.gatheringId, cancellationToken);

        if (member is null || gathring is null)
        {
            return Unit.Value;
        }

       
       


        var  invitation = gathring.SendInvitaion(member);

        if(invitation.IsFailure)
            return Unit.Value;
       

       _invitationRepository.Add(invitation.Vlaue);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
     }
}
