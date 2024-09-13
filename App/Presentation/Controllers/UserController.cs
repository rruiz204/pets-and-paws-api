using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets_And_Paws_Api.App.Domain.Services;

namespace Pets_And_Paws_Api.App.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
  private readonly IUserService _userService = userService;

  [HttpGet]
  [Authorize(Policy = "user:read")]
  public async Task<IActionResult> GetAllUsers()
  {
    return Ok(await _userService.GetAllAsync());
  }
}