using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class ScopeSeed : IEntityTypeConfiguration<Scope>
{
  public void Configure(EntityTypeBuilder<Scope> builder)
  {
    builder.HasData(
      /* User Modele Scopes */
      new Scope() { Id = 1, Name = "user:read", Description = "Allows you to read user information" },
      new Scope() { Id = 2, Name = "user:write", Description = "Allows you to create new user records" },
      new Scope() { Id = 3, Name = "user:update", Description = "Allows modification of existing user information" },
      new Scope() { Id = 4, Name = "user:delete", Description = "Allows deletion of user records" }
    );
  }
}