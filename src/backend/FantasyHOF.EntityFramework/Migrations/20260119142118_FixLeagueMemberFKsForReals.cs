using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FixLeagueMemberFKsForReals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_members_fantasy_members_member_id1",
                table: "league_members");

            migrationBuilder.DropForeignKey(
                name: "fk_league_members_leagues_member_id",
                table: "league_members");

            migrationBuilder.RenameColumn(
                name: "member_id1",
                table: "league_members",
                newName: "league_id1");

            migrationBuilder.RenameIndex(
                name: "ix_league_members_member_id1",
                table: "league_members",
                newName: "ix_league_members_league_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_league_members_fantasy_members_member_id",
                table: "league_members",
                column: "member_id",
                principalTable: "fantasy_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_league_members_leagues_league_id1",
                table: "league_members",
                column: "league_id1",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_league_members_fantasy_members_member_id",
                table: "league_members");

            migrationBuilder.DropForeignKey(
                name: "fk_league_members_leagues_league_id1",
                table: "league_members");

            migrationBuilder.RenameColumn(
                name: "league_id1",
                table: "league_members",
                newName: "member_id1");

            migrationBuilder.RenameIndex(
                name: "ix_league_members_league_id1",
                table: "league_members",
                newName: "ix_league_members_member_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_league_members_fantasy_members_member_id1",
                table: "league_members",
                column: "member_id1",
                principalTable: "fantasy_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_league_members_leagues_member_id",
                table: "league_members",
                column: "member_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
