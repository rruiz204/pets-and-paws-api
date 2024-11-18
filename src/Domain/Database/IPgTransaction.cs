namespace Domain.Database;

public interface IPgTransaction : IDisposable
{
  Task Commit();
  Task Rollback();
}