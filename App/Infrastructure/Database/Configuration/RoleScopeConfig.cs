using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets_And_Paws_Api.App.Domain.Models.Relationships;

namespace Pets_And_Paws_Api.App.Infrastructure.Database.Configuration;

public class RoleScopeConfig : IEntityTypeConfiguration<RoleScope>
{
  public void Configure(EntityTypeBuilder<RoleScope> builder)
  {
    builder.HasKey(rp => new { rp.RoleId, rp.ScopeId });

    builder.HasOne(rp => rp.Role)
      .WithMany(r => r.Scopes)
      .HasForeignKey(rp => rp.RoleId);

    builder.HasOne(rp => rp.Scope)
      .WithMany(p => p.Roles)
      .HasForeignKey(rp => rp.ScopeId);

    builder.HasData(
      new RoleScope { RoleId = 1, ScopeId = 1 }, new RoleScope { RoleId = 1, ScopeId = 2 },
      new RoleScope { RoleId = 1, ScopeId = 3 }, new RoleScope { RoleId = 1, ScopeId = 4 }
    );
  }
}