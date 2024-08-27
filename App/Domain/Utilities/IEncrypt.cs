namespace Pets_And_Paws_Api.App.Domain.Utilities;

public interface IEncrypt
{
  string Hash(string password);
  bool Verify(string hash, string password);
}