using Application.Features.Users.CreateUser;
using Application.Features.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class UserController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpGet("user")]
  public async Task<IActionResult> GetAllUser()
  {
    var users = await _mediator.Send(new GetUsersQuery());
    if (users.Count == 0) return Ok(new { message = "there is not users" });
    return Ok(users);
  }

  [HttpPost("user")]
  public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
  {
    var user = await _mediator.Send(command);
    return Ok(user);
  }
}