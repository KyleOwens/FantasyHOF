using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LeagueImports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "league_import_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_import_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "league_imports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    provider_id = table.Column<int>(type: "integer", nullable: false),
                    providerleague_id = table.Column<string>(type: "text", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    progress = table.Column<int>(type: "integer", nullable: false),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_league_imports", x => x.id);
                    table.ForeignKey(
                        name: "fk_league_imports_fantasy_providers_provider_id",
                        column: x => x.provider_id,
                        principalTable: "fantasy_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_league_imports_league_import_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "league_import_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_league_imports_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "league_import_statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "Queued" },
                    { 1, "Loading data from provider" },
                    { 2, "Formatting data" },
                    { 3, "Saving data" },
                    { 4, "Completed" },
                    { 999, "Failed" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_league_imports_provider_id",
                table: "league_imports",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_imports_status_id",
                table: "league_imports",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_league_imports_user_id",
                table: "league_imports",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "league_imports");

            migrationBuilder.DropTable(
                name: "league_import_statuses");
        }
    }
}
