using Microsoft.AspNetCore.Mvc;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Auth;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.Auth;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Passwd;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Domain.Utilities;

namespace Pets_And_Paws_Api.App.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    return Ok(new AuthDTO(_tokens.Generate(registeredUser)));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
  {
    User loggedUser = await _authService.LoginUser(dto);
    return Ok(new AuthDTO(_tokens.Generate(loggedUser)));
  }

  [HttpPost("Forget")]
  public async Task<IActionResult> Forget([FromBody] ForgetPasswordDTO dto)
  {
    await _authService.SendRecoveryEmail(dto);
    return Ok(new { message = "email sended!" });
  }

  [HttpPost("Reset")]
  public async Task<IActionResult> Reset([FromBody] ResetPasswordDTO dto)
  {
    await _authService.ResetPassword(dto);
    return Ok(new { message = "password updated!" });
  }
}