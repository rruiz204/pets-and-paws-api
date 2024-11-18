using Domain.Entities;

namespace Domain.Services.Jwt;

public interface IJwtService
{
  string Generate(User user);
  int GetCurrentUser();
}