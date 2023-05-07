

using GatheringApp.Domain.Shareds;
using MediatR;

namespace GatheringApp.Application.Members.Queries.GetMemberById
{
    public sealed record GetmemberByIdQuery(Guid Id):IRequest<Result<MemberResponse>>;
    
}
