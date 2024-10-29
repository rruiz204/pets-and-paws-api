using Application.Features.Authentication.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class AuthController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpPost("auth/login")]
  public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
  {
    return Ok(await _mediator.Send(command));
  }
}