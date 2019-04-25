using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.EfDataProvider.Migrations
{
    public partial class RemoveTimeSpentFromChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "PassedTests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeSpent",
                table: "PassedTests",
                nullable: false,
                defaultValue: 0);
        }
    }
}
