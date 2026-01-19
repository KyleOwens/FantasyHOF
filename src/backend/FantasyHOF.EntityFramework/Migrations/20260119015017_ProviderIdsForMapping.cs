using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ProviderIdsForMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "opponent_provider_team_id",
                table: "team_matchups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "provider_player_id",
                table: "matchup_roster_spots",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "provider_member_id",
                table: "league_season_members",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "provider_member_id",
                table: "league_season_member_teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "provider_team_id",
                table: "league_season_member_teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opponent_provider_team_id",
                table: "team_matchups");

            migrationBuilder.DropColumn(
                name: "provider_player_id",
                table: "matchup_roster_spots");

            migrationBuilder.DropColumn(
                name: "provider_member_id",
                table: "league_season_members");

            migrationBuilder.DropColumn(
                name: "provider_member_id",
                table: "league_season_member_teams");

            migrationBuilder.DropColumn(
                name: "provider_team_id",
                table: "league_season_member_teams");
        }
    }
}
