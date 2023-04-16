using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Enums;
using GatheringApp.Domain.Repositories;
using MediatR;

namespace GatheringApp.Application.Gatherings.Commands.CreateGathering;

public sealed class CreateGatheringCommandHandler : IRequestHandler<CreateGatheringCommand, Unit>
{

    private readonly IMemberRepository _memberRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateGatheringCommandHandler(
        IMemberRepository memberRepository, 
        IGatheringRepository gatheringRepository,
        IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _gatheringRepository = gatheringRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateGatheringCommand request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIDAsync(request.MemberId, cancellationToken);
        if (member is null)
        {
            return Unit.Value;
        }

        //Greate Gathering
        var gathering = Gathering.Create
        (
           Guid.NewGuid(),
             member,
            request.SchedualAt,
             request.Type,
             request.Location,
             request.MaximumNmerOfAttendee,
             request.InvitationValidBeforInHours

        );
  
        // add gathering to Db
        _gatheringRepository.Add(gathering);

        //save all changes To entities
        await unitOfWork.SaveChangesAsync(cancellationToken);

        //return void from Unit 
        return Unit.Value;


        
    }
}
