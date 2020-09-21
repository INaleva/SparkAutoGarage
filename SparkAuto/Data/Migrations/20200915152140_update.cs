using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkAuto.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VIM",
                table: "Car");

            migrationBuilder.AddColumn<double>(
                name: "Miles",
                table: "Car",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Car",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miles",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "Kilometers",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VIM",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
