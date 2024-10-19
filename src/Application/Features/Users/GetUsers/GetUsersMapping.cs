using Domain.Entities;
using Mapster;

namespace Application.Features.Users.GetUsers;

public class GetUsersMapping
{
  public static void RegisterMapping()
  {
    TypeAdapterConfig<User, GetUsersResponse>.NewConfig()
      .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
  }
}