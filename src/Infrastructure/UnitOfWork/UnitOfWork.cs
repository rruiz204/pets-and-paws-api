using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Database.Context;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(PgDbContext context) : IUnitOfWork
{
  private readonly PgDbContext _context = context;

  private IUserRepository? _user;
  public IUserRepository User => _user ??= new UserRepository(_context);
}