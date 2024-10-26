using Domain.Database;
using Domain.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure.Database.Context;

public class UnitOfWork(PgDbContext context) : IUnitOfWork
{
  private readonly PgDbContext _context = context;

  private IUserRepository? _user;
  public IUserRepository User => _user ??= new UserRepository(_context);
}