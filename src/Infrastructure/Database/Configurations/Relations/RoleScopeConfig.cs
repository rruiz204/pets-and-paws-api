using Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Relations;

public class RoleScopeConfig : IEntityTypeConfiguration<RoleScope>
{
  public void Configure(EntityTypeBuilder<RoleScope> builder)
  {
    builder.HasKey(rs => new { rs.RoleId, rs.ScopeId });

    builder
      .HasOne(rs => rs.Role)
      .WithMany(r => r.RoleScopes)
      .HasForeignKey(rs => rs.RoleId);

    builder
      .HasOne(rs => rs.Scope)
      .WithMany(s => s.RoleScopes)
      .HasForeignKey(rs => rs.ScopeId);

    builder.HasData(
      // Admin
      new RoleScope { RoleId = 1, ScopeId = 1 },

      // Veterinarian
      new RoleScope { RoleId = 2, ScopeId = 2 },
      new RoleScope { RoleId = 2, ScopeId = 3 },
      new RoleScope { RoleId = 2, ScopeId = 4 },
      new RoleScope { RoleId = 2, ScopeId = 5 }
    );
  }
}