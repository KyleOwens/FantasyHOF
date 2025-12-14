using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class teams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_opponent_id",
                table: "team_matchups");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_team_id",
                table: "team_matchups");

            migrationBuilder.DropIndex(
                name: "ix_team_matchups_opponent_id",
                table: "team_matchups");

            migrationBuilder.DropPrimaryKey(
                name: "pk_league_season_member_teams",
                table: "league_season_member_teams");

            migrationBuilder.DropColumn(
                name: "opponent_id",
                table: "team_matchups");

            migrationBuilder.AddColumn<int>(
                name: "fantasy_provider_id",
                table: "fantasy_members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_league_season_member_teams",
                table: "league_season_member_teams",
                columns: new[] { "member_id", "team_id" });

            migrationBuilder.CreateIndex(
                name: "ix_league_season_member_teams_league_season_id_member_id",
                table: "league_season_member_teams",
                columns: new[] { "league_season_id", "member_id" });

            migrationBuilder.CreateIndex(
                name: "ix_fantasy_members_fantasy_provider_id",
                table: "fantasy_members",
                column: "fantasy_provider_id");

            migrationBuilder.AddForeignKey(
                name: "fk_fantasy_members_fantasy_providers_fantasy_provider_id",
                table: "fantasy_members",
                column: "fantasy_provider_id",
                principalTable: "fantasy_providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_members_league_seasons_league_season_id",
                table: "league_season_members",
                column: "league_season_id",
                principalTable: "league_seasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_team_id",
                table: "team_matchups",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_fantasy_members_fantasy_providers_fantasy_provider_id",
                table: "fantasy_members");

            migrationBuilder.DropForeignKey(
                name: "fk_league_season_members_league_seasons_league_season_id",
                table: "league_season_members");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_team_id",
                table: "team_matchups");

            migrationBuilder.DropPrimaryKey(
                name: "pk_league_season_member_teams",
                table: "league_season_member_teams");

            migrationBuilder.DropIndex(
                name: "ix_league_season_member_teams_league_season_id_member_id",
                table: "league_season_member_teams");

            migrationBuilder.DropIndex(
                name: "ix_fantasy_members_fantasy_provider_id",
                table: "fantasy_members");

            migrationBuilder.DropColumn(
                name: "fantasy_provider_id",
                table: "fantasy_members");

            migrationBuilder.AddColumn<int>(
                name: "opponent_id",
                table: "team_matchups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_league_season_member_teams",
                table: "league_season_member_teams",
                columns: new[] { "league_season_id", "member_id", "team_id" });

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_opponent_id",
                table: "team_matchups",
                column: "opponent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_opponent_id",
                table: "team_matchups",
                column: "opponent_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_teams_team_id",
                table: "team_matchups",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
