using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(PgDbContext context) : GenericRepository<User>(context), IUserRepository
{
  public async Task<List<User>> GetUsers()
  {
    return await dbSet.ToListAsync();
  }
}