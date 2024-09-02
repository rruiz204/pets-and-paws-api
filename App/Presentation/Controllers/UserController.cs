using Microsoft.AspNetCore.Mvc;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Presentation.Filters;

namespace Pets_And_Paws_Api.App.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[TypeFilter<ArgumentExceptionFilter>]
public class UserController(IUserService userService) : ControllerBase
{
  private readonly IUserService _userService = userService;

  [HttpGet]
  public async Task<IActionResult> GetAllUsers()
  {
    return Ok(await _userService.GetAllAsync());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetOneUser(int id)
  {
    return Ok(await _userService.GetAsync(id));
  }
}