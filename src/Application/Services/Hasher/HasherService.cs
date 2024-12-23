using Domain.Entities;
using Domain.Services.Hasher;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Hasher;

public class HasherService(PasswordHasher<User> hasher) : IHasherService
{
  private readonly PasswordHasher<User> _hasher = hasher;
  
  public string Hash(string password) => _hasher.HashPassword(null!, password);

  public bool Verify(string password, string hash)
    => _hasher.VerifyHashedPassword(null!, hash, password) == PasswordVerificationResult.Success;
}