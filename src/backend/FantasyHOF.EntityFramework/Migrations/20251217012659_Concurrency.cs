using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Concurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_roster_spots_position_position_id",
                table: "matchup_roster_spots");

            migrationBuilder.DropPrimaryKey(
                name: "pk_position",
                table: "position");

            migrationBuilder.RenameTable(
                name: "position",
                newName: "positions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_positions",
                table: "positions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_roster_spots_positions_position_id",
                table: "matchup_roster_spots",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_roster_spots_positions_position_id",
                table: "matchup_roster_spots");

            migrationBuilder.DropPrimaryKey(
                name: "pk_positions",
                table: "positions");

            migrationBuilder.RenameTable(
                name: "positions",
                newName: "position");

            migrationBuilder.AddPrimaryKey(
                name: "pk_position",
                table: "position",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_roster_spots_position_position_id",
                table: "matchup_roster_spots",
                column: "position_id",
                principalTable: "position",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
