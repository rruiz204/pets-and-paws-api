using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IRoleRepository
{
  Task<List<Role>> GetAllRolesAsync();
}