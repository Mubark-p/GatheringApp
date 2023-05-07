using GatheringApp.Domain.Shareds;
using MediatR;

namespace GatheringApp.Application.Members.Commands.CreateMember;

public  sealed record CreateMemberCommand
    ( string firstName,string lastName,string email):IRequest<Result<Guid>>;
 
