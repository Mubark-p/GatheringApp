using GatheringApp.Domain.Repositories;
using GatheringApp.Domain.Shareds;
using MediatR;

namespace GatheringApp.Application.Members.Queries.GetMemberById;

public sealed class GetMemberByIdQueryHandler :
    IRequestHandler<GetmemberByIdQuery, Result<MemberResponse>>

{
    private readonly IMemberRepository memberRepository;

    public GetMemberByIdQueryHandler(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    public async Task<Result<MemberResponse>> Handle(GetmemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await memberRepository.GetByIDAsync
              (request.Id, cancellationToken);
        if(member is null)
        {
            return Result.Failure<MemberResponse>(

                error: new Error(
                    "Member.NotFond",
                    $"Ther is no Reecord in |Member for {request.Id}  try onther Id "
                    )
                );
        }

        MemberResponse reponse = new(
            request.Id,
            member.Email

            );
       // return Result.Success<MemberResponse>(memberResponde);
        return reponse;
    }
}
