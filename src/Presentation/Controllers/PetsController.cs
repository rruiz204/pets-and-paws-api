using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Presentation.Controllers;

[ApiController]
public class PetsController(IMediator mediator) : BaseApiController
{
  private readonly IMediator _mediator = mediator;

  [HttpGet("pets")]
  [Authorize(Policy = "Policy:PetsDirectory:Read")]
  public IActionResult GetAllPets()
  {
    return Ok(new { message = "pets directory!" });
  }
}