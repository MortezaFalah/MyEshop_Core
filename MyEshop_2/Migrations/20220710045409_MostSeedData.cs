using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEshop_2.Migrations
{
    public partial class MostSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Item",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "id", "QuantityinStock", "price" },
                values: new object[,]
                {
                    { 1, 0, 5m },
                    { 2, 100, 300000m },
                    { 3, 3, 55.600000m },
                    { 4, 4, 50.980000m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "Description", "ItemId", "Name" },
                values: new object[,]
                {
                    { 1, "گوشی سامسونگ گلکسی s7 edge پرچمدار سابق سامسونگ که هنوز هم حرف های زیادی برای گفتن دارد", 1, "گوشی سامسونگ s7 edge" },
                    { 2, "موس گیمینگ گرین مدل GM 402 دارای رنگ های rgb  و کلید های بک و فوروارد در دو طرف میباشد...این موس دارای 24 ماه گارانتی گرین می باشد", 2, "موس گرین GM 402" },
                    { 3, "کانن 5D مارک ۴ برای عکاسانی ساخته شده که می‌خواهند بهترین دوربین همه‌کاره‌ی این شرکت را داشته باشند. دوربینی مجهز به پیشرفته‌ترین سنسور تصویری که کانن تا سال ۲۰۱۶ ساخته و امکاناتی که باعث شده این دوربین تا چهار سال دیگر در کورس رقابت برترین‌ دوربین‌های DSLR فول‌ُفریم باقی بماند.", 3, "دوربین کانن 5d" },
                    { 4, "تلویزیون ال ای دی هوشمند سونی مدل 65X85J سایز 65 اینچ تلویزیونی مناسب برای تماشای برنامه های تلویزیونی و اینترنتی شما میباشد. این تلویزیون دارای دو درگاه USB آن هم به شما امکان پخش تصاویر و ویدیو های داخل حافظه های جانبی شما را با کیفیت 4K می‌دهد.", 4, "تلویزیون ال ای دی هوشمند سونی مدل 65X85J سایز 65 اینچ" }
                });

            migrationBuilder.InsertData(
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Item",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}
