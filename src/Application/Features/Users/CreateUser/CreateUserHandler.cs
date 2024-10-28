using Domain.Database;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Users.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    var command = request.Adapt<User>();
    var user = await _unitOfWork.User.Create(command);
    return user.Adapt<CreateUserResponse>();
  }
}