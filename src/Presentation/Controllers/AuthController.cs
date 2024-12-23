using Application.Features.Authentication.ForgotPassword;
using Application.Features.Authentication.LoginUser;
using Application.Features.Authentication.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Presentation.Controllers;

[ApiController]
[EnableRateLimiting("Fixed")]
public class AuthController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpPost("auth/login")]
  public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
  {
    return Ok(await _mediator.Send(command));
  }

  [HttpPost("auth/forgot-password")]
  public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
  {
    return Ok(await _mediator.Send(command));
  }

  [HttpPost("auth/reset-password")]
  public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
  {
    return Ok(await _mediator.Send(command));
  }
}