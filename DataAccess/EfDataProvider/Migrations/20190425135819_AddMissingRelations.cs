using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.EfDataProvider.Migrations
{
    public partial class AddMissingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengedTestId",
                table: "ChallengedQuestions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChallengedQuestionId",
                table: "ChallengedAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers",
                column: "ChallengedQuestionId",
                principalTable: "ChallengedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions",
                column: "ChallengedTestId",
                principalTable: "ChallengedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengedTestId",
                table: "ChallengedQuestions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ChallengedQuestionId",
                table: "ChallengedAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers",
                column: "ChallengedQuestionId",
                principalTable: "ChallengedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions",
                column: "ChallengedTestId",
                principalTable: "ChallengedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
