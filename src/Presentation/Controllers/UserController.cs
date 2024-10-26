using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class UserController : BaseApiController
{
  [HttpGet("users")]
  public IActionResult GetAllUsers()
  {
    return Ok(new { message = "all users" });
  }
}