using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineVoting.Domein.Migrations
{
    public partial class DbSetVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_candidates_CandidateId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_users_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "votes");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "votes",
                newName: "IX_votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_CandidateId",
                table: "votes",
                newName: "IX_votes_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_votes",
                table: "votes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_votes_candidates_CandidateId",
                table: "votes",
                column: "CandidateId",
                principalTable: "candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_votes_candidates_CandidateId",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_votes",
                table: "votes");

            migrationBuilder.RenameTable(
                name: "votes",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_votes_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_CandidateId",
                table: "Votes",
                newName: "IX_Votes_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_candidates_CandidateId",
                table: "Votes",
                column: "CandidateId",
                principalTable: "candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
