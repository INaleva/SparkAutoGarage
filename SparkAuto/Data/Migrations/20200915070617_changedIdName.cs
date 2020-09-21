using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkAuto.Data.Migrations
{
    public partial class changedIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceShoppingCart",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "ServiceShoppingCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart",
                column: "ServiceId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "ServiceShoppingCart");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_ServiceType_ServiceId",
                table: "ServiceShoppingCart",
                column: "ServiceId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
