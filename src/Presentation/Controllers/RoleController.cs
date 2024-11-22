using Application.Features.Roles.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class RoleController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpGet("roles")]
  public async Task<IActionResult> GetAllRoles()
  {
    return Ok(await _mediator.Send(new GetAllRolesQuery()));
  }

  /* [HttpPut("roles")]
  public async Task<IActionResult> UpdateRoles()
  {
    return Ok();
  } */
}