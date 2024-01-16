using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuillQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingDefaultCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c70cbfa-38f4-49b2-8ea9-74256cbfc134"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9afb8f0c-22ce-4644-9e73-aaace2a762cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac354ac2-0422-4533-b0de-95b72e40f083"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc7caed9-0c36-4ef7-b01a-43c179aee5c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef1e5d3c-d229-483f-aaab-0a6612279ae2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc535e82-1666-4dff-9c8d-e15a4e7a1a82"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("40df0e0d-5e64-4051-990b-60d5a9718ce7"), "Lala land", "Readers Club", "1113335555", "99999", "NY", "999 Main St" },
                    { new Guid("60812648-064a-4bff-94cd-de5ac60de991"), "Vid City", "Vivid Books", "7779990000", "66666", "IL", "999 Vid St" },
                    { new Guid("72b1d6c1-cd17-4299-a700-db1ec9c60f3a"), "Tech City", "Tech Solution", "6669990000", "12121", "IL", "123 Tech St" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("153ec331-54ef-486f-a5bd-f33f10b57c6d"), "Nancy Hoover", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "\\images\\product\\9c3c9229-e77b-49d3-9178-745b2650f41d.jpg", 40.0, 30.0, 20.0, 25.0, "Dark Skies" },
                    { new Guid("59f47040-1293-4aa3-a43c-7183a0e3667e"), "Abby Muscles", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "\\images\\product\\08291c8d-90d6-407f-a7d2-8f5f10f0eee4.jpg", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("93f2500d-99ff-4f57-a76a-fb45104760f9"), "Billy Spark", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "\\images\\product\\333ef4f7-fcff-405e-b1c9-12b93f761af4.jpg", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("a030736c-1688-4747-9b87-c1138fd73740"), "Ron Parker", new Guid("f7b462a5-8581-4b90-b009-05c316f0e691"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "\\images\\product\\d995464f-3e24-4283-bb74-d52c9f7fa470.jpg", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("c88f9c00-6aea-4900-b36d-0baf96f0adeb"), "Laura Phantom", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\fd9fcccf-75ad-4305-960f-9e776c080d3c.jpg", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { new Guid("d9ed8c12-85f8-4c66-964a-b1132259f43e"), "Julian Button", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "\\images\\product\\966885ea-fa5c-4d4c-8d1b-717d49bf2abe.jpg", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("40df0e0d-5e64-4051-990b-60d5a9718ce7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("60812648-064a-4bff-94cd-de5ac60de991"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("72b1d6c1-cd17-4299-a700-db1ec9c60f3a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("153ec331-54ef-486f-a5bd-f33f10b57c6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59f47040-1293-4aa3-a43c-7183a0e3667e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93f2500d-99ff-4f57-a76a-fb45104760f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a030736c-1688-4747-9b87-c1138fd73740"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c88f9c00-6aea-4900-b36d-0baf96f0adeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9ed8c12-85f8-4c66-964a-b1132259f43e"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("6c70cbfa-38f4-49b2-8ea9-74256cbfc134"), "Abby Muscles", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("9afb8f0c-22ce-4644-9e73-aaace2a762cf"), "Laura Phantom", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { new Guid("ac354ac2-0422-4533-b0de-95b72e40f083"), "Julian Button", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" },
                    { new Guid("dc7caed9-0c36-4ef7-b01a-43c179aee5c9"), "Billy Spark", new Guid("fc591a53-7e51-4c33-b6f4-278de977dd9c"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("ef1e5d3c-d229-483f-aaab-0a6612279ae2"), "Ron Parker", new Guid("f7b462a5-8581-4b90-b009-05c316f0e691"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("fc535e82-1666-4dff-9c8d-e15a4e7a1a82"), "Nancy Hoover", new Guid("9fa92e4c-d942-4f76-9b0d-7f8334791723"), "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "", 40.0, 30.0, 20.0, 25.0, "Dark Skies" }
                });
        }
    }
}
