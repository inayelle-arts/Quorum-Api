using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class FixPassedTestSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceTestId",
                table: "PassedTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PassedTests_SourceTestId",
                table: "PassedTests",
                column: "SourceTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassedTests_Tests_SourceTestId",
                table: "PassedTests",
                column: "SourceTestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassedTests_Tests_SourceTestId",
                table: "PassedTests");

            migrationBuilder.DropIndex(
                name: "IX_PassedTests_SourceTestId",
                table: "PassedTests");

            migrationBuilder.DropColumn(
                name: "SourceTestId",
                table: "PassedTests");
        }
    }
}
