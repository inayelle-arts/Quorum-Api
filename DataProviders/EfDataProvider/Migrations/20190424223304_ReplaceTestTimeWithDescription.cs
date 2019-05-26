using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataProviders.EfDataProvider.Migrations
{
    public partial class ReplaceTestTimeWithDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }
    }
}
