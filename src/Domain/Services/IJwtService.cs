using Domain.Entities;

namespace Domain.Services;

public interface IJwtService
{
  string GenerateToken(User user);
}