using Microsoft.AspNetCore.Mvc;
using Pets_And_Paws_Api.App.DTO.Authentication;
using Pets_And_Paws_Api.App.Filters;
using Pets_And_Paws_Api.App.Models;
using Pets_And_Paws_Api.App.Services.Interfaces;
using Pets_And_Paws_Api.App.Utilities.Interfaces;

namespace Pets_And_Paws_Api.App.Controllers;

[ApiController]
[Route("api/[controller]")]
[TypeFilter<ArgumentExceptionFilter>]
public class AuthController(
  IAuthService authService,
  ITokens tokens
) : ControllerBase
{
  private readonly IAuthService _authService = authService;
  private readonly ITokens _tokens = tokens;

  [HttpPost("Register")]
  public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
  {
    User registeredUser = await _authService.RegisterUser(dto);
    return Ok(new AuthResponseDTO(_tokens.Generate(registeredUser)));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
  {
    User loggedUser = await _authService.LoginUser(dto);
    return Ok(new AuthResponseDTO(_tokens.Generate(loggedUser)));
  }
}