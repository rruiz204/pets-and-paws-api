using Domain.Database;
using MediatR;

namespace Application.Features.Roles.GetMyRoles;

public class GetMyRolesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetMyRolesQuery, GetMyRolesResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async  Task<GetMyRolesResponse> Handle(GetMyRolesQuery request, CancellationToken cancellationToken)
  {
    var user = await _unitOfWork.User.FindWithRolesAndScopes(request.UserId)
      ?? throw new InvalidDataException("This user doesn't exists");

    var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

    var scopes = user.UserRoles.SelectMany(ur => ur.Role.RoleScopes)
      .Select(rs => rs.Scope.Name).Distinct().ToList();

    return new GetMyRolesResponse {
      Roles = roles,
      Scopes = scopes,
    };
  }
}