using Domain.Repositories;

namespace Domain.Database;

public interface IUnitOfWork
{
  IUserRepository User { get; }
}