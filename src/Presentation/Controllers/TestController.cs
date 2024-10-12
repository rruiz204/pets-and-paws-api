using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class TestController : BaseApiController
{
  [HttpGet("test/get")]
  public IActionResult GetTest()
  {
    return Ok(new { message = "testing get method" });
  }
}