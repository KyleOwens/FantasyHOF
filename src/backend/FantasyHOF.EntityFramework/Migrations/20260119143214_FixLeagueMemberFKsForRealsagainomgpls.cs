using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FixLeagueMemberFKsForRealsagainomgpls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_members_leagues_league_id1",
                table: "league_members");

            migrationBuilder.DropIndex(
                name: "ix_league_members_league_id1",
                table: "league_members");

            migrationBuilder.DropColumn(
                name: "league_id1",
                table: "league_members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "league_id1",
                table: "league_members",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_league_members_league_id1",
                table: "league_members",
                column: "league_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_league_members_leagues_league_id1",
                table: "league_members",
                column: "league_id1",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
