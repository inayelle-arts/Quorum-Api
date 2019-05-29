using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.DataProviders.IdentityDataProvider.Migrations
{
    public partial class AddRolesDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuorumRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tutor" },
                    { 2, "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuorumRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuorumRoles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
