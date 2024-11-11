using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ScopeConfig : IEntityTypeConfiguration<Scope>
{
  public void Configure(EntityTypeBuilder<Scope> builder)
  {
    builder.HasData(
      new Scope { Id = 1, Name = "pets-directory:read", Description = "Allows viewing the list and details of pets" },
      new Scope { Id = 2, Name = "pets-directory:create", Description = "Allows adding new pets to the directory" },
      new Scope { Id = 3, Name = "pets-directory:update", Description = "Allows editing information of existing pets" },
      new Scope { Id = 4, Name = "pets-directory:delete", Description = "Allows deleting pets from the directory" }
    );
  }
}