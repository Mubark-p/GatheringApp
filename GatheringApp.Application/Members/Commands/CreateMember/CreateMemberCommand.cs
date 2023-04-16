using MediatR;

namespace GatheringApp.Application.Members.Commands.CreateMember;

public  sealed record CreateMemberCommand
    (Guid MemberId,string firstName,string lastName,string email):IRequest<Unit>
 
