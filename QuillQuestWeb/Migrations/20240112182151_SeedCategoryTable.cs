using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuillQuestWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { new Guid("1d63cdb7-1055-4bb5-8b6d-ae2c4ba5bcad"), 2, "SciFi" },
                    { new Guid("85162168-06cc-4ed5-a754-5cddb2f15fd2"), 3, "History" },
                    { new Guid("af7ddb58-3f36-4b2a-86de-8a41b24a6631"), 1, "Action" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d63cdb7-1055-4bb5-8b6d-ae2c4ba5bcad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("85162168-06cc-4ed5-a754-5cddb2f15fd2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af7ddb58-3f36-4b2a-86de-8a41b24a6631"));
        }
    }
}
