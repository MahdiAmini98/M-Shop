using Microsoft.EntityFrameworkCore.Migrations;

namespace M_Shop.Migrations
{
    public partial class updatetableses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 9, "آشنایی با مفاهیم بازی سازی", "بازی سازی" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityStack" },
                values: new object[] { 17, 473000m, 11 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityStack" },
                values: new object[] { 18, 623000m, 58 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 17, @"امروزه یکی از دغدغه های هر فرد برای شروع یه مهارت و تخصص جدید راه و مسیر شروع هست که توسط یه مقاله یا یک دوره کوتاهی میتونه اینو بدست بیاره

من طبق تجربیات و مطالعاتی که انجام دادم توی این دوره قصد دارم به شما مسیر یادگیری 0 تا 100 طراحی وب رو خدمتتون عرض کنم

از ابزار های طراحی وب گرفته تا زبان های مورد نیاز و نحوه گرفتن پروژه و برسی خیلی از سوالاتی که همه شما ممکنه براتون تا حالا جای سوال باشه

خب ببینید ما هدفمون اینه که دانشجو رو با مهارتی که میخواد یادبگیره آشنا کنیم

شما فرض کن میری یه زبان برنامه نویسی یاد میگیری ولی نمیدونم واسه چی یاد میگیری :) چرا؟؟؟چون نمیدونی این زبانی که در حال اموزش دیدن هستی برای چه حوزه ای هست ایا به کار میاد یا نه ؟؟پس بهتره اول یک مسیر کامل رو بفهمی بعد شروع کنی قدمی توی این مسیر برداری و بتونی ادم موفقی بشی

این دوره با سوالاتی ممکنه واستون پیش بیاد مدام بروز رسانی میشه و امیدوارم شمارو با بهترین مسیر یادگیری آشنا کنم  

ویدیو معرفی دوره رو حتما ببینید!", 17, "SDK Unity" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 18, @"امروزه یکی از دغدغه های هر فرد برای شروع یه مهارت و تخصص جدید راه و مسیر شروع هست که توسط یه مقاله یا یک دوره کوتاهی میتونه اینو بدست بیاره

من طبق تجربیات و مطالعاتی که انجام دادم توی این دوره قصد دارم به شما مسیر یادگیری 0 تا 100 طراحی وب رو خدمتتون عرض کنم

از ابزار های طراحی وب گرفته تا زبان های مورد نیاز و نحوه گرفتن پروژه و برسی خیلی از سوالاتی که همه شما ممکنه براتون تا حالا جای سوال باشه

خب ببینید ما هدفمون اینه که دانشجو رو با مهارتی که میخواد یادبگیره آشنا کنیم

شما فرض کن میری یه زبان برنامه نویسی یاد میگیری ولی نمیدونم واسه چی یاد میگیری :) چرا؟؟؟چون نمیدونی این زبانی که در حال اموزش دیدن هستی برای چه حوزه ای هست ایا به کار میاد یا نه ؟؟پس بهتره اول یک مسیر کامل رو بفهمی بعد شروع کنی قدمی توی این مسیر برداری و بتونی ادم موفقی بشی

این دوره با سوالاتی ممکنه واستون پیش بیاد مدام بروز رسانی میشه و امیدوارم شمارو با بهترین مسیر یادگیری آشنا کنم  

ویدیو معرفی دوره رو حتما ببینید!", 18, "Unity2020" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 9, 17 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 9, 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 9, 17 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 9, 18 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
