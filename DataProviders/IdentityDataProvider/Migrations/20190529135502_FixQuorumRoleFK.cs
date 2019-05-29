using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Quorum.DataProviders.IdentityDataProvider.Migrations
{
    public partial class FixQuorumRoleFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "QuorumUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "QuorumUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "QuorumUsers",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "QuorumUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuorumRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuorumRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuorumUsers_RoleId",
                table: "QuorumUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuorumUsers_QuorumRoles_RoleId",
                table: "QuorumUsers",
                column: "RoleId",
                principalTable: "QuorumRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuorumUsers_QuorumRoles_RoleId",
                table: "QuorumUsers");

            migrationBuilder.DropTable(
                name: "QuorumRoles");

            migrationBuilder.DropIndex(
                name: "IX_QuorumUsers_RoleId",
                table: "QuorumUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "QuorumUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "QuorumUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "QuorumUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "QuorumUsers",
                nullable: true);
        }
    }
}
