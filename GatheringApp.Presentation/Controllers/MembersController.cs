using GatheringApp.Application.Members.Commands.CreateMember;
using GatheringApp.Application.Members.Queries.GetMemberById;
using GatheringApp.Domain.Shareds;
using GatheringApp.Presentation.Abstractions;
using GatheringApp.Presentation.Contracts.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GatheringApp.Presentation.Controllers;
[Route("api/members")]
public sealed class MembersController : ApiController
{
    public MembersController(ISender sender) : base(sender)
    {
    }
    [HttpGet("id/guid")]
    public async Task<ActionResult> GetMemberByAdAsync
        (Guid id, CancellationToken cancellationToken)
    {
        var query = new GetmemberByIdQuery(id);

        Result<MemberResponse> result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Vlaue) : NotFound(result.Error);

    }


    [HttpPost]
    public async Task<ActionResult> RegisterMember
        (
        [FromBody] RegisterMemberRequest request,
        CancellationToken cancellationToken
        )
    {
        var command =   new CreateMemberCommand(
             request.FirstName,
             request.lastName,
             request.Email

            );

        Result<Guid> response =
            await sender.Send(command, cancellationToken);

        if(response.IsFailure) {
            return BadRequest(response.Error);
        }


        return CreatedAtAction(

            nameof(GetMemberByAdAsync),
            new { id = response.Vlaue },
             response.Vlaue
             );

    
    }


}
