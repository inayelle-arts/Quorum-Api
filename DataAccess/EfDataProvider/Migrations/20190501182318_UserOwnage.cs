using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.EfDataProvider.Migrations
{
    public partial class UserOwnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ChallengedTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengedTests_UserId",
                table: "ChallengedTests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedTests_Users_UserId",
                table: "ChallengedTests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedTests_Users_UserId",
                table: "ChallengedTests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_ChallengedTests_UserId",
                table: "ChallengedTests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChallengedTests");
        }
    }
}
