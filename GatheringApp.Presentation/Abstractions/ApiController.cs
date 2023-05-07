using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GatheringApp.Presentation.Abstractions;

[ApiController]
public  abstract class ApiController:ControllerBase

{
    protected readonly ISender sender;

    protected ApiController(ISender sender)
    {
        this.sender = sender;
    }
}
