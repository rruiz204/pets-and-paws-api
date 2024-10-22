using Domain.Repositories;

namespace Domain.UnitOfWork;

public interface IUnitOfWork
{
  IUserRepository User { get; }
}