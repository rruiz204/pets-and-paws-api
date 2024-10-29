using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class PasswordHasherService(PasswordHasher<User> hasher) : IPasswordHasherService
{
  private readonly PasswordHasher<User> _hasher = hasher;
  
  public string Hash(string password) => _hasher.HashPassword(null!, password);

  public bool Verify(string password, string hash)
    => _hasher.VerifyHashedPassword(null!, hash, password) == PasswordVerificationResult.Success;
}