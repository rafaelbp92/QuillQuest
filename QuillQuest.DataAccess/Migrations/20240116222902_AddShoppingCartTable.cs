using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuillQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("001e1120-66de-4076-9975-40ccf01b5e02"), "Ron Parker", new Guid("f7b462a5-8581-4b90-b009-05c316f0e691"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "\\images\\product\\d995464f-3e24-4283-bb74-d52c9f7fa470.jpg", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("5b893726-c613-45ee-a9c3-3e1187c9aaf9"), "Abby Muscles", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "\\images\\product\\08291c8d-90d6-407f-a7d2-8f5f10f0eee4.jpg", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("70fac434-a9f7-4904-a939-1034bf5033a5"), "Billy Spark", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "\\images\\product\\333ef4f7-fcff-405e-b1c9-12b93f761af4.jpg", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("7e80142e-9f63-4e6b-ab1e-0bc4fbfa49bc"), "Laura Phantom", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\fd9fcccf-75ad-4305-960f-9e776c080d3c.jpg", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { new Guid("a514d3dd-8c9d-4b78-bc8c-d668c3b51e27"), "Julian Button", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "\\images\\product\\966885ea-fa5c-4d4c-8d1b-717d49bf2abe.jpg", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" },
                    { new Guid("bd571a72-854f-4ec5-a159-91d0303f8be8"), "Nancy Hoover", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "\\images\\product\\9c3c9229-e77b-49d3-9178-745b2650f41d.jpg", 40.0, 30.0, 20.0, 25.0, "Dark Skies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("001e1120-66de-4076-9975-40ccf01b5e02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b893726-c613-45ee-a9c3-3e1187c9aaf9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70fac434-a9f7-4904-a939-1034bf5033a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e80142e-9f63-4e6b-ab1e-0bc4fbfa49bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a514d3dd-8c9d-4b78-bc8c-d668c3b51e27"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd571a72-854f-4ec5-a159-91d0303f8be8"));

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
        }
    }
}
