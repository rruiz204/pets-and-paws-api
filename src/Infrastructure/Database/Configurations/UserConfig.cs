using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Configurations;

public class UserConfig(IConfiguration configuration) : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasData(
      new User { Id = 1, FirstName = "admin", LastName = "admin", Email = "admin@admin.com", Password = configuration["DefaultUsers:Admin:Password"]! },
      new User { Id = 2, FirstName = "tester", LastName = "tester", Email = "tester@tester.com", Password = configuration["DefaultUsers:Tester:Password"]! }
    );
  }
}