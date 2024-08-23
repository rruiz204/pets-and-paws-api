using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.Utilities.Interfaces;

public interface ITokens
{
  string Generate(User user);
}