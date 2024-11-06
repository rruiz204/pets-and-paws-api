using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Generic;

namespace Infrastructure.Repositories;

public class ResetTokenRepository(PgDbContext context) : GenericRepository<ResetToken>(context), IResetTokenRepository
{

}