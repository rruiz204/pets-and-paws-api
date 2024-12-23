using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
  Task<T?> Find(int id);
  Task<T?> Find(Expression<Func<T, bool>> predicate);
  Task<T> Create(T entity);
  void Delete(T entity);
}