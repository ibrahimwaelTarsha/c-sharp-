using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAndLinq.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameAndPrice",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ' ' + CAST([Price] AS NVARCHAR(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameAndPrice",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[Name] + ' ' + CAST([Price] AS NVARCHAR(20))");
        }
    }
}
