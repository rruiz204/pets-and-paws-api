using MediatR;

namespace Application.Features.Authentication.LoginUser;

public class LoginUserCommand : IRequest<LoginUserResponse>
{
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}