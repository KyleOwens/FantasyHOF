using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups",
                column: "opponent_team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_opponent_team_id",
                table: "team_matchups",
                column: "opponent_team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
