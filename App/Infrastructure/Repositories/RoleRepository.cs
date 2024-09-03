using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Domain.Repositories;
using Pets_And_Paws_Api.App.Infrastructure.Database;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class RoleRepository(DatabaseContext context) 
  : BaseRepository<Role>(context), IRoleRepository
{

}