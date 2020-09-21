using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkAuto.Data.Migrations
{
    public partial class ServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ServiceShoppingCart_ServiceId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceType");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropColumn(
                name: "KM",
                table: "ServiceHeader");

            migrationBuilder.AddColumn<double>(
                name: "Miles",
                table: "ServiceHeader",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCart_ServiceTypeId",
                table: "ServiceShoppingCart",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceTypeId",
                table: "ServiceShoppingCart",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceTypeId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ServiceShoppingCart_ServiceTypeId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropColumn(
                name: "Miles",
                table: "ServiceHeader");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "ServiceShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "KM",
                table: "ServiceHeader",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceShoppingCart_ServiceId",
                table: "ServiceShoppingCart",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart",
                column: "ServiceId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
