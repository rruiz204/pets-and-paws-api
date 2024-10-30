using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Services;
using Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Jwt;

public partial class JwtService(IOptions<JwtSettings> jwtSettings, IHttpContextAccessor context) : IJwtService
{
  private readonly JwtSettings _jwtSettings = jwtSettings.Value;
  private readonly IHttpContextAccessor _context = context;

  public string GenerateToken(User user)
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

  public int? GetUserIdFromToken()
  {
    var user = _context.HttpContext?.User;

    if (user != null)
    {
      var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if (int.TryParse(userIdClaim, out int userId)) return userId;
    }
    
    return null;
  }
}