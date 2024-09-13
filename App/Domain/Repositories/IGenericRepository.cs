using System.Linq.Expressions;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
  Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
  Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
  Task<T> CreateAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}