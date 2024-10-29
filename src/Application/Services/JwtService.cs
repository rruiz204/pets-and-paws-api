using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Services;
using Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtService(IOptions<JwtSettings> jwtSettings) : IJwtService
{
  private readonly JwtSettings _jwtSettings = jwtSettings.Value;

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

  public static JwtBearerEvents GetEvents()
  {
    return new JwtBearerEvents
    {
      OnAuthenticationFailed = context =>
      {
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new { message = "Invalid token" });
      },
      OnChallenge = context =>
      {
        context.HandleResponse();
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new { message = "Token is missing" });
      }
    };
  }
}