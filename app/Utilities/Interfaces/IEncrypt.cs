namespace Pets_And_Paws_Api.App.Utilities.Interfaces;

public interface IEncrypt
{
  string Hash(string password);
  bool Verify(string hash, string password);
}