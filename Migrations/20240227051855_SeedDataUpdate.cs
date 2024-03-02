using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class SeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice" },
                values: new object[] { "A three pack of polo shirts", "https://www.trueclassictees.com/cdn/shop/products/StaplePolo3pack.jpg?v=1680043192&%3Bwidth=500&em-format=avif&em-width=500", "Assortment of Polo Shirts", 30.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImageUrl",
                value: "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSqvN814z6D8TvpO5h1fMllSOg3-hY9hCOb3qCdbUw-3e5tQi5J1oNvBwt2atWcE6gsEudtrrIZ9vCkoN_96PXTZKP-J3XC2rmyxcuDEHfHFIgwbEIW2Km5&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName" },
                values: new object[] { "A nice Sonic t-shirt", "https://m.media-amazon.com/images/I/812lr5yYl2S._AC_SX679_.jpg", "Sonic T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice" },
                values: new object[] { "A nice gaming laptop", "https://c1.neweggimages.com/ProductImageCompressAll1280/34-236-449-01.jpg", "ASUS ROG STRIX Laptop", 1700.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice" },
                values: new object[] { "A nice polo shirt", "https://via.placeholder.com/150", "Polo Shirt", 20.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImageUrl",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName" },
                values: new object[] { "A nice t-shirt", "https://via.placeholder.com/150", "T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice" },
                values: new object[] { "A nice laptop", "https://via.placeholder.com/150", "Laptop", 800.00m });
        }
    }
}
