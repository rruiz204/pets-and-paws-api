using Microsoft.AspNetCore.Mvc;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Presentation.Filters;

namespace Pets_And_Paws_Api.App.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[TypeFilter<ArgumentExceptionFilter>]
public class RoleController(IRoleService roleService) : ControllerBase
{
  private readonly IRoleService _roleService = roleService;

  [HttpGet]
  public async Task<IActionResult> ListRoles()
  {
    return Ok(await _roleService.GetAllAsync());
  }
}