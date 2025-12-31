using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialTake7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_team_details_opponent_matchup_details",
                table: "team_matchups");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_types_matchup_type_id",
                table: "team_matchups");

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "matchup_team_details",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_matchup_team_details_team_id",
                table: "matchup_team_details",
                column: "team_id");

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_team_details_teams_team_id",
                table: "matchup_team_details",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_matchup_team_details_opponent_matchup_details",
                table: "team_matchups",
                column: "opponent_matchup_details_id",
                principalTable: "matchup_team_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_matchup_types_matchup_type_id",
                table: "team_matchups",
                column: "matchup_type_id",
                principalTable: "matchup_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_team_details_teams_team_id",
                table: "matchup_team_details");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_team_details_opponent_matchup_details",
                table: "team_matchups");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_types_matchup_type_id",
                table: "team_matchups");

            migrationBuilder.DropIndex(
                name: "ix_matchup_team_details_team_id",
                table: "matchup_team_details");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "matchup_team_details");

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_matchup_team_details_opponent_matchup_details",
                table: "team_matchups",
                column: "opponent_matchup_details_id",
                principalTable: "matchup_team_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_matchup_types_matchup_type_id",
                table: "team_matchups",
                column: "matchup_type_id",
                principalTable: "matchup_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
