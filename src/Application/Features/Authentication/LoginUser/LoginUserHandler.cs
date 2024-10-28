using Domain.Database;
using MediatR;

namespace Application.Features.Authentication.LoginUser;

public class LoginUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<LoginUserResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
  {
    var user = await _unitOfWork.User.Find(u => u.Email == command.Email)
      ?? throw new InvalidDataException("this user does not exists");

    return new LoginUserResponse {
      Token = "fake token xd",
      Type = "Bearer"
    };
  }
}