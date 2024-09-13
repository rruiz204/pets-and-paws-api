using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

public class RoleSeed : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.HasData(
      new Role() { Id = 1, Name = "admin", Description = "Full access to all system functionalities" },
      new Role() { Id = 2, Name = "tester", Description = "Responsible for testing and ensuring the quality of software" }
    );
  }
}