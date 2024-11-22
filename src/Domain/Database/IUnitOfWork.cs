using Domain.Repositories;

namespace Domain.Database;

public interface IUnitOfWork
{
  Task<IPgTransaction> StartTransaction();
  Task<int> SaveChangesAsync();

  IUserRepository User { get; }
  IRoleRepository Role { get; }
  IScopeRepository Scope {get; }
  IResetTokenRepository ResetToken { get; }
}