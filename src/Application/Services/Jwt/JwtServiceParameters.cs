using System.Text;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Jwt;

public partial class JwtService : IJwtService
{
  public static TokenValidationParameters GetParameters(IConfiguration configuration)
  {
    var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!);
    return new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = configuration["JwtSettings:Issuer"],
      ValidAudience = configuration["JwtSettings:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(key)
    };
  }
}