using Pets_And_Paws_Api.App.Domain.Repositories;

namespace Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
  IUserRepository Users { get; }
  IResetTokenRepository Tokens { get; }
}