using Domain.Database;
using Domain.Services.Jwt;
using Domain.Services.Policy;

namespace Application.Services.Policy;

public class PolicyService(IUnitOfWork unitOfWork, IJwtService jwtService) : IPolicyService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IJwtService _jwtService = jwtService;

  public async Task<bool> Handle(string[] roles, string[] scopes)
  {
    var user = await _unitOfWork.User.FindWithRolesAndScopes(_jwtService.GetCurrentUser())
      ?? throw new InvalidDataException("User with this email does not exist.");

    var hasAnyRole = roles.Intersect(user.UserRoles.Select(ur => ur.Role.Name)).Any();
    if (!hasAnyRole) return false;

    var hasAnyScope = scopes.Intersect(user.UserRoles
      .SelectMany(ur => ur.Role.RoleScopes)
      .Select(rs => rs.Scope.Name)).Any();
    if (!hasAnyScope) return false;

    return true;
  }
}