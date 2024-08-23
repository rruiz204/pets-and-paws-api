namespace Pets_And_Paws_Api.App.DTO.Authentication;

public class AuthResponseDTO(string token)
{
  public string Type { get; set; } = "Bearer";
  public string Token { get; set; } = token;
}