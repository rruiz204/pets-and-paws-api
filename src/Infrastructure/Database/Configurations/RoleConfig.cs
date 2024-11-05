using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder
      .HasMany(r => r.Claims)
      .WithMany(c => c.Roles)
      .UsingEntity(j => j.ToTable("RoleClaim"));

    builder.HasData(
      new Role { Id = 1, Name = "admin", Description = "Responsible for the overall management of the system, with full access to all functions and configurations." }
    );
  }
}