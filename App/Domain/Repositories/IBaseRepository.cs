using System.Linq.Expressions;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
  Task<T?> GetAsync(int id);
  Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
  Task<T> CreateAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}