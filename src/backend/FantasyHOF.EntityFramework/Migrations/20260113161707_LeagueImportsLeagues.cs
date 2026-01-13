using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LeagueImportsLeagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "league_id",
                table: "league_imports",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_league_imports_league_id",
                table: "league_imports",
                column: "league_id");

            migrationBuilder.AddForeignKey(
                name: "fk_league_imports_leagues_league_id",
                table: "league_imports",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_imports_leagues_league_id",
                table: "league_imports");

            migrationBuilder.DropIndex(
                name: "ix_league_imports_league_id",
                table: "league_imports");

            migrationBuilder.DropColumn(
                name: "league_id",
                table: "league_imports");
        }
    }
}
