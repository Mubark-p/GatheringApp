
using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Enums;
using GatheringApp.Domain.Repositories;
using MediatR;

namespace GatheringApp.Application.Invitations.Commands.AcceptInvitation;

public sealed class AcceptInvitationCommandHandler :
    IRequestHandler<AcceptInvitationCommand, Unit>
{

    private readonly IGatheringRepository _gatheringRepository;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IAttendeeRepository _attendeeRepository;

    private readonly IUnitOfWork unitOfWork;

    public AcceptInvitationCommandHandler(
        IGatheringRepository gatheringRepository,
        IInvitationRepository invitationRepository, 
        IMemberRepository memberRepository,
        IAttendeeRepository attendeeRepository,
        IUnitOfWork unitOfWork)
    {
        _gatheringRepository = gatheringRepository;
        _invitationRepository = invitationRepository;
        _memberRepository = memberRepository;
        _attendeeRepository = attendeeRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
       
        var gathering = await _gatheringRepository
          .GetGatheringByIDAsync(request.GatheringId, cancellationToken);

        if(gathering is null)
        { return Unit.Value; }

        var invitation = gathering.InvitationList.FirstOrDefault(x=>x.Id==request.InvitationId);


        if (invitation is null ||
            invitation.Status != InvitationStatus.Pending)
        {
            return Unit.Value;
        }
        var member =  await _memberRepository
            .GetByIDAsync(invitation.MemberId, cancellationToken);    
       
        
       

        if(member is null ) { return Unit.Value; }


        var isExpire = (gathering.Type == GatheringType.WithFixedNumberOfAttendees &&
                       gathering.NumberOfAttendee > gathering.MaximumNumberOfAttendee) ||
                       (gathering.Type == GatheringType.WithExpirationForInvitations &&
                         gathering.ExpireDateOfInvitaionUtc < DateTime.UtcNow);



        if (isExpire) {
            invitation.Expire();
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;  
        
        
        }


        Attendee attendee = gathering.AcceptInvitation(invitation);
       
        _attendeeRepository.Add(attendee);  

        await unitOfWork.SaveChangesAsync(cancellationToken);   

        

        return Unit.Value;




    }
}
