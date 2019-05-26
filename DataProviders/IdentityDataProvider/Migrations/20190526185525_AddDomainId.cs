using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataProviders.IdentityDataProvider.Migrations
{
    public partial class AddDomainId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainId",
                table: "QuorumUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "QuorumUsers");
        }
    }
}
