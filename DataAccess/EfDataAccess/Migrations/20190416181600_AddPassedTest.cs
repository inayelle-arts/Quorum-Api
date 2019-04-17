using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Quorum.DataAccess.Ef.Migrations
{
    public partial class AddPassedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassedTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TimeSpent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassedQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SourceQuestionId = table.Column<int>(nullable: false),
                    PassedTestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedQuestions_PassedTests_PassedTestId",
                        column: x => x.PassedTestId,
                        principalTable: "PassedTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PassedQuestions_Questions_SourceQuestionId",
                        column: x => x.SourceQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SourceAnswerId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    PassedQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedAnswers_PassedQuestions_PassedQuestionId",
                        column: x => x.PassedQuestionId,
                        principalTable: "PassedQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PassedAnswers_Answers_SourceAnswerId",
                        column: x => x.SourceAnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassedAnswers_PassedQuestionId",
                table: "PassedAnswers",
                column: "PassedQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedAnswers_SourceAnswerId",
                table: "PassedAnswers",
                column: "SourceAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedQuestions_PassedTestId",
                table: "PassedQuestions",
                column: "PassedTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedQuestions_SourceQuestionId",
                table: "PassedQuestions",
                column: "SourceQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassedAnswers");

            migrationBuilder.DropTable(
                name: "PassedQuestions");

            migrationBuilder.DropTable(
                name: "PassedTests");
        }
    }
}
