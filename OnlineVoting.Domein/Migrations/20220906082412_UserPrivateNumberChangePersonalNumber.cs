using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVoting.Domein.Migrations
{
    public partial class UserPrivateNumberChangePersonalNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrivateNumber",
                table: "users",
                newName: "PersonalNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "users",
                newName: "PrivateNumber");
        }
    }
}
