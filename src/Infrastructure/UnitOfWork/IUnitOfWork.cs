using Domain.Repositories;

namespace Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
  IUserRepository User { get; }
}