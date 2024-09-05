using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class PermissionSeed : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
    builder.HasData(
      /* User Modele Scopes */
      new Permission() { Id = 1, Name = "user:read" },
      new Permission() { Id = 2, Name = "user:write" },
      new Permission() { Id = 3, Name = "user:update" },
      new Permission() { Id = 4, Name = "user:delete" }
    );
  }
}