using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pets_and_paws_api.App.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddScopesToAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleScope_Scopes_PermissionId",
                table: "RoleScope");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "RoleScope",
                newName: "ScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleScope_PermissionId",
                table: "RoleScope",
                newName: "IX_RoleScope_ScopeId");

            migrationBuilder.InsertData(
                table: "RoleScope",
                columns: new[] { "RoleId", "ScopeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleScope_Scopes_ScopeId",
                table: "RoleScope",
                column: "ScopeId",
                principalTable: "Scopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleScope_Scopes_ScopeId",
                table: "RoleScope");

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RoleScope",
                keyColumns: new[] { "RoleId", "ScopeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.RenameColumn(
                name: "ScopeId",
                table: "RoleScope",
                newName: "PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleScope_ScopeId",
                table: "RoleScope",
                newName: "IX_RoleScope_PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleScope_Scopes_PermissionId",
                table: "RoleScope",
                column: "PermissionId",
                principalTable: "Scopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
