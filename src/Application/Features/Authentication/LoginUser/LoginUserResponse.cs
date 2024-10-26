namespace Application.Features.Authentication.LoginUser;

public class LoginUserResponse
{
  public string Token { get; set; } = string.Empty;
  public string Type { get; set; } = string.Empty;
}