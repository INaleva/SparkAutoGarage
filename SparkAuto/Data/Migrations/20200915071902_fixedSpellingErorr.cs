using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkAuto.Data.Migrations
{
    public partial class fixedSpellingErorr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicPrice",
                table: "ServiceDetails");

            migrationBuilder.AddColumn<double>(
                name: "ServicePrice",
                table: "ServiceDetails",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "ServiceDetails");

            migrationBuilder.AddColumn<double>(
                name: "ServicPrice",
                table: "ServiceDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
