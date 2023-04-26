using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCorePlayground.Data.Migrations
{
    public partial class tablereaname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "MyCustomers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyCustomers",
                table: "MyCustomers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_MyCustomers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "MyCustomers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_MyCustomers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyCustomers",
                table: "MyCustomers");

            migrationBuilder.RenameTable(
                name: "MyCustomers",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
