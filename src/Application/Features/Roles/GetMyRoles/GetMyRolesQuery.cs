using MediatR;

namespace Application.Features.Roles.GetMyRoles;

public class GetMyRolesQuery : IRequest<GetMyRolesResponse>
{
  public int UserId { get; set; }
}