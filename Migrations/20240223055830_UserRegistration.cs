using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class UserRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Seller", "Uid", "Username" },
                values: new object[] { 1, "mshorecode@gmail.com", "Ryan", "Shore", false, "nJznAO7OlpNBrjkasjr5IZSM0Rl2", "mshorecode" });
        }
    }
}
