using Domain.Entities;
using FluentAssertions;
using Infrastructure.Database.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTest.Repositories;

public class UserRepositoryTest
{
  private readonly PgDbContext _context;

  public UserRepositoryTest()
  {
    var builder = new DbContextOptionsBuilder<PgDbContext>()
      .UseInMemoryDatabase(databaseName: "pets-and-paws-test");
    
    _context = new PgDbContext(builder.Options);
  }

  [Fact]
  public async Task GetUser()
  {
    // Arrange
    var user = new User { Id = 1, FirstName = "tester", LastName = "tester", Email = "tester@gmail.com", Password = "12345678" };
    _context.User.Add(user);
    await _context.SaveChangesAsync();
    var repository = new UserRepository(_context);

    // Atc
    var users = await repository.GetUsers();

    // Assert
    users.Should().NotBeNull();
    users[0].Email.Should().BeEquivalentTo(user.Email);
  }
}