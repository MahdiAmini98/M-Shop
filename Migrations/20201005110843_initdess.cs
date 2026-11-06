using Microsoft.EntityFrameworkCore.Migrations;

namespace M_Shop.Migrations
{
    public partial class initdess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "Money ",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal ");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 125.000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "Decimal ",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money ");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 125000m);
        }
    }
}
