using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IResetTokenRepository
{
  Task<ResetToken> CreateResetToken(ResetToken token);
  Task<bool> DeleteResetToken(ResetToken token);
  Task<ResetToken?> FindValidToken(string token);
}