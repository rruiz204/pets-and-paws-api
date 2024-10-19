using MediatR;

namespace Application.Features.Users.CreateUser;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}