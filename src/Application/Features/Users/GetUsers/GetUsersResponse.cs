namespace Application.Features.Users.GetUsers;

public class GetUsersResponse
{
  public int Id { get; set; }
  public string FullName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
}