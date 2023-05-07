using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Repositories;
using GatheringApp.Domain.Shareds;
using GatheringApp.Domain.ValueObjects;
using MediatR;

namespace GatheringApp.Application.Members.Commands.CreateMember;

public sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand,
    Result<Guid>>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var firsrName = FirstName.Create(request.firstName);

        if(firsrName.IsFailure)
        {
            return Result.Failure<Guid>(
               new Error
               (
                   "Member.FirstName",
                   "First Name Of Member Not Vaild Pleas Replace it to Valid First Name"

                   ));
        }
        var member = new Member(
            Guid.NewGuid(),
           firsrName.Vlaue
            , request.lastName
            , request.email);

          _memberRepository.Add(member);


       await unitOfWork.SaveChangesAsync(cancellationToken);

        return member.Id;

    }
}
