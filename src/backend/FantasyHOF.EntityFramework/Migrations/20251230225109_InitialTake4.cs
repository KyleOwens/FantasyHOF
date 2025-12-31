using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialTake4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "season_id",
                table: "teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_teams_season_id",
                table: "teams",
                column: "season_id");

            migrationBuilder.AddForeignKey(
                name: "fk_teams_league_seasons_season_id",
                table: "teams",
                column: "season_id",
                principalTable: "league_seasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_teams_league_seasons_season_id",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_teams_season_id",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "season_id",
                table: "teams");
        }
    }
}
