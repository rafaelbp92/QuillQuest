using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuillQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingApplicationUserToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25a91196-3823-4095-b83e-1b72bcca517b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("456f8546-c8cd-4d59-89bf-baeaf9b28be2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4730055f-d947-4e3b-987d-f8632378f91f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c4f9ce3-3d49-4329-ba98-4ce24f8eb791"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d1dd7ab-fef2-43b0-aa33-be7d7b81d722"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9bd04df7-3307-4ab7-bf13-eb853db5e93e"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("07c9f5f2-278e-413d-be14-38f566a9c5ef"), "Julian Button", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "\\images\\product\\966885ea-fa5c-4d4c-8d1b-717d49bf2abe.jpg", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" },
                    { new Guid("2d766c08-e2b0-4a30-9fd2-6dbd83474294"), "Billy Spark", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "\\images\\product\\333ef4f7-fcff-405e-b1c9-12b93f761af4.jpg", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("355953ea-c431-40df-a26d-4399b554ca46"), "Laura Phantom", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\fd9fcccf-75ad-4305-960f-9e776c080d3c.jpg", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { new Guid("4357b0c1-45ae-45a3-8010-0371880c07be"), "Abby Muscles", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "\\images\\product\\08291c8d-90d6-407f-a7d2-8f5f10f0eee4.jpg", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("7d075759-0c17-486d-81e3-08af57fc41c4"), "Nancy Hoover", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "\\images\\product\\9c3c9229-e77b-49d3-9178-745b2650f41d.jpg", 40.0, 30.0, 20.0, 25.0, "Dark Skies" },
                    { new Guid("913e25f5-56f6-49c8-bb70-0b1ea5db1eba"), "Ron Parker", new Guid("f7b462a5-8581-4b90-b009-05c316f0e691"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "\\images\\product\\d995464f-3e24-4283-bb74-d52c9f7fa470.jpg", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("07c9f5f2-278e-413d-be14-38f566a9c5ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d766c08-e2b0-4a30-9fd2-6dbd83474294"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("355953ea-c431-40df-a26d-4399b554ca46"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4357b0c1-45ae-45a3-8010-0371880c07be"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d075759-0c17-486d-81e3-08af57fc41c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("913e25f5-56f6-49c8-bb70-0b1ea5db1eba"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("25a91196-3823-4095-b83e-1b72bcca517b"), "Abby Muscles", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "\\images\\product\\08291c8d-90d6-407f-a7d2-8f5f10f0eee4.jpg", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("456f8546-c8cd-4d59-89bf-baeaf9b28be2"), "Ron Parker", new Guid("f7b462a5-8581-4b90-b009-05c316f0e691"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "\\images\\product\\d995464f-3e24-4283-bb74-d52c9f7fa470.jpg", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("4730055f-d947-4e3b-987d-f8632378f91f"), "Laura Phantom", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\fd9fcccf-75ad-4305-960f-9e776c080d3c.jpg", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { new Guid("4c4f9ce3-3d49-4329-ba98-4ce24f8eb791"), "Billy Spark", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "\\images\\product\\333ef4f7-fcff-405e-b1c9-12b93f761af4.jpg", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("6d1dd7ab-fef2-43b0-aa33-be7d7b81d722"), "Nancy Hoover", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "\\images\\product\\9c3c9229-e77b-49d3-9178-745b2650f41d.jpg", 40.0, 30.0, 20.0, 25.0, "Dark Skies" },
                    { new Guid("9bd04df7-3307-4ab7-bf13-eb853db5e93e"), "Julian Button", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "\\images\\product\\966885ea-fa5c-4d4c-8d1b-717d49bf2abe.jpg", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" }
                });
        }
    }
}
