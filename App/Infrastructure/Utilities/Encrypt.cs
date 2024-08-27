using Pets_And_Paws_Api.App.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Pets_And_Paws_Api.App.Domain.Utilities;

namespace Pets_And_Paws_Api.App.Infrastructure.Utilities;

public class Encrypt : IEncrypt
{
  private readonly PasswordHasher<User> _hasher = new();

  public string Hash(string password) => _hasher.HashPassword(null!, password);

  public bool Verify(string hash, string password)
  {
    return _hasher.VerifyHashedPassword(null!, hash, password) == PasswordVerificationResult.Success;
  }
}