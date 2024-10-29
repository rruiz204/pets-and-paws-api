using Application.Features.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class UserController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpPost("user")]
  public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
  {
    return Ok(await _mediator.Send(command));
  }
}