using Domain.Database;
using Domain.Entities;
using Domain.Services;
using Mapster;
using MediatR;

namespace Application.Features.Users.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork, IPasswordHasherService hasher) : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IPasswordHasherService _hasher = hasher;

  public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    var command = request.Adapt<User>();
    command.Password = _hasher.Hash(command.Password);

    if (await _unitOfWork.User.Find(u => u.Email == command.Email || u.FirstName == command.FirstName) != null)
      throw new InvalidDataException("credentials in use");

    var user = await _unitOfWork.User.Create(command);
    return user.Adapt<CreateUserResponse>();
  }
}