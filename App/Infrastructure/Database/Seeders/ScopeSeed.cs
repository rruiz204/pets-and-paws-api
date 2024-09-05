using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class PermissionSeed : IEntityTypeConfiguration<Scope>
{
  public void Configure(EntityTypeBuilder<Scope> builder)
  {
    builder.HasData(
      /* User Modele Scopes */
      new Scope() { Id = 1, Name = "user:read" },
      new Scope() { Id = 2, Name = "user:write" },
      new Scope() { Id = 3, Name = "user:update" },
      new Scope() { Id = 4, Name = "user:delete" }
    );
  }
}