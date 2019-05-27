using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataProviders.EfDataProvider.Migrations
{
    public partial class TestShuffleQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShuffleQuestionsOnChallenge",
                table: "Tests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShuffleQuestionsOnChallenge",
                table: "Tests");
        }
    }
}
