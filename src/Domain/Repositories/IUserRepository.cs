using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
  Task<List<User>> GetUsers ();
  Task<User?> FindWithRolesAndScopes(int userId);
}