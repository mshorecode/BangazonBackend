using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class FinishedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "CustomerName", "PaymentId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Ryan Shore", 1, true },
                    { 2, 1, "Ryan Shore", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDescription", "ProductImageUrl", "ProductName", "ProductPrice", "SellerId" },
                values: new object[,]
                {
                    { 1, 1, "A nice polo shirt", "https://via.placeholder.com/150", "Polo Shirt", 20.00m, 1 },
                    { 2, 2, "A nice dress", "https://via.placeholder.com/150", "Dress", 40.00m, 1 },
                    { 3, 3, "A nice t-shirt", "https://via.placeholder.com/150", "T-Shirt", 15.00m, 1 },
                    { 4, 4, "A nice laptop", "https://via.placeholder.com/150", "Laptop", 800.00m, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
