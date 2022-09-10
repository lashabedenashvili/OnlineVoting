using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVoting.Domein.Migrations
{
    public partial class VotesChangeVoteDataTypee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Vote",
                table: "votes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Vote",
                table: "votes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
