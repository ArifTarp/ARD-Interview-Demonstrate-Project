using Microsoft.EntityFrameworkCore.Migrations;

namespace ARD.DataAccess.Migrations
{
    public partial class AddedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ankara" },
                    { 2, "İstanbul" },
                    { 3, "Bursa" },
                    { 4, "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name", "provinceId" },
                values: new object[,]
                {
                    { 1, "Yenimahalle", 1 },
                    { 2, "Çankaya", 1 },
                    { 3, "Bahçeşehir", 2 },
                    { 4, "Beyoğlu", 2 },
                    { 5, "Osmangazi", 3 },
                    { 6, "İnegöl", 3 },
                    { 7, "Selçuk", 4 },
                    { 8, "Seferihisar", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
