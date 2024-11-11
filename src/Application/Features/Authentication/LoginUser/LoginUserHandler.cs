using Domain.Database;
using Domain.Services.Jwt;
using Domain.Services.Hasher;
using MediatR;

namespace Application.Features.Authentication.LoginUser;

public class LoginUserHandler(
  IUnitOfWork unitOfWork,
  IHasherService hasher,
  IJwtService jwtService) : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IHasherService _hasher = hasher;
  private readonly IJwtService _jwtService = jwtService;

  public async Task<LoginUserResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
  {
    var user = await _unitOfWork.User.Find(u => u.Email == command.Email)
      ?? throw new InvalidDataException($"User with this email does not exist.");

    if (!_hasher.Verify(command.Password, user.Password))
      throw new InvalidDataException("The provided password is incorrect.");

    var token = _jwtService.Generate(user);
    return new LoginUserResponse {
      Token = token,
      Type = "Bearer"
    };
  }
}