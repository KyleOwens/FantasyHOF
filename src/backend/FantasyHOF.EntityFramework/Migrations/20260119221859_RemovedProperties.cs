using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Loading seasonal data from provider");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Loading weekly data from provider");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Formatting data for save");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Saving data");

            migrationBuilder.InsertData(
                table: "league_import_statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 5, "Saving miscellaenous data" },
                    { 6, "Saving members" },
                    { 7, "Saving seasons" },
                    { 8, "Saving teams" },
                    { 9, "Saving matchups" },
                    { 10, "Saving rosters" },
                    { 11, "Saving stats" },
                    { 12, "Completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Loading data from provider");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Formatting data");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Saving data");

            migrationBuilder.UpdateData(
                table: "league_import_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Completed");
        }
    }
}
