using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialTake2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                table: "matchup_roster_spots");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_outcomes_matchup_outcome_id",
                table: "team_matchups");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_team_matchups_opponent_matchup_id",
                table: "team_matchups");

            migrationBuilder.DropIndex(
                name: "ix_team_matchups_opponent_matchup_id",
                table: "team_matchups");

            migrationBuilder.DropColumn(
                name: "score",
                table: "team_matchups");

            migrationBuilder.RenameColumn(
                name: "opponent_matchup_id",
                table: "team_matchups",
                newName: "opponent_matchup_details_id");

            migrationBuilder.RenameColumn(
                name: "matchup_outcome_id",
                table: "team_matchups",
                newName: "owner_matchup_details_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_matchups_matchup_outcome_id",
                table: "team_matchups",
                newName: "ix_team_matchups_owner_matchup_details_id");

            migrationBuilder.RenameColumn(
                name: "matchup_id",
                table: "matchup_roster_spots",
                newName: "matchup_team_details_id");

            migrationBuilder.RenameIndex(
                name: "ix_matchup_roster_spots_matchup_id",
                table: "matchup_roster_spots",
                newName: "ix_matchup_roster_spots_matchup_team_details_id");

            migrationBuilder.CreateTable(
                name: "matchup_team_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    score = table.Column<decimal>(type: "numeric", nullable: false),
                    matchup_outcome_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matchup_team_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_matchup_team_details_matchup_outcomes_matchup_outcome_id",
                        column: x => x.matchup_outcome_id,
                        principalTable: "matchup_outcomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_opponent_matchup_details_id",
                table: "team_matchups",
                column: "opponent_matchup_details_id");

            migrationBuilder.CreateIndex(
                name: "ix_matchup_team_details_matchup_outcome_id",
                table: "matchup_team_details",
                column: "matchup_outcome_id");

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_roster_spots_matchup_team_details_matchup_team_deta",
                table: "matchup_roster_spots",
                column: "matchup_team_details_id",
                principalTable: "matchup_team_details",
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
                name: "fk_team_matchups_matchup_team_details_owner_matchup_details_id",
                table: "team_matchups",
                column: "owner_matchup_details_id",
                principalTable: "matchup_team_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_matchup_roster_spots_matchup_team_details_matchup_team_deta",
                table: "matchup_roster_spots");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_team_details_opponent_matchup_details",
                table: "team_matchups");

            migrationBuilder.DropForeignKey(
                name: "fk_team_matchups_matchup_team_details_owner_matchup_details_id",
                table: "team_matchups");

            migrationBuilder.DropTable(
                name: "matchup_team_details");

            migrationBuilder.DropIndex(
                name: "ix_team_matchups_opponent_matchup_details_id",
                table: "team_matchups");

            migrationBuilder.RenameColumn(
                name: "owner_matchup_details_id",
                table: "team_matchups",
                newName: "matchup_outcome_id");

            migrationBuilder.RenameColumn(
                name: "opponent_matchup_details_id",
                table: "team_matchups",
                newName: "opponent_matchup_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_matchups_owner_matchup_details_id",
                table: "team_matchups",
                newName: "ix_team_matchups_matchup_outcome_id");

            migrationBuilder.RenameColumn(
                name: "matchup_team_details_id",
                table: "matchup_roster_spots",
                newName: "matchup_id");

            migrationBuilder.RenameIndex(
                name: "ix_matchup_roster_spots_matchup_team_details_id",
                table: "matchup_roster_spots",
                newName: "ix_matchup_roster_spots_matchup_id");

            migrationBuilder.AddColumn<decimal>(
                name: "score",
                table: "team_matchups",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "ix_team_matchups_opponent_matchup_id",
                table: "team_matchups",
                column: "opponent_matchup_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_matchup_roster_spots_team_matchups_matchup_id",
                table: "matchup_roster_spots",
                column: "matchup_id",
                principalTable: "team_matchups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_matchup_outcomes_matchup_outcome_id",
                table: "team_matchups",
                column: "matchup_outcome_id",
                principalTable: "matchup_outcomes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_team_matchups_team_matchups_opponent_matchup_id",
                table: "team_matchups",
                column: "opponent_matchup_id",
                principalTable: "team_matchups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
