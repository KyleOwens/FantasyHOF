using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FKUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_opponent_id",
                table: "team_matchups");

            migrationBuilder.RenameColumn(
                name: "opponent_id",
                table: "team_matchups",
                newName: "opponent_team_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_matchups_opponent_id",
                table: "team_matchups",
                newName: "ix_team_matchups_opponent_team_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups",
                column: "opponent_team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups");

            migrationBuilder.RenameColumn(
                name: "opponent_team_id",
                table: "team_matchups",
                newName: "opponent_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_matchups_opponent_team_id",
                table: "team_matchups",
                newName: "ix_team_matchups_opponent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_opponent_id",
                table: "team_matchups",
                column: "opponent_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
