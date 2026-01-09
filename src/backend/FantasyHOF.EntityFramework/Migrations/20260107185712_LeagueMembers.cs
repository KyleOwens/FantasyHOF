using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LeagueMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "league_members",
                columns: table => new
                {
                    league_id = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    firstyear = table.Column<int>(type: "integer", nullable: false),
                    lear_year = table.Column<int>(type: "integer", nullable: false),
                    tenure = table.Column<int>(type: "integer", nullable: false),
                    league_id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_members", x => new { x.league_id, x.member_id });
                    table.ForeignKey(
                        name: "fk_league_members_fantasy_members_member_id",
                        column: x => x.member_id,
                        principalTable: "fantasy_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_league_members_leagues_league_id",
                        column: x => x.league_id,
                        principalTable: "leagues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_league_members_leagues_league_id1",
                        column: x => x.league_id1,
                        principalTable: "leagues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_league_members_league_id1",
                table: "league_members",
                column: "league_id1");

            migrationBuilder.CreateIndex(
                name: "ix_league_members_member_id",
                table: "league_members",
                column: "member_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "league_members");
        }
    }
}
