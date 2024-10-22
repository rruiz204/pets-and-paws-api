using Domain.UnitOfWork;
using MediatR;
using Mapster;

namespace Application.Features.Users.GetUsers;

public class GetUsersHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUsersQuery, List<GetUsersResponse>>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<List<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
  {
    var users = await _unitOfWork.User.GetUsers();
    GetUsersMapping.RegisterMapping();
    var response = users.Adapt<List<GetUsersResponse>>();
    return response;
  }
}