using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.Repositories.Interfaces;

public interface IResetTokenRepository
{
  Task<ResetToken> CreateResetToken(ResetToken token);
  Task<bool> DeleteResetToken(ResetToken token);
  Task<ResetToken?> FindValidToken(string token);
}