namespace Domain.Services.Hasher;

public interface IHasherService
{
  string Hash(string password);
  bool Verify(string password, string hash);
}