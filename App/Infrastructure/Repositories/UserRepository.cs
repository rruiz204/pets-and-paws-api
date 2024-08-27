using Pets_And_Paws_Api.App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Domain.Repositories;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
  private readonly DatabaseContext _context = context;

  public async Task<List<User>> ListUsers()
  {
    return await _context.User.ToListAsync();
  }

  public async Task<User> GetUser(int id)
  {
    return await _context.User.FirstAsync(u => u.Id == id);
  }

  public async Task<User> CreateUser(User user)
  {
    await _context.User.AddAsync(user);
    await _context.SaveChangesAsync();
    return await GetUser(user.Id);
  }

  public async Task<User> UpdateUser(User user)
  {
    _context.User.Update(user);
    await _context.SaveChangesAsync();
    return await GetUser(user.Id);
  }

  public async Task<User?> FindUser(User user)
  {
    return await _context.User.FirstOrDefaultAsync(
      u => u.Email == user.Email || u.FirstName == user.FirstName
    );
  }
}