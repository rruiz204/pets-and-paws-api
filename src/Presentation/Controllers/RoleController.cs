using Application.Features.Roles.GetAllRoles;
using Application.Features.Roles.GetMyRoles;
using Domain.Services.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
public class RoleController(IMediator mediator, IJwtService jwtService) : BaseApiController
{
  private readonly IMediator _mediator = mediator;
  private readonly IJwtService _jwtService = jwtService;

  [HttpGet("roles")]
  public async Task<IActionResult> GetAllRoles()
  {
    return Ok(await _mediator.Send(new GetAllRolesQuery()));
  }

  [HttpGet("roles/me")]
  public async Task<IActionResult> GetMyRoles()
  {
    var query = new GetMyRolesQuery { UserId = _jwtService.GetCurrentUser() };
    return Ok(await _mediator.Send(query));
  }


  /* [HttpPut("roles")]
  public async Task<IActionResult> UpdateRoles()
  {
    return Ok();
  } */
}