using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PlayerAggregationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "record");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "record",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    member_id = table.Column<int>(type: "integer", nullable: false),
                    league_id = table.Column<int>(type: "integer", nullable: false),
                    record_type = table.Column<int>(type: "integer", nullable: false),
                    league_value_record_value = table.Column<decimal>(type: "numeric", nullable: true),
                    player_id = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<decimal>(type: "numeric", nullable: true),
                    seasonal_value_record_value = table.Column<decimal>(type: "numeric", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: true),
                    weekly_value_record_value = table.Column<decimal>(type: "numeric", nullable: true),
                    week = table.Column<int>(type: "integer", nullable: true),
                    weekly_value_record_year = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_record", x => x.id);
                    table.ForeignKey(
                        name: "fk_record_fantasy_members_member_id",
                        column: x => x.member_id,
                        principalTable: "fantasy_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_record_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_record_member_id",
                table: "record",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "ix_record_player_id",
                table: "record",
                column: "player_id");
        }
    }
}
