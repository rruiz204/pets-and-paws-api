namespace Domain.Services.HashPassword;

public interface IHashPasswordService
{
  string Hash(string password) ;
  bool Verify(string password, string hash);
}