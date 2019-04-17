using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class TestTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tests");
        }
    }
}
