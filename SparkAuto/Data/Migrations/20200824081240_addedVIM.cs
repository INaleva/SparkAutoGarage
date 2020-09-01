using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkAuto.Data.Migrations
{
    public partial class addedVIM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VIM",
                table: "Car",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIM",
                table: "Car");
        }
    }
}
