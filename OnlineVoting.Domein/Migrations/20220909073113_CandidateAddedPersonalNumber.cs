using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVoting.Domein.Migrations
{
    public partial class CandidateAddedPersonalNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "candidates",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "candidates");
        }
    }
}
