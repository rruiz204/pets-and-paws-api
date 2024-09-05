using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pets_and_paws_api.App.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class FirstPermissionSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1278), "user:read", new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1280) },
                    { 2, new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1283), "user:write", new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1283) },
                    { 3, new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1284), "user:update", new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1285) },
                    { 4, new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1286), "user:delete", new DateTime(2024, 9, 5, 16, 23, 15, 122, DateTimeKind.Utc).AddTicks(1286) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
