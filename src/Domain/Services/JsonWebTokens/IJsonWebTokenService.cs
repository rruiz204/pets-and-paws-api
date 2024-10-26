using Domain.Entities;

namespace Domain.Services.JsonWebTokens;

public interface IJsonWebTokenService
{
  JsonWebTokenModel CreateToken(User user);
}