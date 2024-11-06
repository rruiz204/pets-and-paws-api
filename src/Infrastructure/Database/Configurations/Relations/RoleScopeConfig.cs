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
  }
}