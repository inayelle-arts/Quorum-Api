using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataAccess.EfDataProvider.Migrations
{
    public partial class AddChallengeTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ChallengedAt",
                table: "ChallengedTests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengedAt",
                table: "ChallengedTests");
        }
    }
}
