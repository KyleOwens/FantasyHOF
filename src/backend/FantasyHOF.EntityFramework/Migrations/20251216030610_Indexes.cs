using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_players_provider_id",
                table: "players");

            migrationBuilder.DropIndex(
                name: "ix_fantasy_members_fantasy_provider_id",
                table: "fantasy_members");

            migrationBuilder.CreateIndex(
                name: "ix_players_provider_id_provider_player_id",
                table: "players",
                columns: new[] { "provider_id", "provider_player_id" });

            migrationBuilder.CreateIndex(
                name: "ix_fantasy_members_fantasy_provider_id_provider_member_id",
                table: "fantasy_members",
                columns: new[] { "fantasy_provider_id", "provider_member_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_players_provider_id_provider_player_id",
                table: "players");

            migrationBuilder.DropIndex(
                name: "ix_fantasy_members_fantasy_provider_id_provider_member_id",
                table: "fantasy_members");

            migrationBuilder.CreateIndex(
                name: "ix_players_provider_id",
                table: "players",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_fantasy_members_fantasy_provider_id",
                table: "fantasy_members",
                column: "fantasy_provider_id");
        }
    }
}
