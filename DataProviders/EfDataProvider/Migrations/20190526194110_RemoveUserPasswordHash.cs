using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataProviders.EfDataProvider.Migrations
{
    public partial class RemoveUserPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);
        }
    }
}
