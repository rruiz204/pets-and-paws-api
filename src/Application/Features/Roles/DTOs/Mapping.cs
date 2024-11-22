using Domain.Entities;
using Mapster;

namespace Application.Features.Roles.DTOs;

public class Mapping
{
  public static TypeAdapterConfig GetConfig()
  {
    var config = new TypeAdapterConfig();

    config.NewConfig<Role, RoleDTO>()
      .Map(dest => dest.Scopes, src => src.RoleScopes.Select(rs => rs.Scope.Id).ToList());

    return config;
  }
}