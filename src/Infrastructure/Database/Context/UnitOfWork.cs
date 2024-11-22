using Domain.Database;
using Domain.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure.Database.Context;

public class UnitOfWork(PgDbContext context) : IUnitOfWork
{
  private readonly PgDbContext _context = context;

  public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

  public async Task<IPgTransaction> StartTransaction()
  {
    return new PgTransaction(await _context.Database.BeginTransactionAsync());
  }


  private IUserRepository? _user;
  public IUserRepository User => _user ??= new UserRepository(_context);

  private IRoleRepository? _role;
  public IRoleRepository Role => _role ??= new RoleRepository(_context);

  private IScopeRepository? _scope;
  public IScopeRepository Scope => _scope ??= new ScopeRepository(_context);

  private IResetTokenRepository? _resetToken;
  public IResetTokenRepository ResetToken => _resetToken ??= new ResetTokenRepository(_context);
}