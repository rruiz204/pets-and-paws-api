using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Database.Contexts;
using Infrastructure.Factories.DbContextFactory;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(IDbContextFactory factory) : IUnitOfWork
{
  private readonly BaseDbContext context = factory.GetDbContext();

  private IUserRepository? _user;
  public IUserRepository User => _user ??= new UserRepository(context);
}