using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pets_and_paws_api.App.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 1, "admin@admin.com", "admin", "", "12345678", "", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
