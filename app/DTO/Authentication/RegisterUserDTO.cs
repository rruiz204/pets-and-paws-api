namespace Pets_And_Paws_Api.App.DTO.Authentication;

public class RegisterUserDTO
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  public string PhoneNumber { get; set; }
}