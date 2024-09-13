using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Domain.Utilities;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class UserSeed : IEntityTypeConfiguration<User>
{
  // Password = 12345678
  private const string password = "AQAAAAIAAYagAAAAENG9AhRVMNmmMHnAGmgFw4By3LxV9lekn7r6KC+RJrmRvFYgE2gcgW7G8I3EelghhA==";

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