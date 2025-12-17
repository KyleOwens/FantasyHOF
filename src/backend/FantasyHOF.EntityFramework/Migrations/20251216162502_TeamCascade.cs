using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class TeamCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams");

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams");

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
