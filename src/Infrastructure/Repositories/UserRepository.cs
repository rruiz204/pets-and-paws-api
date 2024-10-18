using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Factories.DbContextFactory;
using Infrastructure.Repositories.Generic;

namespace Infrastructure.Repositories;

public class UserRepository(IDbContextFactory factory) : GenericRepository<User>(factory), IUserRepository
{

}