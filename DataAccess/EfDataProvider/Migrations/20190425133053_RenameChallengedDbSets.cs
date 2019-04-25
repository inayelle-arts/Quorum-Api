using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.EfDataProvider.Migrations
{
    public partial class RenameChallengedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_ChallengedQuestionId",
                table: "PassedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedAnswers_Answers_SourceAnswerId",
                table: "PassedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedQuestions_PassedTests_ChallengedTestId",
                table: "PassedQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedQuestions_Questions_SourceQuestionId",
                table: "PassedQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedTests_Tests_SourceTestId",
                table: "PassedTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassedTests",
                table: "PassedTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassedQuestions",
                table: "PassedQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassedAnswers",
                table: "PassedAnswers");

            migrationBuilder.RenameTable(
                name: "PassedTests",
                newName: "ChallengedTests");

            migrationBuilder.RenameTable(
                name: "PassedQuestions",
                newName: "ChallengedQuestions");

            migrationBuilder.RenameTable(
                name: "PassedAnswers",
                newName: "ChallengedAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_PassedTests_SourceTestId",
                table: "ChallengedTests",
                newName: "IX_ChallengedTests_SourceTestId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedQuestions_SourceQuestionId",
                table: "ChallengedQuestions",
                newName: "IX_ChallengedQuestions_SourceQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedQuestions_ChallengedTestId",
                table: "ChallengedQuestions",
                newName: "IX_ChallengedQuestions_ChallengedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedAnswers_SourceAnswerId",
                table: "ChallengedAnswers",
                newName: "IX_ChallengedAnswers_SourceAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_PassedAnswers_ChallengedQuestionId",
                table: "ChallengedAnswers",
                newName: "IX_ChallengedAnswers_ChallengedQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengedTests",
                table: "ChallengedTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengedQuestions",
                table: "ChallengedQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengedAnswers",
                table: "ChallengedAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers",
                column: "ChallengedQuestionId",
                principalTable: "ChallengedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedAnswers_Answers_SourceAnswerId",
                table: "ChallengedAnswers",
                column: "SourceAnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions",
                column: "ChallengedTestId",
                principalTable: "ChallengedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedQuestions_Questions_SourceQuestionId",
                table: "ChallengedQuestions",
                column: "SourceQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengedTests_Tests_SourceTestId",
                table: "ChallengedTests",
                column: "SourceTestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedAnswers_ChallengedQuestions_ChallengedQuestionId",
                table: "ChallengedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedAnswers_Answers_SourceAnswerId",
                table: "ChallengedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedQuestions_ChallengedTests_ChallengedTestId",
                table: "ChallengedQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedQuestions_Questions_SourceQuestionId",
                table: "ChallengedQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengedTests_Tests_SourceTestId",
                table: "ChallengedTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengedTests",
                table: "ChallengedTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengedQuestions",
                table: "ChallengedQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengedAnswers",
                table: "ChallengedAnswers");

            migrationBuilder.RenameTable(
                name: "ChallengedTests",
                newName: "PassedTests");

            migrationBuilder.RenameTable(
                name: "ChallengedQuestions",
                newName: "PassedQuestions");

            migrationBuilder.RenameTable(
                name: "ChallengedAnswers",
                newName: "PassedAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengedTests_SourceTestId",
                table: "PassedTests",
                newName: "IX_PassedTests_SourceTestId");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengedQuestions_SourceQuestionId",
                table: "PassedQuestions",
                newName: "IX_PassedQuestions_SourceQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengedQuestions_ChallengedTestId",
                table: "PassedQuestions",
                newName: "IX_PassedQuestions_ChallengedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengedAnswers_SourceAnswerId",
                table: "PassedAnswers",
                newName: "IX_PassedAnswers_SourceAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengedAnswers_ChallengedQuestionId",
                table: "PassedAnswers",
                newName: "IX_PassedAnswers_ChallengedQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassedTests",
                table: "PassedTests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassedQuestions",
                table: "PassedQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassedAnswers",
                table: "PassedAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassedAnswers_PassedQuestions_ChallengedQuestionId",
                table: "PassedAnswers",
                column: "ChallengedQuestionId",
                principalTable: "PassedQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedAnswers_Answers_SourceAnswerId",
                table: "PassedAnswers",
                column: "SourceAnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedQuestions_PassedTests_ChallengedTestId",
                table: "PassedQuestions",
                column: "ChallengedTestId",
                principalTable: "PassedTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedQuestions_Questions_SourceQuestionId",
                table: "PassedQuestions",
                column: "SourceQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedTests_Tests_SourceTestId",
                table: "PassedTests",
                column: "SourceTestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
