using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Services.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Jwt;

public partial class JwtService(
  IOptions<JwtSettings> jwtSettings,
  IHttpContextAccessor contextAccessor) : IJwtService
{
  private readonly JwtSettings _jwtSettings = jwtSettings.Value;
  private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

  public string Generate(User user)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    List<Claim> claims = [new(JwtRegisteredClaimNames.Sub, user.Id.ToString())];

    JwtSecurityToken token = new(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      claims: claims,
      signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  public int GetCurrentUser()
  {
    var user = _contextAccessor.HttpContext?.User
      ?? throw new UnauthorizedAccessException("Token is missing");

    var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
      ?? throw new UnauthorizedAccessException("Corrupted token");

    return int.Parse(userIdClaim);
  }
}