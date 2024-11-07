using Domain.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Database.Context;

public class PgTransaction(IDbContextTransaction transaction) : IPgTransaction
{
  private readonly IDbContextTransaction _transaction = transaction;

  public async Task Commit()
  {
    await _transaction.CommitAsync();
    await _transaction.DisposeAsync();
  }

  public async Task Rollback()
  {
    await _transaction.RollbackAsync();
    await _transaction.DisposeAsync();
  }

  public void Dispose()
  {
    _transaction.Dispose();
    GC.SuppressFinalize(this);
  }
}