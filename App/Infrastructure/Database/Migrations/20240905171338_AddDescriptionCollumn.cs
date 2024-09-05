using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pets_and_paws_api.App.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Scopes",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Role",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Scopes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Role");
        }
    }
}
