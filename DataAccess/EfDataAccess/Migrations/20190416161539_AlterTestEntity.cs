using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class AlterTestEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Tests",
                newName: "TimeLimit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeLimit",
                table: "Tests",
                newName: "Time");
        }
    }
}
