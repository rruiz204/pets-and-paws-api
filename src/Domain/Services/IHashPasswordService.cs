namespace Domain.Services;

public interface IHashPasswordService
{
  string Hash(string password) ;
  bool Verify(string password, string hash);
}