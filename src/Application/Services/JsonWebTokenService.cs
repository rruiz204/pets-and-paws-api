using Domain.Entities;
using Domain.Services.JsonWebTokens;

namespace Application.Services;

public class JsonWebTokenService : IJsonWebTokenService
{
  /* private readonly JsonWebTokenSettings _settings = settings;
  public TokenValidationParameters ValidationParameters => new()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = _settings.Issuer,
    ValidAudience = _settings.Audience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey))
  }; */

  public JsonWebTokenModel CreateToken(User user)
  {
    throw new NotImplementedException();
  }
}