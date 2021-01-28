using Microsoft.EntityFrameworkCore.Migrations;

namespace ARD.DataAccess.Migrations
{
    public partial class removeUniqueKeyOnAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ProvinceId_DistrictId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId_DistrictId",
                table: "Addresses",
                columns: new[] { "ProvinceId", "DistrictId" },
                unique: true);
        }
    }
}
