using System.Text;
using System.Security.Claims;
using Pets_And_Paws_Api.App.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Pets_And_Paws_Api.App.Utilities.Interfaces;

namespace Pets_And_Paws_Api.App.Utilities;

public class Tokens(IConfiguration config) : ITokens
{
  private readonly IConfiguration _config = config;

  public string Generate(User user)
  {
    SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
    SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

    List<Claim> claims = [new(JwtRegisteredClaimNames.Sub, user.Id.ToString())];

    JwtSecurityToken token = new(
      issuer: _config["JWT:Issuer"],
      audience: _config["JWT:Audience"],
      claims: claims,
      expires: DateTime.Now.AddHours(3),
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}