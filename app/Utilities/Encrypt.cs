using Pets_And_Paws_Api.App.Models;
using Microsoft.AspNetCore.Identity;
using Pets_And_Paws_Api.App.Utilities.Interfaces;

namespace Pets_And_Paws_Api.App.Utilities;

public class Encrypt : IEncrypt
{
  private readonly PasswordHasher<User> _hasher = new();

  public string Hash(string password) => _hasher.HashPassword(null!, password);

  public bool Verify(string hash, string password)
  {
    return _hasher.VerifyHashedPassword(null!, hash, password) == PasswordVerificationResult.Success;
  }
}