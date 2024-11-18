using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAnScopes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleScope",
                columns: new[] { "RoleId", "ScopeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows access to all modules", "global-access" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows viewing the list and details of pets", "pets-directory:read" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows adding new pets to the directory", "pets-directory:create" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows editing information of existing pets", "pets-directory:update" });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 5, "Allows deleting pets from the directory", "pets-directory:delete" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "tester@tester.com", "tester", "tester", "AQAAAAIAAYagAAAAEJ5qVIICYidnHFACGraHPIwBtNdC1gMeYFEAhQGcWThgLtkhMobm4uj8EbAPPF7CqQ==" });

            migrationBuilder.InsertData(
                table: "RoleScope",
                columns: new[] { "RoleId", "ScopeId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows viewing the list and details of pets", "pets-directory:read" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows adding new pets to the directory", "pets-directory:create" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows editing information of existing pets", "pets-directory:update" });

            migrationBuilder.UpdateData(
                table: "Scope",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Allows deleting pets from the directory", "pets-directory:delete" });
        }
    }
}
