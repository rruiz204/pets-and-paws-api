using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Relations;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
  public void Configure(EntityTypeBuilder<UserRole> builder)
  {
    builder.HasKey(ur => new { ur.UserId, ur.RoleId });

    builder
      .HasOne(ur => ur.User)
      .WithMany(u => u.UserRoles)
      .HasForeignKey(ur => ur.UserId);

    builder
      .HasOne(ur => ur.Role)
      .WithMany(r => r.UserRoles)
      .HasForeignKey(ur => ur.RoleId);

    builder.HasData(
      // Admin
      new UserRole { UserId = 1, RoleId = 1 },

      // Tester
      new UserRole { UserId = 2, RoleId = 2 }
    );
  }
}