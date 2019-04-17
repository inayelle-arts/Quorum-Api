using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class NamingFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "PassedAnswers");

            migrationBuilder.RenameColumn(
                name: "TotalScore",
                table: "PassedTests",
                newName: "MaximumScore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaximumScore",
                table: "PassedTests",
                newName: "TotalScore");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "PassedAnswers",
                nullable: false,
                defaultValue: false);
        }
    }
}
