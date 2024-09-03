using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models.Relationships;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Configuration;

public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
{
  public void Configure(EntityTypeBuilder<RolePermission> builder)
  {
    builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

    builder.HasOne(rp => rp.Role)
      .WithMany(r => r.Permissions)
      .HasForeignKey(rp => rp.RoleId);

    builder.HasOne(rp => rp.Permission)
      .WithMany(p => p.Roles)
      .HasForeignKey(rp => rp.PermissionId);
  }
}