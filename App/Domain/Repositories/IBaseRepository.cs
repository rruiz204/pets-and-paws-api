using System.Linq.Expressions;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
  Task<List<T>> GetAllAsync();
  Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
  Task<T?> GetAsync(int id);
  Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
  Task CreateAsync(T entity);
  Task DeleteAsync(T entity);
  Task UpdateAsync(T entity);
}