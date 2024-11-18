using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.HasData(
      new Role { Id = 1, Name = "admin", Description = "Responsible for the overall management of the system, with full access to all functions and configurations." },
      new Role { Id = 2, Name = "veterinarian", Description = "Provides medical care to animals, performs diagnostics, treatments, and surgeries, and ensures animal health and safety." },
      new Role { Id = 3, Name = "assistant", Description = "Supports veterinarians with patient care, helps prepare animals and equipment, and manages routine tasks in the clinic." },
      new Role { Id = 4, Name = "receptionist", Description = "Manages appointments, handles client check-ins, processes payments, and provides information to clients about services." },
      new Role { Id = 5, Name = "laboratory-technician", Description = "Conducts tests and analyses on samples, supports diagnostics, and maintains laboratory equipment and records." },
      new Role { Id = 6, Name = "adoption-specialist", Description = "Assists clients with pet adoption, provides information on animals, and ensures adoption procedures are followed." },
      new Role { Id = 7, Name = "pharmacist", Description = "Manages and dispenses medications, advises clients on treatments, and ensures pharmaceutical compliance and inventory." }
    );
  }
}