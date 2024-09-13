using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pets_and_paws_api.App.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTesterUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Responsible for testing and ensuring the quality of software", "tester" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 2, "tester@tester.com", "tester", "", "AQAAAAIAAYagAAAAENG9AhRVMNmmMHnAGmgFw4By3LxV9lekn7r6KC+RJrmRvFYgE2gcgW7G8I3EelghhA==", "", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
