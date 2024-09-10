using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IRoleService
{
  Task<List<Role>> GetAllAsync();
}