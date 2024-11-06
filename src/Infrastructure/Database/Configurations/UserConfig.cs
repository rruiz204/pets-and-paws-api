using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    /* builder.HasData(
      new User { Id = 1, FirstName = "admin", LastName = "admin", Email = "admin@admin.com", Password = "" }
    ); */
  }
}