using Domain.Repositories;

namespace Domain.Database;

public interface IUnitOfWork
{
  Task<IPgTransaction> StartTransaction();
  IUserRepository User { get; }
  IResetTokenRepository ResetToken { get; }
}