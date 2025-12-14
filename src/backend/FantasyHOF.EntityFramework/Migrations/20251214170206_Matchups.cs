using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Matchups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                table: "matchup_roster_spots");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_teams_team_id",
                table: "team_matchups");

            migrationBuilder.DropIndex(
                name: "ix_matchup_roster_spots_matchup_id",
                table: "matchup_roster_spots");

            migrationBuilder.AlterColumn<double>(
                name: "score",
                table: "team_matchups",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "opponent_id",
                table: "team_matchups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "opponent_id",
                table: "team_matchups");

            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "team_matchups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "ix_matchup_roster_spots_matchup_id",
                table: "matchup_roster_spots",
                column: "matchup_id");

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                table: "matchup_roster_spots",
                column: "matchup_id",
                principalTable: "team_matchups",
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
    }
}
