using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "Provides medical care to animals, performs diagnostics, treatments, and surgeries, and ensures animal health and safety.", "veterinarian" },
                    { 3, "Supports veterinarians with patient care, helps prepare animals and equipment, and manages routine tasks in the clinic.", "assistant" },
                    { 4, "Manages appointments, handles client check-ins, processes payments, and provides information to clients about services.", "receptionist" },
                    { 5, "Conducts tests and analyses on samples, supports diagnostics, and maintains laboratory equipment and records.", "laboratory-technician" },
                    { 6, "Assists clients with pet adoption, provides information on animals, and ensures adoption procedures are followed.", "adoption-specialist" },
                    { 7, "Manages and dispenses medications, advises clients on treatments, and ensures pharmaceutical compliance and inventory.", "pharmacist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
