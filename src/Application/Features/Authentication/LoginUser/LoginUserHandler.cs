using Domain.Database;
using Domain.Services;
using MediatR;

namespace Application.Features.Authentication.LoginUser;

public class LoginUserHandler(
  IUnitOfWork unitOfWork,
  IPasswordHasherService hasher,
  IJwtService jwtService) : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IPasswordHasherService _hasher = hasher;
  private readonly IJwtService _jwtService = jwtService;

  public async Task<LoginUserResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
  {
    var user = await _unitOfWork.User.Find(u => u.Email == command.Email)
      ?? throw new InvalidDataException("this user does not exists");

    if (!_hasher.Verify(command.Password, user.Password))
      throw new InvalidDataException("incorrect credentials");

    var token = _jwtService.GenerateToken(user);
    return new LoginUserResponse {
      Token = token,
      Type = "Bearer"
    };
  }
}