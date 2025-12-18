using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyHOF.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeedDisplayNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 0,
                column: "name",
                value: "Attempted passes");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Completed passes");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Incomplete passes");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Quarterback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 0,
                column: "name",
                value: "AttemptedPasses");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "CompletedPasses");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "IncompletePasses");

            migrationBuilder.UpdateData(
                table: "stats",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "PassingYards");
        }
    }
}
