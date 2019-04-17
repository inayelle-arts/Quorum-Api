using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class NamingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_PassedQuestionId",
                table: "PassedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedQuestions_PassedTests_PassedTestId",
                table: "PassedQuestions");

            migrationBuilder.RenameColumn(
                name: "PassedTestId",
                table: "PassedQuestions",
                newName: "ChallengedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedQuestions_PassedTestId",
                table: "PassedQuestions",
                newName: "IX_PassedQuestions_ChallengedTestId");

            migrationBuilder.RenameColumn(
                name: "PassedQuestionId",
                table: "PassedAnswers",
                newName: "ChallengedQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedAnswers_PassedQuestionId",
                table: "PassedAnswers",
                newName: "IX_PassedAnswers_ChallengedQuestionId");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "PassedTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserScore",
                table: "PassedTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "PassedQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserScore",
                table: "PassedQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsUserCorrect",
                table: "PassedAnswers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_ChallengedQuestionId",
                table: "PassedAnswers",
                column: "ChallengedQuestionId",
                principalTable: "PassedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedQuestions_PassedTests_ChallengedTestId",
                table: "PassedQuestions",
                column: "ChallengedTestId",
                principalTable: "PassedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_ChallengedQuestionId",
                table: "PassedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedQuestions_PassedTests_ChallengedTestId",
                table: "PassedQuestions");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "PassedTests");

            migrationBuilder.DropColumn(
                name: "UserScore",
                table: "PassedTests");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "PassedQuestions");

            migrationBuilder.DropColumn(
                name: "UserScore",
                table: "PassedQuestions");

            migrationBuilder.DropColumn(
                name: "IsUserCorrect",
                table: "PassedAnswers");

            migrationBuilder.RenameColumn(
                name: "ChallengedTestId",
                table: "PassedQuestions",
                newName: "PassedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedQuestions_ChallengedTestId",
                table: "PassedQuestions",
                newName: "IX_PassedQuestions_PassedTestId");

            migrationBuilder.RenameColumn(
                name: "ChallengedQuestionId",
                table: "PassedAnswers",
                newName: "PassedQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedAnswers_ChallengedQuestionId",
                table: "PassedAnswers",
                newName: "IX_PassedAnswers_PassedQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_PassedQuestionId",
                table: "PassedAnswers",
                column: "PassedQuestionId",
                principalTable: "PassedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedQuestions_PassedTests_PassedTestId",
                table: "PassedQuestions",
                column: "PassedTestId",
                principalTable: "PassedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
