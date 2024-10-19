using Infrastructure.UnitOfWork;
using MediatR;
using Mapster;
using Domain.Entities;
using Domain.Services;

namespace Application.Features.Users.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork, IHashPasswordService hasher) : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IHashPasswordService _hasher = hasher;

  public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    var command = request.Adapt<User>();
    command.Password = _hasher.Hash(request.Password);

    var user = await _unitOfWork.User.Create(command);
    var response = user.Adapt<CreateUserResponse>();
    return response;
  }
}