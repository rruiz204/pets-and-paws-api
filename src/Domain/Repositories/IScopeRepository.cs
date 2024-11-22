using Domain.Entities;

namespace Domain.Repositories;

public interface IScopeRepository : IGenericRepository<Scope>
{
  Task<List<Scope>> GetAllScopes();
}