using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Utilities;

public interface ITokens
{
  string Generate(User user);
}