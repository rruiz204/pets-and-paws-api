using Application.Features.Roles.DTOs;
using Domain.Database;
using Mapster;
using MediatR;

namespace Application.Features.Roles.GetAllRoles;

public class GetAllRolesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllRolesQuery, GetAllRolesResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<GetAllRolesResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
  {
    var scopes = (await _unitOfWork.Scope.GetAllScopes()).Adapt<List<ScopeDTO>>();
    var roles = (await _unitOfWork.Role.GetAllRoles()).Adapt<List<RoleDTO>>(Mapping.GetConfig());

    return new GetAllRolesResponse
    {
      Roles = roles,
      Scopes = scopes
    };
  }
}