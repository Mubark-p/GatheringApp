using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Repositories;
using GatheringApp.Domain.ValueObjects;
using MediatR;

namespace GatheringApp.Application.Members.Commands.CreateMember;

public sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var firsrName = FirstName.Create(request.firstName);

        if(firsrName.IsFailure)
        {
            return Unit.Value;
        }
        var member = new Member(
            Guid.NewGuid(),
           firsrName.Vlaue
            , request.lastName
            , request.email);

          _memberRepository.Add(member);


        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
