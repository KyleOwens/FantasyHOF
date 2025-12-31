using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialTake3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams");

            migrationBuilder.AddColumn<int>(
                name: "league_season_id",
                table: "teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_teams_league_season_id",
                table: "teams",
                column: "league_season_id");

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_league_seasons_league_season_id",
                table: "teams",
                column: "league_season_id",
                principalTable: "league_seasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_league_seasons_league_season_id",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_teams_league_season_id",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "league_season_id",
                table: "teams");

            migrationBuilder.AddForeignKey(
                name: "fk_league_season_member_teams_teams_team_id",
                table: "league_season_member_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
