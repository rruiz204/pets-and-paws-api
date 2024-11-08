using Domain.Database;
using Domain.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure.Database.Context;

public class UnitOfWork(PgDbContext context) : IUnitOfWork
{
  private readonly PgDbContext _context = context;

  public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

  public async Task<IPgTransaction> StartTransaction()
    => new PgTransaction(await _context.Database.BeginTransactionAsync());

  private IUserRepository? _user;
  public IUserRepository User => _user ??= new UserRepository(_context);

  private IResetTokenRepository? _resetToken;
  public IResetTokenRepository ResetToken => _resetToken ??= new ResetTokenRepository(_context);
}