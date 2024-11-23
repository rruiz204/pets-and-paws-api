using Domain.Entities;

namespace Domain.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
  Task<List<Role>> GetAllRoles();
}