using Pets_And_Paws_Api.App.Models;
using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Database;
using Pets_And_Paws_Api.App.Repositories.Interfaces;

namespace Pets_And_Paws_Api.App.Repositories;

public class ResetTokenRepository(DatabaseContext context) : IResetTokenRepository
{
  private readonly DatabaseContext _context = context;

  public async Task<ResetToken> CreateResetToken(ResetToken token)
  {
    await _context.ResetToken.AddAsync(token);
    await _context.SaveChangesAsync();
    return token;
  }

  public async Task<bool> DeleteResetToken(ResetToken token)
  {
    _context.ResetToken.Remove(token);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<ResetToken?> FindValidToken(string token)
  {
    return await _context.ResetToken
      .FirstOrDefaultAsync(rt => rt.Token == token && rt.Expiration > DateTime.UtcNow);
  }
}