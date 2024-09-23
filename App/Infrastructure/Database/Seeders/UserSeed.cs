using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class UserSeed(IConfiguration config) : IEntityTypeConfiguration<User>
{
  private readonly string password = config["DefaultPassword"]!;

    public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasData(
      new User()
      {
        Id = 1,
        FirstName = "admin",
        Email = "admin@admin.com",
        Password = password,
        RoleId = 1
      },
      new User()
      {
        Id = 2,
        FirstName = "tester",
        Email = "tester@tester.com",
        Password = password,
        RoleId = 2
      }
    );
  }
}