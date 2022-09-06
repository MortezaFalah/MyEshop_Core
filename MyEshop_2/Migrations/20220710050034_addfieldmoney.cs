using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEshop_2.Migrations
{
    public partial class addfieldmoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Item",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Item",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
