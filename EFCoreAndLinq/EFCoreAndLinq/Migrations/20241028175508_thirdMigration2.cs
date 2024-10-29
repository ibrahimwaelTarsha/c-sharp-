using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAndLinq.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductDetails_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Product_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Product_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductDetails");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId",
                unique: true,
                filter: "[SupplierId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductDetails_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "ProductDetails",
                principalColumn: "Id");
        }
    }
}
