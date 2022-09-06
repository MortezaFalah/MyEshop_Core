using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEshop_2.Migrations
{
    public partial class InitialTableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Description", "name" },
                values: new object[,]
                {
                    { 1, "محصولات حوزه دیجیتال مانند گوشی و تبلت و لپتاپ", "کالای دیجیتال" },
                    { 2, "لوازم جانبی ابزار کامپیوتر", "لوازم کامپیوتر" },
                    { 3, " تمامی لوازم مورد نیاز شما برای عکاسی حرفه ای", "لوازم عکاسی" },
                    { 4, "کلیه لوازم صوتی تصویری خانه خود را از ما بخواهید", "صوتی تصویری" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
