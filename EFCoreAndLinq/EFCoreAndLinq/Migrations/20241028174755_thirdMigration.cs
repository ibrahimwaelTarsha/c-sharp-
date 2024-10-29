using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAndLinq.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Suppliers_SupplierId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "ProductDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductDetails_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "ProductDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductDetails_SupplierId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "Suppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Suppliers_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
